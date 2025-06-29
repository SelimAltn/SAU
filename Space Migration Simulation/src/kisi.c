/**
 * @author   Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since    12.05.2025
 * <p>
 *   Kisi nesnelerinin oluşturulması, yazdırılması ve silinmesi işlevlerini uygular.  
 *   Statik yardımcı fonksiyonlarla strdup, yazdırma ve bellek temizleme işlemlerini gerçekleştirir.
 * </p>
 */
#include "kisi.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

// private helpers (static)
static void _yazKisi(Kisi this);
static void _deleteKisi(Kisi this);

static char* _strdup(const char* s) {
    size_t n = strlen(s) + 1;
    char* p = malloc(n);
    if (p) memcpy(p, s, n);
    return p;
}

Kisi newKisi(const char* isim, int yas, int kalanOmur, const char* aracAdi) {
    Kisi k = malloc(sizeof *k);
    k->isim       = _strdup(isim);
    k->yas        = yas;
    k->kalanOmur  = kalanOmur;
    k->aracAdi    = _strdup(aracAdi);
    k->yaz        = _yazKisi;
    k->deleteKisi = _deleteKisi;
    return k;
}

// public wrapper for printing
void kisiYazdir(Kisi this) {
    if (this) this->yaz(this);
}

// public wrapper for deletion
void deleteKisi(Kisi this) {
    if (this) this->deleteKisi(this);
}

static void _yazKisi(Kisi this) {
    printf("Isim: %s, Yas: %d, KalanOmur: %d, Arac: %s\n",
           this->isim, this->yas, this->kalanOmur, this->aracAdi);
}

static void _deleteKisi(Kisi this) {
    free(this->isim);
    free(this->aracAdi);
    free(this);
}