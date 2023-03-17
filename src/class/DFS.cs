// program for DFS Voyager with a class
using System;
using myMap;

namespace Algorithm{
    public class DFS : Algorithm
    {
        public DFS()
        {
            treasureFound = 0;
            mapData = new map();
        }

        public DFS(map data)
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
        public override void print(){
            Console.WriteLine("Hello DFS");
        }
    }
};