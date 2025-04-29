#ifndef ZAMAN_H
#define ZAMAN_H

typedef struct {
    int gun;        // 1–31
    int ay;         // 1–12
    int yil;
    int saatSayisi; // o gezegende bir günün kaç saat olduğu
} Zaman;

// Zaman objesini başlatır
void zamanInit(Zaman* z, int gun, int ay, int yil, int saatSayisi);

// Zamanı bir saat ilerletir (takvimsel geçişler dahil)
void zamanIlerle(Zaman* z);

// Zamanı "gg.aa.yyyy" formatında stringe çevirir
// Dönen char* belleği çağıran fonksiyon free() ile temizlemeli
char* zamanToString(const Zaman* z);

#endif // ZAMAN_H
