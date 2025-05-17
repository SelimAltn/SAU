#ifndef KISI_H
#define KISI_H

typedef struct KISI {
    char* isim;
    int   yas;
    int   kalanOmur;
    char* aracAdi;

    void (*yaz)(struct KISI*);
    void (*deleteKisi)(struct KISI*);
} *Kisi;

Kisi newKisi(const char* isim, int yas, int kalanOmur, const char* aracAdi);
void  kisiYazdir(Kisi this);
void  deleteKisi(Kisi this);

#endif // KISI_H