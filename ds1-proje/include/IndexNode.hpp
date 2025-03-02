#ifndef INDEXNODE_HPP
#define INDEXNODE_HPP

#include "Kromozom.hpp" // Eğer Kromozom sınıfı tanımlı değilse, bu dosyayı dahil edin

class IndexNode {
public:
    int index;             // Düğümün indeks değeri
    Kromozom* kromozom;    // Kromozom nesnesine işaretçi
    IndexNode* next;       // Sonraki düğüme işaretçi

    // Constructor
    IndexNode(int i, Kromozom* k);

    // Destructor (isteğe bağlı)
    ~IndexNode();
};

#endif // INDEXNODE_H
