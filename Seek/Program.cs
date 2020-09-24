using System;

namespace Seek
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            Search<string, int> ST = new SequentionalSearch<string, int>();
            FrequencyCounter fc = new FrequencyCounter(ST);
            var res = fc.OneCounter(fileName);
            Console.WriteLine("MaxWord: {0} of {1},Time: {2}",res.maxWord, ST.Get(res.maxWord),res.timeSpan);

        }
    }
}
