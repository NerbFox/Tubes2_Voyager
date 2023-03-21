using System;
using System.Collections.Generic;

namespace GraphAlgorithms
{
    public class Graph
    {
        public int V; // number of vertices
        private List<int>[] adj; // adjacency list

        // constructor
        public Graph(int v)
        {
            V = v;
            adj = new List<int>[V];
            for (int i = 0; i < V; i++)
            {
                adj[i] = new List<int>();
            }
        }

        // add an edge to the graph
        public void AddEdge(int u, int v)
        {
            adj[u].Add(v);
            adj[v].Add(u);
        }

        // DFS with backtracking
        public void DFS(int u, bool[] visited, List<int> path)
        {
            visited[u] = true;
            path.Add(u);

            if (path.Count == V)
            {
                Console.WriteLine(string.Join(" -> ", path)); // print the path
            }
            else
            {
                foreach (int v in adj[u])
                {
                    if (!visited[v])
                    {
                        DFS(v, visited, path);
                    }
                }
            }

            visited[u] = false;
            path.RemoveAt(path.Count - 1);
        }
    }

    class Program
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
}