# Mandatory Assignment – Advanced Software Construction
*pele / mar26*

---

## Idea

Design and implement a library with classes that form a **mini-framework for a turn-based 2D game**. You must use various techniques and tools learned during the course. This framework must **NOT** support any form of GUI.

The library should focus on creating a **world** with different **creatures** that can have various **defences** (protection armor) such as shields, magic, boots, etc., as well as different **attack weapons** such as axes, swords, boomerangs, magic, etc.

The game is 2D (easier than 3D) and turn-based, not real-time (again, to keep it simpler).

---

## Submission

- The assignment is **individual** — submit individually in Wiseflow, but discussing ideas with others is allowed.
- **Work period:** 3 March – 21 April
- **Deadline: Tuesday, 21 April**
- Demonstrate your framework to the instructor between 9:10–15(16).
- Upload a URL to your **GitHub repository** in Wiseflow.
- Upload a **NuGet package** to the NuGet store.
- Prepare a **demo/presentation** for the 21st. A shared schedule will follow.

---

## Detailed Description

*(Changes and clarifications may occur during the assignment period.)*

Build a **library** with classes forming a mini-framework for a turn-based 2D game, featuring a world, creatures, and objects (armor, weapons, treasures, etc.).

**No report required.**

The solution must be accessible as a **NuGet package**.

### Core Objects to Implement

- **World** – A 2D playground
- **Creatures** – Have a position in the world
- **WorldObjects** – Fixed-position objects (e.g. a wall, treasure chest, or elixir)
  - Some can be picked up and removed from the world
  - Some grant bonuses (XP, etc.) or deal damage (new weapons, armor, hit points, …)
- **Attack Items** – Weapons (bow, dagger, magic, …)
- **Defence Items** – Armor (shields, boots, …)

---

## Starting Class Diagram

Use the following design as a starting point (or download the library ZIP):
`https://pele-easj.dk/2026f-ASWC/exercises/Mandatory2DGameFramework.zip`

### Classes

#### `World`
- Properties: `MaxX: int`, `MaxY: int`
- Contains a list of `Creature` / `WorldObject`

#### `Creature`
- Properties: `Name: string`, `HitPoint: int`
- List of attack/defence items
- Methods: `Hit(): int`, `ReceiveHit(hit: int): void`, `Loot(object: WorldObject): void`

#### `WorldObject`
- Properties: `Name: string`, `Lootable: bool`, `Removeable: bool`
- Has a position in the world

#### `AttackItem`
- Properties: `Name: string`, `Hit: int`, `Range: int`
- Can be found in treasure chests or bonus boxes

#### `DefenceItem`
- Properties: `Name: string`, `ReduceHitPoint: int`
- Can be found in treasure chests or bonus boxes

### Core Behaviours

- A **Creature can hit** other creatures.
- A **Creature can loot** an object (if `Lootable`), gaining better weapons, shields, magic, extra hit points, etc.
- A **Creature can receive a hit** and may **die** if hit points reach zero or go negative.

---

## Main Task: Framework Improvement Requirements

Starting from the base implementation (or the ZIP file), refactor the framework **iteratively (agile)** to make it increasingly flexible using techniques from the course.

### Requirements

- **Language:** C#

- **Configuration file (week 7)**
  Load values from an **XML file**, including at minimum:
  - World size (`MaxX`, `MaxY`)
  - Game difficulty level (beginner, normal, expert)

- **Tracing / Logging (week 7)**
  Create a class `MyLogger` that:
  - Is a **Singleton**
  - Supports adding and removing `TraceListeners`
  - Logs various information flexibly
  - **No `Console.WriteLine` in the library**

- **Documentation (week 6)**
  - `///` XML comments on **at least 3 classes**
  - Generate an `index.html` file using **Doxygen**

- **SOLID Principles (week 11)**
  Demonstrate **all 5 SOLID principles** in the framework.

- **Design Patterns (weeks 6, 9, 12, 13)**

  | Pattern | Where |
  |---|---|
  | **Template Method** | `Creature` must be a template |
  | **Observer** | `Creature` notifies observers on `Hit` and on death |
  | **Strategy** | `Creature` must implement at least one method as a Strategy |
  | **Decorator** | `AttackItem` decorator to boost or weaken attack |
  | **Composite** | `AttackItem` composite to group weapons |
  | **Weight system** | `AttackItem` has a `Weight` property; a `Creature` can be configured with a max carry weight (hint: implement in the Composite class) |
  | *(Optional)* | Consider also: **State**, **Factory**, or other patterns |

- **NuGet deployment (week 16)**
  Prepare and deploy the framework to the NuGet store.

- **Operator Overloading (week 15)**
  Demonstrate operator overloading in at least one place in the framework.

- *(Optional)*: Use **Reflection** and/or **Regular Expressions**

### Additional Functional Requirements

- When a creature attacks another, the damage is the **sum of multiple attack weapons**.
- When a creature receives a hit, it is **reduced by multiple defence items** (e.g. a creature can wear both a helmet and chainmail simultaneously).

---

## Testing the Framework – Console Application

- Design and implement a **Console application** that uses your framework to verify it works.
- In `Program.cs`, create concrete classes that inherit from / implement interfaces and classes from your framework — demonstrating its power and ease of use.
- `Console.WriteLine()` **is allowed** in the console application.
- **Do NOT build a complete game** — focus on the framework.

---

## Extra Challenges (for those who finish early)

- Support a **game loop** where each iteration involves a creature moving, looting objects, or fighting another creature.
- Creatures can **move**, always taking the shortest path (e.g. X direction = +3, Y direction = −10), with obstacle checking along the way.
