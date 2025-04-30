#ifndef DOSYA_OKUMA_H
#define DOSYA_OKUMA_H

#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"


// Kisileri dosyadan okur, adet pointer’ında kaç tane döndüğü verilir
Kisi* kisileriOku(const char* dosyaAdi, int* adet);

// Uzay araçlarını dosyadan okur
UzayAraci* araclariOku(const char* dosyaAdi, int* adet);

// Gezegenleri dosyadan okur
Gezegen* gezegenleriOku(const char* dosyaAdi, int* adet);

#endif // DOSYA_OKUMA_H
