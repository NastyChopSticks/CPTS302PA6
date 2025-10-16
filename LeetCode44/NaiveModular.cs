using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode44
{
    internal class NaiveModular
    {
        public bool IsMatch(string s, string p)
        {
            return Match(s, p, 0, 0);
        }

        bool IsFinished(string s, string p, int si, int pi)
        {
            if (si == s.Length && pi == p.Length) return true; // perfect match
            if (pi == p.Length) return false;                 // pattern finished but string not
            if (si == s.Length)                               // string finished but pattern left
            {
                for (int k = pi; k < p.Length; k++)
                    if (p[k] != '*') return false;
                return true;
            }
            return false; // not finished
        }

        bool Match(string s, string p, int si, int pi)
        {
            if (IsFinished(s, p, si, pi)) return true;

            if (p[pi] == '*')
                return Match(s, p, si, pi + 1) || Match(s, p, si + 1, pi); // * options
            else if (p[pi] == '?' || p[pi] == s[si])
                return Match(s, p, si + 1, pi + 1); // single-char match
            else
                return false; // mismatch
        }
    }
}
