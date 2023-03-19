using System;
using System.Collections.Generic;
struct mapElmt
{
    public int index;
    public int row;
    public int col;
    public mapElmt(int index, int row, int col)
    {
        this.index = index;
        this.row = row;
        this.col = col;
    }
}
namespace Graph{
    class MyGraph
    {
        private int v; // number of vertices
        // private List<(int,int)>[] adj; // adjacency list
        private List<mapElmt>[] adj; // adjacency list

        // constructor
        public MyGraph(int vertices)
        {
            v = vertices;
            adj = new List<mapElmt>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<mapElmt>();
            // adj = new List<mapElmt>[4];
            // for (int i = 0; i < 4; ++i)
            //     adj[i] = new List<mapElmt>();
        }

        // add an edge to the graph
        public void AddEdge(int u, mapElmt v)
        {
            adj[u].Add(v);
            // adj[u].Add((v1,v2));
        }

        public void print()
        {
            for (int i = 0; i < v; ++i)
            {
                Console.Write(i + " -> ");
                foreach (mapElmt j in adj[i])
                    Console.Write("(" + j.index + " " + j.row + " " + j.col + ") ");
                Console.WriteLine();
            }
        }

        public void DFS(mapElmt start)
        {
            bool[] visited = new bool[v]; // keep track of visited vertices
            Stack<(mapElmt, int)> DFSStack = new Stack<(mapElmt, int)>(); // DFSStack for DFS

            visited[start.index] = true; // set to true start vertex (visited)
            DFSStack.Push((start, 0)); // push start vertex ke DFSStack

            while (DFSStack.Count != 0)
            {
                (mapElmt current, int depth) = DFSStack.Pop(); // pop DFSStack

                Console.Write(current.index + " "); // print the vertex

                // visit semua adjacent vertices dari vertex saat ini
                foreach (mapElmt i in adj[current.index])
                {
                    if (!visited[i.index])
                    {
                        visited[i.index] = true; // set true untuk adjacent vertex (visited)
                        DFSStack.Push((i, depth + 1)); // push the adjacent vertex ke DFSStack
                    }
                }
            }
        }
    }
}