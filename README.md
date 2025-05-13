# 📘 README — *Series Analyzer*

---

## 🧩 Project Overview

> **Series Analyzer** is a C# console application that allows users to input a series of positive integers and analyze them.  
> It features sorting, reversing, finding max/min, average, and more — all from a clean, menu-driven interface.

---

## 🔧 Key Features

- Input series via:
  - Command-line arguments
  - Interactive console prompt
- Menu-based operations:
  - 🟦 Display original series  
  - 🔁 Display reversed series  
  - 🔼 Sort using insertion sort  
  - 🧮 Show sum, average, max, min  
  - 🔢 Count total numbers  
- Clean and modular structure with SOLID principles
- Easy to test, maintain, and extend

---

## 🗂️ Folder Structure

```
SeriesAnalyzer/
├── Interfaces/
│   └── IUserInterface.cs          # UI abstraction
├── Implementations/
│   └── ConsoleUserInterface.cs    # Console-based implementation
├── Services/
│   └── NumberSeriesService.cs     # Core number logic (validation, parse, sort, etc.)
├── Menu/
│   └── SeriesMenu.cs              # User interaction and menu logic
├── Program.cs                     # Main entry point
└── README.md                      # This file
```

---

## 🚀 Getting Started

### ▶️ Run with Visual Studio
1. Open the solution in **Visual Studio 2022+**
2. Press `Ctrl + F5` to run

### 📦 Run from Command Line
```bash
dotnet run
```

**With arguments:**
```bash
dotnet run -- 5 10 15 20
```

If no arguments are passed, the app will prompt for input interactively.

---

## 🧠 SOLID Principles in Action

| Principle | Application |
|----------|-------------|
| SRP | Each class has a single responsibility (e.g. UI, service, menu) |
| OCP | You can extend functionality (like new UI types) without changing core logic |
| LSP | All implementations of interfaces behave correctly and predictably |
| ISP | Interfaces are minimal and purpose-specific |
| DIP | Logic depends on abstractions (interfaces) rather than concrete types |

---