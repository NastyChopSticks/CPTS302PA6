using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode60
{
    internal class Naive
    {
        public string NaivePermutations(int n, int k)
        {
            //compute the total size aka n!
            int totalSize = 1;
            for (int i = 2; i <= n; i++)
            {
                totalSize *= i;
            }
        
            StringBuilder baseString = new StringBuilder(n);
            List<string> permutations = new List<string>();
            //create a base string that is some sequence ex: n = 4 baseString = "1234"
            for (int i = 0; i < n; i++)
            {
                baseString.Append((i+1).ToString());
            }

            //randomly preform swaps until the list is full
            Random rnd = new Random();
            while (permutations.Count < totalSize)
            {
                int i = rnd.Next(n);
                int j = rnd.Next(n);
                char temp = baseString[i];
                baseString[i] = baseString[j];
                baseString[j] = temp;
                string perm = baseString.ToString();
                if(!permutations.Contains(perm))
                {
                    permutations.Add(perm);
                }

            }
            //sort the perms and return the kth one.
            permutations.Sort();
            string kth = permutations[k];
           
            return kth;
            
        }
    }
}
