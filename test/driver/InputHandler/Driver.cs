using System;
using InputHandler;

class DriverInputHandler
{
    static void Main(string[] args)
    {
        InputHandlerFile file = new InputHandlerFile();
        file.readFile("../../TestInput3.txt");
        Console.WriteLine(file.isValidFile());
        string[] data = file.getInputData();
        for (int i = 0; i < data.Length; i++) {
            Console.WriteLine(data[i]);
        }
        file.getNumberOfLines();
        file.getNumberOfRows();
    }
}