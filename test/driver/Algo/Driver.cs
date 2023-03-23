using System;
using InputHandler;
using Map;
using Algo; 

class DriverAlgo
{
    static void Main(string[] args)
    {
        InputHandlerFile inputHandlerFile = new InputHandlerFile();
        // inputHandlerFile.readFile("../../TestInput1.txt");
        inputHandlerFile.readFile("../../TestMaze.txt");
        MyMap map = new MyMap(inputHandlerFile.getInputData());
        // DFS dfsbacktrack = new DFS(map);
        
        // mapElmt start = new mapElmt(ind, row, col);
        // // g.addEdge(start);
        // // Console.WriteLine("ind = " + ind);
        // // Console.WriteLine("row = " + row);
        // // Console.WriteLine("col = " + col);
        // // Console.WriteLine(index);
        // // Console.WriteLine(ind);
        // // g.print();
        // // Console.WriteLine("ind = " + ind);
        // map.print();
        // Console.WriteLine("\n\nDepth-first traversal (starting from vertex start):");
        
        map.print();
        MyAlgo g = new MyAlgo(map);
        // g.DFS();
        Console.WriteLine("\nBacktracking:");
        g.resetVisited();
        g.dfsbacktrack();
        // g.DFS();
        // g.setResult();

        // BFS bfs = new BFS(map);

        // mapElmt m = new mapElmt(i, j, map.getElement(i, j));
        // MyAlgo g = new MyAlgo(4);
        // mapElmt m1 = new mapElmt(0, 90, 100);
        // mapElmt m2 = new mapElmt(1, 93, 10);
        // mapElmt m3 = new mapElmt(2, 90, 16);
        // g.AddEdge(0, m3);
        // g.AddEdge(0, m2);
        // g.AddEdge(1, m3);
        // g.AddEdge(2, m1);
        // g.AddEdge(2, m3);
        // g.AddEdge(3, m2);
        // Console.WriteLine("Depth-first traversal (starting from vertex 2):");
        // g.DFS(m1);
        // Console.WriteLine("\n\ngraph:");
        // g.print();
    }
}