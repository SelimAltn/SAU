#ifndef KROMOZOM_H
#define KROMOZOM_H

#include "Genler.hpp"
#include <iostream>

using namespace std;

class Kromozom {
public:
    Genler* head;
    Genler* tail;
    bool BuKromozomYeniMi;
    Kromozom* next;
    int genSayisi;

    Kromozom();
    void GenEkle(char value);
    Genler* GenBul(int index);
    void KromozomuEkranaYaz();
    void print();
    ~Kromozom();
};

#endif
