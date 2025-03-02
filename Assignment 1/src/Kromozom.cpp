/*
*  @file         Kromozom.cpp
* @description  :

                    1. Kromozom Oluşturma ve Gen Ekleme:
                       - GenEkle: Yeni gen oluşturur ve bağlı listeye ekler. Liste boşsa başlangıç ve son düğüm olarak ayarlar.

                    2. Gen Bulma:
                       - GenBul: Verilen indeks numarasına göre bir geni bulur, yoksa hata mesajı döndürür.

                    3. Yazdırma:
                       - KromozomuEkranaYaz ve print: Tüm genleri sırayla ekrana yazdırır.

                    4. Bellek Yönetimi:
                       - Destructor (~Kromozom): Dinamik olarak oluşturulmuş gen düğümlerini temizler.
* @course      2.C
* @assignment   1.ödev
* @date      20.11.2024
* @author  SELİM ALTIN , g231210558 

*/


#include "../include/Kromozom.hpp"
#include "../include/Genler.hpp"

Kromozom::Kromozom() : BuKromozomYeniMi(false), head(nullptr), tail(nullptr), genSayisi(0) {}

void Kromozom::GenEkle(char value) {
    Genler* YeniGen = new Genler(value);
    if (head == nullptr) {
        head = tail = YeniGen;
    } else {
        tail->next = YeniGen;
        tail = YeniGen;
    }
    genSayisi++;
}

Genler* Kromozom::GenBul(int index) {
    Genler* temp = head;
    int currentIndex = 0;
    while (temp != nullptr) {
        if (currentIndex == index) return temp;
        currentIndex++;
        temp = temp->next;
    }
    cout << "Geçersiz gen indeksi: " << index << endl;
    return nullptr;
}

void Kromozom::KromozomuEkranaYaz() {
    Genler* temp = head;
    while (temp != nullptr) {
        cout << temp->value << " ";
        temp = temp->next;
    }
    cout << endl;
}

void Kromozom::print() {
    Genler* temp = head;
    while (temp != nullptr) {
        cout << temp->value << " ";
        temp = temp->next;
    }
    cout << endl;
}

Kromozom::~Kromozom() {
    Genler* current = head;
    while (current != nullptr) {
        Genler* toDelete = current;
        current = current->next;
        delete toDelete;
    }
    head = tail = nullptr;
}
