/*
*  @file         populasyon.cpp
* @description :
                Kromozom Ekleme: Yeni bir kromozomu popülasyona ekler ve indeksleme için ayrı bir bağlı liste kullanır.
                Dosyadan Okuma: Verilen dosyadan kromozomları okuyup popülasyona ekler.
                Kromozom Bulma: İndeks numarasına göre hızlıca bir kromozomu bulur. 
                Dosyaya Yazma: Yeni oluşturulan kromozomları dosyaya ekler.
                Bellek Yönetimi: Destructor, dinamik bellek kullanımını temizler (kromozom ve indeks düğümleri).
                Ekran Çıktısı: Tüm popülasyonu ve kromozomları yazdırır.
* @course      2.C
* @assignment   1.ödev
* @date      21.11.2024
* @author  SELİM ALTIN , g231210558 

*/

#include <iostream>
#include <fstream>

#include "../include/Populasyon.hpp"
#include "../include/IndexNode.hpp"
#include "../include/Kromozom.hpp"



using namespace std;


Populasyon::Populasyon()
    : head(nullptr), tail(nullptr), sayisi(0), indexHead(nullptr), indexTail(nullptr) {}

void Populasyon::KromozomEkle(Kromozom* yeniKromozom) {
    if (head == nullptr) {
        head = tail = yeniKromozom;
    } else {
        tail->next = yeniKromozom;
        tail = yeniKromozom;
    }
    yeniKromozom->next = nullptr;
    sayisi++;

    // İndeksleme listesine hızlı ekleme
    IndexNode* newIndex = new IndexNode(sayisi - 1, yeniKromozom);
    if (indexHead == nullptr) {
        indexHead = indexTail = newIndex;
    } else {
        indexTail->next = newIndex;
        indexTail = newIndex;
    }
}

void Populasyon::dosyadanOkuma(const string& dosyaAdi) {
    fstream dosya(dosyaAdi, ios::in);
    if (dosya.is_open()) {
        string satir;
        while (getline(dosya, satir)) {
            Kromozom* yeniKromozom = new Kromozom();
            for (char harf : satir) {
                if (harf != ' ') {
                    yeniKromozom->GenEkle(harf);
                }
            }
            KromozomEkle(yeniKromozom);
        }
        dosya.close();
    } else {
        cerr << "Dosya acilamadi: " << dosyaAdi << endl;
    }
}

Kromozom* Populasyon::kromozomBul(int index) {
    IndexNode* temp = indexHead;
    while (temp) {
        if (temp->index == index) {
            return temp->kromozom;
        }
        temp = temp->next;
    }
    cout << "Gecersiz kromozom numarasi!" << endl;
    return nullptr;
}

void Populasyon::DosyayaYeniKromozomlarYaz(const string& dosyaAdi) {
    ofstream dosya(dosyaAdi, ios::app);
    if (dosya.is_open()) {
        Kromozom* temp = head;
        while (temp != nullptr) {
            if (temp->BuKromozomYeniMi) {
                Genler* gen = temp->head;
                while (gen != nullptr) {
                    dosya << gen->value << " ";
                    gen = gen->next;
                }
                dosya << endl;
                temp->BuKromozomYeniMi = false;
            }
            temp = temp->next;
        }
        dosya.close();
    } else {
        cerr << "Dosya acilamadi: " << dosyaAdi << endl;
    }
}

void Populasyon::printAll()  {
    cout << "\nPopulasyon (" << sayisi << " Kromozom):\n";
    cout << "-----------------------------------------------\n";
    int index = 0;
    Kromozom* temp = head;
    while (temp) {
        cout << "Kromozom " << index++ << ": ";
        temp->print();
        temp = temp->next;
    }
    cout << "-----------------------------------------------\n";
}

Populasyon::~Populasyon() {
    Kromozom* current = head;
    while (current) {
        Kromozom* toDelete = current;
        current = current->next;
        delete toDelete;
    }
    IndexNode* indexCurrent = indexHead;
    while (indexCurrent) {
        IndexNode* indexToDelete = indexCurrent;
        indexCurrent = indexCurrent->next;
        delete indexToDelete;
    }
}
