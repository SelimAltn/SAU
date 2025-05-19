/**
 * @author   Selim Altın <selim.altin@ogr.sakarya.edu.tr>
 * @since    15.05.2025
 * <p>
 *   Simulasyon modülünün başlık dosyası:
 *   kişi, uzay aracı ve gezegen dizilerini alarak
 *   simülasyonu oluşturan, başlatan ve sonlandıran
 *   public API prototiplerini tanımlar.
 *   Ayrıca varış tarihi hesaplama yardımcı fonksiyonunu içerir.
 * </p>
 */
#ifndef SIMULASYON_H
#define SIMULASYON_H

#include "kisi.h"
#include "uzay_araci.h"
#include "gezegen.h"

// Opak yapı
typedef struct SIMULASYON* Simulasyon;

// Oluşturucu / Çalıştırıcı / Yıkıcı
Simulasyon     newSimulasyon(Kisi* kisiler, int kisiSayisi,
                             UzayAraci* araclar, int aracSayisi,
                             Gezegen* gezegenler, int gezegenSayisi);
void           baslatSimulasyon(Simulasyon this);
void           deleteSimulasyon(Simulasyon this);
Zaman _hesaplaVarisTarihi(Zaman departure,
                                 int travelHours,
                                 int targetDayLength);

#endif // SIMULASYON_H
