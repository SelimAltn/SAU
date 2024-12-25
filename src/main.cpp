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

    // İlk ağaç
    BinaryTree* tree1 = new BinaryTree();
    tree1->insert('C');
    tree1->insert('A');
    tree1->insert('B');
    list.addNode(tree1);

    // İkinci ağaç
    BinaryTree* tree2 = new BinaryTree();
    tree2->insert('D');
    tree2->insert('E');
    tree2->insert('F');
    list.addNode(tree2);

    // Listeyi yazdır
    cout << "Initial list:" << endl;
    list.printList();

    // Bir düğümü sil
    list.removeNode(0);

    // Listeyi tekrar yazdır
    cout << "After removing the first node:" << endl;
    list.printList();

    
    return 0;
}
