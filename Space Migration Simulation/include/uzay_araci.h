/**
 * @author   Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since    13.05.2025
 * <p>
 *   UzayAraci soyut veri tipini tanımlar.  
 *   Bir uzay aracının adı, çıkış/varış gezegenleri,  
 *   çıkış ve varış zamanları, mesafe-saat bilgisi,  
 *   yolcu listesi ve durum flag’lerini içeren struct  
 *   ile ilgili public API fonksiyon prototiplerini sağlar.
 * </p>
 */
#ifndef UZAY_ARACI_H
#define UZAY_ARACI_H

#include "zaman.h"
#include "kisi.h"

typedef struct UzayAraci_ {
    char*   isim;
    char*   cikisGezegen;
    char*   varisGezegen;
    Zaman   cikisTarihi;
    Zaman   varisTarihi;
    int     mesafeSaat;
    int     kalanSaat;
    int     imha;
    int     hasDeparted;
    Kisi*   passengers;
    int     passengerCount;

    // Metot pointer’ları
    void (*yaz)(struct UzayAraci_* this);
    void (*setVarisTarihi)(struct UzayAraci_* this, Zaman varis);
    void (*deleteUzayAraci)(struct UzayAraci_* this);
} *UzayAraci;

// Oluşturucu / yıkıcı
UzayAraci newUzayAraci(const char* isim,
                       const char* cikisGezegen,
                       const char* varisGezegen,
                       Zaman cikisTarihi,
                       int mesafeSaat);
void deleteUzayAraci(UzayAraci this);

// Yolcu yönetimi
void uzayAraciAddPassenger(UzayAraci this, Kisi passenger);
void uzayAraciRemovePassenger(UzayAraci this, Kisi passenger);

// Kalkış / saat ilerletme / varış tarihi set etme
void uzayAraciDepart(UzayAraci this, Zaman departureTime);
void uzayAraciAdvanceHour(UzayAraci this,
                          double ageFactorSrc,
                          double ageFactorDst,
                          Zaman targetPlanetTime);
void uzayAraciSetVarisTarihi(UzayAraci this, Zaman varis);

// Yazdırma
void uzayAraciYazdir(UzayAraci this);

#endif // UZAY_ARACI_H