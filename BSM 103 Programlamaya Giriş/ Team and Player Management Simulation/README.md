# 🏀 Team and Player Management Simulation

## 📖 Course

**Introduction to Programming**
**Sakarya University – Department of Computer Engineering**

## 🔹 Project Title

**Console-Based Interactive Team and Player Management System**

## 🔹 Overview

This project simulates a football team management system that allows users to dynamically create, list, update, and delete football teams and players. Users can assign players to teams, simulate matches, and track goal statistics.

This project was developed as a **first-semester term project** for the "Introduction to Programming" course.

The system is entirely console-based and written in **C++**. It employs structures like `class`, `struct`, `vector`, `set`, and `fstream` to provide a realistic, data-driven interaction between teams and players.

---

## 🌐 Features

### ✅ Team Management

* Add new teams (manually or randomly)
* Unique city, phone number, team code, and manager name
* Uses `std::set` to prevent duplicates
* Lists all teams in the console and saves them to `takim.txt`

### ✅ Player Management

* Create single or multiple players (random or custom)
* Each player includes ID number, position, salary, birthdate
* Automatically or manually assign players to teams
* Export player information to `futbolcu.txt`

### ✅ Match Simulation

* Requires teams with at least one player to participate
* Weekly matches simulated with random scores
* Team points are updated automatically
* The team with the highest score is declared the winner

### ✅ Goal Statistics

* Random goal counts are assigned to players
* Goal-scoring players can be listed

### ✅ Player-Team Interaction

* Add or remove players from a team
* Update player info (position or salary)
* List players by team code
* When a team is deleted, player links are removed

---

## 🛠️ Technologies Used

* **Language**: C++
* **Compiler**: g++ (MinGW / Linux GCC)
* **Standard**: C++11+
* **Data Structures**: `vector`, `set`, `struct`, `class`
* **File Handling**: `fstream`

---

## 📊 Sample Expected Output

```
1. Team Name: Ankara SPOR
   Manager: Ahmet Kaya
   Phone: +905555555555
   Code: 123
   Player Count: 3
--------------------------------------
1. Player: Lionel Messi
   Position: ST - Striker
   Salary: 2500000 TL
   Team: Ankara SPOR
   Goals: 2

--- Match Simulation ---
Ankara SPOR vs Bursa SPOR - Winner: Ankara SPOR
Ankara SPOR Points: 3
Bursa SPOR Points: 0

--- Goal Scorers ---
Lionel Messi - Goals: 2
Cristiano Ronaldo - Goals: 1
```

---

## 🎓 Learning Outcomes

* Fundamentals of object-oriented programming
* Console-based menu and system design
* Random data generation and control mechanisms
* Generating output files with `ofstream`
* Memory management with `vector` and `set`
* Menu logic using conditionals and loops

---

## 👤 Project Owner

**Selim Altın**
Sakarya University – Computer Engineering (1st Year)

---

## 🚫 License

This project is a product of a university term assignment. Unauthorized use, sharing, or reproduction outside of academic purposes is prohibited.

---

## ✨ Note

This project was submitted as the **final assignment** of the **first semester** for the "Introduction to Programming" course and was successfully delivered.
