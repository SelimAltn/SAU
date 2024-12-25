#ifndef UTILS_H
#define UTILS_H

#include <iostream>
#include <string>
#include "Populasyon.hpp" // Kullanılan sınıf tanımları dahil edilmeli

void AnaListeYazdirma();
int ReadNumber(std::string mesaj, int from, int to, std::string HataMesaj);
void CarpazlamaGercekles(Populasyon& pop, int kromozom1, int kromozom2);
void KullancidanCaprazlama(int KromozomSayisi, Populasyon& pop);
void KullanciMutasyon(int KromozomSayisi, Populasyon& pop);
void OtomatikMutasyon(Populasyon& pop, int kromozomNumarasi, int genNumarasi);
void IslemleriOkuVeUygula(string dosyaAdi, Populasyon& pop);
void EkranaYaz(Populasyon& pop);
void Secim(Populasyon &pop);


#endif
