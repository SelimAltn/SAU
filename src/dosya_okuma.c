// src/dosya_okuma.c
#include "dosya_okuma.h"
#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"
#include "zaman.h"
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <setjmp.h>

// ———— Hata Yönetimi Makroları —————————————————————————————
jmp_buf jumper; // tüm dosya işlemlerinde kullanılacak

#define throw       longjmp(jumper, -1)
#define try         do { if (!setjmp(jumper)) {
#define catch       } else {
#define tryEnd      } } while (0)

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
    Kisi* liste = NULL;
    *adet = 0;

    try {
        FILE* f = fopen(dosyaAdi, "r");
        if (!f) throw;

        // Header satırını atla
        char satir[256];
        if (!fgets(satir, sizeof(satir), f)) {
            fclose(f);
            throw;
        }

        int kapasite = 8, sayac = 0;
        liste = malloc(sizeof(Kisi) * kapasite);

        while (fgets(satir, sizeof(satir), f)) {
            temizleSatir(satir);
            char* copy = strdup_local(satir);
            char* isim    = strtok(copy, "#");
            char* yasStr  = strtok(NULL, "#");
            char* omurStr = strtok(NULL, "#");
            char* arac    = strtok(NULL, "#");
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
    catch {
        // Hata durumunda temizle ve NULL dön
        if (liste) free(liste);
        *adet = 0;
        return NULL;
    }
    tryEnd;
}

// —— Uzay Araçlarını Oku ————————————————————————————————————————————————
UzayAraci* araclariOku(const char* dosyaAdi, int* adet) {
    UzayAraci* liste = NULL;
    *adet = 0;

    try {
        FILE* f = fopen(dosyaAdi, "r");
        if (!f) throw;

        char satir[256];
        if (!fgets(satir, sizeof(satir), f)) {
            fclose(f);
            throw;
        }

        int kapasite = 4, sayac = 0;
        liste = malloc(sizeof(UzayAraci) * kapasite);

        while (fgets(satir, sizeof(satir), f)) {
            temizleSatir(satir);
            char* copy   = strdup_local(satir);
            char* isim   = strtok(copy, "#");
            char* cikis  = strtok(NULL, "#");
            char* varis  = strtok(NULL, "#");
            char* tarih  = strtok(NULL, "#");
            char* mesafe = strtok(NULL, "#");
            if (!mesafe) { free(copy); continue; }

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
    catch {
        if (liste) free(liste);
        *adet = 0;
        return NULL;
    }
    tryEnd;
}

// —— Gezegenleri Oku ————————————————————————————————————————————————————
Gezegen* gezegenleriOku(const char* dosyaAdi, int* adet) {
    Gezegen* liste = NULL;
    *adet = 0;

    try {
        FILE* f = fopen(dosyaAdi, "r");
        if (!f) throw;

        char satir[256];
        if (!fgets(satir, sizeof(satir), f)) {
            fclose(f);
            throw;
        }

        int kapasite = 4, sayac = 0;
        liste = malloc(sizeof(Gezegen) * kapasite);

        while (fgets(satir, sizeof(satir), f)) {
            temizleSatir(satir);
            char* copy      = strdup_local(satir);
            char* isim      = strtok(copy, "#");
            char* turStr    = strtok(NULL, "#");
            char* gsStr     = strtok(NULL, "#");
            char* tarihStr  = strtok(NULL, "#");
            if (!tarihStr) { free(copy); continue; }

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
                default:liste[sayac++] = newKayacGezegen(isim, z, atoi(gsStr));   break;
            }
            free(copy);
        }

        fclose(f);
        *adet = sayac;
        return liste;
    }
    catch {
        if (liste) free(liste);
        *adet = 0;
        return NULL;
    }
    tryEnd;
}
