/**
 * @author   Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since    15.05.2025
 * <p>
 *   Simulasyon struct’unun tanımı ve tüm
 *   yürütme adımlarını (kalkış, hareket,
 *   zaman ilerletme, durum raporları) uygulayan
 *   kaynak dosyadır. Ayrıca gezegenler arası
 *   varış zamanı hesaplama fonksiyonunu içerir.
 * </p>
 */
#include "simulasyon.h"
#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"
#include "zaman.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>



Zaman _hesaplaVarisTarihi(Zaman departure,
                                 int travelHours,
                                 int targetDayLength)
{
  
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
static int  _tumAraclarTamamlandi(Simulasyon);


/* --- yeni küçük görev fonksiyonları --- */
static void _clearConsole(void);
static void _printSaatBaslik(int saat);
static void _handleDepartures(Simulasyon);
static void _moveShipsAndPassengers(Simulasyon); 
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
    printf("===== iterasyon  %d =====\n", saat);
}
/* --- 1) Çıkış kontrolü ve gerçek ayrılış tarihini yakalama --- */
static void _handleDepartures(Simulasyon this) {
    for (int i = 0; i < this->aracSayisi; ++i) {
        UzayAraci a = this->araclar[i];

        if (!a->hasDeparted) {
            int p = _findPlanet(this, a->cikisGezegen);
            if (p >= 0 && _tarihEsit(a->cikisTarihi, this->gezegenler[p]->tarih)) {
                printf("  [CIKIS] %s araci %s tarihinde yola cikti.\n",
                       a->isim, a->cikisGezegen);
                uzayAraciDepart(a, this->gezegenler[p]->tarih);
            }
        }
    }
}

/* --- 2) Hareket & yolcu ömrü & varış & imha --- */
static void _moveShipsAndPassengers(Simulasyon this) {
    for (int i = 0; i < this->aracSayisi; ++i) {
        UzayAraci a = this->araclar[i];

        // Henüz kalkış yapmamış veya imha olmuşsa atla
        if (!a->hasDeparted || a->imha)
            continue;

        // Yaşlanma faktörlerini bul
        int idxSrc = _findPlanet(this, a->cikisGezegen);
        int idxDst = _findPlanet(this, a->varisGezegen);
        // Yolda olan araç için yaşlanma normal (1.0), aksi halde gezegen katsayısı
        double factorSrc = (a->hasDeparted && a->kalanSaat > 0)
                         ? 1.0
                         : ((idxSrc >= 0)
                            ? this->gezegenler[idxSrc]->yaslanmaKatSayi(this->gezegenler[idxSrc])
                            : 1.0);
        double factorDst = (idxDst >= 0)
                         ? this->gezegenler[idxDst]->yaslanmaKatSayi(this->gezegenler[idxDst])
                         : 1.0;

        // Tüm yolcuların kalan ömrünü düşür ve yaşaması gerekip gerekmediğini say
        int survivors = 0;
        for (int k = 0; k < this->kisiSayisi; ++k) {
            if (strcmp(this->kisiler[k]->aracAdi, a->isim) == 0) {
                this->kisiler[k]->kalanOmur -= factorSrc;
                if (this->kisiler[k]->kalanOmur < 0)
                    this->kisiler[k]->kalanOmur = 0;
                if (this->kisiler[k]->kalanOmur > 0)
                    survivors++;
            }
        }

        // Yolcu kalmadıysa imha et
        if (survivors == 0) {
            a->imha = 1;
            a->kalanSaat = 0;
            printf("  [IMHA]   %s araci imha oldu: tum yolcular öldü.\n", a->isim);
            continue;
        }

        // Her saat için araç içindeki metodu çağır: kalanSaat--, varış tarihini set et
        Gezegen hedef = this->gezegenler[idxDst];
        uzayAraciAdvanceHour(a,
                             factorSrc,
                             factorDst,
                             hedef->tarih);

        // Duruma göre ekrana bas
        if (a->kalanSaat > 0) {
            printf("  [HAREKET] %s araci, kalan sure: %d saat\n",
                   a->isim, a->kalanSaat);
        } else {
            char* vt = a->varisTarihi->toString(a->varisTarihi);
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

// Gezegenlerin güncel tarih ve saati yazdırır
static void _printPlanetTimes(Simulasyon this) {
    for (int i = 0; i < this->gezegenSayisi; ++i) {
        Gezegen g = this->gezegenler[i];
        char* tarihStr   = g->tarih->toString(g->tarih);
        int   saatCounter = g->tarih->saatCounter;
        printf("Gezegen %-3s: %s %02d:00\n",
               g->isim, tarihStr, saatCounter);
        free(tarihStr);
    }
    printf("\n");
}

/* -------------------- Ana Döngü -------------------- */
static void _baslatSimulasyon(Simulasyon this) {
      int saat = 0;
    while (!_tumAraclarTamamlandi(this)) {
        printf("[DEBUG] Saat = %d\n", saat);
        _clearConsole();
        _printSaatBaslik(saat);
        _printPlanetTimes(this); 

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


// Gezegen adını “--X--” şeklinde width alanında ortalar
static void _printCentered(const char* text, int width) {
    int len = strlen(text);
    int padL = (width - len) / 2;
    if (padL < 0) padL = 0;
    int padR = width - len - padL;
    if (padR < 0) padR = 0;
    printf("%*s%s%*s", padL, "", text, padR, "");
}

// Yardımcı: metni “--text--” olarak süsler ve width içinde ortalar
static void _printCenteredDecorated(const char* text, int width) {
    char buf[64];
    snprintf(buf, sizeof buf, "-- %s --", text);
    _printCentered(buf, width);
}

// Tam sayı için ortalama
static void _printCenteredInt(int val, int width) {
    char buf[32];
    snprintf(buf, sizeof buf, "%d", val);
    _printCentered(buf, width);
}
/* -------------------- Durum Raporları -------------------- */
static void _yazdirGezegenDurum(Simulasyon this) {
    int G = this->gezegenSayisi;
    int* pop = calloc(G, sizeof(int));

    for (int i = 0; i < this->kisiSayisi; ++i) {
        Kisi p = this->kisiler[i];
        if (p->kalanOmur <= 0) continue;

        // Bu kişi hangi araçta?
        for (int j = 0; j < this->aracSayisi; ++j) {
            UzayAraci a = this->araclar[j];
            if (strcmp(a->isim, p->aracAdi) != 0) 
                continue;

            int idx = -1;
            if (!a->hasDeparted) {
                // Henüz kalkış yapmadıysa, çıkış gezegenine ekle
                idx = _findPlanet(this, a->cikisGezegen);
            }
            else if (a->kalanSaat == 0) {
                // Varışta: hedef gezegene ekle
                idx = _findPlanet(this, a->varisGezegen);
            }
            // Yolda olanları (hasDeparted && kalanSaat>0) sayma

            if (idx >= 0) 
                pop[idx]++;
            break;
        }
    }

    printf("Gezegenler:\n\n");
    printf("%-20s", "");
    for (int i = 0; i < G; ++i)
        _printCenteredDecorated(this->gezegenler[i]->isim, 20);
    printf("\n");

    printf("%-20s", "Tarih:");
    for (int i = 0; i < G; ++i) {
        char* ts = this->gezegenler[i]->tarih->toString(this->gezegenler[i]->tarih);
        _printCentered(ts, 20);
        free(ts);
    }
    printf("\n");

    printf("%-20s", "Nufus:");
    for (int i = 0; i < G; ++i)
        _printCenteredInt(pop[i], 20);
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
        this->gezegenler[i]->delete(this->gezegenler[i]);
    free(this->gezegenler);
    free(this);
}