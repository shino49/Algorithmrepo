using System;

class SortedMethods
{
    public static void BubbleSort<T>(T[] arr) where T: IComparable
    {
        for (int i = 0;i < arr.Length;i++)
        {
            for(int j = 0;j < arr.Length - 1 - i;j++)
            {
                if(SortHelp.less<T>(arr[j+1],arr[j]))
                    SortHelp.exch<T>(arr, j, j+1);
            }
        }
    }

    public static void SelectSort<T>(T[] arr) where T: IComparable
    {
        int num = arr.Length;
        for(int i = 0;i < num;i++)
        {
            int min = i;
            for(int j = i+1;j < num;j++)
            {
                if(SortHelp.less<T>(arr[j],arr[min]))
                    min = j;
            }
            SortHelp.exch<T>(arr,i,min);
        }
    }

    public static void InsertSort<T>(T[] arr) where T: IComparable
    {
        int num = arr.Length;
        for (int i=1;i < num;i++)
        {
            for(int j=i;j > 0 && SortHelp.less<T>(arr[j],arr[j-1]);j--)
                SortHelp.exch<T>(arr,j,j-1);
        }
    }

    public static void ShellSort<T>(T[] arr) where T: IComparable
    {
        int num = arr.Length;
        int h = 1;
        while(h < num/3)
            h = h*3+1;
        while(h>=1)
        {
            for (int i=h;i < num;i++)
            {
                for(int j=i;j >= h && SortHelp.less<T>(arr[j],arr[j-h]);j -= h)
                    SortHelp.exch<T>(arr,j,j-h);
            }
            h = h/3;
        }
    }
}