#ifndef TREENODE_H
#define TREENODE_H

class TreeNode {
public:
    char data;              // Düğümde tutulan veri
    TreeNode* left;         // Sol alt düğüm
    TreeNode* right;        // Sağ alt düğüm

    TreeNode(char data);    // Yapıcı metot
};

class BinaryTree {
public:
    BinaryTree();           // Yapıcı metot
    ~BinaryTree();          // Yıkıcı metot
    void insert(char data); // Ağaç içine eleman ekle
    void destroyTree();     // Ağacı temizle

private:
    TreeNode* root;         // Ağacın kökü
    void insert(TreeNode*& node, char data); // Yardımcı metot
    void destroyTree(TreeNode* node);       // Yardımcı metot
};

#endif
