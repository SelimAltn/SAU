#include "TreeNode.hpp"
#include <iostream>
#include <iomanip> // Görselleştirme için
#include <cmath>   // Güç fonksiyonu için

using namespace std;

BinaryTree::BinaryTree() : root(nullptr) {}

BinaryTree::~BinaryTree() {
    destroyTree(root);
}

// Düğüm ekleme
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

// Ağacı sıralı yazdırma
void BinaryTree::printInOrder(std::ostream& out) {
    printInOrder(root, out);
    out << std::endl;
}

void BinaryTree::printInOrder(TreeNode* node, std::ostream& out) {
    if (node != nullptr) {
        printInOrder(node->left, out);
        out << node->data << " ";
        printInOrder(node->right, out);
    }
}

// Ağacı bellekten temizleme
void BinaryTree::destroyTree(TreeNode* node) {
    if (node != nullptr) {
        destroyTree(node->left);
        destroyTree(node->right);
        delete node;
    }
}

// Ağacı aynalama
void BinaryTree::mirrorTree() {
    mirrorTree(root);
}

void BinaryTree::mirrorTree(TreeNode*& node) {
    if (node == nullptr) return;

    mirrorTree(node->left);
    mirrorTree(node->right);

    TreeNode* temp = node->left;
    node->left = node->right;
    node->right = temp;
}
int BinaryTree::calculateTotalValue() {
    return calculateTotalValue(root); // Kök düğümden başla
}
// Toplam değer hesaplama
int BinaryTree::calculateTotalValue(TreeNode* node) {
    if (node == nullptr) {
        return 0; // Eğer düğüm boşsa katkısı yok
    }

    // Mevcut düğümün ASCII değerini hesapla
    int currentValue = node->data - 'A' + 1; 

    // Sol düğümün değeri 2 ile çarpılıyor
    int leftValue = 2 * calculateTotalValue(node->left);

    // Sağ düğümün değeri direkt alınıyor
    int rightValue = calculateTotalValue(node->right);

    // Toplam değeri döndür
    return currentValue + leftValue + rightValue;
}
void BinaryTree::printTree() {
    if (root == nullptr) {
        std::cout << "Tree is empty!" << std::endl;
        return;
    }

    int maxDepth = calculateDepth(root); // Maksimum derinliği hesapla
    int currentSize = 1; // Kök seviyesinde sadece 1 düğüm var
    TreeNode** currentLevel = new TreeNode*[currentSize]; // Geçerli seviyenin düğümleri
    currentLevel[0] = root;

    int space = 10 * maxDepth; // İlk seviye için boşluk başlangıcı
    for (int level = 0; level < maxDepth; ++level) {
        // Seviyeyi çizgilerle ayır
        if (level > 0) {
            printHorizontalLine(space, currentSize);
        }

        // Her seviyede düğümleri yazdır
        printSpaces(space / 2); // Başlangıç boşluğu
        TreeNode** nextLevel = new TreeNode*[currentSize * 2]; // Sonraki seviye için daha büyük dizi
        int nextIndex = 0;

        for (int i = 0; i < currentSize; ++i) {
            if (currentLevel[i]) {
                std::cout << currentLevel[i]->data;
                nextLevel[nextIndex++] = currentLevel[i]->left;
                nextLevel[nextIndex++] = currentLevel[i]->right;
            } else {
                std::cout << " "; // Boş düğüm
                nextLevel[nextIndex++] = nullptr;
                nextLevel[nextIndex++] = nullptr;
            }
            printSpaces(space); // Düğümler arasındaki boşluk
        }
        std::cout << std::endl; // Yeni seviyeye geç
        delete[] currentLevel;
        currentLevel = nextLevel;
        currentSize = nextIndex;
        space /= 2; // Boşlukları azalt
    }

    delete[] currentLevel; // Belleği serbest bırak
}

void BinaryTree::printSpaces(int count) {
    for (int i = 0; i < count; ++i) {
        cout << " ";
    }
}

void BinaryTree::printHorizontalLine(int space, int size) {
    printSpaces(space / 2); // Çizgilerin başlangıç boşluğu
    for (int i = 0; i < size; ++i) {
        std::cout << "-----";
        printSpaces(space); // Çizgiler arasındaki boşluk
    }
    cout <<endl;
}

int BinaryTree::calculateDepth(TreeNode* node) {
    if (node == nullptr) {
        return 0;
    }
    return 1 + max(calculateDepth(node->left), calculateDepth(node->right));
}
