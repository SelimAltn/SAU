// include/uzay_araci.h
#ifndef UZAY_ARACI_H
#define UZAY_ARACI_H

#include "zaman.h"

// UzayAraci yapı tanımı
typedef struct UZAYARACI {
    char*  isim;
    char*  cikisGezegen;
    char*  varisGezegen;
    Zaman  cikisTarihi;     // gerçek depart saatiyle oluşturulmuş
    Zaman  varisTarihi;     // hesaplanmış varış tarihi
    int    mesafeSaat;
    int    kalanSaat;
    int    imha;
    

    // Metot pointer’ları
    void (*yaz)(struct UZAYARACI*);
    void (*setVarisTarihi)(struct UZAYARACI*, Zaman);
    void (*deleteUzayAraci)(struct UZAYARACI*);
} *UzayAraci;

// Public API
UzayAraci newUzayAraci(const char* isim,
                       const char* cikisGezegen,
                       const char* varisGezegen,
                       Zaman cikisTarihi,
                       int mesafeSaat);

void uzayAraciSetVarisTarihi(UzayAraci this, Zaman varis);
void uzayAraciYazdir(UzayAraci this);
void deleteUzayAraci(UzayAraci this);

#endif // UZAY_ARACI_H
