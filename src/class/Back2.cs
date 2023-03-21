// C# program for the above approach
using System;
using System.Collections.Generic;

public class GFG
{
    static int N = 1000;
    static List<List<int>> adj = new List<List<int>>();

    // Function to print the complete DFS-traversal
    static void dFSBack(int u, int node, bool[] visited,
                        List<List<int>> road_used,
                        int parent, int it)
    {
        int c = 0;

        // Check if all the node is visited or not
        // and count visited nodes  /
        for (int i = 0; i < node; i++)
            if (visited[i])
                c++;

        // If all the node is visited return;
        if (c == node)
            return;

        // Mark not visited node as visited
        visited[u] = true;

        // Track the current edge
        road_used.Add(new List<int>() { parent, u });

        // Print the node
        Console.Write(u + " ");

        // Check for not visited node and proceed with it.
        foreach (int x in adj[u])
        {
            // call the DFs function if not visited
            if (!visited[x])
            {
                dFSBack(x, node, visited, road_used, u,
                        it + 1);
            }
        }
        // Backtrack through the last
        // visited nodes
        for (int y = 0; y < road_used.Count; y++)
        {
            if (road_used[y][1] == u)
            {
                dFSBack(road_used[y][0], node, visited,
                        road_used, u, it + 1);
            }
        }
    }

    // Function to call the DFS function
    // which prints the DFS-traversal stepwise
    static void dfsbacktrack(int node)
    {
        // Create a array of visited node
        bool[] visited = new bool[node];

        // Vector to track last visited road
        List<List<int>> road_used = new List<List<int>>();

        // Initialize all the node with false
        for (int i = 0; i < node; i++)
        {
            visited[i] = false;
        }

        // call the function
        dFSBack(0, node, visited, road_used, -9999, 0);
    }

    // Function to insert edges in Graph
    static void insertEdge(int u, int v)
    {
        adj[u].Add(v);
        // adj[v].Add(u);
    }
}
// public void DFSBack(){
//     resetVisited();
//     // backtracking DFS
//     Console.WriteLine("Backtracking DFS");
//     bool[] visited = new bool[v];
//     List<mapElmt> path = new List<mapElmt>();
//     DFSBacktracking(start, visited, path);
// }
// public void DFSBacktracking(mapElmt u, bool[] visited, List<mapElmt> path)
// {
//     visited[u.index] = true;
//     path.Add(u);

//     if (path.Count == v)
//     {
//         Console.WriteLine(v);
//         // Console.WriteLine(string.Join(" -> ", path)); 
//         // print the path
//         foreach (mapElmt elmt in path){
//             Console.WriteLine(elmt.index + " " + elmt.row + " " + elmt.col + " -> ");
//         }
//     }
//     else
//     {
//         foreach (mapElmt v in adj[u.index])
//         {
//             if (!visited[v.index])
//             {
//                 DFSBacktracking(v, visited, path);
//             }
//         }
//     }
//     visited[u.index] = false;
//     path.RemoveAt(path.Count - 1);

// }