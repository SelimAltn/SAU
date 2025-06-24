#ifndef FILEMANAGER_H
#define FILEMANAGER_H


#include <fstream> // Dosya işlemleri
#include <string>  // Satır tutmak için
using namespace std;


class FileManager {
public:
    bool openFile(const char* fileName);  // Dosyayı aç
    bool readLine(string& line);    // Bir satır oku
    void closeFile();                    // Dosyayı kapat

    void ReadLinesAndBuildTree(const std::string& dosyaAdi);

private:
    ifstream file; // Dosya okuma akışı
};

#endif
