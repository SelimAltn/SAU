#ifndef POPULASYON_H
#define POPULASYON_H

#include "Kromozom.hpp"
#include"IndexNode.hpp"
#include <fstream>
#include <string>

class Populasyon {
public:
    Kromozom* head;
    Kromozom* tail;
    IndexNode* indexHead; // İndeksleme için bağlı liste başı
    IndexNode* indexTail;
    
    int sayisi;

    Populasyon();
    void KromozomEkle(Kromozom* Yenikromozom);
    void dosyadanOkuma(const string& dosyaAdi);
    Kromozom* kromozomBul(int index);
    void DosyayaYeniKromozomlarYaz(const string& dosyaAdi);
    void printAll();
    ~Populasyon();
};

#endif
