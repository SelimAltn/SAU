// include/gezegen.h
#ifndef GEZEGEN_H
#define GEZEGEN_H

#include "zaman.h"

// Soyut Gezegen tipi ve metod pointerları
typedef struct GEZEGEN {
    char* isim;
    Zaman tarih;
    int   gunSaat;
    int   tur;  // 0=Kayac,1=GazDevi,2=BuzDevi,3=Cuce

    double (*yaslanmaKatSayi)(struct GEZEGEN*);
    void   (*deleteGezegen)(struct GEZEGEN*);
} *Gezegen;

// Constructorlar
Gezegen newKayacGezegen(const char* isim, Zaman tarih, int gunSaat);
Gezegen newGazDeviGezegen(const char* isim, Zaman tarih, int gunSaat);
Gezegen newBuzDeviGezegen(const char* isim, Zaman tarih, int gunSaat);
Gezegen newCuceGezegen(const char* isim, Zaman tarih, int gunSaat);

// Wrapper: gezegen bilgilerini yazdırır
void gezegenYazdir(Gezegen this);

#endif // GEZEGEN_H