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
        newNode->prev = temp; // Çift yönlü bağlantı

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
void LinkedList::navigateList() {
    if (head == nullptr) {
        cout << "The list is empty. Nothing to navigate!" << endl;
        return;
    }

    ListNode* current = head;
    char command;
    cout << "Navigating the list. Use 'a' to go left, 'd' to go right, and 'q' to quit." << endl;

    while (true) {
        cout << "\nCurrently at node: ";
        current->tree->printInOrder(); // Mevcut düğümün ağacını yazdır
        cout << endl;

        cout << "Enter command (a: left, d: right, q: quit): ";
        cin >> command;

        if (command == 'a') {
            if (current->prev != nullptr) {
                current = current->prev;
            } else {
                cout << "Already at the first node. Can't go left!" << endl;
            }
        } else if (command == 'd') {
            if (current->next != nullptr) {
                current = current->next;
            } else {
                cout << "Already at the last node. Can't go right!" << endl;
            }
        } else if (command == 'q') {
            cout << "Exiting navigation." << endl;
            break;
        } else {
            cout << "Invalid command. Please use 'a', 'd', or 'q'." << endl;
        }
    }
}