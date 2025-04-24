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

        while (!tumAraclarTamamlandi(araclar)) {
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
                            int omur = k.getKalanOmur() - 1;
                            if (omur <= 0) {
                                it.remove();
                            } else {
                                k.setKalanOmur(omur);
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
                Thread.sleep(200);
            } catch (InterruptedException e) {
                break;
            }
        }

        System.out.println("\n--- Simülasyon Bitti ---\n");
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
    }
}
