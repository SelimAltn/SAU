/**
 * @author   Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since    11.05.2025
 * <p>
 *   KISI (Kisi) soyut veri tipini tanımlar.  
 *   Bir kişinin adı, yaşı, kalan ömrü ve ilişkili araç adını tutar.  
 *   Ayrıca yazdırma ve bellek temizleme işlevleri için fonksiyon işaretçileri sağlar.
 * </p>
 */
#ifndef KISI_H
#define KISI_H

typedef struct KISI {
    char* isim;
    int   yas;
    int   kalanOmur;
    char* aracAdi;

    void (*yaz)(struct KISI*);
    void (*deleteKisi)(struct KISI*);
} *Kisi;

Kisi newKisi(const char* isim, int yas, int kalanOmur, const char* aracAdi);
void  kisiYazdir(Kisi this);
void  deleteKisi(Kisi this);

#endif // KISI_H