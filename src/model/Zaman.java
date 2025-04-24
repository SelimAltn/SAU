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
        return gun + "." + ay + "." + yil;
    }

}
