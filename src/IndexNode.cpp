/*
*  @file         IndexNode.cpp
* @description   :
                    Constructor: Bir indeks değeri ve bir kromozom işaretçisi atanır.
                    Destructor: Eğer kromozom nesnesi dinamik olarak oluşturulmuşsa bellekteki alan temizlenir.
* @course      2.C
* @assignment   1.ödev
* @date      20.11.2024
* @author  SELİM ALTIN , g231210558 

*/

#include "../include/IndexNode.hpp"

// Constructor: Index ve Kromozom işaretçisi atanır.
IndexNode::IndexNode(int i, Kromozom* k) 
    : index(i), kromozom(k), next(nullptr) {}

// Destructor: Kromozom nesnesinin bellekten silinmesini sağlar (isteğe bağlı).
IndexNode::~IndexNode() {
    delete kromozom; // Eğer kromozom dinamik olarak oluşturulmuşsa
}
