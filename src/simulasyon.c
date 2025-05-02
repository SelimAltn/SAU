#include "simulasyon.h"
#include <stdlib.h>
#include <stdio.h>

struct SIMULASYON {
    Kisi*       kisiler;
    int         kisiSayisi;
    UzayAraci*  araclar;
    int         aracSayisi;
    Gezegen*    gezegenler;
    int         gezegenSayisi;
    // Metot pointer’ları
    void (*baslat)(struct SIMULASYON*);
    void (*deleteSimulasyon)(struct SIMULASYON*);
};

// forward deklarasyonlar
static void _baslatSimulasyon(Simulasyon this);
static void _deleteSimulasyon(Simulasyon this);

Simulasyon newSimulasyon(Kisi* kisiler, int kisiSayisi,
                         UzayAraci* araclar, int aracSayisi,
                         Gezegen* gezegenler, int gezegenSayisi)
{
    Simulasyon s = malloc(sizeof(*s));
    s->kisiler      = kisiler;
    s->kisiSayisi   = kisiSayisi;
    s->araclar      = araclar;
    s->aracSayisi   = aracSayisi;
    s->gezegenler   = gezegenler;
    s->gezegenSayisi= gezegenSayisi;
    s->baslat       = &_baslatSimulasyon;
    s->deleteSimulasyon = &_deleteSimulasyon;
    return s;
}

static void _baslatSimulasyon(Simulasyon this) {
    printf("Simulasyon basladi: %d kisi, %d arac, %d gezegen\n",
           this->kisiSayisi, this->aracSayisi, this->gezegenSayisi);
    // ... simülasyon döngüsü buraya gelecek
}

static void _deleteSimulasyon(Simulasyon this) {
    if (!this) return;
    free(this);
}

void baslatSimulasyon(Simulasyon this) {
    this->baslat(this);
}

void deleteSimulasyon(Simulasyon this) {
    this->deleteSimulasyon(this);
}
