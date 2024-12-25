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
    void printInOrder(std::ostream& out = std::cout); // Varsayılan std::cout
    void mirrorTree(); // Ağaç düğümlerini aynala
    void destroyTree();



private:
    TreeNode* root;         // Ağacın kökü
    void insert(TreeNode*& node, char data); // Yardımcı insert fonksiyonu
    void destroyTree(TreeNode* node);        // Ağacı bellekten temizle
    void mirrorTree(TreeNode*& node); // Yardımcı aynalama fonksiyonu
    void printInOrder(TreeNode* node, std::ostream& out); // Varsayılan std::cout



};

#endif
