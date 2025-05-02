#ifndef GEZEGEN_H
#define GEZEGEN_H

#include "zaman.h"

// Soyut Gezegen tipinin kendisi
struct GEZEGEN;
typedef struct GEZEGEN* Gezegen;

struct GEZEGEN {
    char* isim;
    Zaman tarih;
    int   gunSaat;

    // Alt türlerin override edeceği metotlar
    double (*yaslanmaKatSayi)(Gezegen self);
    void   (*deleteGezegen)(Gezegen self);
};

// “Constructor”lar
Gezegen newKayacGezegen(const char* isim, Zaman tarih, int gunSaat);
Gezegen newGazDeviGezegen(const char* isim, Zaman tarih, int gunSaat);
Gezegen newBuzDeviGezegen(const char* isim, Zaman tarih, int gunSaat);
Gezegen newCuceGezegen   (const char* isim, Zaman tarih, int gunSaat);

#endif // GEZEGEN_H
