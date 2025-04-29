#ifndef SIMULASYON_H
#define SIMULASYON_H

#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"

// Simülasyonu çalıştırır
void simulasyonuBaslat(Kisi* kisiler, int kisiSayisi,
                       UzayAraci* araclar, int aracSayisi,
                       Gezegen* gezegenler, int gezegenSayisi);

#endif // SIMULASYON_H
