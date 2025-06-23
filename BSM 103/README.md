# Programming Fundamentals – Assignment 1

*Sakarya University, Computer Engineering Department*

## 📚 Overview

This repository contains two versions of my very first university programming assignment:

| Folder               | Description                                                                                                                                            |
| -------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **`v1-first-year/`** | The original code I wrote as a 1st-year student in Fall 2023. It met the requirements but is verbose, repetitious and procedural.                      |
| **`v2-refactored/`** | A cleaner, object-oriented rewrite completed one year later. It applies better naming, separation of concerns, STL containers and modern C++ features. |

> **Purpose of the repo:** to document my growth as a developer by putting both implementations side-by-side.

---

## 📝 Assignment Brief

**Course:** Programming Fundamentals (BSM 103)
**Task:**

1. Accept user-defined weightings (mid-term, two homework tasks, two quizzes).
2. Generate random scores for *N* students, distributed across three performance tiers (top 20 %, middle 50 %, bottom 30 %).
3. Compute each student’s weighted average, assign a letter grade (AA-FF) and determine pass/fail status.
4. Output per-student details and overall class statistics:

   * class average
   * highest / lowest average and corresponding students
   * standard deviation
   * letter-grade counts + percentages

---

## 🔄 Key Differences Between Versions

| Aspect          | **v1 (First Year)**            | **v2 (Refactored)**                                                                      |
| --------------- | ------------------------------ | ---------------------------------------------------------------------------------------- |
| Data structures | Raw arrays, manual counters    | `std::vector`, structs with default initializers                                         |
| Repetition      | High – many copy-pasted blocks | Minimized via helper functions & loops                                                   |
| Random logic    | Hard-coded ranges              | Central `generateRandomGrade()`                                                          |
| Output          | Unformatted `cout`             | Width/align formatting for tidy tables                                                   |
| Statistics      | Calculated inline              | Dedicated functions (`calculateStandardDeviation`, `CalculateLowestHighestScores`, etc.) |
| Maintainability | Difficult to extend            | Single-source-of-truth constants, easier to tweak                                        |

---

## 🛠️ How to Build & Run

```bash
# inside either v1-first-year or v2-refactored
g++ -std=c++17 main.cpp -o assignment1
./assignment1
```

> Tested on GCC 13 / Clang 17 and Windows 10 MSVC.

---

## ✨ What I Learned

* **Clean architecture matters:** breaking logic into small, purpose-driven functions makes the program far easier to read and debug.
* **Containers beat raw arrays:** `std::vector` and range-based loops remove manual indexing errors.
* **Meaningful naming & defaults:** descriptive identifiers and in-struct initializers reduce bugs and boilerplate.
* **Incremental improvement:** revisiting past code is an excellent way to measure progress and cement good habits.

---

