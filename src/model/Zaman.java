/**
 * 
 * @author  Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since   21.04.2025
 * <p>
 *  Zaman sınıfı, bir gezegenin tarih ve saat bilgisini yönetmek için
 *  tasarlanmıştır. Gün, ay, yıl ve saat bileşenlerini ayrı ayrı saklar,
 *  her saat adedinde zamanı ilerletmeye ve formatlı çıktı üretmeye olanak tanır.
 * </p>
 */

package model;

public class Zaman {
	private int gun;
	private int ay;
	private int yil;
	private int saat;
	private int gunSaat; // 1 gün kaç saatten oluşuyor

	public Zaman(String tarih, int gunSaat) {
		String[] parca = tarih.split("\\.");
		this.gun = Integer.parseInt(parca[0]);
		this.ay = Integer.parseInt(parca[1]);
		this.yil = Integer.parseInt(parca[2]);
		this.saat = 0;
		this.gunSaat = gunSaat;
	}

	public void ilerlet(int saatAdet) {
		saat += saatAdet;
		while (saat >= gunSaat) {
			saat -= gunSaat;
			gun++;
			if (gun > 30) { // her ay 30 gün sayılır
				gun = 1;
				ay++;
				if (ay > 12) {
					ay = 1;
					yil++;
				}
			}
		}
	}

	public String tarihYaz() {
		return gun + "." + ay + "." + yil + " - " + saat + ":00";
	}

	public int getSaat() {
		return saat;
	}

	public String getTarihSadece() {
		return String.format("%02d.%02d.%04d", gun, ay, yil);
	}

	public boolean ayniGunMu(String tarih) {
		String[] parca = tarih.split("\\.");
		int gun2 = Integer.parseInt(parca[0]);
		int ay2 = Integer.parseInt(parca[1]);
		int yil2 = Integer.parseInt(parca[2]);

		return (this.gun == gun2 && this.ay == ay2 && this.yil == yil2);
	}

	/**
	 * Geçerli Zaman'ın, parametre olarak verilen tarih öncesi olup olmadığını
	 * döner.
	 * 
	 * @param digerTarih "gün.ay.yıl" formatlı (ör. "3.11.2022")
	 * @return true eğer this < digerTarih; false aksi halde
	 */
	public boolean ondanOnceMi(String digerTarih) {
		String[] p = digerTarih.split("\\.");
		int dg = Integer.parseInt(p[0]);
		int da = Integer.parseInt(p[1]);
		int dy = Integer.parseInt(p[2]);

		if (this.yil < dy)
			return true;
		if (this.yil > dy)
			return false;
		if (this.ay < da)
			return true;
		if (this.ay > da)
			return false;
		if (this.gun < dg)
			return true;
		// aynı güne denk geliyorsa "önce" değil, eşit veya geçmiş kabul edelim:
		return false;
	}

}
