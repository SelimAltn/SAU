# Interplanetary Spacecraft Simulation

## Overview
This Java console application simulates interplanetary travel of multiple spacecraft, managing independent time lines on each planet, passenger lifespans, vehicle activation/destruction logic, and produces a detailed end‐of‐run report.

## Project Details
- **Course**: Programlama Dillerinin Prensipleri  
- **Institution**: Sakarya University  
- **Assignment**: Read `Kisiler.txt`, `Gezegenler.txt`, `Araclar.txt`; simulate:
  - Planetary time flow (each planet has its own “hours per day”)
  - Spacecraft activation at departure date
  - Hourly decrement of travel distance and passenger lifespan
  - Vehicle destruction if all passengers die
  - Arrival logging and population updates


    ![image](https://github.com/user-attachments/assets/fad54ee8-8d8f-4233-be34-8bc216395568)


## Features
- **Flexible file parsing**: skips header rows if present; recovers from malformed lines  
- **Independent planetary clocks**: each planet advances by its own day‐length  
- **Robust activation logic**: spacecraft activate when planet date ≥ departure date (`ondanOnceMi()` helper)  
- **Passenger lifecycle**: hourly lifespan decrement; safe removal via `Iterator`  
- **Vehicle states**: WAITING, EN ROUTE, ARRIVED, DESTROYED  
- **Live console output**: clears console each hour, prints aligned tables for planets and vehicles  
- **End‐of‐simulation summary**: total hours, survivors, destroyed/victorious vehicle counts

## Technologies Used
- **Java SE 8+**  
- **Eclipse IDE**  
- **Collections**: `ArrayList<Kisi>`, `ArrayList<Gezegen>`, `ArrayList<UzayAraci>`  
- **Maps**: `HashMap<String,Zaman>` for planetary clocks  
- **I/O**: `BufferedReader` & `FileReader`  
- **Formatting**: `System.out.printf` for aligned tables  
- **Thread control**: `Thread.sleep(10)` for smooth console animation

## Database Design
> _(Here “database” refers to the input text files.)_

- **Kisiler.txt**  
  ```
  Name#Age#RemainingLifespan(hours)#SpacecraftID
  ```
- **Gezegenler.txt**  
  ```
  PlanetName#HoursPerDay#StartDate(dd.MM.yyyy)
  ```
- **Araclar.txt**  
  ```
  CraftID#DeparturePlanet#ArrivalPlanet#DepartureDate(dd.MM.yyyy)#Distance(hours)
  ```

## Installation & Usage

1. **Clone the repo**  
   ```bash
   git clone https://github.com/yourusername/interplanetary-simulation.git
   cd interplanetary-simulation
   ```
2. **Build in Eclipse**  
   - Import project as “Existing Java Project”  
   - Ensure `data/` folder (with `.txt` files) is on classpath or copied to project root  
3. **Create JAR**  
   - In Eclipse: **Export → Runnable JAR File → dist/main.jar**  
   - Make sure `Main-Class: sim.Simulasyon` is set  
4. **Run from command line**  
   ```bash
   cd dist
   java -jar main.jar
   ```
   > _If resource files are in `dist/`, the code will look for `dist/Kisiler.txt`, etc._

## Assignment Objectives
- **Data Integration**: Read and parse traveler, planet and spacecraft data from text files.  
- **Independent Time Streams**: Simulate each planet’s own day–hour cycle, allowing days of different lengths.  
- **Vehicle Activation Logic**: Activate spacecraft when a planet’s simulated date reaches the departure date.  
- **Traveler Lifespan Management**: Reduce each traveler’s remaining life by one hour per simulation step; remove deceased travelers and destroy empty spacecraft.  
- **Journey Tracking**: Decrease spacecraft distance each hour, mark arrivals, record arrival dates in the correct planetary timezone.  
- **Dynamic Population Counts**: Update planet populations as travelers depart, die, or arrive.  
- **Real-time Console Visualization**: Clear and refresh the console each hour with aligned planet and spacecraft tables.  
- **Summary Reporting**: Produce end-of-simulation statistics: total hours elapsed, survivors, destroyed vs. arrived spacecraft, final planet times and populations.  
- **Packaging**: Package the project as a runnable JAR with console-clearing support for command-line execution.

## Contributors
  📌 Selim Altın (Student, Sakarya University)
  
## License
© 2025 Sakarya University.  
This code and accompanying materials are a homework assignment for the course **Programlama Dillerinin Prensipleri**. Unauthorized distribution or use outside the scope of the course is prohibited.
```
