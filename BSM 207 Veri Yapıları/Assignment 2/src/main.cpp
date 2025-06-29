#include <iostream>
#include "Processor.hpp"
#include "TreeNode.hpp"
#include "LinkedList.hpp"


using namespace std;

using namespace std;
int main() {
    // Program başlangıç noktası
    cout<<"--------------------------------------------------\n";
    cout << "Program is starting...\n";
    cout<<"--------------------------------------------------\n";
   Processor processor;
    LinkedList list;

    string fileName = "data.txt";
    processor.ProcessFile(fileName, list); // Dosyadan ağaçları yükle
    processor.RunMenu(list);              // Menü ve kullanıcı arayüzünü çalıştır
    return 0;
}
