#ifndef GEZEGEN_H
#define GEZEGEN_H

#include "zaman.h"

typedef enum {
    KAYAC = 0,
    GAZ_DEVI,
    BUZ_DEVI,
    CUCE
} Gezegentur;

typedef struct {
    char isim[50];
    Gezegentur tur;
    int gunSaat;   // o gezegende bir gün kaç saat
    Zaman tarih;
} Gezegen;

// Gezegen nesnesi oluşturur
Gezegen gezegenOlustur(const char* isim, Gezegentur tur, int gunSaat, Zaman tarih);

// Gezegen bilgisini ekrana yazdırır
void gezegenYazdir(const Gezegen* g);

#endif // GEZEGEN_H
