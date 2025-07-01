# Assignment 1: Single Linked List for DNA Data Processing

## 📌 Course
BSM 207 - Veri Yapıları (*Data Structures*)

## 📄 Description
This project utilizes a **single linked list** to process and manipulate DNA data. It features two types of lists:
- **Chromosome List**: Contains gene sequences.
- **Population List**: Stores chromosomes.

Genes are inserted using `GenEkle`, while chromosomes are added via `KromozomEkle`. The system reads gene sequences from a file and dynamically creates linked data structures.

## ✨ Features
- Reads thousands of gene sequences efficiently from a file.
- Crossover and mutation operations are implemented to simulate biological mechanisms.
- Allows interactive and automated processing via file commands.
- Traverses population to find longest gene sequences.
- Dynamic memory is properly freed using destructors.

## 🧪 Performance
- 10,000 lines processed in ~35 ms.
- 800,000 lines processed in ~630 ms.

## ⚠️ Known Limitations
- Uses single linked list for memory efficiency; double linked list could offer better performance but is avoided intentionally.

## 🛠️ Compile & Run
```bash
mingw32-make
./Assignment1.exe 
```

## 👤 Author

Selim Altın – Sakarya University

