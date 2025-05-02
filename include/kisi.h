#ifndef KISI_H
#define KISI_H

struct KISI;
typedef struct KISI* Kisi;

// Constructor & Destructor
Kisi   newKisi(const char* isim, int yas, int kalanOmur, const char* aracAdi);
void   deleteKisi(Kisi this);

// Metot pointer’ları
void   yazKisi(Kisi this);

#endif // KISI_H
