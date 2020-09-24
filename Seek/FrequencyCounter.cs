using System;
using System.IO;
using System.Diagnostics;

namespace Seek
{
    public class FrequencyCounter
    {
        Search<string, int> searchtable;
        int minlen;
        public FrequencyCounter(Search<string, int> table)
        {
            this.searchtable = table;
            this.minlen = 1;
        }
        public FrequencyCounter(Search<string, int> table, int min)
        {
            this.searchtable = table;
            this.minlen = min;
        }
        public CounterInfo OneCounter(String fileName)
        {
            Stopwatch sw = new Stopwatch();
            using (var stream = new StreamReader(fileName))
            {
                string nextLine;
                sw.Start();
                while ((nextLine = stream.ReadLine()) != null)
                {
                    string[] wordList = nextLine.Split(new char[] { ' ', ',', '.', '!' });
                    foreach (string word in wordList)
                    {
                        if (word.Trim().Length < minlen)
                            continue;
                        if (!searchtable.Contains(word))
                            searchtable.Put(word, 1);
                        else
                            searchtable.Put(word, searchtable.Get(word) + 1);
                    }
                }
                sw.Stop();
            }

            String maxWord = " ";
            searchtable.Put(maxWord, 0);
            foreach (string word in searchtable.Keys())
            {
                if (searchtable.Get(word) > searchtable.Get(maxWord))
                    maxWord = word;
            }

            return new CounterInfo { maxWord = maxWord, timeSpan = sw.Elapsed.TotalSeconds };
        }

        public CounterInfo OneCounterAllInMemory(String fileName)
        {
            Stopwatch sw = new Stopwatch();

            string[] lines = File.ReadAllLines(fileName);
            sw.Start();
            foreach(string nextLine in lines)
            {
                string[] wordList = nextLine.Split(new char[] { ' ', ',', '.', '!' });
                foreach (string word in wordList)
                {
                    if (word.Trim().Length < minlen)
                        continue;
                    if (!searchtable.Contains(word))
                        searchtable.Put(word, 1);
                    else
                        searchtable.Put(word, searchtable.Get(word) + 1);
                }
            }
            sw.Stop();


            String maxWord = " ";
            searchtable.Put(maxWord, 0);
            foreach (string word in searchtable.Keys())
            {
                if (searchtable.Get(word) > searchtable.Get(maxWord))
                    maxWord = word;
            }

            return new CounterInfo { maxWord = maxWord, timeSpan = sw.Elapsed.TotalSeconds };
        }

    }
}

public struct CounterInfo
{
    public string maxWord;
    public double timeSpan;

}