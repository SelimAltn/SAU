#include "zaman.h"
#include <stdio.h>
#include <stdlib.h>

void zamanInit(Zaman* z, int gun, int ay, int yil, int saatSayisi) {
    z->gun = gun;
    z->ay = ay;
    z->yil = yil;
    z->saatSayisi = saatSayisi;
}

void zamanIlerle(Zaman* z) {
    // 1 saat ilerlediğini simüle etmek için:
    // Saatler gün içinde sayılan değere ulaştığında tarihi bir gün ilerletiriz.
    static int saatCounter = 0;
    saatCounter++;
    if (saatCounter >= z->saatSayisi) {
        saatCounter = 0;
        z->gun += 1;
        int maxGun = (z->ay == 2 ? 28 :
                     (z->ay==4||z->ay==6||z->ay==9||z->ay==11 ? 30 : 31));
        if (z->gun > maxGun) {
            z->gun = 1;
            z->ay += 1;
            if (z->ay > 12) {
                z->ay = 1;
                z->yil += 1;
            }
        }
    }
}

char* zamanToString(const Zaman* z) {
    char* buf = malloc(12);
    if (!buf) return NULL;
    snprintf(buf, 12, "%02d.%02d.%04d", z->gun, z->ay, z->yil);
    return buf;
}
