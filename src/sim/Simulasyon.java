package sim;
import io.DosyaOkuma;
import java.util.*;
import model.Kisi;
import model.Gezegen;
import model.UzayAraci;
import model.Zaman;
import java.util.ArrayList;

public class Simulasyon {
	public static void main(String[] args) {
		ArrayList<Kisi> kisiler = DosyaOkuma.kisileriOku("Kisiler.txt");
        ArrayList<Gezegen> gezegenler = DosyaOkuma.gezegenleriOku("Gezegenler.txt");
        ArrayList<UzayAraci> araclar = DosyaOkuma.araclariOku("Araclar.txt");

        HashMap<String, Zaman> gezegenZamanlari = new HashMap<>();

        for (Gezegen g : gezegenler) {
            gezegenZamanlari.put(g.getAd(), new Zaman(g.getTarih(), g.getGunSaat()));
        }

        while (true) {

            // Zamanı ilerlet
            for (Zaman z : gezegenZamanlari.values()) {
                z.ilerlet(1);
            }

            // Ekranı temizle
            System.out.print("\033[H\033[2J");
            System.out.flush();

            // Konsola güncel zamanları yaz
            for (Map.Entry<String, Zaman> entry : gezegenZamanlari.entrySet()) {
                System.out.println(entry.getKey() + ": " + entry.getValue().tarihYaz());
            }

            // TODO: Araç hareketleri, ömür düşürme, ölü kontrolü, bitiş kontrolü buraya eklenecek

            try {
                Thread.sleep(200); // simülasyon bekleme süresi (200ms)
            } catch (InterruptedException e) {
                break;
            }

        }
		
		
	
		
	}
}
