/**
 * @author   Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since    18.05.2025
 * <p>
 *   Dosya okuma modülünün başlık dosyası:
 *   kişiler, uzay araçları ve gezegen verilerini
 *   okuyacak fonksiyon prototiplerini ve
 *   hata yönetimi makrolarını tanımlar.
 * </p>
 */
#ifndef DOSYA_OKUMA_H
#define DOSYA_OKUMA_H

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <setjmp.h>         // jmp_buf ve setjmp/longjmp için
#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"

// ———— Hata Yönetimi Makroları —————————————————————————————
extern jmp_buf jumper;      // hata atlamaları için tek bir ortak buffer

#define throw   longjmp(jumper, -1)
#define try     do { if (!setjmp(jumper)) {
#define catch   } else {
#define tryEnd  } } while (0)

// ———— Fonksiyon Prototipleri ——————————————————————————————
Kisi*      kisileriOku(const char* dosyaAdi, int* adet);
UzayAraci* araclariOku(const char* dosyaAdi, int* adet);
Gezegen*   gezegenleriOku(const char* dosyaAdi, int* adet);

#endif // DOSYA_OKUMA_H