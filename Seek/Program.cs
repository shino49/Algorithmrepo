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
            Console.WriteLine("Size: {0}",ST.Size());
            foreach(string k in ST.Keys())
                Console.WriteLine("{0}: {1}",k,ST.Get(k));

            ST.Put("D", 9);
            ST.Put("E", 11);
            ST.Put("B", 12);
            Console.WriteLine("Size: {0}", ST.Size());
            foreach (string k in ST.Keys())
                Console.WriteLine("{0}: {1}", k, ST.Get(k));

            ST.Delete("A");
            ST.Delete("D");
            ST.Delete("H");
            Console.WriteLine("Size: {0}", ST.Size());
            foreach (string k in ST.Keys())
                Console.WriteLine("{0}: {1}", k, ST.Get(k));
        }
    }
}
