/**
 * 
 * @author  Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since   21.04.2025
 * <p>
 *  Her bir yolcunun adını, yaşını, kalan ömrünü saat cinsinden ve bağlı olduğu uzay aracını
 *  tutan model sınıfı. Ayrıca, kalan ömrü bir saat azaltan yardımcı metoda sahiptir.
 * </p>
 */
package model;

public class Kisi {
	private String isim;
	private int yas;
	private int kalanOmur;
	private String uzayAraci;

	public Kisi(String isim, int yas, int kalanOmur, String uzayAraci) {
		this.isim = isim;
		this.yas = yas;
		this.kalanOmur = kalanOmur;
		this.uzayAraci = uzayAraci;
	}

	public String getIsim() {
		return isim;
	}

	public int getYas() {
		return yas;
	}

	public int getKalanOmur() {
		return kalanOmur;
	}

	public String getUzayAraci() {
		return uzayAraci;
	}

	public void setKalanOmur(int omur) {
		this.kalanOmur = omur;
	}

	public boolean birSaatAzalt() {
		kalanOmur--;
		return kalanOmur > 0;
	}

	@Override
	public String toString() {
		return isim + " (" + yas + ") - " + kalanOmur + " saat - " + uzayAraci;
	}

}
