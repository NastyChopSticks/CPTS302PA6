using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode44
{
    internal class OptimizedSolution
    {
        public bool IsMatchDP(string s, string p)
        {
            int m = s.Length;
            int n = p.Length;

            bool[,] dp = InitializeDP(s, p);

            FillDPTable(dp, s, p);

            return dp[m, n];
        }

        
        //this inits our DP based on our string sizes as well as it sets 0,0 to true.
        bool[,] InitializeDP(string s, string p)
        {
            int m = s.Length;
            int n = p.Length;
            bool[,] dp = new bool[m + 1, n + 1];

            dp[0, 0] = true; 

            
            for (int j = 1; j <= n; j++)
                if (p[j - 1] == '*')
                    dp[0, j] = dp[0, j - 1];

            return dp;
        }

       //fills our DP table. Basically we have a m x n grid
       //Then we iterate through the table. If we have some character c and a ? in our pattern we set the DP truth table to the last diagonal.
       //If we have a matching character we also set it to the last diagonal.
        //last case is if we have some character vs *. In this case we look at the cell above and to the left of it and use OR. so if the above cell is F but the left is T we take T || F = T. 
        void FillDPTable(bool[,] dp, string s, string p)
        {
            int m = s.Length;
            int n = p.Length;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    //if we have a *.
                    //check the left and above cells and or them.
                    if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i, j - 1] || dp[i - 1, j];
                    }
                    //if we have a ? or match characters, set to the last diagonal value
                    else if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = false;
                    }
                }
            }
        }
    }
}
