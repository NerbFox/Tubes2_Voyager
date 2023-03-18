using System;
using Algorithm;
using inputHandler;
using Map;

class driverDFS
{
    static void Main(string[] args)
    {
        inputHandlerFile inputHandlerFile = new inputHandlerFile();
        inputHandlerFile.readFile("../../testInput3.txt");    
        map map = new map(inputHandlerFile.getInputData());
        DFS dfs = new DFS(map);
        dfs.printMap();  
        dfs.print();  
        int i = 0; 
    }
}