#ifdef _WIN32
  #include <windows.h>
#endif
#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include "zaman.h"
#include "dosya_okuma.h"
#include "simulasyon.h"
#include "uzay_araci.h"
#include <string.h>

// *** testDate fonksiyonu buraya ekleniyor ***
void testDate() {
    Zaman dep = newZaman(1, 5, 2025, 24);
    Zaman arr = _hesaplaVarisTarihi(dep, 300, 24);  // 300 saati 24’e bölsün, artanı tam gün yapsın

    char* s = arr->toString(arr);
    printf("Computed arrival: %s\n", s);            // artık 14.05.2025 çıkacak

    free(s);
    dep->deleteZaman(dep);
    arr->deleteZaman(arr);
}
// *** testDate sonu ***


int main(void) {
    
      // 1) Windows konsolunu UTF-8’e geçir
  #ifdef _WIN32
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
  #endif
      testDate();

    // 2) C kütüphanesinin locale’ini ayarla (printf vb. fonksiyonlar için)
    setlocale(LC_ALL, "");
    int kisiSayisi    = 0;
    int aracSayisi    = 0;
    int gezegenSayisi = 0;
    

    // 1) Dosyalardan oku
    Kisi*      kisiler    = kisileriOku("data/Kisiler.txt",   &kisiSayisi);
    if (!kisiler) {
        fprintf(stderr, "Hata: Kisiler.txt okunamadi!\n");
        return EXIT_FAILURE;
    }

    UzayAraci* araclar    = araclariOku("data/Araclar.txt",    &aracSayisi);
    if (!araclar) {
        fprintf(stderr, "Hata: Araclar.txt okunamadi!\n");
        // kisileri temizle
        for (int i = 0; i < kisiSayisi; ++i) deleteKisi(kisiler[i]);
        free(kisiler);
        return EXIT_FAILURE;
    }

    Gezegen*   gezegenler = gezegenleriOku("data/Gezegenler.txt",&gezegenSayisi);
    if (!gezegenler) {
        fprintf(stderr, "Hata: Gezegenler.txt okunamadi!\n");
        // kisileri temizle
        for (int i = 0; i < kisiSayisi; ++i) deleteKisi(kisiler[i]);
        free(kisiler);
        // araçları temizle
        for (int i = 0; i < aracSayisi; ++i) deleteUzayAraci(araclar[i]);
        free(araclar);
        return EXIT_FAILURE;
    }
    
    // 1.5) Her kişi için ilgili araca yolcu ekle
    for (int i = 0; i < kisiSayisi; ++i) {
        for (int j = 0; j < aracSayisi; ++j) {
            // kisiler[i]->aracAdi ile araclar[j]->isim eşleşiyorsa
            if (strcmp(kisiler[i]->aracAdi, araclar[j]->isim) == 0) {
                uzayAraciAddPassenger(araclar[j], kisiler[i]);
                break;
            }
        }
    }

    // 2) Simülasyonu oluştur ve çalıştır
    Simulasyon sim = newSimulasyon(
        kisiler,      kisiSayisi,
        araclar,      aracSayisi,
        gezegenler,   gezegenSayisi
    );
    baslatSimulasyon(sim);
    

    // 3) Belleği komple temizle
    deleteSimulasyon(sim);

    return EXIT_SUCCESS;
}
