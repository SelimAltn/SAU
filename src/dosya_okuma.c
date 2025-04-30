// src/dosya_okuma.c
#include "dosya_okuma.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// satır sonu \r\n temizleme (yalnızca bu dosyada)
static void temizleSatir(char* satir) {
    size_t len = strlen(satir);
    while (len > 0 && (satir[len-1]=='\n' || satir[len-1]=='\r'))
        satir[--len] = '\0';
}

// strdup benzeri, POSIX olmayan ortamlar için
static char* strdup_local(const char* s) {
    size_t l = strlen(s) + 1;
    char* p = malloc(l);
    if (p) memcpy(p, s, l);
    return p;
}

// —— Kisileri oku —————————————————————————————————————————————————

Kisi* kisileriOku(const char* dosyaAdi, int* adet) {
    FILE* f = fopen(dosyaAdi, "r");
    if (!f) return NULL;

    int kapasite = 8, sayac = 0;
    Kisi* liste = malloc(sizeof(Kisi) * kapasite);
    char satir[128];
    int baslikGecildi = 0;

    while (fgets(satir, sizeof(satir), f)) {
        temizleSatir(satir);

        if (!baslikGecildi) {
            // başlık satırında strtok ile ilkinin "isim" olup olmadığını kontrol et
            char tmp[128]; strcpy(tmp, satir);
            char* ilk = strtok(tmp, "#");
            if (ilk && strcmp(ilk, "isim")==0) {
                baslikGecildi = 1;
                continue;
            }
            baslikGecildi = 1;
        }

        char* copy = strdup_local(satir);
        char* isim = strtok(copy, "#");
        char* yasStr = strtok(NULL, "#");
        char* omurStr = strtok(NULL, "#");
        char* arac = strtok(NULL, "#");
        if (!arac) { free(copy); continue; }

        if (sayac == kapasite) {
            kapasite *= 2;
            liste = realloc(liste, sizeof(Kisi)*kapasite);
        }

        Kisi* k = &liste[sayac++];
        strncpy(k->isim, isim, sizeof(k->isim)-1);
        k->isim[sizeof(k->isim)-1] = '\0';
        k->yas = atoi(yasStr);
        k->kalan_omur = atoi(omurStr);
        strncpy(k->aracAdi, arac, sizeof(k->aracAdi)-1);
        k->aracAdi[sizeof(k->aracAdi)-1] = '\0';

        free(copy);
    }

    fclose(f);
    *adet = sayac;
    return liste;
}


// —— Uzay Araçlarını Oku ————————————————————————————————————————————————
UzayAraci* araclariOku(const char* dosyaAdi, int* adet) {
    FILE* f = fopen(dosyaAdi, "r");
    if (!f) return NULL;

    int kapasite = 4, sayac = 0;
    UzayAraci* liste = malloc(sizeof(UzayAraci) * kapasite);
    char satir[128];
    int baslikGecildi = 0;

    while (fgets(satir, sizeof(satir), f)) {
        temizleSatir(satir);

        // Başlık satırını atla: ilk token uzunluğu >1 ise
        if (!baslikGecildi) {
            char tmp[128]; strcpy(tmp, satir);
            char* ilk = strtok(tmp, "#");
            if (ilk && strlen(ilk) > 1) {
                baslikGecildi = 1;
                continue;
            }
            baslikGecildi = 1;
        }

        // Gerçek veri: A#X#Y#gg.aa.yyyy#mesafe
        char* copy  = strdup_local(satir);
        char* isim   = strtok(copy, "#");
        char* cikis  = strtok(NULL, "#");
        char* varis  = strtok(NULL, "#");
        char* tarih  = strtok(NULL, "#");
        char* mesafe = strtok(NULL, "#");
        if (!mesafe) { free(copy); continue; }

        if (sayac == kapasite) {
            kapasite *= 2;
            liste = realloc(liste, sizeof(UzayAraci) * kapasite);
        }

        UzayAraci* a = &liste[sayac++];
        // metin alanları doldur
        strncpy(a->isim,        isim,   sizeof(a->isim)-1);
        a->isim[sizeof(a->isim)-1] = '\0';
        strncpy(a->cikisGezegen, cikis, sizeof(a->cikisGezegen)-1);
        a->cikisGezegen[sizeof(a->cikisGezegen)-1] = '\0';
        strncpy(a->varisGezegen, varis, sizeof(a->varisGezegen)-1);
        a->varisGezegen[sizeof(a->varisGezegen)-1] = '\0';
        a->mesafeSaat = atoi(mesafe);
        a->kalanSaat  = a->mesafeSaat;
        a->imha       = 0;
        // tarihi parse et ve başlat
        {
            int g, ay, yil;
            if (sscanf(tarih, "%d.%d.%d", &g, &ay, &yil) == 3) {
                zamanInit(&a->cikisTarihi, g, ay, yil, 0);
            }
        }

        free(copy);
    }

    fclose(f);
    *adet = sayac;
    return liste;
}


// —— Gezegenleri Oku ————————————————————————————————————————————————————
Gezegen* gezegenleriOku(const char* dosyaAdi, int* adet) {
    FILE* f = fopen(dosyaAdi, "r");
    if (!f) return NULL;

    int kapasite = 4, sayac = 0;
    Gezegen* liste = malloc(sizeof(Gezegen) * kapasite);
    char satir[128];
    int baslikGecildi = 0;

    while (fgets(satir, sizeof(satir), f)) {
        temizleSatir(satir);

        // Başlık satırını atla: ilk token uzunluğu >1 ise
        if (!baslikGecildi) {
            char tmp[128]; strcpy(tmp, satir);
            char* ilk = strtok(tmp, "#");
            if (ilk && strlen(ilk) > 1) {
                baslikGecildi = 1;
                continue;
            }
            baslikGecildi = 1;
        }

        // Gerçek veri: X#tur#gunSaat#gg.aa.yyyy
        char* copy      = strdup_local(satir);
        char* isim      = strtok(copy, "#");
        char* turStr    = strtok(NULL, "#");
        char* gsStr     = strtok(NULL, "#");
        char* tarihStr  = strtok(NULL, "#");
        if (!tarihStr) { free(copy); continue; }

        if (sayac == kapasite) {
            kapasite *= 2;
            liste = realloc(liste, sizeof(Gezegen) * kapasite);
        }

        Gezegen* g = &liste[sayac++];
        strncpy(g->isim, isim, sizeof(g->isim)-1);
        g->isim[sizeof(g->isim)-1] = '\0';
        g->tur     = (Gezegentur)atoi(turStr);
        g->gunSaat = atoi(gsStr);
        // tarihi parse et ve başlat
        {
            int gg, ay, yil;
            if (sscanf(tarihStr, "%d.%d.%d", &gg, &ay, &yil) == 3) {
                zamanInit(&g->tarih, gg, ay, yil, g->gunSaat);
            }
        }

        free(copy);
    }

    fclose(f);
    *adet = sayac;
    return liste;
}