#ifndef PROCESSOR_H
#define PROCESSOR_H

#include <string>
#include "TreeNode.hpp"
using namespace std;

class Processor {
public:
    Processor();                              // Yapıcı
    ~Processor();                             // Yıkıcı
    void ProcessFile(const string& fileName); // Dosyayı işle ve ağaç oluştur

private:
    void BuildTreeFromLine(const string& line); // Her satırdan ağaç oluştur
};

#endif
