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
    LinkedList list;
    Processor processor;

    // TXT dosyasından ağaç oluştur ve listeye ekle
    string fileName = "data.txt";
    processor.ProcessFile(fileName, list);

    // Listeyi gezmek için
    list.navigateList();
    return 0;
}
