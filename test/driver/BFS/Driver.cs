using System;
using Algo;
using System.Collections.Generic;
using Map;
using InputHandler;

class DriverBFS
{
    static void Main(string[] args)
    {
        InputHandlerFile inputHandlerFile = new InputHandlerFile();
        inputHandlerFile.readFile("../../TestInput4.txt");
        MyMap map = new MyMap(inputHandlerFile.getInputData());
        MyAlgo g = new MyAlgo(map.getMapSize(), map);
        BFS bfs = new BFS(g);
        bfs.printMap();
        bfs.BFSMethod();
    }
}