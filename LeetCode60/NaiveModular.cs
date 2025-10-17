using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode60
{
    internal class NaiveModular
    {
        public static string NaivePermutations(int n, int k)
        {
            int totalSize = Factorial(n);
            StringBuilder baseString = CreateBaseString(n);
            List<string> permutations = GenerateRandomPermutations(baseString, totalSize);
            permutations.Sort();
            return permutations[k];
        }

        // Compute factorial of n
        public static int Factorial(int n)
        {
            int result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        // Create the base string "123...n"
        public static StringBuilder CreateBaseString(int n)
        {
            StringBuilder sb = new StringBuilder(n);
            for (int i = 1; i <= n; i++)
                sb.Append(i.ToString());
            return sb;
        }

        // Generate all unique permutations using random swaps
        public static List<string> GenerateRandomPermutations(StringBuilder baseString, int totalSize)
        {
            int n = baseString.Length;
            List<string> permutations = new List<string>();
            Random rnd = new Random();

            while (permutations.Count < totalSize)
            {
                // Swap two random characters
                int i = rnd.Next(n);
                int j = rnd.Next(n);
                Swap(baseString, i, j);

                string perm = baseString.ToString();
                if (!permutations.Contains(perm))
                    permutations.Add(perm);
            }

            return permutations;
        }

        // Helper method to swap two characters in a StringBuilder
        public static void Swap(StringBuilder sb, int i, int j)
        {
            char temp = sb[i];
            sb[i] = sb[j];
            sb[j] = temp;
        }
    }
}
