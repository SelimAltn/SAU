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

    // Dosyayı işle ve ağaçları oluştur
    string fileName = "data.txt";
    processor.ProcessFile(fileName, list);

    // Ağaçları çiz
    cout << "Drawing all trees:" << endl;
    list.printAllTrees();
    return 0;
}
