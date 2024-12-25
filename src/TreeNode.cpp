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

void BinaryTree::printInOrder(std::ostream& out) {
    printInOrder(root, out);
    out << std::endl;
}


void BinaryTree::printInOrder(TreeNode* node, std::ostream& out) {
    if (node != nullptr) {
        printInOrder(node->left, out);      // Sol alt düğüm
        out << node->data << " ";          // Mevcut düğüm
        printInOrder(node->right, out);    // Sağ alt düğüm
    }
}

void BinaryTree::destroyTree() {
    destroyTree(root);
    root = nullptr;
}

void BinaryTree::destroyTree(TreeNode* node) {
    if (node != nullptr) {
        destroyTree(node->left);
        destroyTree(node->right);
        delete node;
    }
}
void BinaryTree::mirrorTree() {
    mirrorTree(root);
}

void BinaryTree::mirrorTree(TreeNode*& node) {
    if (node == nullptr) return;

    // Alt düğümleri aynala
    mirrorTree(node->left);
    mirrorTree(node->right);

    // Sol ve sağ düğümleri değiştir
    TreeNode* temp = node->left;
    node->left = node->right;
    node->right = temp;
}
