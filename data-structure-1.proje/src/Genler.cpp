/*
*  @file         Genler.cpp
* @description : 
                Constructor: Bir genin değerini alır ve bağlı listenin bir sonraki düğümüne işaretçi atar.
                Destructor Gereksinimi: Eğer başka dinamik nesnelerle ilişkilendirilmiş değilse, destructor gerekmez, çünkü genler kendisi için ayrılmış bellekten sorumlu değildir
* @course      2.C
* @assignment   1.ödev
* @date      20.11.2024
* @author  SELİM ALTIN , g231210558 

*/
#include "../include/Genler.hpp"

Genler::Genler(char val) : value(val), next(nullptr) {}
