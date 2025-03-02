#include "FileManager.hpp"
#include "TreeNode.hpp"
#include <iostream>
#include <fstream>
#include <sstream>
#include <string>


bool FileManager::openFile(const char* fileName) {
    file.open(fileName);
    return file.is_open();
}

bool FileManager::readLine(std::string& line) {
    if (file.is_open() && std::getline(file, line)) {
        return true;
    }
    return false;
}

void FileManager::closeFile() {
    if (file.is_open()) {
        file.close();
    }
}
