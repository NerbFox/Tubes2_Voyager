using Map;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Algo
{
    struct mapElmt
    {
        public int index;
        public int row;
        public int col;
        public int n_visited;
        public mapElmt(int index, int row, int col)
        {
            this.index = index;
            this.row = row;
            this.col = col;
            this.n_visited = 0;

        }
    }
    class MyAlgo
    {
        protected int v; // number of vertices
        // private List<(int,int)>[] adj; // adjacency list
        protected List<mapElmt>[] adj; // adjacency list array of list map elmt
        protected mapElmt start;
        public bool[] visited;
        public MyMap map;
        public int n_treasure;
        // list of tuple index map
        public List<(int, int)> path;
        // list of step to take : D, U, L, R
        public List<char> step;
        // constructor
        public MyAlgo(){
            this.path = new List<(int, int)>();
            this.step = new List<char>();
            this.v = 0;
            adj = new List<mapElmt>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<mapElmt>();
            visited = new bool[v]; // keep track of visited vertices
            for (int i = 0; i < v; i++)
                visited[i] = false; // set all vertices to false (not visited)
            map = new MyMap();
            n_treasure = 0;
        }
        public MyAlgo(MyMap _map)
        {
            this.path = new List<(int, int)>();
            this.step = new List<char>();
            this.v = _map.getMapSize();
            adj = new List<mapElmt>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<mapElmt>();
            visited = new bool[v]; // keep track of visited vertices
            for (int i = 0; i < v; i++)
                visited[i] = false; // set all vertices to false (not visited)
            map = _map;

            // initialize the start position from the map
            int ver = 0;
            int row = 0;
            int col = 0;
            int ind = 9;
            n_treasure = 0;
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
                        ind = ver - 1;
                    }
                }
                // Console.WriteLine();
            }
            start = new mapElmt(ind, row, col);


            // add edges to the graph from the map
            int index = 0;
            mapElmt m = new mapElmt(0, 0, 0);
            for (int i = 0; i < map.getMapHeight(); i++)
            {
                for (int j = 0; j < map.getMapWidth(); j++)
                {
                    // buat mapElmt
                    if (map.getElement(i, j) != 'X')
                    {
                        // mapElmt m = new mapElmt(index, i, j);
                        if (i > 0 && map.getElement(i - 1, j) != 'X')
                        {
                            mapElmt m1 = new mapElmt(index - map.getMapWidth(), i - 1, j);
                            AddEdge(index, m1);
                        }
                        if (i < map.getMapHeight() - 1 && map.getElement(i + 1, j) != 'X')
                        {
                            mapElmt m2 = new mapElmt(index + map.getMapWidth(), i + 1, j);
                            AddEdge(index, m2);
                        }
                        if (j > 0 && map.getElement(i, j - 1) != 'X')
                        {
                            mapElmt m3 = new mapElmt(index - 1, i, j - 1);
                            AddEdge(index, m3);
                        }
                        if (j < map.getMapWidth() - 1 && map.getElement(i, j + 1) != 'X')
                        {
                            mapElmt m4 = new mapElmt(index + 1, i, j + 1);
                            AddEdge(index, m4);
                        }
                        // v++;
                    }
                    index++;
                    // Console.WriteLine(index);
                }
            }
            // adj = new List<mapElmt>[4];
            // for (int i = 0; i < 4; ++i)
            //     adj[i] = new List<mapElmt>();

            // adj = new List<List<mapElmt>>(vertices);
            // visited = new bool[vertices]; // set the size of the "visited" array to the total number of vertices
            // for (int i = 0; i < vertices; i++)
            // {
            //     adjList.Add(new List<mapElmt>());
            //     visited[i] = false;
            // }
        }
        public void MyAlgoSetter(MyMap _map){
            // delete the old path and step
            this.path.Clear();
            this.step.Clear();
            this.path = new List<(int, int)>();
            this.step = new List<char>();
            this.v = _map.getMapSize();
            adj = new List<mapElmt>[v];
            for (int i = 0; i < v; ++i)
                adj[i] = new List<mapElmt>();
            visited = new bool[v]; // keep track of visited vertices
            for (int i = 0; i < v; i++)
                visited[i] = false; // set all vertices to false (not visited)
            map = _map;

            // initialize the start position from the map
            int ver = 0;
            int row = 0;
            int col = 0;
            int ind = 9;
            n_treasure = 0;
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
                        ind = ver - 1;
                    }
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

        public void DFS()
        {
            // stack of path for backtracking
            // Stack<(mapElmt, int)> path = new Stack<(mapElmt, int)>();

            // DFS
            Stack<(mapElmt, int)> DFSStack = new Stack<(mapElmt, int)>(); // DFSStack for DFS
            visited[start.index] = true; // set to true start vertex (visited)
            DFSStack.Push((start, 0)); // push start vertex ke DFSStack
            // Console.Write(DFSStack.Count);

            // selama DFSStack tidak kosong dan belum semua treasure terambil
            while (DFSStack.Count != 0 && n_treasure != 0)
            {
                (mapElmt current, int depth) = DFSStack.Pop(); // pop DFSStack
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
                        DFSStack.Push((i, depth + 1)); // push the adjacent vertex ke DFSStack
                        // push current to stack for backtracking in DFSStack
                        // DFSStack.Push((current, depth));

                        // update treasure count
                        if (map.getElement(i.row, i.col) == 'T')
                        {
                            n_treasure--;
                        }
                        // update path
                        // path.Push((i, depth + 1));
                    }
                    // print i
                    // Console.Write("b " + i.index + " " + i.row + " " + i.col + " -> ");

                    // // print path
                    // foreach (mapElmt j in path)
                    // {
                    //     Console.Write("b " + j.index + " " + j.row + " " + j.col + " -> ");
                    // }

                }
            }
        }

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
        public void dFSBack(mapElmt u, int node, bool[] visited,
                        List<List<mapElmt>> road_used,
                        mapElmt parent, int it)
        {
            // check if index is valid
            if (u.index != -1)
            {
                int c = 0;

                // Check if all the node is visited or not
                // and count visited nodes  /
                for (int i = 0; i < node; i++)
                    if (visited[i])
                        c++;

                // print u row and col
                // Console.WriteLine("Nih " + u.index + " " + u.row + " " + u.col);

                // check if get treasure
                if (map.getElement(u.row, u.col) == 'T' && !visited[u.index])
                {
                    n_treasure--;
                    if (n_treasure == 0){
                        Console.Write(u.index + " " + u.row + " " + u.col + " -> ");
                        // add to path a tuple of u.row and u.col
                        this.path.Add((u.row, u.col));
                    }
                    Console.WriteLine("Nih " + u.index + " " + u.row + " " + u.col);
                }

                // If all the node is visited return;
                if (c == node || n_treasure == 0)
                    return;

                // Mark not visited node as visited
                visited[u.index] = true;

                // Track the current edge
                road_used.Add(new List<mapElmt>() { parent, u });

                // Print the node
                Console.Write(u.index + " " + u.row + " " + u.col + " -> ");
                // add to path a tuple of u.row and u.col
                this.path.Add((u.row, u.col));

                // Check for not visited node and proceed with it.
                foreach (mapElmt x in adj[u.index])
                {
                    // call the DFs function if not visited
                    if (!visited[x.index])
                    {
                        dFSBack(x, node, visited, road_used, u,
                                it + 1);
                    }
                }

                // Backtrack through the last
                // visited nodes
                for (int y = 0; y < road_used.Count; y++)
                {
                    if (road_used[y][1].index == u.index)
                    {
                        dFSBack(road_used[y][0], node, visited,
                                road_used, u, it + 1);
                    }
                }
            }
        }

        public void dfsbacktrack()
        {
            Console.WriteLine("DFS Backtrack");
            // treasure count
            Console.WriteLine("treasure count " + n_treasure);
            // Create a array of visited node
            bool[] visited = new bool[v];

            // Vector to track last visited road
            List<List<mapElmt>> road_used = new List<List<mapElmt>>();

            // Initialize all the v with false
            for (int i = 0; i < v; i++)
            {
                visited[i] = false;
            }
            mapElmt parent = new mapElmt(-1, -1, -1);
            // call the function
            dFSBack(this.start, v, visited, road_used, parent, 0);
            Console.WriteLine("treasure count " + n_treasure);
        }
        public void printMap(){
            map.print();
        }
        public void setResult(){
            // result of path list<int,int>
            // print list of path
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
            // using nearest neighbour algorithm
        }
    }
}