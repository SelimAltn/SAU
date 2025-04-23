package model;

public class UzayAraci {
	 private String ad;
	    private String cikis;
	    private String varis;
	    private String tarih;
	    private int mesafe;

	    public UzayAraci(String ad, String cikis, String varis, String tarih, int mesafe) {
	        this.ad = ad;
	        this.cikis = cikis;
	        this.varis = varis;
	        this.tarih = tarih;
	        this.mesafe = mesafe;
	    }

	    public String getAd() {
	        return ad;
	    }

	    public String getCikis() {
	        return cikis;
	    }

	    public String getVaris() {
	        return varis;
	    }

	    public String getTarih() {
	        return tarih;
	    }

	    public int getMesafe() {
	        return mesafe;
	    }

	    @Override
	    public String toString() {
	        return ad + ": " + cikis + " → " + varis + " | " + tarih + " | " + mesafe + " saat";
	    }

}
