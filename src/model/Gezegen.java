package model;
import java.util.Map;


public class Gezegen {
	private String ad;
	private int gunSaat;
	private String tarih;
	private int nufus=0;

	public Gezegen(String ad, int gunSaat, String tarih) {
		this.ad = ad;
		this.gunSaat = gunSaat;
		this.tarih = tarih;
	}

	public String getAd() {
		return ad;
	}

	public int getNufus() {
		return nufus;
	}

	public int getGunSaat() {
		return gunSaat;
	}

	public String getTarih() {
		return tarih;
	}

	@Override
	public String toString() {
		return ad + " - " + gunSaat + "saatlik gün - " + tarih;
	}
	public String formatliBaslikSatiri() {
	    return String.format("%-25s", "--- " + ad + " ---");
	}

	public String formatliTarihSatiri(Map<String, Zaman> zamanMap) {
	    return String.format("%-25s", zamanMap.get(ad).getTarihSadece());
	}

	public String formatliNufusSatiri() {
	    return String.format("%-25s", nufus);
	}
	public void azaltNufus() {
	    if (nufus > 0) {
	        nufus--;
	    }
	}
	public void artirNufus() {
	    this.nufus++;
	}


	

}
