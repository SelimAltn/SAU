#ifndef LINKEDLIST_H
#define LINKEDLIST_H

#include "TreeNode.hpp" // Ağaç yapısını kullanacağız

struct ListNode {
    BinaryTree* tree; // Her düğüm bir ağacı temsil eder
    ListNode* next;   // Sonraki düğüm
    ListNode* prev;   // Çift yönlü gezinme için ekledik

    ListNode(BinaryTree* t) : tree(t), next(nullptr), prev(nullptr) {}
};

class LinkedList {
public:
    LinkedList();                      // Yapıcı
    ~LinkedList();                     // Yıkıcı
    void addNode(BinaryTree* tree);    // Düğüm ekleme
    void removeNode(int index);        // Belirli bir indeksteki düğümü silme
    void printList();                  // Listeyi yazdırma
    void navigateList();               // Kullanıcı ile liste gezintisi
    void removeCurrentNode(ListNode*& current); // Mevcut düğümü ve ağacını sil
    ListNode* getHead() const;         // head üyesine erişim sağlamak için bir getter
    void calculateAndPrintTotals();    // Her ağacın toplam değerini hesapla ve yazdır
    void printAllTrees();              // Tüm ağaçları yazdır
    ListNode* getCurrentNode() const;  // Şu anda seçili olan düğümü getir
    void printListWithArrows(ListNode* selected, int startIndex, int endIndex);
    void drawSelectedTree(ListNode* selected);
    ListNode* getNodeAt(int index);
void removeAndShiftNodes(ListNode*& current, int& startIndex, int& endIndex);
    int getSize() const { return size; } // Listenin boyutunu döndürür

private:
    ListNode* head;    // Listenin başlangıç düğümü
    ListNode* tail;    // Listenin son düğümü
    ListNode* current; // Şu anda seçili olan düğüm
    int size;          // Listedeki düğüm sayısı
};

#endif
