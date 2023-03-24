using Map;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Collections;
namespace Algo
{
    interface ICoordinate
    {
        int row { get; set;}
        int col { get; set;}
    }
    struct mapElmt : ICoordinate
    {
        public int index {get; set;}
        public int row { get; set;}
        public int col { get; set;}
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
        protected int v; // number of vertices
        protected List<mapElmt>[] adj; // adjacency list array of list mapElment
        protected mapElmt start; // start from map
        public List<bool> visited; // keep track of visited vertices
        public MyMap map; // map
        public int n_treasure; // number of treasure
        public int n_visited; // number of visited vertices
        public List<(int, int)> path; // list of tuple (point map)
        public List<char> step; // list of step to take : D, U, L, R
        // constructor
        public Solver(){
            this.path = new List<(int, int)>();
            this.step = new List<char>();
            this.v = 0;

            adj = new List<mapElmt>[v];
            for (int i = 0; i < v; ++i) adj[i] = new List<mapElmt>();

            // keep track of visited vertices
            visited = new List<bool>();
            
            for (int i = 0; i < v; i++) visited[i] = false; // set all vertices to false (not visited)

            map = new MyMap();
            n_treasure = 0;
            n_visited = 0;
        }
        public Solver(MyMap _map)
        {
            this.path = new List<(int, int)>();
            this.step = new List<char>();
            this.v = _map.getMapSize();
            
            adj = new List<mapElmt>[v];
            for (int i = 0; i < v; ++i) adj[i] = new List<mapElmt>();

            visited = new List<bool>(); // keep track of visited vertices
            for (int i = 0; i < v; i++){
                visited.Add(false); // set all vertices to false (not visited)
            } // set all vertices to false (not visited)
            
            map = _map;

            // initialize the start position from the map
            int ver = 0;
            int row = 0;
            int col = 0;
            int ind = 9;
            int tempIndex = 0;
            n_treasure = 0;
            n_visited = 0;
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
            // delete the old path and step
            this.path.Clear();
            this.step.Clear();
            this.path = new List<(int, int)>();
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
            n_visited = 0;
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
        // getter for the path
        public List<(int, int)> getPath()
        {
            return this.path;
        }
        // getter for the step
        public List<char> getStep()
        {
            return this.step;
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
        
            List<(int,int)> road = new List<(int,int)>();
            List<(int,int)> subRoad = new List<(int,int)>();


            TSPQueue.AddLast(this.start);
            this.visited[this.start.index] = true;
            this.path.Add((start.row,start.col));

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
                        this.path.Add((mapEl.row,mapEl.col));
                        if (map.getElement(mapEl.row, mapEl.col) == 'T')
                        {
                        
                            n_treasure--;

                            GetPathBFSAlgorithmStrategies(ref subRoad, startNode, mapEl);
                            foreach ((int,int) item in subRoad)
                            {
                                if (!road.Contains(item)) road.Add(item);
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
            foreach ((int,int) item in subRoad)
            {
                if (!road.Contains(item)) road.Add(item);
            }
            subRoad.Clear();

            this.path.Add((this.start.row,this.start.col));
            this.path.AddRange(road);
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
            this.path.Add((start.row,start.col));

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
// Console.Write($"-> ({mapEl.row},{mapEl.col}) {visited[mapEl.index]} ");
                    if (!this.visited[mapEl.index])
                    {
                        BFSQueue.AddLast(mapEl);
                        this.visited[mapEl.index] = true;
                        this.path.Add((mapEl.row,mapEl.col));
                        if (map.getElement(mapEl.row, mapEl.col) == 'T')
                        {
                            // update treasure count
                            n_treasure--;

// Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAA");
// Console.Write($"Start : {startNode.row},{startNode.col} -> ");
                            GetPathBFSAlgorithmStrategies(ref subRoad, startNode, mapEl);
                            foreach ((int,int) item in subRoad)
                            {
                                if (!road.Contains(item)) road.Add(item);
                            }
                            startNode = mapEl;
// Console.WriteLine($"End : {mapEl.row},{mapEl.col} == ");
// foreach (var item in subRoad)
// {
//     Console.Write($"({item.Item1},{item.Item2}) -> ");
// }
// Console.WriteLine("\nAAAAAAAAAAAAAAAAAAAAAAAA");
                            subRoad.Clear();

                            // BFSQueue.Clear();
                            BFSQueue.AddFirst(mapEl);
                        }
                    }
                }
            }
            this.path.Add((this.start.row,this.start.col));
            this.path.AddRange(road);
        }

        private void GetPathBFSAlgorithmStrategies(ref List<(int,int)> subRoad, mapElmt start_tile, mapElmt end_tile)
        {
            // Finding path from start_tile to end_tile with BFS
            // BFSQueue for BFS
            Queue<mapElmt> BFSQueue = new Queue<mapElmt>();
            Dictionary<(int,int),(int,int)> parentOf = new Dictionary<(int,int),(int,int)>();
            bool[] CopyVisited = this.visited.ToArray();

            BFSQueue.Enqueue(start_tile);
            CopyVisited[start_tile.index] = false;
            parentOf[(start_tile.row,start_tile.col)] = (-1,-1);

// Console.WriteLine("BBBBBBBBBBBBBBBBBBBBB");
            while (BFSQueue.Count != 0)
            {
                mapElmt currentElMap = BFSQueue.Dequeue(); // dequeue BFSQueue

                // visit semua adjacent vertices dari vertex saat ini
                foreach (mapElmt mapEl in this.adj[currentElMap.index])
                {
                    // jika adjacent vertex belum dikunjungi
// Console.Write($"-> ({mapEl.row},{mapEl.col}) {CopyVisited[mapEl.index]} ");
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
// Console.WriteLine("\nBBBBBBBBBBBBBBBBBBBBB");
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
                mapElmt current = DFSStack.Pop(); // pop DFSStack
                // if (DFSStack.Count == 0)
                //     Console.Write(current.index  + " " + current.row + " " + current.col); // print the vertex
                // else
                //     Console.Write(current.index  + " " + current.row + " " + current.col + " -> "); // print the vertex
                Console.Write(current.index + " " + current.row + " " + current.col + " -> "); // print the vertex

                // visit semua adjacent vertices dari vertex saat ini
                foreach (mapElmt i in adj[current.index])
                {
                    // jika adjacent vertex belum dikunjungi
                    // Console.WriteLine(i.index);

                    if (!visited[i.index])
                    {
                        // Console.WriteLine("uhuy");
                        visited[i.index] = true; // set true untuk adjacent vertex (visited)
                        DFSStack.Push(i); // push the adjacent vertex ke DFSStack
                        // push current to stack for backtracking in DFSStack

                        // update treasure count
                        if (map.getElement(i.row, i.col) == 'T')
                        {
                            n_treasure--;
                        }
                    }
                }
            }
        }
        public void dFSBack(mapElmt current, mapElmt pred, List <bool> visited, List<List<mapElmt>> pathUsed)
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
                        // add to path a tuple of u.row and u.col
                        this.path.Add((current.row, current.col));
                        // Console.WriteLine("AAAA " +n_treasure);
                        // return;  // ga harus return di sini 
                    }
                    Console.WriteLine("Nih " + current.index + " " + current.row + " " + current.col);
                }

                // print u row and col
                // Console.WriteLine("Nih " + u.index + " " + u.row + " " + u.col);

                // If all the node is visited return;
                if (n_visited == v || n_treasure == 0){
                    return;
                }
                // Mark not visited node as visited
                visited[current.index] = true;
                n_visited++;

                // Track the current edge
                pathUsed.Add(new List<mapElmt>() {pred, current});
                // add to path a tuple of current.row and current.col
                this.path.Add((current.row, current.col));

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
                        dFSBack(x, current, visited, pathUsed);
                    }
                }

                // Backtrack through the last visited nodes
                for (int y = 0; y < pathUsed.Count; y++)
                {
                    if (pathUsed[y][1].index == current.index)
                    {
                        dFSBack(pathUsed[y][0], current, visited, pathUsed);
                    }
                }
            }
        }

        public void dfsbacktrack()
        {
            Console.WriteLine("DFS Backtrack");
            // treasure count
            Console.WriteLine("treasure count " + n_treasure);

            // Vector to track last visited road
            List<List<mapElmt>> pathUsed = new List<List<mapElmt>>();

            mapElmt pred = new mapElmt(-1, -1, -1);
            // call the function
            dFSBack(this.start, pred, visited, pathUsed);
            Console.WriteLine("treasure count " + n_treasure);
            Console.WriteLine("Selesai");
        }
        public void printMap(){
            map.print();
        }
        public void setResult(){
            // result of path list<int,int>
            // print list of path
            Console.WriteLine("\nPath: ");
            foreach (var i in path)
            {
                // a,b -> c,d -> e,f if end of path
                if (i == path.Last())
                {
                    Console.Write(i.Item1 + "," + i.Item2 + "\n\n");
                }
                else
                {
                    Console.Write(i.Item1 + "," + i.Item2 + " -> ");
                }
            }
            // set list of step : U, D, L, R (up, down, left, right)
            foreach (var i in path){
                if (i != path.Last()){
                    // get next step
                    var next = path[path.IndexOf(i) + 1];
                    // get current step
                    var current = path[path.IndexOf(i)];
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
        public void tsp(){
            // travelling salesman problem
            // end point is start point

            // using dfs backtrack
            dfsbacktrack();
            // continue move to start point
            // find the next path to start point that is the shortest
            // get the last path
            var last = path.Last();
            // initialize new path with path in reverse order
            List<(int, int)> new_path = new List<(int, int)>();
            foreach (var i in path){
                new_path.Add(i);
            }
            new_path.Reverse();
            // remove the first path in new path
            new_path.RemoveAt(0);

            // find the path from last to start point
            // iterate the path from last to start point (backwards)
                  
            // concat the path with the new_path
            foreach (var i in new_path){
                path.Add(i);
            }
        }

        private int getDistance(mapElmt a, mapElmt b)
        {
            // Compute the Manhattan distance between two treasures
            return Math.Abs(a.row - b.row) + Math.Abs(a.col - b.col);
        }

        public void reset(){
            // reset all variable
            // reset visited
            resetVisited();
            // reset path
            path.Clear();
            // reset step
            step.Clear();
            // visited
            visited.Clear();
            // n_visited
            n_visited = 0;
            // Initialize all the visited with false
            for (int i = 0; i < v; i++)
            {
                visited.Add(false);
            }
        }
    }
}