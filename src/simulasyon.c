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
// simulasyon.c
static void _baslatSimulasyon(Simulasyon this) {
    int saat = 0;
    int tamamlanan = 0;

    // 1) Ana döngü: tüm araçlar hedefe ulaşana kadar
    while (tamamlanan < this->aracSayisi) {
        // Konsolu temizle
        printf("\033[H\033[J");      // ANSI/Unix
        // system("cls");            // Windows için açabilirsin

        tamamlanan = 0;
        printf("===== Saat %d =====\n", saat);

        // Çıkış tarihlerini kontrol et
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

        // Araçları hareket ettir ve yolcuların ömrünü azalt
        for (int i = 0; i < this->aracSayisi; ++i) {
            UzayAraci a = this->araclar[i];
            if (a->kalanSaat <= 0) {
                ++tamamlanan;
                continue;
            }
            a->kalanSaat--;
            for (int k = 0; k < this->kisiSayisi; ++k) {
                if (strcmp(this->kisiler[k]->aracAdi, a->isim) == 0) {
                    this->kisiler[k]->kalanOmur--;
                }
            }
            printf("  [HAREKET] %s aracı, kalan süre: %d saat\n",
                   a->isim, a->kalanSaat);

            // Varış anı
            if (a->kalanSaat == 0) {
                int q = _findPlanet(this, a->varisGezegen);
                char* vt = this->gezegenler[q]->tarih->toString(this->gezegenler[q]->tarih);
                printf("  [VARIŞ]   %s hedefe ulaştı: %s tarihinde\n",
                       a->isim, vt);
                free(vt);
            }
        }

        // Gezegen zamanlarını ilerlet
        for (int i = 0; i < this->gezegenSayisi; ++i) {
            this->gezegenler[i]->tarih->ilerle(this->gezegenler[i]->tarih);
        }

        printf("------------------------\n\n");
        saat++;
        // İstersen sleep(1) ekleyebilirsin
    }

    // 2) Simülasyon bitti, nüfusları dinamik hesapla
    int* pop = malloc(this->gezegenSayisi * sizeof(int));
    for (int i = 0; i < this->gezegenSayisi; ++i) pop[i] = 0;

    for (int i = 0; i < this->kisiSayisi; ++i) {
        // Sağ kalan yolcu
        if (this->kisiler[i]->kalanOmur > 0) {
            // Yolcunun indiği gezegeni bul
            const char* aracAd = this->kisiler[i]->aracAdi;
            for (int j = 0; j < this->aracSayisi; ++j) {
                UzayAraci a = this->araclar[j];
                if (strcmp(a->isim, aracAd) == 0) {
                    int p = _findPlanet(this, a->varisGezegen);
                    if (p >= 0) pop[p]++;
                    break;
                }
            }
        }
    }

    // 3) Gezegenler tablosu
    printf("\nGezegenler:\n\n");
    printf("%-15s", "Gezegen");
    for (int i = 0; i < this->gezegenSayisi; ++i)
        printf("%-15s", this->gezegenler[i]->isim);
    printf("\n");

    printf("%-15s", "Tarih");
    for (int i = 0; i < this->gezegenSayisi; ++i) {
        char* t = this->gezegenler[i]->tarih->toString(this->gezegenler[i]->tarih);
        printf("%-15s", t);
        free(t);
    }
    printf("\n");

    printf("%-15s", "Nüfus");
    for (int i = 0; i < this->gezegenSayisi; ++i)
        printf("%-15d", pop[i]);
    printf("\n\n");

    free(pop);

    // 4) Uzay araçları tablosu
    printf("Uzay Araçları:\n\n");
    printf("%-10s %-10s %-6s %-6s %-12s %s\n",
           "Araç Adı","Durum","Çıkış","Varış","Kalan Saat","Varış Tarihi");
    for (int i = 0; i < this->aracSayisi; ++i) {
        UzayAraci a = this->araclar[i];
        const char* durum = (a->kalanSaat == a->mesafeSaat) ? "Bekliyor"
                             : (a->kalanSaat > 0) ? "Yolda" : "Vardı";
        int idx = _findPlanet(this, a->varisGezegen);
        char* vt = this->gezegenler[idx]->tarih->toString(this->gezegenler[idx]->tarih);

        printf("%-10s %-10s %-6s %-6s %-12d %s\n",
               a->isim, durum,
               a->cikisGezegen, a->varisGezegen,
               a->kalanSaat, vt);

        free(vt);
    }

    printf("\nTüm araçlar hedefe ulaştı. Simülasyon tamamlandı.\n");
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
