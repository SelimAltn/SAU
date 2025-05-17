/* include/uzay_araci.h */

#ifndef UZAY_ARACI_H
#define UZAY_ARACI_H

#include "zaman.h"
#include "kisi.h"

typedef struct UzayAraci_* UzayAraci;

// Oluşturucu ve yıkıcı
UzayAraci newUzayAraci(const char* isim,
                       const char* cikisGezegen,
                       const char* varisGezegen,
                       Zaman cikisTarihi,
                       int mesafeSaat);
void deleteUzayAraci(UzayAraci this);

// Kalkış ve her saat ilerleme
void uzayAraciDepart(UzayAraci this, Zaman departureTime);
void uzayAraciAdvanceHour(UzayAraci this,
                          double ageFactorSrc,
                          double ageFactorDst,
                          Zaman targetPlanetTime);

// Yolcu yönetimi
void uzayAraciAddPassenger(UzayAraci this, Kisi passenger);
void uzayAraciRemovePassenger(UzayAraci this, Kisi passenger);

// Varış tarihini set etme (setter)
void uzayAraciSetVarisTarihi(UzayAraci this, Zaman varisTarihi);

// Yazdırma
void uzayAraciYazdir(UzayAraci this);

#endif // UZAY_ARACI_H


/* src/uzay_araci.c */
#include "uzay_araci.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

struct UzayAraci_ {
    char*      isim;
    char*      cikisGezegen;
    char*      varisGezegen;
    Zaman      cikisTarihi;
    Zaman      varisTarihi;
    int        mesafeSaat;
    int        kalanSaat;
    int        imha;
    int        hasDeparted;
    Kisi*      passengers;
    int        passengerCount;

    // method pointers
    void     (*yaz)(UzayAraci);
    void     (*setVarisTarihi)(UzayAraci, Zaman);
    void     (*deleteUzayAraci)(UzayAraci);
};

static char* _strdup(const char* s) {
    size_t n = strlen(s) + 1;
    char* p = malloc(n);
    if (p) memcpy(p, s, n);
    return p;
}

// Private helpers
static void _yazUzayAraci(UzayAraci this);
static void _setVarisTarihiImpl(UzayAraci this, Zaman varis);
static void _deleteUzayAraciImpl(UzayAraci this);

UzayAraci newUzayAraci(const char* isim,
                       const char* cikisGezegen,
                       const char* varisGezegen,
                       Zaman cikisTarihi,
                       int mesafeSaat)
{
    UzayAraci a = malloc(sizeof *a);
    a->isim            = _strdup(isim);
    a->cikisGezegen    = _strdup(cikisGezegen);
    a->varisGezegen    = _strdup(varisGezegen);
    a->cikisTarihi     = cikisTarihi;
    a->varisTarihi     = NULL;
    a->mesafeSaat      = mesafeSaat;
    a->kalanSaat       = mesafeSaat;
    a->imha            = 0;
    a->hasDeparted     = 0;
    a->passengers      = NULL;
    a->passengerCount  = 0;

    a->yaz             = _yazUzayAraci;
    a->setVarisTarihi  = _setVarisTarihiImpl;
    a->deleteUzayAraci = _deleteUzayAraciImpl;
    return a;
}

void deleteUzayAraci(UzayAraci this) {
    if (this) this->deleteUzayAraci(this);
}

void uzayAraciAddPassenger(UzayAraci this, Kisi passenger) {
    this->passengers = realloc(this->passengers,
                               sizeof *this->passengers * (this->passengerCount + 1));
    this->passengers[this->passengerCount++] = passenger;
}

void uzayAraciRemovePassenger(UzayAraci this, Kisi passenger) {
    int i, j;
    for (i = 0; i < this->passengerCount; ++i) {
        if (this->passengers[i] == passenger) {
            for (j = i; j < this->passengerCount - 1; ++j)
                this->passengers[j] = this->passengers[j+1];
            this->passengerCount--;
            break;
        }
    }
    this->passengers = realloc(this->passengers,
                               sizeof *this->passengers * this->passengerCount);
}

void uzayAraciDepart(UzayAraci this, Zaman departureTime) {
    if (!this->hasDeparted) {
        this->hasDeparted = 1;
        this->cikisTarihi->deleteZaman(this->cikisTarihi);
        this->cikisTarihi = newZaman(
            departureTime->gun,
            departureTime->ay,
            departureTime->yil,
            departureTime->saatSayisi
        );
    }
}

void uzayAraciAdvanceHour(UzayAraci this,
                          double ageFactorSrc,
                          double ageFactorDst,
                          Zaman targetPlanetTime) {
    if (!this->hasDeparted || this->imha || this->kalanSaat == 0)
        return;

    // Yolcu yaşlanması
    for (int i = 0; i < this->passengerCount; ++i) {
        Kisi k = this->passengers[i];
        k->kalanOmur -= (int)ageFactorSrc;  // örnek: sadece çıkış faktörü
        if (k->kalanOmur < 0) k->kalanOmur = 0;
    }

    this->kalanSaat--;
    if (this->kalanSaat < 0)
        this->kalanSaat = 0;

    if (this->kalanSaat == 0 && !this->varisTarihi) {
        this->varisTarihi = newZaman(
            targetPlanetTime->gun,
            targetPlanetTime->ay,
            targetPlanetTime->yil,
            targetPlanetTime->saatSayisi
        );
    }
}

static void _setVarisTarihiImpl(UzayAraci this, Zaman varis) {
    if (this->varisTarihi) this->varisTarihi->deleteZaman(this->varisTarihi);
    this->varisTarihi = varis;
}

static void _yazUzayAraci(UzayAraci this) {
    char* cstr = this->cikisTarihi->toString(this->cikisTarihi);
    char* vstr = this->varisTarihi
                ? this->varisTarihi->toString(this->varisTarihi)
                : _strdup("--. --. ----");
    printf("Arac: %-3s  Cikis: %-2s  Varis: %-2s  CikisT: %s  Kalan: %4d  Durum: %-4s  VarisT: %s\n",
           this->isim,
           this->cikisGezegen,
           this->varisGezegen,
           cstr,
           this->kalanSaat,
           this->imha ? "IMHA" : "AKTIF",
           vstr);
    free(cstr);
    free(vstr);
}

static void _deleteUzayAraciImpl(UzayAraci this) {
    if (this->cikisTarihi) this->cikisTarihi->deleteZaman(this->cikisTarihi);
    if (this->varisTarihi) this->varisTarihi->deleteZaman(this->varisTarihi);
    free(this->isim);
    free(this->cikisGezegen);
    free(this->varisGezegen);
    free(this->passengers);
    free(this);
}
