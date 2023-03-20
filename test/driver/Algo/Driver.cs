using System;
using Algorithm;
using InputHandler;
using Map;
using Algo;

class DriverAlgo
{
    static void Main(string[] args)
    {
        InputHandlerFile inputHandlerFile = new InputHandlerFile();
        inputHandlerFile.readFile("../../TestInput4.txt");
        MyMap map = new MyMap(inputHandlerFile.getInputData());
        // DFS dfs = new DFS(map);
        // int v = 0;
        // int row = 0;
        // int col = 0;
        // int ind = 9;
        // for (int i = 0; i < map.getMapHeight(); i++)
        // {
        //     for (int j = 0; j < map.getMapWidth(); j++)
        //     {
        //         if (map.getElement(i, j) != 'X')
        //         {
        //             v++;
        //         }
        //         Console.Write(map.getElement(i, j) + " ");
        //         if (map.getElement(i, j) == 'K')
        //         {
        //             Console.WriteLine("K");
        //             row = i;
        //             col = j;
        //             ind = v-1;
        //         }
        //     }
        //     Console.WriteLine();
        // }
        // // Console.WriteLine(v);
        // MyAlgo g = new MyAlgo(map.getMapSize());
        // int index = 0;
        // for (int i = 0; i < map.getMapHeight(); i++)
        // {
        //     for (int j = 0; j < map.getMapWidth(); j++)
        //     {
        //         if (map.getElement(i, j) != 'X')
        //         {
        //             // mapElmt m = new mapElmt(index, i, j);
        //             if (i > 0 && map.getElement(i - 1, j) != 'X')
        //             {
        //                 mapElmt m1 = new mapElmt(index - map.getMapWidth(), i - 1, j);
        //                 g.AddEdge(index, m1);
        //             }
        //             if (i < map.getMapHeight() - 1 && map.getElement(i + 1, j) != 'X')
        //             {
        //                 mapElmt m2 = new mapElmt(index + map.getMapWidth(), i + 1, j);
        //                 g.AddEdge(index, m2);
        //             }
        //             if (j > 0 && map.getElement(i, j - 1) != 'X')
        //             {
        //                 mapElmt m3 = new mapElmt(index - 1, i, j - 1);
        //                 g.AddEdge(index, m3);
        //             }
        //             if (j < map.getMapWidth() - 1 && map.getElement(i, j + 1) != 'X')
        //             {
        //                 mapElmt m4 = new mapElmt(index + 1, i, j + 1);
        //                 g.AddEdge(index, m4);
        //             }
        //             // v++;
        //         }
        //         index++;
        //         // Console.WriteLine(index);
        //     }
        // }
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
        MyAlgo g = new MyAlgo(map.getMapSize(), map);
        g.DFS();
        Console.WriteLine("\nBacktracking:");
        g.resetVisited();
        // g.DFSBack();/
        // g.dfs();

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