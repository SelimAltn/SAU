#ifdef _WIN32
  #include <windows.h>
#endif
#include <stdio.h>
#include <stdlib.h>
#include <locale.h>
#include "zaman.h"
#include "dosya_okuma.h"
#include "simulasyon.h"


int main(void) {
    
      // 1) Windows konsolunu UTF-8’e geçir
  #ifdef _WIN32
    SetConsoleOutputCP(CP_UTF8);
    SetConsoleCP(CP_UTF8);
  #endif

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
