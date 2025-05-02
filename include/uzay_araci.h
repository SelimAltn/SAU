#ifndef UZAY_ARACI_H
#define UZAY_ARACI_H

#include "zaman.h"

struct UZAYARACI;
typedef struct UZAYARACI* UzayAraci;

// Constructor & Destructor
UzayAraci newUzayAraci(const char* isim,
                       const char* cikisGezegen,
                       const char* varisGezegen,
                       Zaman cikisTarihi,
                       int mesafeSaat);
void      deleteUzayAraci(UzayAraci this);

// Metot pointer’ları
void      yazUzayAraci(UzayAraci this);

#endif // UZAY_ARACI_H
