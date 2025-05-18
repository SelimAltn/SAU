#include "gezegen.h"
#include <stdlib.h>
#include <string.h>

/* — Alt türlerin yaslanma fonksiyonları — */
static double _yasKayac(Gezegen self)   { return 1.0; }
static double _yasGazDevi(Gezegen self) { return 0.1; }
static double _yasBuzDevi(Gezegen self) { return 0.5; }
static double _yasCuce(Gezegen self)    { return 0.01; }

/* — Alt türlerin delete fonksiyonları — */
static void _deleteKayac(Gezegen self) {
    free(self->isim);
    self->tarih->deleteZaman(self->tarih);
    free(self);
}
static void _deleteGazDevi(Gezegen self) {
    free(self->isim);
    self->tarih->deleteZaman(self->tarih);
    free(self);
}
static void _deleteBuzDevi(Gezegen self) {
    free(self->isim);
    self->tarih->deleteZaman(self->tarih);
    free(self);
}
static void _deleteCuce(Gezegen self) {
    free(self->isim);
    self->tarih->deleteZaman(self->tarih);
    free(self);
}

/* — Basit strdup muadili — */
static char* _strdup(const char* s) {
    size_t n = strlen(s) + 1;
    char* p = malloc(n);
    memcpy(p, s, n);
    return p;
}

/* — Constructor’lar — */
Gezegen newKayacGezegen(const char* isim, Zaman tarih, int gunSaat) {
    KayacGezegen* obj = malloc(sizeof *obj);
    obj->base.isim            = _strdup(isim);
    obj->base.tarih           = tarih;
    obj->base.gunSaat         = gunSaat;
    obj->base.yaslanmaKatSayi = _yasKayac;
    obj->base.delete          = _deleteKayac;
    return (Gezegen)obj;
}

Gezegen newGazDeviGezegen(const char* isim, Zaman tarih, int gunSaat) {
    GazDeviGezegen* obj = malloc(sizeof *obj);
    obj->base.isim            = _strdup(isim);
    obj->base.tarih           = tarih;
    obj->base.gunSaat         = gunSaat;
    obj->base.yaslanmaKatSayi = _yasGazDevi;
    obj->base.delete          = _deleteGazDevi;
    return (Gezegen)obj;
}

Gezegen newBuzDeviGezegen(const char* isim, Zaman tarih, int gunSaat) {
    BuzDeviGezegen* obj = malloc(sizeof *obj);
    obj->base.isim            = _strdup(isim);
    obj->base.tarih           = tarih;
    obj->base.gunSaat         = gunSaat;
    obj->base.yaslanmaKatSayi = _yasBuzDevi;
    obj->base.delete          = _deleteBuzDevi;
    return (Gezegen)obj;
}

Gezegen newCuceGezegen(const char* isim, Zaman tarih, int gunSaat) {
    CuceGezegen* obj = malloc(sizeof *obj);
    obj->base.isim            = _strdup(isim);
    obj->base.tarih           = tarih;
    obj->base.gunSaat         = gunSaat;
    obj->base.yaslanmaKatSayi = _yasCuce;
    obj->base.delete          = _deleteCuce;
    return (Gezegen)obj;
}
