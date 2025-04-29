#ifndef UZAY_ARACI_H
#define UZAY_ARACI_H

#include "zaman.h"

typedef struct {
    char isim[20];
    char cikisGezegen[50];
    char varisGezegen[50];
    Zaman cikisTarihi;
    int mesafeSaat;
    int kalanSaat;
    int imha;  // 0 = aktif, 1 = imha
} UzayAraci;

// UzayAraci nesnesi oluşturur
UzayAraci uzayAraciOlustur(const char* isim,
                           const char* cikisGezegen,
                           const char* varisGezegen,
                           Zaman cikisTarihi,
                           int mesafeSaat);

// Uzay aracını ekrana yazdırır
void uzayAraciYazdir(const UzayAraci* a);

#endif // UZAY_ARACI_H
