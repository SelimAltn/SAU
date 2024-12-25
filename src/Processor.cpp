#include "Processor.hpp"
#include <iostream>
#include <fstream>
using namespace std;

Processor::Processor() {
    // Gerekirse başlangıç işlemleri
}

Processor::~Processor() {
    // Gerekirse bellek temizliği
}

void Processor::ProcessFile(const string& fileName) {
    ifstream file(fileName);
    if (!file.is_open()) {
        cerr << "File could not be opened: " << fileName <<endl;
        return;
    }

    string line;
    int lineNumber = 1;
    while (getline(file, line)) {
        cout << "Processing line " << lineNumber << ": " << line << endl;
        BuildTreeFromLine(line);
        lineNumber++;
    }

    file.close();
}

void Processor::BuildTreeFromLine(const string& line) {
    BinaryTree tree; // Yeni bir ikili arama ağacı oluştur
    for (char character : line) {
        if (character != ' ' && character != '\t') { // Boşlukları atla
            tree.insert(character);
        }
    }
    cout << "Binary tree created from line: " << line << "\n";
}
