using System;
using Map;
using System.Collections.Generic;

namespace Algorithm
{
    public abstract class MyAlgorithm
    {
        protected int treasureFound;
        protected int treasure;
        protected MyMap mapData;
        // matrix of adjacencies
        protected bool[,] adj;
        // visited nodes
        protected bool[,] visited;
        // stack of visited nodes tuple (row, col)
        protected (int,int)[] stack;
        // protected Stack<int> stacksd;
        public abstract void print();
    }
}