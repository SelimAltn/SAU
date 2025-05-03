
// src/gezegen.c
#include "gezegen.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

// Helper: strdup muadili
static char* _strdup(const char* s) {
    size_t n = strlen(s) + 1;
    char* p = malloc(n);
    if (p) memcpy(p, s, n);
    return p;
}

// Yaşlanma katsayıları
static double _yasKayac(struct GEZEGEN* self)   { return 1.0; }
static double _yasGazDevi(struct GEZEGEN* self) { return 0.1; }
static double _yasBuzDevi(struct GEZEGEN* self) { return 0.5; }
static double _yasCuce(struct GEZEGEN* self)    { return 0.01; }

// Ortak delete metodu
static void _deleteGezegen(struct GEZEGEN* self) {
    if (!self) return;
    free(self->isim);
    self->tarih->deleteZaman(self->tarih);
    free(self);
}

// Ortak oluşturucu
static Gezegen _createGezegen(const char* isim, Zaman tarih, int gunSaat,
                              int tur, double (*yaslanma)(struct GEZEGEN*)) {
    Gezegen g = malloc(sizeof *g);
    g->isim            = _strdup(isim);
    g->tarih           = tarih;
    g->gunSaat         = gunSaat;
    g->tur             = tur;
    g->yaslanmaKatSayi = yaslanma;
    g->deleteGezegen   = _deleteGezegen;
    return g;
}

// Public constructorlar
Gezegen newKayacGezegen(const char* isim, Zaman tarih, int gunSaat) {
    return _createGezegen(isim, tarih, gunSaat, 0, _yasKayac);
}

Gezegen newGazDeviGezegen(const char* isim, Zaman tarih, int gunSaat) {
    return _createGezegen(isim, tarih, gunSaat, 1, _yasGazDevi);
}

Gezegen newBuzDeviGezegen(const char* isim, Zaman tarih, int gunSaat) {
    return _createGezegen(isim, tarih, gunSaat, 2, _yasBuzDevi);
}

Gezegen newCuceGezegen(const char* isim, Zaman tarih, int gunSaat) {
    return _createGezegen(isim, tarih, gunSaat, 3, _yasCuce);
}

// Wrapper fonksiyonu: gezegen bilgisini ekrana basar
void gezegenYazdir(Gezegen this) {
    char* tarihStr = this->tarih->toString(this->tarih);
    printf("Gezegen: %s | Tür: %d | Gün/Saat: %d | Tarih: %s\n",
           this->isim,
           this->tur,
           this->gunSaat,
           tarihStr);
    free(tarihStr);
}
