// using System;
// using Map;

// namespace Algorithm
// {
//     public class DFS : MyAlgorithm
//     {
//         public DFS()
//         {
//             treasureFound = 0;
//             mapData = new MyMap();
//         }

//         public DFS(MyMap data)
//         {
//             treasureFound = 0;
//             mapData = data;
//             // matrix of adjacencies
//             // graph, 1 if there is a path, 0 if there is no path -> tree -> linked l
//             // adj = new int[mapData.getMapSize()][];

//             int h = mapData.getMapHeight();
//             int w = mapData.getMapWidth();
//             // initialize adj matrix

//             visited = new bool[h,w]; 
//             // initialize visited matrix with 1 or 0 if there is a path or not
//             for (int i = 0; i < h; i++)
//             {   
//                 for (int j = 0; j < w; j++)
//                 {
//                     visited[i,j] = false;
//                 }
//             }

//             // for (int i = 0; i < mapData.getMapSize(); i++)
//             // {
//             //     // adj[i] = new int[mapData.getMapSize()];
//             //     for (int j = 0; j < mapData.getMapSize(); j++)
//             //     {
//             //         // adj[i][j] = 0;
//             //     }
//             // }
//             // initialize visited matrix with 1 or 0 if there is a path or not 
//                     // mapData element is 'R' is a path, K is a start, T is a treasure, and X is a wall
//                     // if(mapData.getElement(i, j) == 'R'){
//                     //     visited[i,j] = true;
//                     // } else {
//                     //     visited[i,j] = false;
//                     // }
//                 // initialize visited matrix with 1 or 0 if there is a path or not 
//                 // mapData element is 'R' is a path, K is a start, T is a treasure, and X is a wall

//                 // if(mapData.getElement(i/mapData.getMapWidth(), i%mapData.getMapWidth()) == 'R'){
//                 //     visited[i] = new int[mapData.getMapSize()];
//                 //     for (int j = 0; j < mapData.getMapSize(); j++)
//                 //     {
//                 //         if(mapData.getElement(j/mapData.getMapWidth(), j%mapData.getMapWidth()) == 'R'){
//                 //             visited[i][j] = 1;
//                 //         } else {
//                 //             visited[i][j] = 0;
//                 //         }
//                 //     }
//                 // } else {
//                 //     visited[i] = new int[0];
//                 // }

//         }

//         public void printMap(){
//             mapData.print();
//         }

//         // public void printVisMatrix(){
//         //     // print adj matrix
//         //     int h = mapData.getMapHeight();
//         //     int w = mapData.getMapWidth();
//         //     Console.WriteLine("Map Height: " + h);
//         //     Console.WriteLine("Map Width: " + w);
//         //     Console.WriteLine("vis Matrix");
//         //     for(int i = 0; i < h; i++){
//         //         for (int j = 0; j < w; j++){
//         //             Console.Write(visited[i,j]);
//         //         }
//         //         Console.WriteLine();
//         //     }
//         // }

//         public void DFSMethod(int row, int col)
//         {
//             // visited[v] = true;
//             // for (int i = 0; i < adj[v].Length; i++)
//             // {
//             //     if (adj[v][i] == 1 && !visited[i])
//             //     {
//             //         DFSMethod(i);
//             //     }
//             // }
//             // visited[v] = true; 
//             int i = 0;
//             while(treasureFound < treasure){
//                 if(mapData.getElement(row, col) == 'T'){
//                     treasureFound++;
                    
//                 }
//                 // if (mapData.getElement())
//                 // if (adj[v][i] == 1 && !visited[i])
//                 // {
//                 //     // print map with treasure found change to 'x'
//                 //     DFSMethod(i);
//                 // }
//                 i++;
//             }
//         }

//         public override void print()
//         {
//             Console.WriteLine("Hello DFS");
//         }
//     }
// }