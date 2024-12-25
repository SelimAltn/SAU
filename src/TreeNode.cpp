#include "TreeNode.hpp"
#include <iostream>

using namespace std;

BinaryTree::BinaryTree() : root(nullptr) {}

BinaryTree::~BinaryTree() {
    destroyTree(root);
}

void BinaryTree::insert(char data) {
    insert(root, data);
}

void BinaryTree::insert(TreeNode*& node, char data) {
    if (node == nullptr) {
        node = new TreeNode(data);
    } else if (data < node->data) {
        insert(node->left, data);
    } else if (data > node->data) {
        insert(node->right, data);
    }
}

void BinaryTree::printInOrder() {
    printInOrder(root);
    cout << endl; // Her ağacı yeni satırda bitir
}

void BinaryTree::printInOrder(TreeNode* node) {
    if (node != nullptr) {
        printInOrder(node->left);           // Sol alt düğümü gez
        cout << node->data << " ";          // Kök düğümü yazdır
        printInOrder(node->right);          // Sağ alt düğümü gez
    }
}

void BinaryTree::destroyTree(TreeNode* node) {
    if (node != nullptr) {
        destroyTree(node->left);
        destroyTree(node->right);
        delete node;
    }
}
