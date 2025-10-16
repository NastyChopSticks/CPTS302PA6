using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode44
{
    internal class NaiveWildCard
    {
        public bool NaiveWildCardCheck(string s, int si, string p, int pi)
        {
            return MatchHelper(s,si, p, pi);
        }
        bool MatchHelper(string s, int si, string p, int pi)
        {
            // Base case: if both strings are done
            if (si == s.Length && pi == p.Length) return true;

            // Pattern finished but string not → no match
            if (pi == p.Length) return false;

            // String finished but pattern has remaining
            if (si == s.Length)
            {
                // Only valid if remaining pattern is all '*'
                for (int k = pi; k < p.Length; k++)
                    if (p[k] != '*') return false;
                return true;
            }

            // Current pattern character
            if (p[pi] == '*')
            {
                // '*' can match 0 characters OR 1+ characters
                return MatchHelper(s, si, p, pi + 1) || MatchHelper(s, si + 1, p, pi);
            }
            else if (p[pi] == '?' || p[pi] == s[si])
            {
                // Match current char and move both pointers
                return MatchHelper(s, si + 1, p, pi + 1);
            }
            else
            {
                return false;
            }
        }
    }
}
