/*
*  @file         utils.cpp
* @description   :
                Menü ve Giriş Kontrolü: AnaListeYazdirma: Kullanıcıya menü gösterir.
                ReadNumber: Girdi aralığını kontrol eder ve hatalı girişleri temizler.
                 İşlevler:
                Çaprazlama (CarpazlamaGercekles):İki kromozomun genlerini yarıdan böler, yeni iki kromozom oluşturur ve popülasyona ekler.
                Mutasyon (KullanciMutasyon ve OtomatikMutasyon):Belirli bir kromozom ve gen seçilir; seçilen gen 'X' olarak değiştirilir.
                Otomatik İşlemler (IslemleriOkuVeUygula): Bir dosyadan komutları okuyarak çaprazlama veya mutasyon işlemlerini gerçekleştirir.
                Sonuç Yazdırma (EkranaYaz):Tüm kromozomların ilk genlerini veya en küçük genlerini ekrana yazdırır.
                Bellek Yönetimi: İşlemler tamamlandığında bellek doğru şekilde temizlenir.
                Kullanıcı Etkileşimi:Kullanıcı menüden işlem seçer ve seçilen işlem adım adım gerçekleştirilir.
* @course      2.C
* @assignment   1.ödev
* @date      22.11.2024
* @author  SELİM ALTIN , g231210558 

*/

#include "utils.hpp"
#include <limits>
#include <sstream>
#include <chrono>
using namespace chrono;
const string HizliIslemler = "doc/HizliIslemler.txt";


void AnaListeYazdirma() {
    cout << "----------------------------------------------------------" << endl;
    cout << "                  Programin Menusu : \n";
    cout << "----------------------------------------------------------" << endl;
    cout << "1. Caprazlama islemi yap. \n";
    cout << "2. Mutasyon islemi yap. \n";
    cout << "3. Otomatik Islemleri yap. \n";
    cout << "4. Ekrana Yazma isemi yap. \n";
    cout << "5.Tum kromozmoleri yazdir : \n";
    cout << "6. Cikis. \n";
    cout << "----------------------------------------------------------" << endl;
}

int ReadNumber(string mesaj, int from, int to, string HataMesaj) {
    int temp;
    cout << mesaj << endl;
    do {
        cout << "> ";
        cin >> temp;
        if (cin.fail()) {
            cin.clear(); // Hata durumunu sıfırla
            cin.ignore(numeric_limits<streamsize>::max(), '\n'); // Hatalı girişi temizle
            cout << "Gecersiz giris. Lutfen bir sayi giriniz." << endl;
        }
        else if (temp<from || temp>to)
            cout << HataMesaj << endl;
    } while (temp<from || temp>to || cin.fail());

    return temp;

}

void CarpazlamaGercekles(Populasyon& pop, int kromozom1, int kromozom2) {
    Kromozom* BirinciKromozom = pop.kromozomBul(kromozom1);
    Kromozom* IkinciKromozom = pop.kromozomBul(kromozom2);

    if (!BirinciKromozom || !IkinciKromozom) {
        return;
    }

    // Uzunlukları hesaplama
    int uzunluk1 = 0, uzunluk2 = 0;
    Genler* temp = BirinciKromozom->head;
    while (temp != NULL) {
        uzunluk1++;
        temp = temp->next;
    }
    temp = IkinciKromozom->head;
    while (temp != NULL) {
        uzunluk2++;
        temp = temp->next;
    }

    // Orta noktaları hesaplama
    int Orta1 = uzunluk1 / 2;
    int Orta2 = uzunluk2 / 2;

    // Kromozom 1 için sol ve sağ parçaları ayırma
    Genler* Sol1 = BirinciKromozom->head;
    Genler* Sag1 = NULL, * Onceki1 = nullptr;
    for (int i = 0; i < Orta1; i++) {
        Onceki1 = Sol1;
        Sol1 = Sol1->next;
    }
    Sag1 = Sol1;

    // Kromozom 2 için sol ve sağ parçaları ayırma
    Genler* Sol2 = IkinciKromozom->head;
    Genler* Sag2 = NULL, * Onceki2 = nullptr;
    for (int i = 0; i < Orta2; i++) {
        Onceki2 = Sol2;
        Sol2 = Sol2->next;
    }
    Sag2 = Sol2;

    // Yeni kromozomlar oluşturma
    Kromozom* yeniKromozom1 = new Kromozom(); // Kromozom 1 sol + Kromozom 2 sağ
    Kromozom* yeniKromozom2 = new Kromozom(); // Kromozom 2 sol + Kromozom 1 sağ

    // Yeni kromozom 1: 1. kromozom sol + 2. kromozom sağ
    temp = BirinciKromozom->head;
    for (int i = 0; i < Orta1; i++) {
        yeniKromozom1->GenEkle(temp->value);
        temp = temp->next;
    }
    temp = Sag2;
    while (temp != NULL) {
        yeniKromozom1->GenEkle(temp->value);
        temp = temp->next;
    }

    // Yeni kromozom 2: 2. kromozom sol + 1. kromozom sağ
    temp = IkinciKromozom->head;
    for (int i = 0; i < Orta2; i++) {
        yeniKromozom2->GenEkle(temp->value);
        temp = temp->next;
    }
    temp = Sag1;
    while (temp != NULL) {
        yeniKromozom2->GenEkle(temp->value);
        temp = temp->next;
    }

    // Yeni kromozomları popülasyona ekleme
    yeniKromozom1->BuKromozomYeniMi = true;
    yeniKromozom2->BuKromozomYeniMi = true;
    pop.KromozomEkle(yeniKromozom1);
    pop.KromozomEkle(yeniKromozom2);
}


void KullancidanCaprazlama(int KromozomSayisi, Populasyon& pop) {
    cout << "Hangi kromozomlari birlestirmek istiyorsunuz ? \n";
    int kromozom1 = 0, kromozom2 = 0;
    do {
        kromozom1 = ReadNumber("1. Kromozomu giriniz : ", 0, KromozomSayisi - 1, "Girdiginiz numara bir kromozoma ait degil.!");
        kromozom2 = ReadNumber("2. Kromozomu giriniz : ", 0, KromozomSayisi - 1, "Girdiginiz numara bir kromozoma ait degil.!");
        if (kromozom1 == kromozom2)
            cout << "Ayni kromozom Caprazlama islemi yapilmaz...Tekrar Giriniz.\n";
    } while (kromozom1 == kromozom2);

    CarpazlamaGercekles(pop, kromozom1, kromozom2);

    cout << "Caprazlama islemi başariyla tamamlandi! Yeni kromozomlar populasyona eklendi.\n";
}

void KullanciMutasyon(int KromozomSayisi, Populasyon& pop) {
    cout << "Mutasyon islemi ile hosgeldiniz \n";
    int KromozmNumarasi = ReadNumber("Hangi kromozomu Mutasyon islemi yapmak istiyorsunuz ?", 0, pop.sayisi - 1, "Girdiginiz numara bir kromozoma ait degil.!");
    Kromozom* SecilenKromozom = pop.kromozomBul(KromozmNumarasi);
    if (!SecilenKromozom) {
        cout << "Yalnis kromozom numasrasi secildi !" << endl;
        return;

    }
    int GenNumarasi = ReadNumber("Hangi geni degistirmek istiyorsunuz ?", 0, SecilenKromozom->genSayisi - 1, "Girdiginiz numara bir Gene ait degil.!");
    Genler* SecilenGen = SecilenKromozom->GenBul(GenNumarasi);
    if (!SecilenGen) {
        cout << "Yalnıs Gen numasrasi secildi !" << endl;
        return;

    }
    cout << "-------------------------------------------------\n";
    cout << "Seçtiniz Gen : " << SecilenGen->value << endl;
    cout << "----------------Mutasyon islemi gerceklesiyor-------------" << endl;
    cout << "Mutasyon Oncesinde  kromozom : <";
    SecilenKromozom->KromozomuEkranaYaz();
    SecilenGen->value = 'X';
    cout << "Mutasyon sonrasinda kromozom : <";
    SecilenKromozom->KromozomuEkranaYaz();

}

void OtomatikMutasyon(Populasyon& pop, int kromozomNumarasi, int genNumarasi) {
    Kromozom* SecilenKromozom = pop.kromozomBul(kromozomNumarasi);
    if (!SecilenKromozom) {
        return;
    }
    Genler* SecilenGen = SecilenKromozom->GenBul(genNumarasi);
    if (!SecilenGen) {
        return;
    }
    SecilenGen->value = 'X';
}
void IslemleriOkuVeUygula(string dosyaAdi, Populasyon& pop) {
    ifstream dosya(dosyaAdi);
    if (!dosya.is_open()) {
        cerr << "Dosya açılamadı: " << dosyaAdi << std::endl;
        return;
    }

    string satir;
    while (getline(dosya, satir)) {
        // Satırı işlem komutlarına göre ayırma
        char islemTuru;
        int param1, param2;
        istringstream iss(satir);
        if (iss >> islemTuru >> param1 >> param2) {
            if (islemTuru == 'C') {
                CarpazlamaGercekles(pop, param1, param2);
            }
            else if (islemTuru == 'M') {
                OtomatikMutasyon(pop, param1, param2);
            }
        }
        else {
           cerr << "Geçersiz satır: " << satir << endl;
        }
    }

    dosya.close();
    cout << "Islem tamamlandi." << endl;
}
void EkranaYaz(Populasyon& pop) {
    if (pop.sayisi == 0) {
        cout << "Populasyonda kromozom yok." << endl;
        return;
    }

    cout << "Ekran yaz sonucunda: ";

    // Tüm kromozomları sırayla işle
    Kromozom* currentKromozom = pop.head;
    while (currentKromozom) {
        char ilkGen = currentKromozom->head->value; // İlk gen
        char sonuc = ilkGen; // Varsayılan olarak ilk gen yazılacak
        Genler* currentGen = currentKromozom->head;
        Genler* prevGen = nullptr;

        // Listenin sonuna ulaş
        while (currentGen && currentGen->next) {
            prevGen = currentGen;
            currentGen = currentGen->next;
        }

        // Sağdan sola git
        while (currentGen) {
            if (currentGen->value < ilkGen) {
                sonuc = currentGen->value; // Daha küçük bir gen bulundu
                break;
            }
            currentGen = prevGen;
            if (prevGen) { // Bir önceki düğümü bul
                Genler* temp = currentKromozom->head;
                while (temp && temp->next != prevGen) {
                    temp = temp->next;
                }
                prevGen = temp;
            }
        }

        cout << sonuc << " "; // Sonucu yazdır
        currentKromozom = currentKromozom->next; // Sonraki kromozoma geç
    }

    cout << endl;
}
void Secim(Populasyon &pop) {
    AnaListeYazdirma();
    short secim = 0; 
    while (1) {
        secim = ReadNumber("Yapmak istediniz islem numarasi giriniz.", 1, 6, "1-6 arasindaki sayilari girebillirsiniz.");
        switch (secim)
        {
        case 1:
            system("cls");//cmd silen emir
            AnaListeYazdirma();
            KullancidanCaprazlama(pop.sayisi, pop);
            break;
        case 2:
            system("cls");//cmd silen emir
            AnaListeYazdirma();
            KullanciMutasyon(pop.sayisi, pop);
            break;
        case 3:
            system("cls");//cmd silen emir
            AnaListeYazdirma();
            IslemleriOkuVeUygula(HizliIslemler,pop);
            
            break;
        case 4:
            system("cls");//cmd silen emir
            AnaListeYazdirma();
            EkranaYaz(pop);
            break;
        case 5:
         system("cls");//cmd silen emir
            AnaListeYazdirma();
            pop.printAll();
            break;
        case 6:
            return;

        }
    }
  

}
