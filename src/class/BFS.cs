using System;
using Map;

namespace Algorithm{
    public class BFS : MyAlgorithm
    {
        public BFS()
        {
            this.treasureFound = 0;
            this.mapData = new MyMap();
            this.treasure = 0;
            this.adj = new bool[mapData.getMapHeight(), mapData.getMapWidth()];
            this.visited = new bool[1,1];
            this.stack = new (int,int)[1];
        }

        public BFS(MyMap maps)
        {
            this.treasureFound = 0;
            this.mapData = maps;
        }
        public override void print()
        {
            Console.WriteLine("Hello BFS");
        }


    }
}