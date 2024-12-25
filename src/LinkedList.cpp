#include "LinkedList.hpp"
#include <iostream>

using namespace std;

LinkedList::LinkedList() : head(nullptr), size(0) {}

LinkedList::~LinkedList() {
    ListNode* current = head;
    while (current != nullptr) {
        ListNode* toDelete = current;
        current = current->next;
        delete toDelete->tree; // Ağacı temizle
        delete toDelete;       // Düğümü temizle
    }
}

void LinkedList::addNode(BinaryTree* tree) {
    ListNode* newNode = new ListNode(tree);
    if (head == nullptr) {
        head = newNode; // Liste boşsa, yeni düğüm baş olur
    } else {
        ListNode* temp = head;
        while (temp->next != nullptr) {
            temp = temp->next;
        }
        temp->next = newNode; // Liste sonunda yeni düğüm eklenir
    }
    size++;
}

void LinkedList::removeNode(int index) {
    if (index < 0 || index >= size) {
        cout << "Invalid index!" << endl;
        return;
    }

    ListNode* current = head;
    if (index == 0) {
        head = current->next; // İlk düğüm siliniyor
    } else {
        ListNode* prev = nullptr;
        for (int i = 0; i < index; i++) {
            prev = current;
            current = current->next;
        }
        prev->next = current->next; // Düğüm atlanarak silinir
    }

    delete current->tree; // Ağacı temizle
    delete current;       // Düğümü temizle
    size--;
}

void LinkedList::printList() {
    ListNode* current = head;
    int index = 0;
    while (current != nullptr) {
        cout << "Tree at index " << index++ << ":" << endl;
        current->tree->printInOrder(); // Ağacı yazdır
        current = current->next;
    }
}
