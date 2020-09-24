using System;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var Arr = SortHelp.ArrayGenerate(3000,1,10000);
            String[] methodList = {"select","bubble","insert","shell"};
            foreach(String name in methodList)
            {
                BenchMark<int> benchMark = new BenchMark<int>(name);
                benchMark.OneBench(100, Arr);
                benchMark.showData();
            } 
        }
    }
}

struct BenchInfo
{
    public string method;
    public int totalTimes;
    public int succedTimes;
    public double averageMiliSeconds;

}
