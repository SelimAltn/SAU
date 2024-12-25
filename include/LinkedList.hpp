#ifndef LINKEDLIST_H
#define LINKEDLIST_H

#include "TreeNode.hpp" // Ağaç yapısını kullanacağız

struct ListNode {
    BinaryTree* tree; // Her düğüm bir ağacı temsil eder
    ListNode* next;   // Sonraki düğüm
    ListNode* prev; // Çift yönlü gezinme için ekledik


    ListNode(BinaryTree* t) : tree(t), next(nullptr), prev(nullptr) {}
};

class LinkedList {
public:
    LinkedList();                      // Yapıcı
    ~LinkedList();                     // Yıkıcı
    void addNode(BinaryTree* tree);    // Düğüm ekleme
    void removeNode(int index);        // Belirli bir indeksteki düğümü silme
    void printList();                  // Listeyi yazdırma
    void navigateList(); // Kullanıcı ile liste gezintisi

private:
    ListNode* head; // Listenin başlangıç düğümü
    int size;       // Listedeki düğüm sayısı
};

#endif
