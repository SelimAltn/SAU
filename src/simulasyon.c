#include "simulasyon.h"
#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"
#include "zaman.h"

// Fully define SIMULATION struct so fields are visible here
struct SIMULASYON {
    Kisi*      kisiler;
    int        kisiSayisi;
    UzayAraci* araclar;
    int        aracSayisi;
    Gezegen*   gezegenler;
    int        gezegenSayisi;
    void       (*baslat)(struct SIMULASYON*);
    void       (*deleteSimulasyon)(struct SIMULASYON*);
};
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Forward declarations
static int  _tarihEsit(Zaman a, Zaman b);
static int  _findPlanet(Simulasyon this, const char* ad);
static void _baslatSimulasyon(Simulasyon this);
static void _deleteSimulasyon(Simulasyon this);

// Public constructor and destructor
Simulasyon newSimulasyon(Kisi* kisiler, int kisiSayisi,
                         UzayAraci* araclar, int aracSayisi,
                         Gezegen* gezegenler, int gezegenSayisi)
{
    Simulasyon s = malloc(sizeof *s);
    s->kisiler            = kisiler;
    s->kisiSayisi         = kisiSayisi;
    s->araclar            = araclar;
    s->aracSayisi         = aracSayisi;
    s->gezegenler         = gezegenler;
    s->gezegenSayisi      = gezegenSayisi;
    s->baslat             = _baslatSimulasyon;
    s->deleteSimulasyon   = _deleteSimulasyon;
    return s;
}

void baslatSimulasyon(Simulasyon this) {
    this->baslat(this);
}

void deleteSimulasyon(Simulasyon this) {
    this->deleteSimulasyon(this);
}

// Static helper: compare dates
static int _tarihEsit(Zaman a, Zaman b) {
    return a->gun == b->gun && a->ay == b->ay && a->yil == b->yil;
}

// Static helper: find planet index by name
static int _findPlanet(Simulasyon this, const char* ad) {
    for (int i = 0; i < this->gezegenSayisi; ++i) {
        if (strcmp(this->gezegenler[i]->isim, ad) == 0)
            return i;
    }
    return -1;
}

// Main simulation loop
static void _baslatSimulasyon(Simulasyon this) {
    int saat = 0;
    int tamamlanan = 0;

    while (tamamlanan < this->aracSayisi) {
        tamamlanan = 0;
        printf("===== Saat %d =====\n", saat);

        // 1) Check departure dates
        for (int i = 0; i < this->aracSayisi; ++i) {
            UzayAraci a = this->araclar[i];
            if (a->kalanSaat == a->mesafeSaat) {
                int p = _findPlanet(this, a->cikisGezegen);
                if (p >= 0 && _tarihEsit(a->cikisTarihi, this->gezegenler[p]->tarih)) {
                    printf("  [ÇIKIŞ] %s aracı %s tarihinde yola çıktı.\n",
                           a->isim, a->cikisGezegen);
                }
            }
        }

        // 2) Move ships and reduce lifespan
        for (int i = 0; i < this->aracSayisi; ++i) {
            UzayAraci a = this->araclar[i];
            if (a->kalanSaat <= 0) {
                ++tamamlanan;
                continue;
            }
            a->kalanSaat--;
            for (int k = 0; k < this->kisiSayisi; ++k) {
                if (strcmp(this->kisiler[k]->aracAdi, a->isim) == 0)
                    this->kisiler[k]->kalanOmur--;
            }
            printf("  [HAREKET] %s aracı, kalan süre: %d saat\n",
                   a->isim, a->kalanSaat);
            if (a->kalanSaat == 0) {
                int q = _findPlanet(this, a->varisGezegen);
                char* vt = this->gezegenler[q]->tarih->toString(
                              this->gezegenler[q]->tarih);
                printf("  [VARIŞ] %s hedefe ulaştı: %s tarihinde\n",
                       a->isim, vt);
                free(vt);
            }
        }

        // 3) Advance planet times
        for (int i = 0; i < this->gezegenSayisi; ++i) {
            this->gezegenler[i]->tarih->ilerle(
                this->gezegenler[i]->tarih);
        }

        printf("------------------------\n\n");
        saat++;
    }

    printf("Tüm araçlar hedefe ulaştı. Simülasyon tamamlandı.\n");
}

// Static destructor
static void _deleteSimulasyon(Simulasyon this) {
    if (!this) return;
    for (int i = 0; i < this->kisiSayisi; ++i)
        deleteKisi(this->kisiler[i]);
    free(this->kisiler);
    for (int i = 0; i < this->aracSayisi; ++i)
        deleteUzayAraci(this->araclar[i]);
    free(this->araclar);
    for (int i = 0; i < this->gezegenSayisi; ++i)
        this->gezegenler[i]->deleteGezegen(this->gezegenler[i]);
    free(this->gezegenler);
    free(this);
}
