#ifndef UZAY_ARACI_H
#define UZAY_ARACI_H

#include "zaman.h"

// Tek satırda struct tanımı ve typedef
typedef struct UZAYARACI {
    char*  isim;
    char*  cikisGezegen;
    char*  varisGezegen;
    Zaman  cikisTarihi;
    int    mesafeSaat;
    int    kalanSaat;
    int    imha;

    // Metot pointer’ları
    void (*yaz)(struct UZAYARACI*);
    void (*deleteUzayAraci)(struct UZAYARACI*);
} *UzayAraci;

// Public API
UzayAraci newUzayAraci(const char* isim,
                       const char* cikisGezegen,
                       const char* varisGezegen,
                       Zaman cikisTarihi,
                       int mesafeSaat);

// Global wrapper’lar
void uzayAraciYazdir(UzayAraci this);
void deleteUzayAraci(UzayAraci this);

#endif // UZAY_ARACI_H
