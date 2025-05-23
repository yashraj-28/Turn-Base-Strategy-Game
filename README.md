# 🧠 Turn-Based Strategy Game (C# + A* Algorithm + AI Logic)

A 3D top-down **Turn-Based Strategy Game** featuring AI opponents, pathfinding with the A* algorithm, tactical combat, and scoring — all driven by **C#**.

> 🎯 This game is a showcase of clean, decision-based logic, modular system design, and algorithmic thinking using **C#** in Unity.

---

## ♟️ Core Features

### 🤖 AI Logic
- Enemy units calculate optimal moves based on player position, visibility, and health
- State-driven enemy behavior: Patrol → Engage → Retreat
- Custom decision trees implemented in C#

### 🧭 A* Pathfinding
- Fully implemented **A* pathfinding algorithm** in C#
- Dynamic obstacle avoidance and terrain cost evaluation
- Units move along calculated paths step-by-step per turn

### 🔫 Combat System
- Grid-based turn order system
- Units perform actions like **Move, Shoot, Take Cover**
- Each attack calculates hit chance based on line-of-sight and range

---

## 🧱 Built With

| Component     | Tech Stack                     |
|---------------|--------------------------------|
| Language       | C# (.NET / Mono)              |
| Engine         | Unity 3D                      |
| Visuals        | 3D top-down with grid overlay |
| Audio          | BGM, SFX, and VFX with AudioManager in C# |
| IDE            | Visual Studio                 |

---

## 🎮 Gameplay Mechanics

- 🧠 **Strategic Turns**: Alternating turns between player and AI
- 🔄 **Action Points System**: Units perform actions within AP budget
- 🏹 **Cover Mechanics**: Half and full cover affect hit chance
- 🎯 **Shooting Logic**: Includes accuracy, damage range, and elevation modifiers
- 📈 **Score Tracking**: Player earns points for tactical kills and efficiency

---

## 🎵 Audio & Visual Polish

- 🎧 Background music with turn-based intensity changes
- 💥 Attack VFX and UI feedback on hit/miss
- 🔊 SFX for movement, firing, and UI clicks

---

## 🧠 C# Technical Highlights

- **Modular Architecture** using interfaces and abstract classes for unit actions
- **Data-Driven Design**: Grid and map data are serializable for flexibility
- **AI States** coded via finite state machines (FSMs)
- **Event System** for turn flow, combat results, and score updates
- **Object Pooling** for VFX and audio sources to enhance performance

---

## 🚀 Getting Started

### Requirements
- Unity Editor 2021.3+
- Visual Studio (with C# tools)

### Setup

```bash
git clone https://github.com/yourusername/Turn-Based-Strategy-Game.git
```

Run the application with Unity version 2021 or higher.
