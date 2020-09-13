using System;
using System.Diagnostics;

public class BenchMark<T> where T: IComparable
{
    public delegate void SortedMethod(T[] arr);
    SortedMethod sortedMethod;
    BenchInfo benchInfo;

    public BenchMark(string methodName)
    {
        benchInfo.method = methodName;
        switch (methodName)  
        {
            case "bubble":
            sortedMethod = new SortedMethod(SortedMethods.BubbleSort<T>);
            break;

            case "select":
            sortedMethod = new SortedMethod(SortedMethods.SelectSort<T>);
            break;

            case "insert":
            sortedMethod = new SortedMethod(SortedMethods.InsertSort<T>);
            break;

            case "shell":
            sortedMethod = new SortedMethod(SortedMethods.ShellSort<T>);
            break;

            default:
            break;
        }
    }

    public void OneBench(int num, T[] oriArr)
    {
        T[] curArr;
        Stopwatch sw = new Stopwatch();
        benchInfo.totalTimes = num;
        benchInfo.succedTimes = 0;

        for(int i=0;i<num;i++)
        {
            curArr = oriArr.Clone() as T[];
            sw.Start();
            sortedMethod(curArr);
            sw.Stop();
            if(SortHelp.isSorted(curArr))
                benchInfo.succedTimes += 1;
        }
        TimeSpan time  = sw.Elapsed;
        benchInfo.averageMiliSeconds = time.TotalMilliseconds/num;
    }

    public void showData()
    {
        Console.WriteLine(
            "{0} method took {1}ms averagely, total: {2}, correct: {3}, fail: {4}. {5}",
            benchInfo.method,
            benchInfo.averageMiliSeconds,
            benchInfo.totalTimes,
            benchInfo.succedTimes,
            benchInfo.totalTimes-benchInfo.succedTimes,
            benchInfo.totalTimes==benchInfo.succedTimes?"yes":"no"
        );

    }

}