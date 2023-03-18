using System;
using Algorithm;
using inputHandler;
using Map;

namespace Main
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Ghazi Akmal Fauzan");    
      Console.WriteLine("Tubes 2");
      Console.WriteLine("Voyager");
      Console.WriteLine("====================================");
      Console.WriteLine("1. BFS");
      Console.WriteLine("2. DFS");
      DFS dfs = new DFS();
      BFS bfs = new BFS();
      Console.Write("Pilih Algoritma: ");
      dfs.print();
      bfs.print();
    }
  }
}