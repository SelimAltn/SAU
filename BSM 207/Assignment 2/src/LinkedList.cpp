#include "LinkedList.hpp"
#include "Processor.hpp" // Processor sınıfını dahil et
#include <iostream>
#include <iomanip> // setw için gerekli

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

    Processor processor; // Döngünün dışında bir kez tanımlandı
    ListNode* current = head;
    char command;
    cout << "Navigating the list. Use 'a' to go left, 'd' to go right, 's' to delete, 'w' to mirror, and 'q' to quit." << endl;

    while (true) {
        if (current == nullptr || current->tree == nullptr) {
            cout << "Current node or tree is null!" << endl;
            break;
        }

        cout << "\nCurrently at node: ";
        current->tree->printInOrder(); // Mevcut düğümün ağacını yazdır
        cout << endl;

        cout << "Enter command (a: left, d: right, s: delete, w: mirror, q: quit): ";
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
        } else if (command == 's') {
            ListNode* toDelete = current;
            if (current->next != nullptr) {
                current = current->next;
            } else if (current->prev != nullptr) {
                current = current->prev;
            } else {
                current = nullptr;
            }

            removeCurrentNode(toDelete);

            if (current == nullptr) {
                processor.RewriteFile("data.txt", *this);
                cout << "The list is now empty. Exiting navigation." << endl;
                break;
            }

            processor.RewriteFile("data.txt", *this); // Dosyayı güncelle
        } else if (command == 'w') {
            if (current->tree) {
                current->tree->mirrorTree(); // Ağacı aynala
                cout << "Tree mirrored." << endl;
            }
        } else if (command == 'q') {
            cout << "Exiting navigation." << endl;
            break;
        } else {
            cout << "Invalid command. Please use 'a', 'd', 's', 'w', or 'q'." << endl;
        }
    }
}


void LinkedList::removeCurrentNode(ListNode*& current) {
    if (current == nullptr) return;

    // Düğüm baştaysa
    if (current == head) {
        head = head->next;
        if (head) head->prev = nullptr;
    } else {
        // Aradaki veya sondaki düğüm
        if (current->prev) current->prev->next = current->next;
        if (current->next) current->next->prev = current->prev;
    }

    delete current->tree; // Ağacı sil
    delete current;       // Düğümü sil
    current = nullptr;    // İşaretçiyi sıfırla
    size--;
}
ListNode* LinkedList::getHead() const {
    return head; // head üyesini döndürür
}

ListNode* LinkedList::getNodeAt(int index) {
    ListNode* current = head;
    int count = 0;

    while (current != nullptr) {
        if (count == index) {
            return current;
        }
        current = current->next;
        count++;
    }

    return nullptr; // İndeks geçerli değilse
}
void LinkedList::calculateAndPrintTotals() {
    ListNode* current = head;
    int index = 0;

    while (current != nullptr) {
        int totalValue = current->tree->calculateTotalValue(); // Ağacın toplam değerini hesapla
        cout << "Tree at index " << index << " has a total value of: " << totalValue << endl;
        current = current->next;
        index++;
    }
}

void LinkedList::printAllTrees() {
    ListNode* current = head;
    int index = 0;

    while (current != nullptr) {
        std::cout << "Tree " << index << ":" << std::endl;
        current->tree->printTree(); // Ağacı çizdir
        std::cout << std::endl;
        current = current->next;
        index++;
    }
}

ListNode* LinkedList::getCurrentNode() const{
    return current; // Şu anda seçili olan düğümü döndür


}void LinkedList::printListWithArrows(ListNode* selected, int startIndex, int endIndex) {
    ListNode* current = head;
    

    // 1. Adresleri yazdır
    current = head; // current değişkenini başlat
    int index = 0;  // index değişkenini başlat
    while (current != nullptr && index < startIndex) {
        current = current->next;
        index++;
    }
    for (int i = startIndex; current != nullptr && i < endIndex; i++) {
        cout << setw(12) << current; // Düğüm adreslerini yazdır
        current = current->next;
    }
    cout << endl;

    // 2. Ağacın toplam değerlerini yazdır
    current = head; // current yeniden başlat
    index = 0;      // index yeniden başlat
    while (current != nullptr && index < startIndex) {
        current = current->next;
        index++;
    }
    for (int i = startIndex; current != nullptr && i < endIndex; i++) {
        cout << setw(12) << current->tree->calculateTotalValue(); // Ağacın toplam değerini yazdır
        current = current->next;
    }
    cout << endl;

    // 3. Sonraki düğüm adreslerini yazdır
    current = head; // current yeniden başlat
    index = 0;      // index yeniden başlat
    while (current != nullptr && index < startIndex) {
        current = current->next;
        index++;
    }
    for (int i = startIndex; current != nullptr && i < endIndex; i++) {
        if (current->next) {
            cout << setw(12) << current->next; // Sonraki düğüm adresini yazdır
        } else {
            cout << setw(12) << "NULL"; // Eğer sonraki düğüm yoksa NULL yazdır
        }
        current = current->next;
    }
    cout << endl;

    // 4. Okları yazdır (^^^^^)
    current = head; // current yeniden başlat
    index = 0;      // index yeniden başlat
    while (current != nullptr && index < startIndex) {
        current = current->next;
        index++;
    }
    for (int i = startIndex; current != nullptr && i < endIndex; i++) {
        if (current == selected) {
            cout << setw(12) << "^^^^^"; // Seçili düğüm için okları yaz
        } else {
            cout << setw(12) << " ";    // Diğer düğümler için boşluk bırak
        }
        current = current->next;
    }
    cout << endl;

    // 5. Çizgileri yazdır (||||)
    current = head; // current yeniden başlat
    index = 0;      // index yeniden başlat
    while (current != nullptr && index < startIndex) {
        current = current->next;
        index++;
    }
    for (int i = startIndex; current != nullptr && i < endIndex; i++) {
        if (current == selected) {
            cout << setw(12) << "||||"; // Seçili düğüm için çizgi yaz
        } else {
            cout << setw(12) << " ";    // Diğer düğümler için boşluk bırak
        }
        current = current->next;
    }
    cout << endl;
}


void LinkedList::drawSelectedTree(ListNode* selected) {
    if (selected == nullptr || selected->tree == nullptr) {
        cout << "No tree selected to draw." << endl;
        return;
    }

    selected->tree->printTree(); // Seçili ağacı çiz
}
void LinkedList::removeAndShiftNodes(ListNode*& current, int& startIndex, int& endIndex) {
    if (current == nullptr) {
        cout << "No trees to delete!" << endl;
        return;
    }

    // Düğümü sil
    ListNode* toDelete = current;

    if (current == head) {
        head = head->next;
        if (head != nullptr) {
            head->prev = nullptr;
        }
        current = head;
    } else {
        if (current->prev) {
            current->prev->next = current->next;
        }
        if (current->next) {
            current->next->prev = current->prev;
            current = current->next;
        } else {
            current = current->prev;
        }
    }

    delete toDelete->tree;
    delete toDelete;
    size--;

    // Görünen aralığı güncelle
    if (head == nullptr) {
        cout << "All trees have been deleted!" << endl;
        startIndex = 0;
        endIndex = 0;
    } else if (current == nullptr || size < endIndex) {
        endIndex = size;
        startIndex = max(0, endIndex - 10);
    }
}
