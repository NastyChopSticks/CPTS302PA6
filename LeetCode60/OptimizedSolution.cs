using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode60
{
    internal class OptimizedSolution
    {
        public string GetKthPermutation(int n, int k)
        {
            List<int> numbers = CreateNumberList(n);
            List<int> factorials = ComputeFactorials(n);

            StringBuilder sb = new StringBuilder();
            k = k % factorials[n]; // wrap around in case k >= n!

            for (int i = n; i >= 1; i--)
            {
                int fact = factorials[i - 1];
                int index = k / fact;
                sb.Append(numbers[index]);
                numbers.RemoveAt(index);
                k %= fact;
            }

            return sb.ToString();
        }

        // Create list [1,2,...,n]
        public static List<int> CreateNumberList(int n)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= n; i++)
                list.Add(i);
            return list;
        }

        // Precompute factorials [0!, 1!, 2!, ..., n!]
        public static List<int> ComputeFactorials(int n)
        {
            List<int> factorials = new List<int> { 1 }; // 0! = 1
            int f = 1;
            for (int i = 1; i <= n; i++)
            {
                f *= i;
                factorials.Add(f);
            }
            return factorials;
        }
    }
}

