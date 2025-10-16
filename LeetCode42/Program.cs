using PA6._2;
using System;
using System.Buffers;
using System.Runtime.InteropServices;


namespace PA6
{
    
    class Program
    {
        static int Main()
        {
            Naive naive = new Naive();
            int[] arr = { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            naive.NaiveSolution(arr);

            return 0;
        }
    }
}


