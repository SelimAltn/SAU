#include <iostream>
#include "Processor.hpp"
using namespace std;

using namespace std;
int main() {
    // Program başlangıç noktası
    cout<<"--------------------------------------------------\n";
    cout << "Program is starting...\n";
    cout<<"--------------------------------------------------\n";

    Processor processor;                  // İşlem sınıfı nesnesi
    string fileName = "data.txt";    // İşlenecek dosyanın adı
    processor.ProcessFile(fileName);     // Dosyayı işle
    return 0;
}
    