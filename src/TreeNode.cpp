#include "TreeNode.hpp"
#include <cstddef> // NULL için

TreeNode::TreeNode(char data) : data(data), left(NULL), right(NULL) {}

BinaryTree::BinaryTree() : root(NULL) {}

BinaryTree::~BinaryTree() {
    destroyTree();
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
    // Eşit olduğunda hiçbir işlem yapma (tekrarlı eleman yok)
}

void BinaryTree::destroyTree() {
    destroyTree(root);
    root = NULL;
}

void BinaryTree::destroyTree(TreeNode* node) {
    if (node != NULL) {
        destroyTree(node->left);
        destroyTree(node->right);
        delete node;
    }
}
