#ifndef TREENODE_H
#define TREENODE_H

#include <iostream>
#include <vector> // İstersek sonuçları bir vektöre koyabiliriz

struct TreeNode {
    char data;              // Düğümde tutulan veri
    TreeNode* left;         // Sol alt düğüm
    TreeNode* right;        // Sağ alt düğüm

    TreeNode(char d) : data(d), left(nullptr), right(nullptr) {}
};

class BinaryTree {
public:
    BinaryTree();           // Yapıcı
    ~BinaryTree();          // Yıkıcı
    void insert(char data); // Eleman ekle
    void printInOrder();    // Ağacı sıralı yazdır

private:
    TreeNode* root;         // Ağacın kökü
    void insert(TreeNode*& node, char data); // Yardımcı insert fonksiyonu
    void printInOrder(TreeNode* node);       // In-order traversal için yardımcı fonksiyon
    void destroyTree(TreeNode* node);        // Ağacı bellekten temizle
};

#endif
