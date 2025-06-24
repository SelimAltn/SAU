# Sakarya University - Computer Engineering
## Data Structures - Assignments

## Overview
This repository contains two assignments for the Data Structures course. Each project focuses on different data structures and their implementations, including single linked lists and binary search trees.

---
## Assignment 1: Single Linked List for DNA Data Processing
### Project Description
In this project, a single linked list is used to process DNA data. Two main lists are implemented:
- **Chromosome List**: Stores genes.
- **Population List**: Stores chromosomes.

Genes are added using the `GenEkle` function, and chromosomes are added to the population list using the `KromozomEkle` function. Data is read from a file using `getline`, processed into genes, and inserted into these lists.

### Features Implemented
1. **Data Reading and Listing**:
   - Reads data from a file, splits it into genes, and inserts them into the list.
   - Performance tests:
     - 10,000 lines: ~35 ms.
     - 800,000 lines: ~630 ms.
   - A single linked list was chosen for memory efficiency over a double linked list.

2. **Crossover Operation**:
   - Retrieves chromosomes from the list using the `KromozomBul` function.
   - Combines genes from two chromosomes to create new ones.
   - Adds newly formed chromosomes to the population list.
   - Can be performed both interactively and programmatically.

3. **Mutation Operation**:
   - Selects a specific chromosome and gene using `GenBul`.
   - Mutates the gene by changing it to 'X'.

4. **Automated Processing**:
   - Reads and applies operations from a file using `IslemleriOkuVeUygula`.
   - Uses `sstream` for processing parameters efficiently.

5. **Output Display**:
   - Scans the population list to find the largest gene from right to left.
   - Displays results in sequence.

6. **Memory Management**:
   - Uses destructors to free dynamically allocated memory.
   - Ensures proper cleanup of chromosomes and genes at program termination.

### Challenges Faced
- **Gene Insertion Performance**:
  - Initially, finding the last element required traversing the entire list (O(n)).
  - Solution: Added a tail pointer to the `Kromozom` class for O(1) insertion.

- **Performance Testing**:
  - Used `getline` and optimized list algorithms for large file processing.
  - Considered using a double linked list but prioritized memory efficiency.

### Limitations
- **Double Linked List Not Used**:
  - Could have improved performance but was avoided to reduce memory usage.

---
## Assignment 2: Binary Search Tree and Linked List Implementation
### Project Description
This project involves reading data from a file to construct binary search trees (BSTs) and organizing them in a linked list.

### Key Objectives
1. Read data from a file and create a BST for each line.
2. Link BSTs using a dynamic linked list.
3. Provide an interactive console interface for list navigation, tree deletion, and mirroring.
4. Compute and visualize the total value of each tree.

### Concepts Learned
- **Data Structures**: Deep understanding of BSTs and linked lists.
- **Dynamic Memory Management**: Efficient memory allocation and deallocation.
- **User Interface Design**: Implemented a console-based interactive UI.
- **Visualization**: Representing BST structures in a readable format.

### Implementation Details
1. **Binary Search Tree (BST) Design**:
   - `TreeNode` structure holds characters.
   - `BinaryTree` class provides:
     - `insert`: Adds characters in order.
     - `calculateTotalValue`: Computes tree sum (left subtree ×2, right subtree ×1).
     - `mirrorTree`: Flips the tree structure.
     - `printTree`: Displays tree hierarchy with improved alignment.

2. **Linked List Design**:
   - `LinkedList` class links multiple BSTs.
   - Each node represents a BST.
   - `addNode` and `removeNode` update the list dynamically.
   - Users navigate with "a" and "d" keys.
   - `printListWithArrows` visually highlights the selected tree.

3. **File Processing**:
   - `Processor` class reads file line by line and constructs BSTs.
   - `RewriteFile` saves modifications back to the file.

4. **User Interactions**:
   - "w": Mirrors the selected tree.
   - "s": Deletes the selected tree.
   - Prevents crashes when the last tree is deleted.
   - Displays messages when at the start or end of the list.

5. **Visualization Enhancements**:
   - Levels in BSTs are separated by lines (`-----`).
   - Empty nodes use placeholders.
   - Node spacing is dynamically adjusted based on depth.

### Challenges Faced
1. **Total Value Calculation**:
   - Ensured ASCII values were correctly summed.
   - Applied the formula (left ×2, right ×1) to resolve issues.

2. **List Navigation**:
   - Implemented dynamic traversal and pagination.
   - Limited display to 10 nodes per page, controlled by "a" and "d" keys.

3. **Tree Visualization**:
   - Initial alignment issues required fine-tuning.
   - Improved readability with proper spacing and line formatting.

### Limitations
1. **Visualization Improvements**:
   - Output formatting could be more polished.

2. **User-Friendly Interface**:
   - Further refinements needed to enhance ease of use.

---
## Compilation and Execution
- This project uses a `Makefile` for compilation.
- To compile the project, run the following command:
  ```sh
  mingw32-make
  ```
- To clean the compiled files, use:
  ```sh
  mingw32-make clean
  ```

---
## Conclusion
These projects provided practical experience in working with fundamental data structures such as linked lists and binary search trees. They reinforced key concepts such as dynamic memory management, algorithm optimization, and user interaction design. Future improvements could focus on better visualization, optimized memory usage, and enhanced usability.

---
## Contributors
**Selim Altın** (Student, Sakarya University)

