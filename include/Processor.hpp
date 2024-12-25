#ifndef PROCESSOR_H
#define PROCESSOR_H

#include <string>
#include "TreeNode.hpp"
#include "LinkedList.hpp"

using namespace std;

class Processor {
public:
    Processor();                              // Yapıcı
    ~Processor();                             // Yıkıcı
       void ProcessFile(const std::string& fileName, LinkedList& list);// Dosyayı işle ve ağaç oluştur
       void RewriteFile(const std::string& fileName, LinkedList& list); // Dosyayı güncelle


private:
     void BuildTreeFromLine(const std::string& line, LinkedList& list); // Her satırdan ağaç oluştur
};

#endif
