/* --- simulasyon.c (refactor: SOLID-vari alt fonksiyon ayrımı) --- */

#include "simulasyon.h"
#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"
#include "zaman.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

/* -------------------- Yapı Tanımı -------------------- */
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

/* ---------- Önden Bildirimler (private helpers) ---------- */
static int  _tarihEsit(Zaman, Zaman);
static int  _findPlanet(Simulasyon, const char*);

/* --- yeni küçük görev fonksiyonları --- */
static void _clearConsole(void);
static void _printSaatBaslik(int saat);
static void _handleDepartures(Simulasyon);
static void _moveShipsAndPassengers(Simulasyon, int* tamamlanan);
static void _advancePlanetTimes(Simulasyon);
static void _yazdirGezegenDurum(Simulasyon);
static void _yazdirAracDurum(Simulasyon);

static void _baslatSimulasyon(Simulasyon);
static void _deleteSimulasyon(Simulasyon);

/* -------------------- Public API -------------------- */
Simulasyon newSimulasyon(Kisi* kisiler, int kisiSayisi,
                         UzayAraci* araclar, int aracSayisi,
                         Gezegen* gezegenler, int gezegenSayisi)
{
    Simulasyon s = malloc(sizeof *s);
    s->kisiler          = kisiler;
    s->kisiSayisi       = kisiSayisi;
    s->araclar          = araclar;
    s->aracSayisi       = aracSayisi;
    s->gezegenler       = gezegenler;
    s->gezegenSayisi    = gezegenSayisi;
    s->baslat           = _baslatSimulasyon;
    s->deleteSimulasyon = _deleteSimulasyon;
    return s;
}
void baslatSimulasyon(Simulasyon this)  { this->baslat(this); }
void deleteSimulasyon(Simulasyon this) { this->deleteSimulasyon(this); }

/* -------------------- Yardımcılar -------------------- */
static int _tarihEsit(Zaman a, Zaman b) {
    return a->gun == b->gun && a->ay == b->ay && a->yil == b->yil;
}
static int _findPlanet(Simulasyon this, const char* ad) {
    for (int i = 0; i < this->gezegenSayisi; ++i)
        if (strcmp(this->gezegenler[i]->isim, ad) == 0) return i;
    return -1;
}
static void _clearConsole(void) { printf("\033[H\033[J"); }   /* Unix; Win için system("cls") */
static void _printSaatBaslik(int saat) {
    printf("===== Saat %d =====\n", saat);
}

/* --- 1) Çıkış kontrolü ve olay mesajı --- */
static void _handleDepartures(Simulasyon this) {
    for (int i = 0; i < this->aracSayisi; ++i) {
        UzayAraci a = this->araclar[i];
        if (a->kalanSaat == a->mesafeSaat) {
            int p = _findPlanet(this, a->cikisGezegen);
            if (p >= 0 && _tarihEsit(a->cikisTarihi, this->gezegenler[p]->tarih))
                printf("  [CIKIS] %s araci %s tarihinde yola cikti.\n",
                       a->isim, a->cikisGezegen);
        }
    }
}

/* --- 2) Hareket & yolcu ömrü & varış olayları --- */
static void _moveShipsAndPassengers(Simulasyon this, int* tamamlanan) {
    for (int i = 0; i < this->aracSayisi; ++i) {
        UzayAraci a = this->araclar[i];
        if (a->kalanSaat <= 0) { (*tamamlanan)++; continue; }

        a->kalanSaat--;
        for (int k = 0; k < this->kisiSayisi; ++k)
            if (strcmp(this->kisiler[k]->aracAdi, a->isim) == 0)
                this->kisiler[k]->kalanOmur--;

        printf("  [HAREKET] %s araci, kalan sure: %d saat\n",
               a->isim, a->kalanSaat);

        if (a->kalanSaat == 0) {
            int q = _findPlanet(this, a->varisGezegen);
            char* vt = this->gezegenler[q]->tarih
                           ->toString(this->gezegenler[q]->tarih);
            printf("  [VARIS]   %s hedefe ulasti: %s tarihinde\n", a->isim, vt);
            free(vt);
        }
    }
}

/* --- 3) Gezegen zamanlarını ilerletme --- */
static void _advancePlanetTimes(Simulasyon this) {
    for (int i = 0; i < this->gezegenSayisi; ++i)
        this->gezegenler[i]->tarih->ilerle(this->gezegenler[i]->tarih);
}

/* -------------------- Ana Döngü -------------------- */
static void _baslatSimulasyon(Simulasyon this) {
    int saat = 0, tamamlanan = 0;

    while (tamamlanan < this->aracSayisi) {
        _clearConsole();
        _printSaatBaslik(saat);

        _handleDepartures(this);
        tamamlanan = 0;                            /* her saatte yeniden say */
        _moveShipsAndPassengers(this, &tamamlanan);
        _advancePlanetTimes(this);

        printf("------------------------\n\n");
        ++saat;
        /* sleep(1);  // isterseniz */
    }

    _yazdirGezegenDurum(this);
    _yazdirAracDurum(this);
    printf("Tum araclar hedefe ulasti. Simulasyon tamamlandi.\n");
}


// Print planet status table
static void _yazdirGezegenDurum(Simulasyon this) {
    int G = this->gezegenSayisi;
    int* pop = malloc(G * sizeof(int));
    for (int i = 0; i < G; ++i) pop[i] = 0;
    for (int i = 0; i < this->kisiSayisi; ++i) {
        if (this->kisiler[i]->kalanOmur > 0) {
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

    printf("Gezegenler:\n\n");
    // Header row
    printf("%-20s", "");
    for (int i = 0; i < G; ++i)
        printf("%-20s", this->gezegenler[i]->isim);
    printf("\n");

    // Date row
    printf("%-20s", "Tarih:");
    for (int i = 0; i < G; ++i) {
        char* t = this->gezegenler[i]->tarih
                       ->toString(this->gezegenler[i]->tarih);
        printf("%-20s", t);
        free(t);
    }
    printf("\n");

    // Population row
    printf("%-20s", "Nüfus:");
    for (int i = 0; i < G; ++i)
        printf("%-20d", pop[i]);
    printf("\n\n");

    free(pop);
}

// Print ship status table
static void _yazdirAracDurum(Simulasyon this) {
    int A = this->aracSayisi;
    printf("Uzay Araclari:\n");
    printf("%-10s %-10s %-10s %-10s %-20s %-20s\n",
           "Arac Adi", "Durum", "cikis", "varis",
           "Hedefe Kalan Saat", "Hedef Tarih");

    for (int i = 0; i < A; ++i) {
        UzayAraci a = this->araclar[i];
        const char* durum = (a->kalanSaat == a->mesafeSaat) ? "Bekliyor"
                             : (a->kalanSaat > 0)         ? "Yolda"
                                                           : "Vardi";
        int idx = _findPlanet(this, a->varisGezegen);
        char* vt = this->gezegenler[idx]->tarih
                       ->toString(this->gezegenler[idx]->tarih);

        printf("%-10s %-10s %-10s %-10s %-20d %-20s\n",
               a->isim, durum,
               a->cikisGezegen, a->varisGezegen,
               a->kalanSaat, vt);
        free(vt);
    }
    printf("\n");
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
