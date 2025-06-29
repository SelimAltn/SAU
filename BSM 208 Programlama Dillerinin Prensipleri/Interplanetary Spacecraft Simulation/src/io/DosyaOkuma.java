/**
 * 
 * @author Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since   20.04.2025
 * <p>
 *  Kisiler.txt, Gezegenler.txt ve Araclar.txt dosyalarından satır satır veri
 *  okuyup model nesnelerine dönüştüren yardımcı sınıf.
 * </p>
 */
package io;

import model.Kisi;
import model.Gezegen;
import java.io.*;
import java.util.ArrayList;
import model.UzayAraci;

public class DosyaOkuma {

	public static Kisi parseKisi(String satir) {
		String[] parca = satir.split("#");
		String isim = parca[0];
		int yas = Integer.parseInt(parca[1]);
		int kalan = Integer.parseInt(parca[2]);
		String uzayAraci = parca[3];
		return new Kisi(isim, yas, kalan, uzayAraci);
	}

	public static ArrayList<Kisi> kisileriOku(String dosyaAdi) {
		ArrayList<Kisi> kisiler = new ArrayList<>();
		try (BufferedReader br = new BufferedReader(new FileReader(dosyaAdi))) {
			String satir = br.readLine();

			if (satir != null) {
				try {
					kisiler.add(parseKisi(satir));
				} catch (Exception e) {
					// ilk satır başlıksa parse edilemez → atla
					satir = br.readLine();
				}
			}

			while (satir != null) {
				try {
					kisiler.add(parseKisi(satir));
				} catch (Exception ignored) {
				}
				satir = br.readLine();
			}

		} catch (IOException e) {
			System.out.println("Kisiler dosyası okunamadı: " + e.getMessage());
		}
		return kisiler;
	}

	public static Gezegen parseGezegen(String satir) {
		satir = satir.replace("\u00A0", "").trim();
		String[] parca = satir.split("#");
		if (parca.length < 3) {
			System.out.println("Hatalı satır (Eksik parça): " + satir);
			return null;
		}
		String ad = parca[0];
		int gunSaat = Integer.parseInt(parca[1]);
		String tarih = parca[2];
		return new Gezegen(ad, gunSaat, tarih);
	}

	public static ArrayList<Gezegen> gezegenleriOku(String dosyaAdi) {
		ArrayList<Gezegen> gezegenler = new ArrayList<>();
		try (BufferedReader br = new BufferedReader(new FileReader(dosyaAdi))) {
			String satir = br.readLine();

			if (satir != null) {
				try {
					Gezegen g = parseGezegen(satir);
					if (g != null)
						gezegenler.add(g);
				} catch (Exception e) {
					satir = br.readLine(); // başlıksa geç
				}
			}

			while (satir != null) {
				try {
					Gezegen g = parseGezegen(satir);
					if (g != null)
						gezegenler.add(g);
				} catch (Exception ignored) {
				}
				satir = br.readLine();
			}

		} catch (IOException e) {
			System.out.println("Gezegenler dosyası okunamadı: " + e.getMessage());
		}
		return gezegenler;
	}

	public static UzayAraci parseUzayAraci(String satir) {
		satir = satir.replace("\u00A0", "").trim();
		String[] parca = satir.split("#");
		if (parca.length < 5) {
			System.out.println("Hatalı satır (Eksik parça): " + satir);
			return null;
		}
		String ad = parca[0];
		String cikis = parca[1];
		String varis = parca[2];
		String tarih = parca[3];
		int mesafe = Integer.parseInt(parca[4]);
		return new UzayAraci(ad, cikis, varis, tarih, mesafe);
	}

	public static ArrayList<UzayAraci> araclariOku(String dosyaAdi) {
		ArrayList<UzayAraci> araclar = new ArrayList<>();
		try (BufferedReader br = new BufferedReader(new FileReader(dosyaAdi))) {
			String satir = br.readLine();

			if (satir != null) {
				try {
					UzayAraci a = parseUzayAraci(satir);
					if (a != null)
						araclar.add(a);
				} catch (Exception e) {
					satir = br.readLine(); // başlıksa geç
				}
			}

			while (satir != null) {
				try {
					UzayAraci a = parseUzayAraci(satir);
					if (a != null)
						araclar.add(a);
				} catch (Exception ignored) {
				}
				satir = br.readLine();
			}

		} catch (IOException e) {
			System.out.println("Araclar dosyası okunamadı: " + e.getMessage());
		}
		return araclar;
	}
}
