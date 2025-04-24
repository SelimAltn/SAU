// Simulasyon.java (modüler hale getirilmiş)
package sim;

import io.DosyaOkuma;
import java.util.*;
import model.*;

public class Simulasyon {

    private static boolean tumAraclarTamamlandi(List<UzayAraci> araclar) {
        for (UzayAraci a : araclar) {
            if (!a.hedefeUlasti() && !a.isImha()) return false;
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
        for (Zaman z : zamanMap.values()) z.ilerlet(1);
    }

    private static void aracAktiflestir(List<UzayAraci> araclar, Map<String, Zaman> zamanMap) {
        for (UzayAraci a : araclar) {
            if (!a.isAktif() && !a.hedefeUlasti() && !a.isImha()) {
                Zaman zaman = zamanMap.get(a.getCikis());
                if (zaman.getTarihSadece().equals(a.getTarih())) a.aktivasyonBaslat();
            }
        }
    }

    private static void araclariIslet(List<UzayAraci> araclar, List<Kisi> kisiler, Map<String, Zaman> zamanMap) {
        for (UzayAraci a : araclar) {
            if (!a.isAktif()) continue;

            a.birSaatIlerle();

            int yolcuSayisi = 0;
            Iterator<Kisi> it = kisiler.iterator();
            while (it.hasNext()) {
                Kisi k = it.next();
                if (k.getUzayAraci().equals(a.getAd())) {
                    if (!k.birSaatAzalt()) it.remove();
                    else yolcuSayisi++;
                }
            }

            if (yolcuSayisi == 0) a.setImha(true);

            if (a.getKalanMesafe() <= 0 && !a.isImha() && a.getVarisTarihi() == null) {
                a.setVarisTarihi(zamanMap.get(a.getVaris()).tarihYaz());
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
        System.out.printf("%-10s %-10s %-10s %-10s %-20s %-20s\n",
                "Araç Adı", "Durum", "Çıkış", "Varış", "Hedefe Kalan Saat", "Hedefe Varacağı Tarih");

        for (UzayAraci a : araclar) {
            String[] satir = a.raporSatiri();
            System.out.printf("%-10s %-10s %-10s %-10s %-20s %-20s\n",
                    satir[0], satir[1], satir[2], satir[3], satir[4], satir[5]);
        }

        for (UzayAraci a : araclar) {
            System.out.println(a.getAd() + ": " + a.getDurumYazili());
        }
    }

   

    public static void main(String[] args) {
        List<Kisi> kisiler = DosyaOkuma.kisileriOku("Kisiler.txt");
        List<Gezegen> gezegenler = DosyaOkuma.gezegenleriOku("Gezegenler.txt");
        List<UzayAraci> araclar = DosyaOkuma.araclariOku("Araclar.txt");

        Map<String, Zaman> zamanMap = zamanlariOlustur(gezegenler);

        int toplamSaat = 0;
        while (!tumAraclarTamamlandi(araclar)) {
            toplamSaat++;
            gezegenTarihiIlerle(zamanMap);
            System.out.print("\033[H\033[2J");
            System.out.flush();

            for (Map.Entry<String, Zaman> z : zamanMap.entrySet()) {
                System.out.println(z.getKey() + ": " + z.getValue().tarihYaz());
            }

            aracAktiflestir(araclar, zamanMap);
            araclariIslet(araclar, kisiler, zamanMap);

            try {
                Thread.sleep(10);
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
        long ulasti = araclar.stream().filter(UzayAraci::hedefeUlasti).count();

        System.out.println("\n=== 📊 Simülasyon Özeti ===\n");
        System.out.printf("%-30s %d saat\n", "Toplam geçen süre:", toplamSaat);
        System.out.printf("%-30s %d\n", "Toplam başlangıç yolcusu:", toplamYolcu);
        System.out.printf("%-30s %d\n", "Hayatta kalan yolcu:", kalanYolcu);
        System.out.printf("%-30s %d\n", "İmha olan araç sayısı:", imha);
        System.out.printf("%-30s %d\n", "Ulaşan araç sayısı:", ulasti);

        System.out.println("\n=== 👤 Hayatta Kalan Yolcular ===");
        if (kalanYolcu == 0) System.out.println("- Kalan yolcu yok.");
        else kisiler.forEach(k -> System.out.printf("- %-10s (%2d yaşında) → %3d saat kaldı | Araç: %s\n", k.getIsim(), k.getYas(), k.getKalanOmur(), k.getUzayAraci()));

        System.out.println("\n=== 🖠 Gezegenlerin Son Zamanı ===");
        zamanMap.forEach((k, v) -> System.out.println(k + ": " + v.tarihYaz()));
    }
}
