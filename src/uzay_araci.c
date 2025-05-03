#include "uzay_araci.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

// Private helpers
static void _yazUzayAraci(UzayAraci this);
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
    a->mesafeSaat      = mesafeSaat;
    a->kalanSaat       = mesafeSaat;
    a->imha            = 0;

    // Metot pointer’larını ata
    a->yaz             = _yazUzayAraci;
    a->deleteUzayAraci = _deleteUzayAraciImpl;
    return a;
}

// Global wrappers

void uzayAraciYazdir(UzayAraci this) {
    if (this) this->yaz(this);
}

void deleteUzayAraci(UzayAraci this) {
    if (this) this->deleteUzayAraci(this);
}

// Private implementations

static void _yazUzayAraci(UzayAraci this) {
    char* s = this->cikisTarihi->toString(this->cikisTarihi);
    printf("Arac: %s, Cikis: %s, Varis: %s, CikisTarih: %s, Mesafe: %d, Kalan: %d, Durum: %s\n",
           this->isim,
           this->cikisGezegen,
           this->varisGezegen,
           s,
           this->mesafeSaat,
           this->kalanSaat,
           this->imha ? "IMHA" : "AKTIF");
    free(s);
}

static void _deleteUzayAraciImpl(UzayAraci this) {
    // önce zamanı sil
    this->cikisTarihi->deleteZaman(this->cikisTarihi);
    // ardından diğer dinamik alanlar
    free(this->isim);
    free(this->cikisGezegen);
    free(this->varisGezegen);
    free(this);
}
