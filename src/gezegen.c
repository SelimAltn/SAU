#include "gezegen.h"
#include <stdlib.h>
#include <string.h>

// Helper: ism için strdup muadili
static char* _strdup(const char* s) {
    size_t n = strlen(s) + 1;
    char* p = malloc(n);
    if (p) memcpy(p, s, n);
    return p;
}

// Her tür için farklı yaşlanma katsayısı
static double _yaslanmaKayac(Gezegen self) {
    return 1.0;
}
static double _yaslanmaGazDevi(Gezegen self) {
    return 0.1;
}
static double _yaslanmaBuzDevi(Gezegen self) {
    return 0.5;
}
static double _yaslanmaCuce(Gezegen self) {
    return 0.01;
}

// Tüm Gezegen tipleri için ortak yıkıcı
static void _deleteGezegen(Gezegen self) {
    if (!self) return;
    free(self->isim);
    free(self);
}

// Ortak initialization
static Gezegen _create(
    const char* isim,
    Zaman tarih,
    int gunSaat,
    double (*yaslanma)(Gezegen)
) {
    Gezegen g = malloc(sizeof(*g));
    g->isim             = _strdup(isim);
    g->tarih            = tarih;
    g->gunSaat          = gunSaat;
    g->yaslanmaKatSayi  = yaslanma;
    g->deleteGezegen    = _deleteGezegen;
    return g;
}

// Public constructor’lar
Gezegen newKayacGezegen(const char* isim, Zaman tarih, int gunSaat) {
    return _create(isim, tarih, gunSaat, _yaslanmaKayac);
}

Gezegen newGazDeviGezegen(const char* isim, Zaman tarih, int gunSaat) {
    return _create(isim, tarih, gunSaat, _yaslanmaGazDevi);
}

Gezegen newBuzDeviGezegen(const char* isim, Zaman tarih, int gunSaat) {
    return _create(isim, tarih, gunSaat, _yaslanmaBuzDevi);
}

Gezegen newCuceGezegen(const char* isim, Zaman tarih, int gunSaat) {
    return _create(isim, tarih, gunSaat, _yaslanmaCuce);
}
