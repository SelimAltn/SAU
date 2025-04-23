package model;

public class Gezegen {
	private String ad;
    private int gunSaat;
    private String tarih;

    public Gezegen(String ad, int gunSaat, String tarih) {
        this.ad = ad;
        this.gunSaat = gunSaat;
        this.tarih = tarih;
    }

    public String getAd() {
        return ad;
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

}
