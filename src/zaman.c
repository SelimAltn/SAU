#include "zaman.h"
#include <stdio.h>
#include <string.h>

// Helper fonksiyonlar
static void _ilerle(struct ZAMAN* this) {
    this->saatCounter++;
    if (this->saatCounter >= this->saatSayisi) {
        this->saatCounter = 0;
        this->gun++;
        int maxGun = (this->ay==2?28:
                     (this->ay==4||this->ay==6||this->ay==9||this->ay==11?30:31));
        if (this->gun > maxGun) {
            this->gun = 1;
            this->ay++;
            if (this->ay > 12) {
                this->ay = 1;
                this->yil++;
            }
        }
    }
}

static char* _toString(struct ZAMAN* this) {
    char* buf = malloc(12);
    snprintf(buf, 12, "%02d.%02d.%04d", this->gun, this->ay, this->yil);
    return buf;
}

static void _deleteZaman(struct ZAMAN* this) {
    if (!this) return;
    free(this);
}

Zaman newZaman(int gun, int ay, int yil, int saatSayisi) {
    Zaman z = malloc(sizeof *z);
    z->gun           = gun;
    z->ay            = ay;
    z->yil           = yil;
    z->saatSayisi    = saatSayisi;
    z->saatCounter   = 0;
    // Metot pointer’larını ata
    z->ilerle        = &_ilerle;
    z->toString      = &_toString;
    z->deleteZaman   = &_deleteZaman;
    return z;
}
