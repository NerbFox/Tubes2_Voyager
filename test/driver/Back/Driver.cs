using System;
using System.Collections.Generic;
using GraphAlgorithms;

class DriverBack
{
    static void Main(string[] args)
    {
        // create a sample graph
        Graph g = new Graph(5);
        g.AddEdge(0, 1);
        g.AddEdge(0, 2);
        g.AddEdge(1, 2);
        g.AddEdge(1, 3);
        g.AddEdge(2, 3);
        g.AddEdge(3, 4);

        // run DFS with backtracking
        bool[] visited = new bool[g.V];
        List<int> path = new List<int>();
        g.DFS(0, visited, path);
    }
}