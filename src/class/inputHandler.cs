using System;
using System.IO;

namespace inputHandler
{
    public class inputHandlerFile
    {
        private string[] inputFileData;

        public inputHandlerFile()
        {
            inputFileData = new string[0];
        }

        public int getNumberOfLines()
        {
            return inputFileData.Length;
        }

        public int getNumberOfRows()
        {
            return inputFileData[0].Length;
        }
        
        public string[] getInputData()
        {
            return inputFileData;
        }

        public void ReadFile(string path)
        {
            if (File.Exists(path)) {
                inputFileData = File.ReadAllLines(path);
                for (int i = 0; i < inputFileData.Length; i++) {
                    inputFileData[i] = inputFileData[i].Replace(" ", "");
                }
            } else {
                Console.WriteLine("File does not exist!");
            }
        }
    }

    public class inputHandlerCommand
    {
        private int command;

        public inputHandlerCommand()
        {
            command = 0;
        }

        public int getCommand()
        {
            return command;
        }

        public void input(int min, int max)
        {
            while (true) {
                command = Convert.ToInt32(Console.ReadLine());
                if (command >= min && command <= max) {
                    break;
                } else {
                    Console.WriteLine("Please enter a valid input! (" + min + "/" + max + ")");
                }
            }
        }
    }
}