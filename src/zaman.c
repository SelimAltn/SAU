#include "zaman.h"
#include <stdlib.h>
#include <stdio.h>
#include <string.h>

// artık yıl kontrolü
static int _isLeapYear(int yil) {
    if ((yil % 400) == 0) return 1;
    if ((yil % 100) == 0) return 0;
    return (yil % 4) == 0;
}

// ayın gün sayısını döner
static int _daysInMonth(int ay, int yil) {
    switch (ay) {
        case 2: return _isLeapYear(yil) ? 29 : 28;
        case 4: case 6: case 9: case 11: return 30;
        default: return 31;
    }
}

// gün/saat ilerletme metodu
static void _ilerle(struct ZAMAN* this) {
    this->saatCounter++;
    if (this->saatCounter >= this->saatSayisi) {
        this->saatCounter = 0;
        this->gun++;
        int dim = _daysInMonth(this->ay, this->yil); // Ayın gün sayısı
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
