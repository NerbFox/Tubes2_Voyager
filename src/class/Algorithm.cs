using System;
using Map;

namespace Algorithm
{
    public abstract class MyAlgorithm
    {
        protected int treasureFound;
        protected MyMap mapData = new MyMap();
        public abstract void print();
    }
}