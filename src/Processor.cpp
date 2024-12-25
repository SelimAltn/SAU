#include "Processor.hpp"
#include "FileManager.hpp"
#include "LinkedList.hpp"
#include "TreeNode.hpp"
#include <iostream>
#include <fstream>
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