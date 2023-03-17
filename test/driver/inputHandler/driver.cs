using System;

namespace inputHandler
{
    class driverInputHandler
    {
        static void Main(string[] args)
        {
            inputHandlerFile file = new inputHandlerFile();
            inputHandlerCommand command = new inputHandlerCommand();
            file.ReadFile("../../testInput.txt");
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
}