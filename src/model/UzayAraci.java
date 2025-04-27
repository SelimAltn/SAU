package model;

public class UzayAraci {
	 private String ad;
	    private String cikis;
	    private String varis;
	    private String tarih;
	    private int mesafe;
	    private int kalanMesafe;
	    private boolean aktif = false;
	    private boolean tamamlandi = false;
	    private boolean imha = false;
	    private String varisTarihi = null;


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
	    public void aktivasyonBaslat() {
	        aktif = true;
	        kalanMesafe = mesafe;
	    }

	    public void birSaatIlerle() {
	        if (aktif && !tamamlandi) {
	            kalanMesafe--;
	            if (kalanMesafe <= 0) {
	                aktif = false;
	                tamamlandi = true;
	            }
	        }
	    }

	    public boolean hedefeUlasti() {
	        return tamamlandi;
	        
	    }

	    public boolean isImha() {
	        return imha;
	    }

	    public void setImha(boolean durum) {
	        imha = durum;
	    }

	    public boolean isAktif() {
	        return aktif;
	    }

	    public int getKalanMesafe() {
	        return kalanMesafe;
	    }

	    public String getDurumYaz() {
	        if 	(imha) return "İMHA";
	        if (tamamlandi) return "ULAŞTI";
	        if (aktif) return "YOLDA";
	        return "BEKLEMEDE";
	    }
	    
	    public void setVarisTarihi(String tarih) {
	        this.varisTarihi = tarih;
	    }

	    public String getVarisTarihi() {
	        return varisTarihi;
	    }
	    public String[] raporSatiri() {
	        String durum = isImha() ? "IMHA" : hedefeUlasti() ? "Vardı" : isAktif() ? "Yolda" : "Bekliyor";
	        String kalan = isImha() ? "--" : hedefeUlasti() ? "0" : isAktif() ? String.valueOf(getKalanMesafe()) : String.valueOf(getMesafe());
	        String varisTarih = isImha() || !hedefeUlasti() ? "--" : getVarisTarihi();
	        return new String[] { ad, durum, cikis, varis, kalan, varisTarih };
	    }

	    public String getDurumYazili() {
	        if (isImha()) return "İMHA";
	        if (hedefeUlasti()) return "ULAŞTI → " + getVarisTarihi();
	        if (isAktif()) return "YOLDA → Kalan: " + getKalanMesafe() + " saat";
	        return "BEKLEMEDE";
	    }



}
