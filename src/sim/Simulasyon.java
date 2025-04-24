package sim;

import io.DosyaOkuma;
import java.util.*;
import model.Kisi;
import model.Gezegen;
import model.UzayAraci;
import model.Zaman;

public class Simulasyon {

    private static boolean tumAraclarTamamlandi(ArrayList<UzayAraci> araclar) {
        for (UzayAraci a : araclar) {
            if (!a.hedefeUlasti() && !a.isImha()) {
                return false;
            }
        }
        return true;
    }

    public static void main(String[] args) {
        ArrayList<Kisi> kisiler = DosyaOkuma.kisileriOku("Kisiler.txt");
        ArrayList<Gezegen> gezegenler = DosyaOkuma.gezegenleriOku("Gezegenler.txt");
        ArrayList<UzayAraci> araclar = DosyaOkuma.araclariOku("Araclar.txt");

        HashMap<String, Zaman> gezegenZamanlari = new HashMap<>();
        for (Gezegen g : gezegenler) {
            gezegenZamanlari.put(g.getAd(), new Zaman(g.getTarih(), g.getGunSaat()));
        }

        int toplamSimulasyonSaati = 0;
        int toplamYolcu;
        int kalanYolcu;
        int imhaSayisi = 0;
        int ulasanSayisi = 0;

        while (!tumAraclarTamamlandi(araclar)) {
            toplamSimulasyonSaati++;
            for (Zaman z : gezegenZamanlari.values()) {
                z.ilerlet(1);
            }

            System.out.print("\033[H\033[2J");
            System.out.flush();

            for (Map.Entry<String, Zaman> entry : gezegenZamanlari.entrySet()) {
                System.out.println(entry.getKey() + ": " + entry.getValue().tarihYaz());
            }

            for (UzayAraci a : araclar) {
                if (!a.isAktif() && !a.hedefeUlasti() && !a.isImha()) {
                    String gezegenAdi = a.getCikis();
                    Zaman gezegenZamani = gezegenZamanlari.get(gezegenAdi);
                    if (gezegenZamani.getTarihSadece().equals(a.getTarih())) {
                        a.aktivasyonBaslat();
                    }
                }

                if (a.isAktif()) {
                    a.birSaatIlerle();

                    int yolcuSayisi = 0;
                    Iterator<Kisi> it = kisiler.iterator();

                    while (it.hasNext()) {
                        Kisi k = it.next();
                        if (k.getUzayAraci().equals(a.getAd())) {
                            if (!k.birSaatAzalt()) {
                                it.remove();
                            } else {
                                yolcuSayisi++;
                            }
                        }
                    }

                    if (yolcuSayisi == 0) {
                        a.setImha(true);
                    }

                    if (a.getKalanMesafe() <= 0 && !a.isImha() && a.getVarisTarihi() == null) {
                        String hedefGezegen = a.getVaris();
                        Zaman varisZamani = gezegenZamanlari.get(hedefGezegen);
                        a.setVarisTarihi(varisZamani.tarihYaz());
                    }
                }
            }

            try {
                Thread.sleep(10);
            } catch (InterruptedException e) {
                break;
            }
        }

        toplamYolcu = DosyaOkuma.kisileriOku("Kisiler.txt").size();
        kalanYolcu = kisiler.size();

        System.out.println("--- Simülasyon Bitti ---");

        // === 📋 HOCANIN FORMATINA GÖRE ===
        System.out.println("Gezegenler:\n");

     // Satır 1: Başlıklar
     System.out.printf("%-20s", "");  // Boşluk bırak tarih/nüfus için
     for (Gezegen g : gezegenler) {
         System.out.printf("%-25s", String.format("--- %-3s ---", g.getAd()));
     }
     System.out.println();

     // Satır 2: Tarihler
     System.out.printf("%-20s", "Tarih:");
     for (Gezegen g : gezegenler) {
         String tarih = gezegenZamanlari.get(g.getAd()).getTarihSadece();
         System.out.printf("%-25s", tarih);
     }
     System.out.println();

     // Satır 3: Nüfuslar
     System.out.printf("%-20s", "Nüfus:");
     for (Gezegen g : gezegenler) {
         System.out.printf("%-25s", "--"); // Sabit tutulmuştu
     }
     System.out.println();

        

        System.out.println("Uzay Araçları:");
       
        System.out.printf("%-10s %-10s %-10s %-10s %-20s %-20s\n",
                "Araç Adı", "Durum", "Çıkış", "Varış", "Hedefe Kalan Saat", "Hedefe Varacağı Tarih");

        for (UzayAraci a : araclar) {
            String durum;
            String kalanSaat;
            String varisTarih;

            if (a.isImha()) {
                durum = "IMHA";
                kalanSaat = "--";
                varisTarih = "--";
            } else if (a.hedefeUlasti()) {
                durum = "Vardı";
                kalanSaat = "0";
                varisTarih = a.getVarisTarihi();
            } else if (a.isAktif()) {
                durum = "Yolda";
                kalanSaat = String.valueOf(a.getKalanMesafe());
                varisTarih = "--";
            } else {
                durum = "Bekliyor";
                kalanSaat = String.valueOf(a.getMesafe());
                varisTarih = "--";
            }

           
            System.out.printf("%-10s %-10s %-10s %-10s %-20s %-20s\n",
                    a.getAd(), durum, a.getCikis(), a.getVaris(), kalanSaat, varisTarih);
        }

        for (UzayAraci a : araclar) {
            System.out.print(a.getAd() + ": ");
            if (a.isImha()) {
                System.out.println("İMHA");
            } else if (a.hedefeUlasti()) {
                System.out.println("ULAŞTI → " + a.getVarisTarihi());
            } else if (a.isAktif()) {
                System.out.println("YOLDA → Kalan: " + a.getKalanMesafe() + " saat");
            } else {
                System.out.println("BEKLEMEDE");
            }
        }

        for (UzayAraci a : araclar) {
            if (a.isImha()) imhaSayisi++;
            if (a.hedefeUlasti()) ulasanSayisi++;
        }
        System.out.println("\n=== 📊 Simülasyon Özeti ===\n");

        System.out.printf("%-30s %d saat\n", "Toplam geçen süre:", toplamSimulasyonSaati);
        System.out.printf("%-30s %d\n", "Toplam başlangıç yolcusu:", toplamYolcu);
        System.out.printf("%-30s %d\n", "Hayatta kalan yolcu:", kalanYolcu);
        System.out.printf("%-30s %d\n", "İmha olan araç sayısı:", imhaSayisi);
        System.out.printf("%-30s %d\n", "Ulaşan araç sayısı:", ulasanSayisi);

        System.out.println("\n=== 👤 Hayatta Kalan Yolcular ===");
        if (kalanYolcu == 0) {
            System.out.println("- Kalan yolcu yok.");
        } else {
            for (Kisi k : kisiler) {
                System.out.printf("- %-10s (%2d yaşında) → %3d saat kaldı | Araç: %s\n",
                        k.getIsim(), k.getYas(), k.getKalanOmur(), k.getUzayAraci());
            }
        }

        System.out.println("\n=== 🪐 Gezegenlerin Son Zamanı ===");
        for (Map.Entry<String, Zaman> entry : gezegenZamanlari.entrySet()) {
            System.out.println(entry.getKey() + ": " + entry.getValue().tarihYaz());
        }

        
    }
}
