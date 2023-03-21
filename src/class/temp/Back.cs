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
}