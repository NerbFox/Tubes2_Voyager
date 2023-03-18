using System;
using inputHandler;
using Map;

class driverMap
{
    static void Main(string[] args)
    {
        inputHandlerFile file = new inputHandlerFile();
        file.readFile("../../testInput3.txt");
        map map = new map(file.getInputData());
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