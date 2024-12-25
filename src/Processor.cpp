#include "Processor.hpp"
#include "FileManager.hpp"
#include "LinkedList.hpp"
#include "TreeNode.hpp"
#include <iostream>
#include <fstream>
#include <cstdlib>  // system() için

using namespace std;

Processor::Processor() {
    // Gerekirse başlangıç işlemleri
}

Processor::~Processor() {
    // Gerekirse bellek temizliği
}

void Processor::ProcessFile(const std::string& fileName, LinkedList& list) {
    FileManager fileManager;

    if (!fileManager.openFile(fileName.c_str())) {
        cerr << "Failed to open file: " << fileName << endl;
        return;
    }

    string line;
    while (fileManager.readLine(line)) {
        BuildTreeFromLine(line, list); // Satırdan ağaç oluştur ve listeye ekle
    }

    fileManager.closeFile();
}

void Processor::BuildTreeFromLine(const std::string& line, LinkedList& list) {
    BinaryTree* tree = new BinaryTree();

    for (char ch : line) {
        if (ch != ' ' && ch != '\t') { // Boşluk ve tab karakterlerini atla
            tree->insert(ch);
        }
    }

    // Ağacı listeye ekle
    list.addNode(tree);
    cout << "Tree created and added to list from line: " << line << endl;
}
void Processor::RewriteFile(const std::string& fileName, LinkedList& list) {
    ofstream outFile(fileName);
    if (!outFile.is_open()) {
        cerr << "Failed to open file for writing: " << fileName << endl;
        return;
    }

    ListNode* current = list.getHead(); // head yerine getter kullanıldı
    while (current != nullptr) {
        current->tree->printInOrder(outFile); // Ağacı sıralı yazdır
        outFile << endl; // Satır sonu
        current = current->next;
    }

    outFile.close();
    cout << "File updated successfully." << endl;
}

void clearScreen() {
#ifdef _WIN32
    system("cls"); // Windows için ekran temizleme
#endif
}




void Processor::displayMenu() {
    cout << "--------------------------------------------------" << endl;
    cout << "               Binary Tree Manager                " << endl;
    cout << "--------------------------------------------------" << endl;
    cout << "1. Navigate List (a: left, d: right)" << endl;
    cout << "2. Delete Current Node (s)" << endl;
    cout << "3. Mirror Current Tree (w)" << endl;
    cout << "4. Print All Trees" << endl;
    cout << "5. Exit" << endl;
    cout << "--------------------------------------------------" << endl;
    cout << "Enter your choice: ";

}
void Processor::RunMenu(LinkedList& list) {
    ListNode* selected = list.getHead(); // Bağlı listenin başı
    int startIndex = 0;                 // Başlangıç indeksi
    int endIndex = 10;                  // Görünen liste sınırı
    char command;

    while (true) {
        clearScreen(); // Ekranı temizle

        if (list.getHead() == nullptr) { // Eğer liste tamamen boşsa
            cout << "All trees have been deleted." << endl;
            cout << "Press 'q' to quit." << endl;

            cin >> command;
            if (command == 'q') {
                cout << "Exiting navigation." << endl;
                break;
            } else {
                cout << "Invalid command. Please press 'q' to quit." << endl;
            }
            continue; // Döngüye devam et
        }

        // Bağlı listeyi ve okları yazdır
        list.printListWithArrows(selected, startIndex, endIndex);
        // Seçili düğümdeki ağacı çiz
        list.drawSelectedTree(selected);

        cout << "Enter command (a: left, d: right, s: delete, q: quit): ";
        cin >> command;

        if (command == 'a') { // Geri git
            if (selected != nullptr && selected->prev != nullptr) {
                selected = selected->prev; // Önceki düğüme geç
                if (selected == list.getNodeAt(startIndex - 1)) {
                    startIndex = max(0, startIndex - 10);
                    endIndex = startIndex + 10;
                }
            } else {
                cout << "Already at the first node!" << endl;
            }
        } else if (command == 'd') { // Sonraki düğüme geç
            if (selected != nullptr && selected->next != nullptr) {
                selected = selected->next; // Sonraki düğüme geç
                if (selected == list.getNodeAt(endIndex)) {
                    startIndex += 10;
                    endIndex = min(startIndex + 10, list.getSize());
                }
            } else {
                cout << "Already at the last node!" << endl;
            }
        } else if (command == 's') { // Silme işlemi
            if (selected != nullptr) {
                ListNode* toDelete = selected;

                if (selected->next != nullptr) {
                    selected = selected->next; // Bir sonraki düğüme geç
                } else if (selected->prev != nullptr) {
                    selected = selected->prev; // Bir önceki düğüme geç
                } else {
                    selected = nullptr; // Tüm liste boşsa
                }

                list.removeCurrentNode(toDelete); // Düğümü sil

                // Silme sonrası listeyi güncelle
                if (startIndex >= list.getSize()) {
                    startIndex = max(0, list.getSize() - 10);
                    endIndex = list.getSize();
                } else if (endIndex > list.getSize()) {
                    endIndex = list.getSize();
                }
            } else {
                cout << "No trees to delete!" << endl;
            }
        } else if (command == 'q') { // Çıkış
            cout << "Exiting navigation." << endl;
            break;
        } else {
            cout << "Invalid command. Please try again!" << endl;
        }
    }
}