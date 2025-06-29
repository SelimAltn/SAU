/**
 * 
 * @author  Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since   20.04.2025
 * <p>
 *  Simulasyon sınıfı, gezegen zamanlarının ilerletilmesi, uzay araçlarının
 *  aktivasyonu, yolcu ömürlerinin yönetimi ve simülasyonun ana döngüsünü
 *  koordine ederek sonuçların ekrana raporlanmasından sorumludur.
 * </p>
 */

package sim;

import io.DosyaOkuma;
import java.util.*;
import model.*;

public class Simulasyon {

	private static boolean tumAraclarTamamlandi(List<UzayAraci> araclar) {
		for (UzayAraci a : araclar) {
			if (!a.hedefeUlasti() && !a.isImha()) {
				return false;
			}
		}
		return true;
	}

	private static Map<String, Zaman> zamanlariOlustur(List<Gezegen> gezegenler) {
		Map<String, Zaman> zamanMap = new HashMap<>();
		for (Gezegen g : gezegenler) {
			zamanMap.put(g.getAd(), new Zaman(g.getTarih(), g.getGunSaat()));
		}
		return zamanMap;
	}

	private static void gezegenTarihiIlerle(Map<String, Zaman> zamanMap) {
		for (Zaman z : zamanMap.values())
			z.ilerlet(1);
	}

	private static void aracAktiflestir(List<UzayAraci> araclar, Map<String, Zaman> zamanMap, List<Kisi> kisiler,
			List<Gezegen> gezegenler) {
		for (UzayAraci a : araclar) {
			if (!a.isAktif() && !a.hedefeUlasti() && !a.isImha()) {
				Zaman z = zamanMap.get(a.getCikis());
				if (z != null && !z.ondanOnceMi(a.getTarih())) {
					a.aktivasyonBaslat();
// yolcuları çıkış gezegeninden düş
					for (Kisi k : kisiler) {
						if (k.getUzayAraci().equals(a.getAd())) {
							gezegenler.stream().filter(g -> g.getAd().equals(a.getCikis())).findFirst()
									.ifPresent(Gezegen::azaltNufus);
						}
					}
				}
			}
		}
	}

	private static void araclariIslet(List<UzayAraci> araclar, List<Kisi> kisiler, Map<String, Zaman> zamanMap,
			List<Gezegen> gezegenler) {
		for (UzayAraci a : araclar) {
			if (!a.isAktif())
				continue;

			a.birSaatIlerle();

			int yolcuSayisi = 0;
			Iterator<Kisi> it = kisiler.iterator();
			// Simülasyon.araclariIslet içinden…
			while (it.hasNext()) {
				Kisi k = it.next();
				if (k.getUzayAraci().equals(a.getAd())) {
					// önce ömrü azalt
					if (!k.birSaatAzalt()) {
						// ölen yolcuyu sadece listeden çıkar
						it.remove();
					} else {
						yolcuSayisi++;
					}
				}
			}
			if (yolcuSayisi == 0)
				a.setImha(true);
			// Araç hedefe ulaştıysa ve varış tarihi henüz belirlenmediyse
			if (a.getKalanMesafe() <= 0 && !a.isImha() && a.getVarisTarihi() == null) {
				Zaman varisZamani = zamanMap.get(a.getVaris());

				if (varisZamani != null) {
					a.setVarisTarihi(varisZamani.tarihYaz());

					// Yolcuları yalnızca bir kez varış gezegenine ekle
					for (Kisi k : kisiler) {
						if (k.getUzayAraci().equals(a.getAd())) {
							for (Gezegen g : gezegenler) {
								if (g.getAd().equals(a.getVaris())) {
									g.artirNufus();
									break;
								}
							}
						}
					}
				} else {
					System.out.println("HATA: Varış gezegeni zamanMap'te yok → " + a.getVaris());
				}

			}
		}
	}

	private static void yazdirGezegenDurum(List<Gezegen> gezegenler, Map<String, Zaman> zamanMap) {
		System.out.println("Gezegenler:\n");
		System.out.printf("%-20s", "");
		for (Gezegen g : gezegenler) {
			System.out.print(g.formatliBaslikSatiri());
		}
		System.out.println();

		System.out.printf("%-20s", "Tarih:");
		for (Gezegen g : gezegenler) {
			System.out.print(g.formatliTarihSatiri(zamanMap));
		}
		System.out.println();

		System.out.printf("%-20s", "Nüfus:");
		for (Gezegen g : gezegenler) {
			System.out.print(g.formatliNufusSatiri());
		}
		System.out.println();
	}

	private static void yazdirAracDurum(List<UzayAraci> araclar) {
		System.out.println("Uzay Araçları:");
		System.out.printf("%-10s %-10s %-10s %-10s %-20s %-20s\n", "Araç Adı", "Durum", "Çıkış", "Varış",
				"Hedefe Kalan Saat", "Hedefe Varacağı Tarih");

		for (UzayAraci a : araclar) {
			String[] satir = a.raporSatiri();
			System.out.printf("%-10s %-10s %-10s %-10s %-20s %-20s\n", satir[0], satir[1], satir[2], satir[3], satir[4],
					satir[5]);
		}

	}

	private static void baslangictaNufusEkle(List<Kisi> kisiler, List<Gezegen> gezegenler, List<UzayAraci> araclar) {
		Map<String, UzayAraci> aracMap = new HashMap<>();
		for (UzayAraci a : araclar) {
			aracMap.put(a.getAd(), a);
		}

		for (Kisi k : kisiler) {
			UzayAraci a = aracMap.get(k.getUzayAraci());
			if (a != null && !a.isAktif() && !a.hedefeUlasti() && !a.isImha()) {
				for (Gezegen g : gezegenler) {
					if (g.getAd().equals(a.getCikis())) {
						g.artirNufus(); // Bu metodu Gezegen sınıfına ekleyeceğiz
						break;
					}
				}
			}
		}
	}

	public static void main(String[] args) {
	 
		List<Kisi> kisiler = DosyaOkuma.kisileriOku("dist/Kisiler.txt");
		List<Gezegen> gezegenler = DosyaOkuma.gezegenleriOku("dist/Gezegenler.txt");
		List<UzayAraci> araclar = DosyaOkuma.araclariOku("dist/Araclar.txt");

		Map<String, Zaman> zamanMap = zamanlariOlustur(gezegenler);
		baslangictaNufusEkle(kisiler, gezegenler, araclar);

		int toplamSaat = 0;
		int maxSaat = 10000;
		while (!tumAraclarTamamlandi(araclar)) {

			toplamSaat++;

			gezegenTarihiIlerle(zamanMap);
			System.out.print("\033[H\033[2J");
			System.out.flush();

			

			aracAktiflestir(araclar, zamanMap, kisiler, gezegenler);
			araclariIslet(araclar, kisiler, zamanMap, gezegenler);

			try {
				Thread.sleep(1);
			} catch (InterruptedException e) {
				break;
			}
		}

		System.out.println("--- Simülasyon Bitti ---");

		yazdirGezegenDurum(gezegenler, zamanMap);
		yazdirAracDurum(araclar);

		int toplamYolcu = DosyaOkuma.kisileriOku("Kisiler.txt").size();
		int kalanYolcu = kisiler.size();
		long imha = araclar.stream().filter(UzayAraci::isImha).count();
		long ulasti = araclar.stream().filter(a -> a.hedefeUlasti() && !a.isImha()).count();
		System.out.println("\n=== 📊 Simülasyon Özeti ===\n");
		System.out.printf("%-30s %d saat\n", "Toplam geçen süre:", toplamSaat);
		System.out.printf("%-30s %d\n", "Toplam başlangıç yolcusu:", toplamYolcu);
		System.out.printf("%-30s %d\n", "Hayatta kalan yolcu:", kalanYolcu);
		System.out.printf("%-30s %d\n", "İmha olan araç sayısı:", imha);
		System.out.printf("%-30s %d\n", "Ulaşan araç sayısı:", ulasti);

		System.out.println("\n=== 🖠 Gezegenlerin Son Zamanı ===");
		zamanMap.forEach((k, v) -> System.out.println(k + ": " + v.tarihYaz()));

	}
}
