// uzay_araci.c
#include "uzay_araci.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

// Private helpers
static void _yazUzayAraci(UzayAraci this);
static void _setVarisTarihiImpl(UzayAraci this, Zaman varis);
static void _deleteUzayAraciImpl(UzayAraci this);

static char* _strdup(const char* s) {
    size_t n = strlen(s) + 1;
    char* p = malloc(n);
    if (p) memcpy(p, s, n);
    return p;
}

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
    a->varisTarihi     = NULL;             // başlangıçta yok
    a->mesafeSaat      = mesafeSaat;
    a->kalanSaat       = mesafeSaat;
    a->imha            = 0;


    // Metot pointer’larını ata
    a->yaz             = _yazUzayAraci;
    a->setVarisTarihi  = _setVarisTarihiImpl;
    a->deleteUzayAraci = _deleteUzayAraciImpl;
    return a;
}

// Global wrappers

void uzayAraciSetVarisTarihi(UzayAraci this, Zaman varisTarihi) {
    if (this) this->setVarisTarihi(this, varisTarihi);
}

void uzayAraciYazdir(UzayAraci this) {
    if (this) this->yaz(this);
}

void deleteUzayAraci(UzayAraci this) {
    if (this) this->deleteUzayAraci(this);
}

// Private implementations

static void _setVarisTarihiImpl(UzayAraci this, Zaman varis) {
    // varsa eskiyi temizle
    if (this->varisTarihi) this->varisTarihi->deleteZaman(this->varisTarihi);
    this->varisTarihi = varis;
}

static void _yazUzayAraci(UzayAraci this) {
    char* cstr = this->cikisTarihi->toString(this->cikisTarihi);
    char* vstr = NULL;
    if (this->varisTarihi)
        vstr = this->varisTarihi->toString(this->varisTarihi);
    else
        vstr = _strdup("--. --. ----");
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
    free(this);
}