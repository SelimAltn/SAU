```markdown
# Space Migration Simulation

> **Sakarya Üniversitesi**  
> Programlama Dillerinin Prensipleri II – 2. Ödevi

---

## Overview

This is a **space migration simulation** written in C, modeling passengers traveling between planets with different day lengths and aging factors. It reads input from text files, advances time on each planet, moves ships and passengers hour by hour, handles departures, arrivals, passenger aging, and reports final populations and vehicle statuses.

---

## Project Details

- **Language:** C (C11)  
- **Build System:** Makefile + GCC (MinGW on Windows)  
- **Folder Layout:**
```

UzaySimulasyonu/
├── Makefile
├── data/                 # Input files: Kisiler.txt, Araclar.txt, Gezegenler.txt
├── include/              # Public headers (.h)
├── src/                  # Source files (.c)
├── build/                # Compiled object files
└── README.md             # This document

![alt text](image.png)

```

---

## Features

- **SOLID-inspired C “OO” design** with pointer-based structs, constructors, method pointers, and destructors  
- **Flexible “database”** via dynamic file-based input (no external DB)  
- **Multiple planet types** with different aging factors (rocky, gas giant, ice giant, dwarf)  
- **Timekeeping module** supporting variable day lengths and real calendar (leap years, month lengths)  
- **Per-hour simulation loop**  
- Ship departures when planetary clocks match departure times  
- Passenger aging and survival checks  
- Ship movement, arrival date calculation  
- Planet clocks advance by one hour each iteration  
- **Formatted console output**: aligned tables of planet dates/populations and ship statuses  

---

## Technologies Used

- **C** (C11 standard)  
- **GCC** (MinGW on Windows)  
- **Make** (Makefile)  
- **Standard C Library** (`stdio.h`, `stdlib.h`, `string.h`)  

---

## Database Design (Input Files)

Rather than a relational database, this project uses plain-text files in `data/`:

1. **Kisiler.txt**  
```

isim#yas#kalanOmur#aracAdi
Alice#30#100#X
Bob#42#120#Y

```
2. **Araclar.txt**  
```

isim#cikisGezegen#varisGezegen#gun#ay#yil#saat#mesafeSaat
X#A#B#1#5#2025#12#10

```
3. **Gezegenler.txt**  
```

isim#gunSaat#gun#ay#yil#tipID
A#24#1#5#2025#0

````
- **Parsing module** skips header lines, dynamically grows arrays, allocates struct instances via constructors.

---

## Installation & Usage

1. **Clone** or download the repository.  
2. **Build**:
```sh
make
````

3. **Run**:

   ```sh
   ./program    # or program.exe on Windows
   ```
4. **Clean**:

   ```sh
   make clean
   ```

---

## Assignment Objectives

1. **Object-oriented design in C**: use opaque pointers, method pointers, encapsulation
2. **Modularity and SOLID principles**: separate concerns into multiple modules (.h/.c)
3. **File I/O robustness**: header skipping, safe parsing, dynamic resizing
4. **Time and calendar simulation**: leap-year, month lengths, variable day-lengths
5. **Simulation control flow**: per-hour updates, departure/arrival logic, passenger aging
6. **Formatted reporting**: aligned tables, custom centering functions

---

## Contributors

* **Author**: \[Selim Altın (Student, Sakarya University)]
* **Course**: Programlama Dillerinin Prensipleri II (2025)

---

## License

© 2025 Sakarya University.
This code and accompanying materials are a homework assignment for the course Programlama Dillerinin Prensipleri. Unauthorized distribution or use outside the scope of the course is prohibited.
```
```
