#ifndef KISI_H
#define KISI_H

typedef struct {
    char isim[50];
    int yas;
    int kalan_omur;
    char aracAdi[10];
} Kisi;

// Kisiyi struct olarak oluşturur
Kisi kisiOlustur(const char* isim, int yas, int kalan_omur, const char* aracAdi);

// Kisi bilgisini ekrana yazar
void kisiYazdir(const Kisi* k);

#endif // KISI_H
