using System;
using System.IO;
using System.Text.RegularExpressions;

namespace InputHandler
{
    public class InputHandlerFile
    {
        private string[] inputFileData;
        private bool isValid;

        public InputHandlerFile()
        {
            inputFileData = new string[0];
            isValid = true;
        }

        public int getNumberOfLines()
        {
            return inputFileData.Length;
        }

        public int getNumberOfRows()
        {
            return inputFileData[0].Length;
        }

        public bool isValidFile()
        {
            return isValid;
        }
        
        public string[] getInputData()
        {
            return inputFileData;
        }

        public void readFile(string path)
        {
            if (File.Exists(path)) {
                // check if file contains only 'X', 'R', 'T', or 'K'
                Regex regex = new Regex(@"^[XRTK]+$");
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++) {
                    lines[i] = lines[i].Replace(" ", "");
                }
                for (int i = 0; i < lines.Length; i++) {
                    if (!regex.IsMatch(lines[i])) {
                        isValid = false;
                    }
                }
                inputFileData = lines;
            } 
            else 
            {
                isValid = false;
            }
        }
    }
}