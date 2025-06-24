/*
*  @file         main.cpp
* @description   programın başlicağı yerdir ve burda dosyayı okunyor ve listeye ekleniyor dosya okumada ne kadar sürdüğünu hesaplar sonra secim menusu çağarak kullancıdan işlem alınır.
* @course      2.C
* @assignment   1.ödev
* @date      20.11.2024
* @author  SELİM ALTIN , g231210558 

*/
#include <iostream>
#include <chrono>
#include "../include/Populasyon.hpp"
#include "../include/utils.hpp"
#include <locale> 
using namespace chrono;
using namespace std ;
const string KromozomDosyasi1 = "doc/Kromozom.txt";
const string KromozomDosyasi2 = "doc/large_chromosome_data.txt";
const string HizliIslemler = "doc/HizliIslemler.txt";

int main()
{
    // Türkçe karakterler için locale ayarı
    setlocale(LC_ALL, "Turkish");
    
  

    Populasyon pop; // Popülasyonu oluştur
    auto baslangic2 = high_resolution_clock::now();
    pop.dosyadanOkuma(KromozomDosyasi2); // Dosyadan verileri oku
    auto bitis2 = high_resolution_clock::now();
    auto sure2 = duration_cast<milliseconds>(bitis2 - baslangic2).count();
    cout << "\n-------------------------------\n";
    cout << "Dosyadan veri okuma ve listeye ekleme suresi: " << sure2 << " ms" << endl;
    

    Secim(pop);

}