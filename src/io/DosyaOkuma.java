package io;

import model.Kisi;
import model.Gezegen;
import java.io.*;
import java.util.ArrayList;
import model.UzayAraci;

public class DosyaOkuma {
	public static ArrayList<Kisi> kisileriOku(String dosyaAdi) {
		ArrayList<Kisi> kisiler = new ArrayList<>();

		try (BufferedReader br = new BufferedReader(new FileReader(dosyaAdi))) {
			String satir = br.readLine(); // BAŞLIĞI OKU VE ATLAMA YAP
			

			while ((satir = br.readLine()) != null) {
			    String[] parca = satir.split("#");
			    if (parca.length == 4) {
			        String isim = parca[0];
			        int yas = Integer.parseInt(parca[1]);
			        int kalan = Integer.parseInt(parca[2]);
			        String uzayAraci = parca[3];
			        kisiler.add(new Kisi(isim, yas, kalan, uzayAraci));
			    }
			}
		} catch (IOException e) {
			System.out.println("Kisiler dosyasi okunurken hata oldu: " + e.getMessage());
		}

		return kisiler;
	}
	public static ArrayList<Gezegen> gezegenleriOku(String dosyaAdi) {
	    ArrayList<Gezegen> gezegenler = new ArrayList<>();

	    try (BufferedReader br = new BufferedReader(new FileReader(dosyaAdi))) {
	        String satir = br.readLine(); // başlık varsa atla
	        while ((satir = br.readLine()) != null) {
	            String[] parca = satir.split("#");
	            if (parca.length == 3) {
	                String ad = parca[0];
	                int gunSaat = Integer.parseInt(parca[1]);
	                String tarih = parca[2];
	                gezegenler.add(new Gezegen(ad, gunSaat, tarih));
	            }
	        }
	    } catch (IOException e) {
	        System.out.println("Gezegenler dosyası okunamadı: " + e.getMessage());
	    }

	    return gezegenler;
	}
	public static ArrayList<UzayAraci> araclariOku(String dosyaAdi) {
	    ArrayList<UzayAraci> araclar = new ArrayList<>();

	    try (BufferedReader br = new BufferedReader(new FileReader(dosyaAdi))) {
	        String satir = br.readLine(); // başlık varsa atla
	        while ((satir = br.readLine()) != null) {
	            String[] parca = satir.split("#");
	            if (parca.length == 5) {
	                String ad = parca[0];
	                String cikis = parca[1];
	                String varis = parca[2];
	                String tarih = parca[3];
	                int mesafe = Integer.parseInt(parca[4]);
	                araclar.add(new UzayAraci(ad, cikis, varis, tarih, mesafe));
	            }
	        }
	    } catch (IOException e) {
	        System.out.println("Araclar dosyası okunamadı: " + e.getMessage());
	    }

	    return araclar;
	}
	

}
