/**
 * @author   Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since    11.05.2025
 * <p>
 *   Gezegen soyut veri tipinin tanımını içerir.  
 *   `GEZEGEN` base struct’ı ile kayaç, gaz devi, buz devi ve cüce  
 *   alt türlerinin struct’larını, sanal (fonksiyon işaretçisi)  
 *   metod tanımlarını ve public API constructor prototiplerini sağlar.
 * </p>
 */
#ifndef GEZEGEN_H
#define GEZEGEN_H

#include "zaman.h"

typedef struct GEZEGEN* Gezegen;

/* Soyut base struct */
struct GEZEGEN {
    char*    isim;
    Zaman    tarih;
    int      gunSaat;
    /* Pure-virtual benzetimi */
    double (*yaslanmaKatSayi)(Gezegen self);
    /* Destructor işaretçisi */
    void   (*delete)(Gezegen self);
};

/* Her alt tür için ayrı struct; ilk üye olarak base’ı taşıyor */
typedef struct {
    struct GEZEGEN base;
} KayacGezegen;

typedef struct {
    struct GEZEGEN base;
} GazDeviGezegen;

typedef struct {
    struct GEZEGEN base;
} BuzDeviGezegen;

typedef struct {
    struct GEZEGEN base;
} CuceGezegen;

// Public API
Gezegen newKayacGezegen(const char* isim, Zaman tarih, int gunSaat);
Gezegen newGazDeviGezegen(const char* isim, Zaman tarih, int gunSaat);
Gezegen newBuzDeviGezegen(const char* isim, Zaman tarih, int gunSaat);
Gezegen newCuceGezegen(const char* isim, Zaman tarih, int gunSaat);

#endif // GEZEGEN_H
