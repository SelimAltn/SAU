package sim;
import io.DosyaOkuma;
import model.Kisi;
import model.Gezegen;
import model.UzayAraci;
import java.util.ArrayList;

public class Simulasyon {
	public static void main(String[] args) {
		 ArrayList<Kisi> kisiler = DosyaOkuma.kisileriOku("Kisiler.txt");

	        for (Kisi k : kisiler) {
	            System.out.println(k);
	        }
	        ArrayList<Gezegen> gezegenler = DosyaOkuma.gezegenleriOku("Gezegenler.txt");

	        for (Gezegen g : gezegenler) {
	            System.out.println(g);
	        }
	        ArrayList<UzayAraci> araclar = DosyaOkuma.araclariOku("Araclar.txt");

	        for (UzayAraci a : araclar) {
	            System.out.println(a);
	        }

	}

}
