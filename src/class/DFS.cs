using System;
using Map;

namespace Algorithm
{
    public class DFS : MyAlgorithm
    {
        public DFS()
        {
            treasureFound = 0;
            mapData = new MyMap();
        }

        public DFS(MyMap data)
        {
            treasureFound = 0;
            mapData = data;
        }

        public void printMap(){
            mapData.print();
        }

        public void DFSMethod(int v, char Map)
        {
            // // mark v as visited
            // visited[v] = true;
            // // for each vertex w adjacent to v
            // for (int w : G.adj(v))
            // {
            //     // if w is not visited
            //     if (!visited[w])
            //     {
            //         // recursively visit w
            //         DFS(w);
            //     }
            // }
        }

        public override void print()
        {
            Console.WriteLine("Hello DFS");
        }
    }
}