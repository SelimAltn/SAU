#include <stdio.h>
#include <stdlib.h>
#include "zaman.h"
#include "dosya_okuma.h"

int main() {
    int kisiSayisi = 0, aracSayisi = 0, gezegenSayisi = 0;

    // 1) Kisileri oku ve yazdır
    Kisi* kisiler = kisileriOku("data/Kisiler.txt", &kisiSayisi);
    printf("Okunan Kisi sayisi: %d\n", kisiSayisi);
    for (int i = 0; i < kisiSayisi; ++i) {
        kisiYazdir(&kisiler[i]);
    }
    printf("\n");

    // 2) Uzay araclarini oku ve yazdir
    UzayAraci* araclar = araclariOku("data/Araclar.txt", &aracSayisi);
    printf("Okunan UzayAraci sayisi: %d\n", aracSayisi);
    for (int i = 0; i < aracSayisi; ++i) {
        uzayAraciYazdir(&araclar[i]);
    }
    printf("\n");

    // 3) Gezegenleri oku ve yazdir
    Gezegen* gezegenler = gezegenleriOku("data/Gezegenler.txt", &gezegenSayisi);
    printf("Okunan Gezegen sayisi: %d\n", gezegenSayisi);
    for (int i = 0; i < gezegenSayisi; ++i) {
        gezegenYazdir(&gezegenler[i]);
    }
    printf("\n");

    // Belleği temizle
    free(kisiler);
    free(araclar);
    free(gezegenler);

    return 0;
}
