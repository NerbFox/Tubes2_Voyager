using System;

namespace Map
{
    public class MyMap
    {
        private char[,] mapData;
        private int mapWidth;
        private int mapHeight;
        private int mapSize;

        public MyMap()
        {
            mapData = new char[0, 0];
            mapWidth = 0;
            mapHeight = 0;
            mapSize = 0;
        }

        public MyMap(string[] data)
        {
            mapWidth = data[0].Length;
            mapHeight = data.Length;
            mapSize = mapWidth * mapHeight;
            mapData = new char[mapHeight, mapWidth];
            for (int i = 0; i < mapHeight; i++) {
                for (int j = 0; j < mapWidth; j++) {
                    mapData[i, j] = data[i][j];
                }
            }
        }

        public char getElement(int row, int col)
        {
            return mapData[row, col];
        }

        public int getMapWidth()
        {
            return mapWidth;
        }

        public int getMapHeight()
        {
            return mapHeight;
        }

        public int getMapSize()
        {
            return mapSize;
        }

        public char[,] getMapData()
        {
            return mapData;
        }

        public void setMapData(char[,] data)
        {
            mapData = data;
        }

        public void setMapData(string[] data)
        {
            mapWidth = data[0].Length;
            mapHeight = data.Length;
            mapSize = mapWidth * mapHeight;
            mapData = new char[mapHeight, mapWidth];
            for (int i = 0; i < mapHeight; i++) {
                for (int j = 0; j < mapWidth; j++) {
                    mapData[i, j] = data[i][j];
                }
            }
        }

        public void setMapWidth(int width)
        {
            mapWidth = width;
        }

        public void setMapHeight(int height)
        {
            mapHeight = height;
        }

        public void setMapSize(int size)
        {
            mapSize = size;
        }

        public void print()
        {
            for (int i = 0; i <= mapWidth; i++) {
                Console.Write("* ");
            }
            Console.Write("*\n");
            for (int i = 0; i < mapHeight; i++) {
                Console.Write("* ");
                if (getElement(i, 0) == 'X') {
                    Console.Write(" ");
                } else {
                    Console.Write(getElement(i, 0));
                }
                for (int j = 1; j < mapWidth; j++) {
                    if (getElement(i, j) == 'X') {
                        Console.Write("  ");
                    } else {
                        Console.Write(" " + getElement(i, j));
                    }
                }
                Console.Write(" *\n");
            }
            for (int i = 0; i <= mapWidth; i++) {
                Console.Write("* ");
            }
            Console.Write("*\n");
        }
    }
}