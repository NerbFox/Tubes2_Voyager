# Maze Treasure Hunt with _BFS and DFS_ Algorithm

## Table of Contents
- [Maze Treasure Hunt with _BFS and DFS_ Algorithm](#maze-treasure-hunt-with-bfs-and-dfs-algorithm)
  - [Table of Contents](#table-of-contents)
  - [Program Description](#program-description)
  - [Algorithm](#algorithm)
  - [Requirements](#requirements)
  - [Program Structure](#program-structure)
  - [How To Run](#how-to-run)
  - [Project Status](#project-status)
  - [Acknowledgements](#acknowledgements)
  - [Authors](#authors)

## Program Description
__BFS__ is an algorithm used to traverse or search in a graph or tree data structure. The algorithm starts from the root node or source node and explores all the nodes at the current depth before moving on to nodes at the next depth level. __BFS__ is implemented using a queue data structure, where nodes are inserted into the queue and then processed in a FIFO (first in, first out) order.

__DFS__, on the other hand, is an algorithm used to traverse or search in a graph or tree data structure. The algorithm starts from the root node or source node and explores as far as possible along each branch before backtracking. __DFS__ can be implemented using either a stack or recursion. When using a stack, nodes are pushed onto the stack and then processed in a LIFO (last in, first out) order. When using recursion, the function calls itself for each child node until it reaches the base case.

Both __BFS and DFS__ have their own advantages and disadvantages depending on the situation. __BFS__ is useful when we want to find the shortest path in an unweighted graph or tree, whereas __DFS__ is useful when we want to search for a particular node or find a path in a weighted graph or tree.

In this project, the authors was tasked to develop an application with a simple GUI that can implement BFS and DFS to get a route to get all the existing treasures. The program can accept and read as input a txt file that contains a maze that will find a route solution to get the treasure. There are 4 objects in the maze, namely:
- __K__: Starting point
- __T__: Treasure
- __R__: Accessible path
- __X__: Inaccessible path

## Algorithm
- BFS (Breadth-First Search)
- DFS (Depth-First Search)

## Requirements
- C# (Tested on dotnet sdk version 7.0)
- make (optional)

## Program Structure
```
.
├── bin/net7.0-windows/
│   ├── main.deps.json
│   ├── main.dll
│   ├── main.exe
│   ├── main.pdb
│   └── main.runtimeconfig.json
├── doc/
│   ├── Tubes2_K1_13521043_Voyager.pdf
│   └── Spek_Tubes2-Stima-2023.pdf
├── src/
│   ├── class/
│   │   ├── Algo.cs
│   │   ├── GUI.cs
│   │   ├── InputHandler.cs
│   │   └── Map.cs
│   ├── UI/
│   │   ├── Illustrator
│   │   ├── Background.png
│   │   └── Icon.co
│   ├── .gitignore
|   ├── main.cs
│   └── main.csproj
├── test/
│   ├── driver/
│   └── TestCases
├── Makefile
└── README.md
```

## How To Run
To run the program in the terminal _root directory_ using make, run the command __make__. If you're not using make, change directory to _src_, then run command __dotnet build__. After done generating bin files, run the command __dotnet run__ to run the program.
```
make

or

dotnet build (inside src folder)
dotnet run (inside src folder)
```
The program can also be run by directly compiling _main.cs_ while including all of the class files using dotnet framework. This step can be done just like compiling C++ program (g++ for c++, csc for c#).

However, it is better to run the program using __make__ because it is easier to use and more convenient.

## Project Status
Project progress: ![100%](https://geps.dev/progress/100)

## Acknowledgements
Thank you to all of Algorithm Stategy lecturers:
- Dr. Nur Ulfa Maulidevi ST,M.Sc,
- Dr. Ir. Rinaldi Munir, M.T., and
- Dr.Ir. Rila Mandala, M.Eng.

And also thank you to the IF2211 Lecture Assistant Team.

## Authors
- 13521043 [Nigel Sahl](https://github.com/NerbFox)
- 13521058 [Ghazi Akmal Fauzan](https://github.com/ghaziakmalf)
- 13521070 [Akmal Mahardika Nurwahyu Pratama](https://github.com/akmaldika)