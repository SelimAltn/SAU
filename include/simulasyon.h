#ifndef SIMULASYON_H
#define SIMULASYON_H

#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"
#include "zaman.h"

struct SIMULASYON;
typedef struct SIMULASYON* Simulasyon;

// Constructor & Destructor
Simulasyon newSimulasyon(Kisi* kisiler, int kisiSayisi,
                         UzayAraci* araclar, int aracSayisi,
                         Gezegen* gezegenler, int gezegenSayisi);
void       deleteSimulasyon(Simulasyon this);

// Metot pointer’ları
void       baslatSimulasyon(Simulasyon this);

#endif // SIMULASYON_H
