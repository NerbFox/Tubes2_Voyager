using System;
using InputHandler;

class DriverInputHandler
{
    static void Main(string[] args)
    {
        InputHandlerFile file = new InputHandlerFile();
        InputHandlerCommand command = new InputHandlerCommand();
        file.readFile("../../TestInput2.txt");
        string[] data = file.getInputData();
        for (int i = 0; i < data.Length; i++) {
            Console.WriteLine(data[i]);
        }
        file.getNumberOfLines();
        file.getNumberOfRows();

        Console.WriteLine("Command Input:");
        command.input(1, 3);
        Console.WriteLine(command.getCommand());
    }
}