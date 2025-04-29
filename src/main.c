#include <stdio.h>
#include <stdlib.h>
#include "zaman.h"

int main() {
    Zaman z;
    zamanInit(&z, 28, 2, 2025, 24);
    for(int i = 0; i < 25; i++) {
        char* s = zamanToString(&z);
        printf("Tarih: %s\n", s);
        free(s);
        zamanIlerle(&z);
    }
    return 0;
}
