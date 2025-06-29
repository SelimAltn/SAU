/**
 * @author   Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since    12.05.2025
 * <p>
 *   `newZaman` constructor’ı ile oluşturulan Zaman struct’unun  
 *   metodlarını uygular. Artık yıl kontrolü ve ay gün sayısı hesaplama  
 *   yardımcı fonksiyonları, saat ilerletme (`_ilerle`),  
 *   tarih formatlama (`_toString`) ve yıkıcı (`_deleteZaman`)  
 *   fonksiyonlarını içerir.
 * </p>
 */
#include "zaman.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

// artık yıl kontrolü
static int IsLeapYear(int yil) {
       return yil % 400 == 0 || (yil % 4 == 0 && yil % 100 != 0) ;
}

// ayın gün sayısını döner
static int NumberOfDayesInMonth(int ay, int yil) {
    short arrDayys31[12] = {31,28,31,30,31,30,31,31,30,31,30,31};
	return (ay == 2) ? (IsLeapYear(yil) ? 29 : 28) : arrDayys31[ay - 1];
}

// gün/saat ilerletme metodu
static void _ilerle(struct ZAMAN* this) {
    this->saatCounter++;
    if (this->saatCounter >= this->saatSayisi) {
        this->saatCounter = 0;
        this->gun++;
        int dim = NumberOfDayesInMonth(this->ay, this->yil); // Ayın gün sayısı
        if (this->gun > dim) {
            this->gun = 1;
            this->ay++;
            if (this->ay > 12) {
                this->ay = 1;
                this->yil++;
            }
        }
    }
}

// tarihi stringe çevirme
static char* _toString(struct ZAMAN* this) {
    char* buf = malloc(12);
    snprintf(buf, 12, "%02d.%02d.%04d", this->gun, this->ay, this->yil);
    return buf;
}

// yıkıcı
static void _deleteZaman(struct ZAMAN* this) {
    if (!this) return;
    free(this);
}

// constructor
Zaman newZaman(int gun, int ay, int yil, int saatSayisi) {
    Zaman z = malloc(sizeof *z);
    z->gun          = gun;
    z->ay           = ay;
    z->yil          = yil;
    z->saatSayisi   = saatSayisi;
    z->saatCounter  = 0;
    z->ilerle       = &_ilerle;
    z->toString     = &_toString;
    z->deleteZaman  = &_deleteZaman;
    return z;
}