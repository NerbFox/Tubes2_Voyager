// namespace Algorithm{
//     public class BFS : MyAlgorithm
//     {
//         public override void print()
//         {
//             Console.WriteLine("Hello BFS");
//         }
//     }
// }
// mau pake partial class buat nambahin method BFS
using System;
namespace Algo{
    class BFS{
        protected MyAlgo A;
        public BFS(MyAlgo _A){
            A = _A;
        }
        public void printMap(){
            Console.WriteLine("Hello BFS");
            A.printMap();
        }
        public void BFSMethod(){
            // A.printMap();
            Console.WriteLine("BFS method activated");
        }


    }
}