using Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
namespace Algo
{
    interface ICoordinate
    {
        int row {get; set;}
        int col {get; set;}
    }
    struct mapElmt : ICoordinate
    {
        public int index {get; set;}
        public int row {get; set;}
        public int col {get; set;}
        public mapElmt(int index, int row, int col)
        {
            this.index = index;
            this.row = row;
            this.col = col;
        }

        public override string ToString()
        {
            return $"{index} ({row},{col})";
        }
    }
    class Solver
    {
        private int v; // number of vertices
        private List<mapElmt>[] adj; // adjacency list array of list mapElment
        private mapElmt start; // start from map
        private List<bool> visited; // keep track of visited vertices
        private MyMap map; // map
        private int n_treasure; // number of treasure
        private int n_visited; // number of visited vertices
        private List<(int, int)> scannedPath; // list of tuple (point map)
        private List<(int, int)> pathToTreasure;
        private List<char> step; // list of step to take : D, U, L, R
        public List<int> treasureIndex; // list of treasure index
        // constructor
        public Solver(){
            this.scannedPath = new List<(int, int)>();
            this.step = new List<char>();
            this.pathToTreasure = new List<(int, int)>();
            this.v = 0;

            adj = new List<mapElmt>[v];
            for (int i = 0; i < v; ++i) adj[i] = new List<mapElmt>();

            visited = new List<bool>();
            for (int i = 0; i < v; i++) visited[i] = false; // set all vertices to false (not visited)

            map = new MyMap();
            n_treasure = 0;
            this.n_visited = 0;
            treasureIndex = new List<int>();
        }
        public Solver(MyMap _map)
        {
            this.scannedPath = new List<(int, int)>();
            this.pathToTreasure = new List<(int, int)>();
            this.step = new List<char>();
            this.v = _map.getMapSize();
            
            adj = new List<mapElmt>[v];
            for (int i = 0; i < v; ++i) adj[i] = new List<mapElmt>();

            visited = new List<bool>();
            for (int i = 0; i < v; i++) visited.Add(false);
            
            
            map = _map;

            // initialize the start position from the map
            int ver = 0;
            int row = 0;
            int col = 0;
            int ind = 9;
            int tempIndex = 0;
            n_treasure = 0;
            this.n_visited = 0;
            treasureIndex = new List<int>();
            for (int i = 0; i < map.getMapHeight(); i++)
            {
                for (int j = 0; j < map.getMapWidth(); j++)
                {
                    // count treasure
                    if (map.getElement(i, j) == 'T')
                    {
                        n_treasure++;
                    }
                    if (map.getElement(i, j) != 'X')
                    {
                        ver++;
                    }
                    // Console.Write(map.getElement(i, j) + " ");
                    if (map.getElement(i, j) == 'K')
                    {
                        // Console.WriteLine("K");
                        row = i;
                        col = j;
                        ind = tempIndex;
                    }
                    tempIndex++;
                }
                // Console.WriteLine();
            }
            start = new mapElmt(ind, row, col);
            Console.WriteLine("Start at index " + start.index + " at row " + start.row + " and col " + start.col);


            // add edges to the graph from the map
            int index = 0;
            for (int i = 0; i < map.getMapHeight(); i++)
            {
                for (int j = 0; j < map.getMapWidth(); j++)
                {
                    // buat mapElmt
                    if (map.getElement(i, j) != 'X')
                    {
                        // mapElmt m = new mapElmt(index, i, j);
                        if (i < map.getMapHeight() - 1 && map.getElement(i + 1, j) != 'X')
                        {
                            mapElmt m2 = new mapElmt(index + map.getMapWidth(), i + 1, j);
                            AddEdge(index, m2);
                        }
                        if (j < map.getMapWidth() - 1 && map.getElement(i, j + 1) != 'X')
                        {
                            mapElmt m4 = new mapElmt(index + 1, i, j + 1);
                            AddEdge(index, m4);
                        }
                        if (i > 0 && map.getElement(i - 1, j) != 'X')
                        {
                            mapElmt m1 = new mapElmt(index - map.getMapWidth(), i - 1, j);
                            AddEdge(index, m1);
                        }
                        if (j > 0 && map.getElement(i, j - 1) != 'X')
                        {
                            mapElmt m3 = new mapElmt(index - 1, i, j - 1);
                            AddEdge(index, m3);
                        }
                        // v++;
                    }
                    // Console.WriteLine(index);
                    // print the adjacency list of index
                    Console.Write("Adjacency list of vertex " + index + ": ");
                    foreach (var u in adj[index])
                    {
                        Console.Write(u.index + ", ");
                    }
                    Console.WriteLine();
                    index++;
                }
            }
        }
        public void SolverSetter(MyMap _map){
            // delete the old scannedPath and step
            this.scannedPath.Clear();
            this.step.Clear();
            this.scannedPath = new List<(int, int)>();
            this.step = new List<char>();
            this.v = _map.getMapSize();
            adj = new List<mapElmt>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<mapElmt>();
            visited = new List<bool>(); // keep track of visited vertices
            for (int i = 0; i < v; i++)
                visited[i] = false; // set all vertices to false (not visited)
            map = _map;

            // initialize the start position from the map
            int ver = 0;
            int row = 0;
            int col = 0;
            int ind = 9;
            int tempIndex = 0;
            n_treasure = 0;
            this.n_visited = 0;
            List<int> treasureIndex = new List<int>();
            for (int i = 0; i < map.getMapHeight(); i++)
            {
                for (int j = 0; j < map.getMapWidth(); j++)
                {
                    // count treasure
                    if (map.getElement(i, j) == 'T')
                    {
                        n_treasure++;
                    }
                    if (map.getElement(i, j) != 'X')
                    {
                        ver++;
                    }
                    // Console.Write(map.getElement(i, j) + " ");
                    if (map.getElement(i, j) == 'K')
                    {
                        // Console.WriteLine("K");
                        row = i;
                        col = j;
                        ind = tempIndex;
                    }
                    tempIndex++;
                }
                // Console.WriteLine();
            }
            start = new mapElmt(ind, row, col);
        }

        // getter for map 
        public MyMap getMap()
        {
            return this.map;
        }
        // getter for the scannedPath
        public List<(int, int)> getScannedPath()
        {
            return this.scannedPath;
        }
        // getter for the step
        public List<char> getStep()
        {
            return this.step;
        }
        public List<(int, int)> getPathToTreasure()
        {
            return this.pathToTreasure;
        }
        // add an edge to the graph
        public void AddEdge(int u, mapElmt v)
        {
            adj[u].Add(v);
            // adj[v.index].Add(u);
            // Console.WriteLine(u + " " + v.index + " " + v.row + " " + v.col);
            // print();    
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
/* ==================================================================== TSP ==================================================================== */
        public void TSPAlgorithmStrategies()
        {
            LinkedList<mapElmt> TSPQueue = new LinkedList<mapElmt>();
        
            LinkedList<(int,int)> road = new LinkedList<(int,int)>();
            List<(int,int)> subRoad = new List<(int,int)>();


            TSPQueue.AddLast(this.start);
            this.visited[this.start.index] = true;
            this.scannedPath.Add((start.row,start.col));

            mapElmt startNode = this.start;
        
            while (TSPQueue.Count != 0 && n_treasure != 0)
            {
                mapElmt currentElMap = TSPQueue.First();
                TSPQueue.RemoveFirst();

            
                foreach (mapElmt mapEl in this.adj[currentElMap.index])
                {
                
                    if (!this.visited[mapEl.index])
                    {
                        TSPQueue.AddLast(mapEl);
                        this.visited[mapEl.index] = true;
                        this.scannedPath.Add((mapEl.row,mapEl.col));
                        if (map.getElement(mapEl.row, mapEl.col) == 'T')
                        {
                        
                            n_treasure--;

                            GetPathBFSAlgorithmStrategies(ref subRoad, startNode, mapEl);
                            foreach ((int,int) item in subRoad)
                            {
                                if (!road.Contains(item)) road.AddLast(item);
                            }
                            startNode = mapEl;

                            
                            subRoad.Clear();
                        
                            TSPQueue.AddFirst(mapEl);
                        }
                    }
                }
            }
            // Perbedaan dari TSP
            
            GetPathBFSAlgorithmStrategies(ref subRoad, startNode, this.start);
            subRoad.RemoveAt(0);
            foreach ((int,int) item in subRoad)
            {
               road.AddLast(item);
            }
            subRoad.Clear();

            // this.scannedPath.Add((this.start.row,this.start.col));
            // road.RemoveFirst();
            this.pathToTreasure.AddRange(road);
        }


/* ==================================================================== BFS ==================================================================== */
        public void BFSAlgorithmStrategies()
        {
            // BFSQueue for BFS
            LinkedList<mapElmt> BFSQueue = new LinkedList<mapElmt>();
            // List<mapElmt> checkedPattern  = new List<mapElmt>();
            List<(int,int)> road = new List<(int,int)>();
            List<(int,int)> subRoad = new List<(int,int)>();


            BFSQueue.AddLast(this.start); // enqueue start vertex ke BFSQueue
            this.visited[this.start.index] = true; // set to true start vertex (visited)
            this.scannedPath.Add((start.row,start.col));

            mapElmt startNode = this.start;
            // selama BFSQueue tidak kosong dan belum semua treasure terambil
            while (BFSQueue.Count != 0 && n_treasure != 0)
            {
                mapElmt currentElMap = BFSQueue.First(); // dequeue BFSQueue
                BFSQueue.RemoveFirst();

                // visit semua adjacent vertices dari vertex saat ini
                foreach (mapElmt mapEl in this.adj[currentElMap.index])
                {
                    // jika adjacent vertex belum dikunjungi
                    if (!this.visited[mapEl.index])
                    {
                        BFSQueue.AddLast(mapEl);
                        this.visited[mapEl.index] = true;
                        this.scannedPath.Add((mapEl.row,mapEl.col));
                        if (map.getElement(mapEl.row, mapEl.col) == 'T')
                        {
                            // update treasure count
                            n_treasure--;

                            GetPathBFSAlgorithmStrategies(ref subRoad, startNode, mapEl);
                            foreach ((int,int) item in subRoad)
                            {
                                if (!road.Contains(item)) road.Add(item);
                            }
                            startNode = mapEl;
                            subRoad.Clear();

                            // BFSQueue.Clear();
                            BFSQueue.AddFirst(mapEl);
                        }
                    }
                }
            }
            // this.scannedPath.Add((this.start.row,this.start.col));
            this.pathToTreasure.AddRange(road);
        }

        private void GetPathBFSAlgorithmStrategies(ref List<(int,int)> subRoad, mapElmt start_tile, mapElmt end_tile)
        {
            // Finding scannedPath from start_tile to end_tile with BFS
            // BFSQueue for BFS
            Queue<mapElmt> BFSQueue = new Queue<mapElmt>();
            Dictionary<(int,int),(int,int)> parentOf = new Dictionary<(int,int),(int,int)>();
            bool[] CopyVisited = this.visited.ToArray();

            BFSQueue.Enqueue(start_tile);
            CopyVisited[start_tile.index] = false;
            parentOf[(start_tile.row,start_tile.col)] = (-1,-1);

            while (BFSQueue.Count != 0)
            {
                mapElmt currentElMap = BFSQueue.Dequeue(); // dequeue BFSQueue

                // visit semua adjacent vertices dari vertex saat ini
                foreach (mapElmt mapEl in this.adj[currentElMap.index])
                {
                    // jika adjacent vertex belum dikunjungi
                    if (CopyVisited[mapEl.index])
                    {
                        BFSQueue.Enqueue(mapEl);
                        CopyVisited[mapEl.index] = false;
                        parentOf[(mapEl.row,mapEl.col)] = (currentElMap.row,currentElMap.col);
    

                        if (mapEl.index == end_tile.index)
                        {
                            // Start Finding road to all treasure
                            (int,int) tile = (mapEl.row,mapEl.col);
                            // road from start to end (start = start or Treasure)
                            while (tile != (-1,-1))
                            {
                                subRoad.Add(tile);
                                tile = parentOf[tile];
                            }
                        }
                    }
                }
            }
            subRoad.Reverse();
        }

/* ==================================================================== DFS ==================================================================== */
        public void resetVisited()
        {
            for (int i = 0; i < v; i++)
            {
                visited[i] = false;
            }
            // reset treasure count
            n_treasure = 0;
            for (int i = 0; i < map.getMapHeight(); i++)
            {
                for (int j = 0; j < map.getMapWidth(); j++)
                {
                    if (map.getElement(i, j) == 'T')
                    {
                        n_treasure++;
                    }
                }
            }
        }
        public void DFS()
        {
            // DFS
            Stack<mapElmt> DFSStack = new Stack<mapElmt>(); // DFSStack for DFS
            visited[start.index] = true; // set to true start vertex (visited)
            DFSStack.Push(start); // push start vertex ke DFSStack

            // Console.Write(DFSStack.Count);
            Console.WriteLine("Count: " + DFSStack.Count + "T: " + n_treasure);
            
            // selama DFSStack tidak kosong dan belum semua treasure terambil
            while (DFSStack.Count != 0 && n_treasure != 0)
            {
                // pop DFSStack 
                mapElmt current = DFSStack.Pop(); 
                Console.Write(current.index + " " + current.row + " " + current.col + " -> "); // print the vertex

                // visit semua adjacent vertices dari vertex saat ini
                foreach (mapElmt i in adj[current.index])
                {
                    // jika adjacent vertex belum dikunjungi
                    // Console.WriteLine(i.index);

                    if (!visited[i.index])
                    {
                        visited[i.index] = true; // set true untuk adjacent vertex (visited)
                        DFSStack.Push(i); // push adjacent vertex ke DFSStack

                        // update treasure count jika adjacent vertex adalah treasure
                        if (map.getElement(i.row, i.col) == 'T')
                        {
                            n_treasure--;
                        }
                    }
                }
            }
        }
        
        public void printMap(){
            map.print();
        }
        public void dfsbacktrack()
        {
            Console.WriteLine("DFS Backtrack");
            // treasure count
            Console.WriteLine("treasure count " + n_treasure);

            // Vector to track last visited road
            List<List<mapElmt>> pathUsed = new List<List<mapElmt>>();
            
            // stack for DFS from start to treasures
            Stack<mapElmt> DFSStack = new Stack<mapElmt>();


            // initialize pred to -1 (dummy value)
            mapElmt pred = new mapElmt(-1, -1, -1);

            // call the function
            dFSBack(this.start, pred, visited, pathUsed, DFSStack);
            Console.WriteLine("treasure count " + n_treasure);
            Console.WriteLine("Selesai");
            // print pathUsed
            // foreach (List<mapElmt> path in pathUsed)
            // {
            //     Console.WriteLine("Pathhhh");
            //     foreach (mapElmt mapEl in path)
            //     {
            //         Console.Write(mapEl.index + " " + mapEl.row + " " + mapEl.col + " -> ");
            //     }
            //     Console.WriteLine();
            // }
        }
        public void dFSBack(mapElmt current, mapElmt pred, List <bool> visited, List<List<mapElmt>> pathUsed, Stack<mapElmt> DFSStack)
        {
            // check if index is valid
            if (current.index != -1)
            {
                // check if get treasure
                if (map.getElement(current.row, current.col) == 'T' && !visited[current.index])
                {
                    n_treasure--;
                    if (n_treasure == 0){
                        Console.Write(current.index + " " + current.row + " " + current.col + " -> ");
                        // add to scannedPath a tuple of u.row and u.col
                        this.scannedPath.Add((current.row, current.col));
                        DFSStack.Push(current);
                        // Console.WriteLine("AAAA " +n_treasure);
                        // return;  // ga harus return di sini 
                    }
                    // treasureIndex.Add(scannedPath.Count - 1);
                    Console.WriteLine("Nih " + current.index + " " + current.row + " " + current.col);
                    // add stack to pathToTreasure
                    // while (DFSStack.Count != 0)
                    // {
                    //     mapElmt mapEl = DFSStack.Pop();
                    //     // Console.Write(mapEl.index + " " + mapEl.row + " " + mapEl.col + " -> ");
                    //     // add to scannedPath a tuple of u.row and u.col
                    //     this.scannedPath.Add((mapEl.row, mapEl.col));
                    // }
                    // (int,int) i1 = (start.row,start.col);
                    // (int,int) i2 = (current.row,current.col);
                    // add treasure index to treasureIndex
                    // int i1 = 0;
                    // int i2 = scannedPath.Count - 1;
                    // update treasurePath
                    // print jumlah scannedPath
                    Console.WriteLine("Jumlah scannedPath " + scannedPath.Count);
                    // getPathToTreasureDFS(i1, i2);
                    // pathToTreasure.Reverse();
                }

                // print u row and col
                // Console.WriteLine("Nih " + u.index + " " + u.row + " " + u.col);

                // If all the node is visited return;
                if (this.n_visited == v || n_treasure == 0){
                    return;
                }
                // Mark not visited node as visited
                visited[current.index] = true;
                this.n_visited++;

                // Track the current edge
                pathUsed.Add(new List<mapElmt>() {pred, current});
                // add to scannedPath a tuple of current.row and current.col
                this.scannedPath.Add((current.row, current.col));
                // add to DFSStack
                DFSStack.Push(current);

                // Print the node
                Console.Write(current.index + " " + current.row + " " + current.col + " -> ");
                // print jumlah adjancent node
                // Console.WriteLine("\nCount adj: " + adj[u.index].Count);

                // Check for not visited node and proceed with it.
                foreach (mapElmt x in adj[current.index])
                {
                    // Console.WriteLine(" adj: " + x.index + " " + x.row + " " + x.col );
                    // call the DFs function if not visited
                    if (!visited[x.index] && n_treasure != 0)
                    {
                        dFSBack(x, current, visited, pathUsed, DFSStack);
                    }
                }

                // int nPathUsed = 0;
                // Backtrack through the last visited nodes
                for (int y = 0; y < pathUsed.Count; y++)
                {
                    if (pathUsed[y][1].index == current.index)
                    {
                        // nPathUsed++;
                        dFSBack(pathUsed[y][0], current, visited, pathUsed, DFSStack);
                        // DFSStack.Pop();
                    }
                }
                // // if backtracking is done, pop the current node from the 
                // for (int y = 0; y < nPathUsed ; y++)
                // {
                //     // DFSStack.Pop();
                //     // if (pathUsed[y][1].index == current.index)
                //     // {
                //     //     DFSStack.Pop();
                //     // }
                // }
            }
        }
        public void getPathToTreasureDFS(int i1, int i2, List<(int,int)> subPath){
            // find path from last to first index of scannedPath with the skip index
            subPath.Clear();
            int idx = i2;
            var t = scannedPath[i2];
            subPath.Add(t);
            Console.WriteLine("scannedPath[i2] " + scannedPath[i2].Item1 + " " + scannedPath[i2].Item2);
            // idx--;
            while (subPath.Last() != scannedPath[i1]){
                // int count = 0;
                for (int i = i1; i < idx; i++){
                    t = scannedPath[i];
                    // change t to mapElmt 
                    // cek apakah t adjacent dengan subPath.Last()
                    if ( (isAdjacent(t, subPath.Last()) && scannedPath[i+1]==subPath.Last() ) || t == scannedPath[idx-1]){
                        // add to subPath
                        subPath.Add(t);
                        // decrement idx
                        idx--;
                        break;
                    }
                }
            }
            // reverse subPath
            subPath.Reverse();            
        }
        public void setPathToTreasure(){
            // add index tresure from scannedPath to treasureIndex
            for (int i = 0; i < scannedPath.Count; i++){
                // kondisi jika scannedPath[i] == 'T'
                if (map.getElement(scannedPath[i].Item1,scannedPath[i].Item2) == 'T'){
                    // add to treasureIndex
                    if (treasureIndex.Count == 0) 
                        treasureIndex.Add(i);
                    // add to treasureIndex if i tidak sama dengan sebelumnya 
                    else if (scannedPath[i] != scannedPath[treasureIndex.Last()]){
                        treasureIndex.Add(i);
                    }
                }
            }
            
            // add path to tresureIndex 
            List<(int, int)> subPath  = new List<(int, int)>();
            getPathToTreasureDFS(0, treasureIndex[0], subPath);
            
            // call getPathToTreasureDFS 
            getPathToTreasureDFS(0, treasureIndex[0], subPath);
            foreach (var j in subPath){
                pathToTreasure.Add(j);
            }
            for (int i = 0; i < treasureIndex.Count - 1; i++){
                getPathToTreasureDFS(treasureIndex[i], treasureIndex[i+1], subPath);
                // add subPath to pathToTreasure
                foreach (var j in subPath){
                    // add if current element is not the same as the last element
                    if (pathToTreasure.Count == 0 || j != pathToTreasure.Last())
                        pathToTreasure.Add(j);
                }
            }

        }
        public void setResult(){
            // result of scannedPath list<int,int>
            // print list of scannedPath
            Console.WriteLine("\nPath: ");
            foreach (var i in scannedPath)
            {
                // a,b -> c,d -> e,f if end of scannedPath
                if (i == scannedPath.Last())
                {
                    Console.Write(i.Item1 + "," + i.Item2 + "\n\n");
                }
                else
                {
                    Console.Write(i.Item1 + "," + i.Item2 + " -> ");
                }
            }
            // set list of step : U, D, L, R (up, down, left, right)
            foreach (var i in scannedPath){
                if (i != scannedPath.Last()){
                    // get next step
                    var next = scannedPath[scannedPath.IndexOf(i) + 1];
                    // get current step
                    var current = scannedPath[scannedPath.IndexOf(i)];
                    // check if next step is up
                    if (next.Item1 < current.Item1){
                        step.Add('U');
                    }
                    // check if next step is down
                    else if (next.Item1 > current.Item1){
                        step.Add('D');
                    }
                    // check if next step is left
                    else if (next.Item2 < current.Item2){
                        step.Add('L');
                    }
                    // check if next step is right
                    else if (next.Item2 > current.Item2){
                        step.Add('R');
                    }
                    Console.Write(step.Last() + " -> ");
                }
            }
            
        }
        public void DFSTsp(){
            // using dfs backtrack
            dfsbacktrack();
            // set path to treasure
            setPathToTreasure();   
 
            // initialize new scannedPath with scannedPath in reverse order
            List<(int, int)> new_path = pathToTreasure.ToList();
            new_path.Reverse();
            // remove the first scannedPath in new scannedPath
            new_path.RemoveAt(0);
                  
            // concat the scannedPath with the new_path
            foreach (var i in new_path){
                pathToTreasure.Add(i);
            }
        }
        private int getDistance(mapElmt a, mapElmt b)
        {
            // Compute the Manhattan distance between two treasures
            return Math.Abs(a.row - b.row) + Math.Abs(a.col - b.col);
        }
        private bool isAdjacent((int,int) a, (int,int) b)
        {
            // Check if two treasures are adjacent
            return (Math.Abs(a.Item1 - b.Item1) + Math.Abs(a.Item2 - b.Item2) == 1);
        }
        public void reset(){
            // reset all variable
            // reset visited
            resetVisited();
            // reset pathToTreasure
            pathToTreasure.Clear();
            // reset scannedPath
            scannedPath.Clear();
            // reset step
            step.Clear();
            // visited
            visited.Clear();
            // this.n_visited
            this.n_visited = 0;
            // Initialize all the visited with false
            for (int i = 0; i < v; i++)
            {
                visited.Add(false);
            }
            // reset treasureIndex
            treasureIndex.Clear();
        }
        public void printPathToTreasure(){
            // print path to treasure
            Console.WriteLine("\nPath to treasure: ");
            foreach (var i in pathToTreasure)
            {
                // a,b -> c,d -> e,f if end of scannedPath
                Console.WriteLine(i.Item1 + "," + i.Item2 + " -> ");
            }
        }
    }
}