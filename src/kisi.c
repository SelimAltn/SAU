#include "kisi.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

struct KISI {
    char* isim;
    int   yas;
    int   kalanOmur;
    char* aracAdi;
    // Metot pointer’ları
    void (*yaz)(struct KISI*);
    void (*deleteKisi)(struct KISI*);
};

// forward deklarasyonlar
static void _yazKisi(Kisi this);
static void _deleteKisi(Kisi this);

static char* _strdup(const char* s) {
    size_t n = strlen(s)+1;
    char* p = malloc(n);
    if (p) memcpy(p, s, n);
    return p;
}

Kisi newKisi(const char* isim, int yas, int kalanOmur, const char* aracAdi) {
    Kisi k = malloc(sizeof(*k));
    k->isim       = _strdup(isim);
    k->yas        = yas;
    k->kalanOmur  = kalanOmur;
    k->aracAdi    = _strdup(aracAdi);
    k->yaz        = &_yazKisi;
    k->deleteKisi = &_deleteKisi;
    return k;
}

static void _yazKisi(Kisi this) {
    printf("Isim: %s, Yas: %d, KalanOmur: %d, Arac: %s\n",
           this->isim, this->yas, this->kalanOmur, this->aracAdi);
}

static void _deleteKisi(Kisi this) {
    if (!this) return;
    free(this->isim);
    free(this->aracAdi);
    free(this);
}
