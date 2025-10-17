

using LeetCode60;

class Program
{
    static void Main()
    {
        Naive naive = new Naive();
        int n = 4;
        int k = 5;
        string kth = naive.NaivePermutations(n, k);
        Console.WriteLine($"the {k}th perm is: {kth}");
        OptimizedSolution solution = new OptimizedSolution();
        kth = solution.GetKthPermutation(n, k);
        Console.WriteLine($"the {k}th perm is: {kth}");
    }
}