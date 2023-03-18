using System;
using Algorithm;
using InputHandler;
using Map;

class DriverDFS
{
    static void Main(string[] args)
    {
        InputHandlerFile inputHandlerFile = new InputHandlerFile();
        inputHandlerFile.readFile("../../testInput3.txt");    
        MyMap map = new MyMap(inputHandlerFile.getInputData());
        DFS dfs = new DFS(map);
        dfs.printMap();  
        dfs.print();  
        int i = 0; 
    }
}