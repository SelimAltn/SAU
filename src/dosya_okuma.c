// src/dosya_okuma.c
#include "dosya_okuma.h"
#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"
#include "zaman.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Satır sonu \r\n temizleme (yalnızca bu dosyada)
static void temizleSatir(char* satir) {
    size_t len = strlen(satir);
    while (len > 0 && (satir[len-1] == '\n' || satir[len-1] == '\r'))
        satir[--len] = '\0';
}

// POSIX olmayan ortamlar için strdup benzeri
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

    // Header satırını atla
    char satir[256];
    if (!fgets(satir, sizeof(satir), f)) {
        *adet = 0; fclose(f); return NULL;
    }

    int kapasite = 8, sayac = 0;
    Kisi* liste = malloc(sizeof(Kisi) * kapasite);

    while (fgets(satir, sizeof(satir), f)) {
        temizleSatir(satir);
        char* copy = strdup_local(satir);
        char* isim   = strtok(copy, "#");
        char* yasStr = strtok(NULL, "#");
        char* omurStr= strtok(NULL, "#");
        char* arac   = strtok(NULL, "#");
        if (!arac) { free(copy); continue; }

        if (sayac == kapasite) {
            kapasite *= 2;
            liste = realloc(liste, sizeof(Kisi) * kapasite);
        }
        liste[sayac++] = newKisi(isim,
                                 atoi(yasStr),
                                 atoi(omurStr),
                                 arac);
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

    char satir[256];
    if (!fgets(satir, sizeof(satir), f)) {
        *adet = 0; fclose(f); return NULL;
    }

    int kapasite = 4, sayac = 0;
    UzayAraci* liste = malloc(sizeof(UzayAraci) * kapasite);

    while (fgets(satir, sizeof(satir), f)) {
        temizleSatir(satir);
        char* copy  = strdup_local(satir);
        char* isim   = strtok(copy, "#");
        char* cikis  = strtok(NULL, "#");
        char* varis  = strtok(NULL, "#");
        char* tarih  = strtok(NULL, "#");
        char* mesafe = strtok(NULL, "#");
        if (!mesafe) { free(copy); continue; }

        // tarih parse
        int g, ay, yil;
        Zaman z = NULL;
        if (sscanf(tarih, "%d.%d.%d", &g, &ay, &yil) == 3)
            z = newZaman(g, ay, yil, 0);

        if (sayac == kapasite) {
            kapasite *= 2;
            liste = realloc(liste, sizeof(UzayAraci) * kapasite);
        }
        liste[sayac++] = newUzayAraci(isim, cikis, varis, z, atoi(mesafe));
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

    char satir[256];
    if (!fgets(satir, sizeof(satir), f)) {
        *adet = 0; fclose(f); return NULL;
    }

    int kapasite = 4, sayac = 0;
    Gezegen* liste = malloc(sizeof(Gezegen) * kapasite);

    while (fgets(satir, sizeof(satir), f)) {
        temizleSatir(satir);
        char* copy     = strdup_local(satir);
        char* isim     = strtok(copy, "#");
        char* turStr   = strtok(NULL, "#");
        char* gsStr    = strtok(NULL, "#");
        char* tarihStr = strtok(NULL, "#");
        if (!tarihStr) { free(copy); continue; }

        // parse
        int gg, ay, yil;
        Zaman z = NULL;
        if (sscanf(tarihStr, "%d.%d.%d", &gg, &ay, &yil) == 3)
            z = newZaman(gg, ay, yil, atoi(gsStr));

        int tur = atoi(turStr);
        if (sayac == kapasite) {
            kapasite *= 2;
            liste = realloc(liste, sizeof(Gezegen) * kapasite);
        }
        switch (tur) {
            case 1: liste[sayac++] = newGazDeviGezegen(isim, z, atoi(gsStr)); break;
            case 2: liste[sayac++] = newBuzDeviGezegen(isim, z, atoi(gsStr));  break;
            case 3: liste[sayac++] = newCuceGezegen(isim, z, atoi(gsStr));     break;
            default: liste[sayac++] = newKayacGezegen(isim, z, atoi(gsStr));   break;
        }
        free(copy);
    }

    fclose(f);
    *adet = sayac;
    return liste;
}
