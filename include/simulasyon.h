#ifndef SIMULASYON_H
#define SIMULASYON_H

#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"

// Opak yapı
typedef struct SIMULASYON* Simulasyon;

// Oluşturucu / Çalıştırıcı / Yıkıcı
Simulasyon     newSimulasyon(Kisi* kisiler, int kisiSayisi,
                             UzayAraci* araclar, int aracSayisi,
                             Gezegen* gezegenler, int gezegenSayisi);
void           baslatSimulasyon(Simulasyon this);
void           deleteSimulasyon(Simulasyon this);

#endif // SIMULASYON_H
