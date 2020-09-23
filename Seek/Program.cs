using System;

namespace Seek
{
    class Program
    {
        static void Main(string[] args)
        {
            SequentionalSearch<string,int> ST = new SequentionalSearch<string, int>();
            ST.Put("A",2);
            ST.Put("B",4);
            ST.Put("C",7);
            foreach(string k in ST.Keys())
                Console.WriteLine("{0}: {1}",k,ST.Get(k));
        }
    }
}
