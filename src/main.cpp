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

    string fileName = "data.txt";
    processor.ProcessFile(fileName, list);

    list.navigateList(); // Listeyi gezin ve işlemleri uygula
    return 0;
}
