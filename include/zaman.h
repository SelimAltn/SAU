#ifndef ZAMAN_H
#define ZAMAN_H

#include <stdlib.h>

// Zaman nesnesinin tanımı (tam açılım)
struct ZAMAN {
    int gun;
    int ay;
    int yil;
    int saatSayisi;     // bu gezegende bir gün kaç saat
    int saatCounter;    // o gün içinde kaç saat geçti
    // Metot pointer'ları
    void  (*ilerle)(struct ZAMAN*);
    char* (*toString)(struct ZAMAN*);
    void  (*deleteZaman)(struct ZAMAN*);
};

// Zaman tipinin pointer-tabanlı alias’ı
typedef struct ZAMAN* Zaman;

// Constructor
Zaman newZaman(int gun, int ay, int yil, int saatSayisi);

#endif // ZAMAN_H
