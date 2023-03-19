using System;
using InputHandler;
using Map;

class DriverMap
{
    static void Main(string[] args)
    {
        InputHandlerFile file = new InputHandlerFile();
        file.readFile("../../TestInput3.txt");
        MyMap map = new MyMap(file.getInputData());
        Console.WriteLine(map.getMapWidth());
        Console.WriteLine(map.getMapHeight());
        Console.WriteLine(map.getMapSize());
        char[,] data = map.getMapData();
        for (int row = 0; row < data.GetLength(0); row++) {
            for (int col = 0; col < data.GetLength(1); col++) {
                Console.Write(data[row, col] + " ");
            }
            Console.WriteLine();
        }
        map.print();
    }
}