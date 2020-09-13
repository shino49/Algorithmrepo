using System;

class SortHelp
{
    public static bool less<T>(T v, T w) where T : IComparable
    {
        return v.CompareTo(w) < 0;
    }

    public static void exch<T>(T[] a, int i, int j) where T : IComparable
    {
        T t = a[i];
        a[i] = a[j];
        a[j] = t;
    }

    public static void show<T>(T[] a) where T : IComparable
    {
        Console.Write("[");
        for (int i = 0; i < a.Length; i++)
            Console.Write("{0}  ", a[i]);
        Console.Write("\b]");
        Console.WriteLine();
    }

    public static bool isSorted<T>(T[] a) where T : IComparable
    {
        for (int i = 1; i < a.Length; i++)
        {
            if (less<T>(a[i], a[i - 1]))
                return false;
        }
        return true;
    }

    public static int[] ArrayGenerate(int n, int min, int max)
    {
        int[] arr = new int[n];
        Random rd = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rd.Next(min, max);
        }
        return arr;
    }
    public static double[] ArrayGenerate(int n, double min, double max)
    {
        double[] arr = new double[n];
        Random rd = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = min + rd.NextDouble() * (max - min);
        }
        return arr;
    }
}