/* --- simulasyon.c (refactor: SOLID-vari alt fonksiyon ayrımı) --- */

#include "simulasyon.h"
#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"
#include "zaman.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// simulasyon.c’in en başında includes’lerden hemen sonra:
static int _isLeapYear(int yil) {
    if (yil % 400 == 0) return 1;
    if (yil % 100 == 0) return 0;
    return (yil % 4) == 0;
}

static int _daysInMonth(int ay, int yil) {
    switch (ay) {
        case 2: return _isLeapYear(yil) ? 29 : 28;
        case 4: case 6: case 9: case 11: return 30;
        default: return 31;
    }
}
// simülasyon.c’in en başında includes’lerden sonra:
Zaman _hesaplaVarisTarihi(Zaman departure,
                                 int travelHours,
                                 int targetDayLength)
{
    // departure günü/saatSayısı bilgisini kullanma, yeni zaman objesini
    // hedef gezegenin gün uzunluğuyla yarat
    Zaman arrival = newZaman(
        departure->gun,
        departure->ay,
        departure->yil,
        targetDayLength
    );
    // her saat için ilerlet
    for (int h = 0; h < travelHours; ++h) {
        arrival->ilerle(arrival);
    }
    return arrival;
}


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
static int  _tumAraclarTamamlandi(Simulasyon); // 🔸 EKLENDİ


/* --- yeni küçük görev fonksiyonları --- */
static void _clearConsole(void);
static void _printSaatBaslik(int saat);
static void _handleDepartures(Simulasyon);
static void _moveShipsAndPassengers(Simulasyon); // 🔸 Güncellendi
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
static void _clearConsole(void) { printf("\033[H\033[J"); }
static void _printSaatBaslik(int saat) {
    printf("===== Saat %d =====\n", saat);
}
/* --- 1) Çıkış kontrolü ve gerçek ayrılış tarihini yakalama --- */
static void _handleDepartures(Simulasyon this) {
    for (int i = 0; i < this->aracSayisi; ++i) {
        UzayAraci a = this->araclar[i];
        if (a->kalanSaat == a->mesafeSaat && !a->hasDeparted) {
            int p = _findPlanet(this, a->cikisGezegen);
            Gezegen src = this->gezegenler[p];
            if (p >= 0 && _tarihEsit(a->cikisTarihi, src->tarih)) {
                printf("  [CIKIS] %s araci %s tarihinde yola cikti.\n",
                       a->isim, a->cikisGezegen);
                a->hasDeparted = 1;    // << işaretle
                a->cikisTarihi->deleteZaman(a->cikisTarihi);
                a->cikisTarihi = newZaman(
                    src->tarih->gun,
                    src->tarih->ay,
                    src->tarih->yil,
                    src->gunSaat
                );
            }
        }
    }
}

/* --- 2) Hareket & yolcu ömrü & varış & imha --- */
static void _moveShipsAndPassengers(Simulasyon this) {
    for (int i = 0; i < this->aracSayisi; ++i) {
        UzayAraci a = this->araclar[i];

        // Henüz yola çıkmamış veya zaten imha olmuşsa atla
        if (!a->hasDeparted || a->imha)
            continue;

        // Yolcuların ömrünü azaltacak yaşlanma faktörünü belirle
        int idxSrc = _findPlanet(this, a->cikisGezegen);
        int idxDst = _findPlanet(this, a->varisGezegen);
        double factor;
        if (a->kalanSaat == a->mesafeSaat) {
            // tam yola çıkış anı: çıkış gezegeni katsayısı
            factor = (idxSrc >= 0)
                   ? this->gezegenler[idxSrc]->yaslanmaKatSayi(this->gezegenler[idxSrc])
                   : 1.0;
        } else if (a->kalanSaat == 1) {
            // varışın hemen öncesi: varış gezegeni katsayısı
            factor = (idxDst >= 0)
                   ? this->gezegenler[idxDst]->yaslanmaKatSayi(this->gezegenler[idxDst])
                   : 1.0;
        } else {
            // ara adımlar: varsayılan (ya da çıkış gezegeni)
            factor = (idxSrc >= 0)
                   ? this->gezegenler[idxSrc]->yaslanmaKatSayi(this->gezegenler[idxSrc])
                   : 1.0;
        }

        // Tüm yolcuların kalan ömrünü düş ve hayatta kalan sayısını hesapla
        int survivors = 0;
        for (int k = 0; k < this->kisiSayisi; ++k) {
            if (strcmp(this->kisiler[k]->aracAdi, a->isim) == 0) {
                this->kisiler[k]->kalanOmur -= factor;
                if (this->kisiler[k]->kalanOmur < 0)
                    this->kisiler[k]->kalanOmur = 0;
                if (this->kisiler[k]->kalanOmur > 0)
                    survivors++;
            }
        }

        // Eğer kimse kalmadıysa imha et ve atla
        if (survivors == 0) {
            a->imha = 1;
            a->kalanSaat = 0;
            printf("  [IMHA]   %s araci imha oldu: tum yolcular öldü.\n", a->isim);
            continue;
        }

        // 1 saat yol kat et
        a->kalanSaat--;
        if (a->kalanSaat > 0) {
            // hâlâ yolculukta
            printf("  [HAREKET] %s araci, kalan sure: %d saat\n",
                   a->isim, a->kalanSaat);
        } else {
            // varış anı: tarih hesapla ve raporla
            Gezegen hedef = this->gezegenler[idxDst];
            Zaman arrival = _hesaplaVarisTarihi(
                a->cikisTarihi,
                a->mesafeSaat,
                hedef->gunSaat
            );
            if (a->varisTarihi)
                a->varisTarihi->deleteZaman(a->varisTarihi);
            a->varisTarihi = arrival;

            char* vt = arrival->toString(arrival);
            printf("  [VARIS]   %s hedefe ulasti: %s\n", a->isim, vt);
            free(vt);
        }
    }
}



/* --- 3) Gezegen zamanlarını ilerletme --- */
static void _advancePlanetTimes(Simulasyon this) {
    for (int i = 0; i < this->gezegenSayisi; ++i)
        this->gezegenler[i]->tarih->ilerle(this->gezegenler[i]->tarih);
}


/* --- 4) Tüm araçlar tamamlandı mı? --- */

static int _tumAraclarTamamlandi(Simulasyon this) {
    // Eğer kalanSaat > 0 olan en az bir araç varsa, simülasyon devam etsin
    for (int i = 0; i < this->aracSayisi; ++i) {
        if (this->araclar[i]->kalanSaat > 0)
            return 0;  
    }
    // Hiçbiri >0 değilse (yani hepsi ≤0 olmuşsa) bitiş sinyali ver
    return 1;
}

/* -------------------- Ana Döngü -------------------- */
static void _baslatSimulasyon(Simulasyon this) {
      int saat = 0;
    while (!_tumAraclarTamamlandi(this)) {
        printf("[DEBUG] Saat = %d\n", saat);
        //_clearConsole();
        _printSaatBaslik(saat);

        _handleDepartures(this);
        _moveShipsAndPassengers(this);
        _advancePlanetTimes(this);

        printf("------------------------\n\n");
        ++saat;
    }
    _yazdirGezegenDurum(this);
    _yazdirAracDurum(this);
    printf("Tum araclar hedefe ulasti. Simulasyon tamamlandi.\n");
}



/* -------------------- Durum Raporları -------------------- */
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
    printf("%-20s", "");
    for (int i = 0; i < G; ++i)
        printf("%-20s", this->gezegenler[i]->isim);
    printf("\n");

    printf("%-20s", "Tarih:");
    for (int i = 0; i < G; ++i) {
        char* t = this->gezegenler[i]->tarih
                       ->toString(this->gezegenler[i]->tarih);
        printf("%-20s", t);
        free(t);
    }
    printf("\n");

    printf("%-20s", "Nüfus:");
    for (int i = 0; i < G; ++i)
        printf("%-20d", pop[i]);
    printf("\n\n");

    free(pop);
}

/* --- Durum Raporu: araçlar --- */
static void _yazdirAracDurum(Simulasyon this) {
    printf("Uzay Araclari:\n");
    printf("%-10s %-10s %-10s %-10s %-20s %-20s\n",
           "Arac Adi", "Durum", "cikis", "varis",
           "Hedefe Kalan Saat", "Hedef Tarih");

    for (int i = 0; i < this->aracSayisi; ++i) {
        UzayAraci a = this->araclar[i];

        if (a->imha) {
            printf("%-10s %-10s %-10s %-10s %-20s %-20s\n",
                   a->isim, "IMHA",
                   a->cikisGezegen, a->varisGezegen,
                   "--", "--");
        } else {
            const char* durum = (a->kalanSaat == a->mesafeSaat) ? "Bekliyor"
                                 : (a->kalanSaat > 0)         ? "Yolda"
                                                               : "Vardi";
            char* vt = a->varisTarihi
                       ? a->varisTarihi->toString(a->varisTarihi)
                       : strdup("--");
            printf("%-10s %-10s %-10s %-10s %-20d %-20s\n",
                   a->isim, durum,
                   a->cikisGezegen, a->varisGezegen,
                   a->kalanSaat, vt);
            free(vt);
        }
    }
    printf("\n");
}


/* -------------------- Destructor -------------------- */
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
