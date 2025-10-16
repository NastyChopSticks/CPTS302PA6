using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA6._2
{
    internal class Optimized
    {
        public int OptimizedSolution(int[] height)
        {
            int totalWater = TrapWaterOptimized(height);
            return totalWater;
        }

    int TrapWaterOptimized(int[] height)
            {
                if (height.Length < 3)
                {
                    Console.WriteLine("Array too short to trap any water.");
                    return 0;
                }

                int n = height.Length;

                int[] maxLeft = ComputeMaxLeft(height);
                int[] maxRight = ComputeMaxRight(height);

                int total = 0;
                for (int i = 0; i < n; i++)
                {
                    int waterHere = Math.Max(0, Math.Min(maxLeft[i], maxRight[i]) - height[i]);
                    total += waterHere;
                    Console.WriteLine($"Index {i}: height={height[i]}, maxLeft={maxLeft[i]}, maxRight={maxRight[i]}, water added={waterHere}, running total={total}");
                }

                return total;
            }

            // Precompute max heights from the left
            int[] ComputeMaxLeft(int[] height)
            {
                int n = height.Length;
                int[] maxLeft = new int[n];
                maxLeft[0] = height[0];
                for (int i = 1; i < n; i++)
                    maxLeft[i] = Math.Max(maxLeft[i - 1], height[i]);
                return maxLeft;
            }

            // Precompute max heights from the right
            int[] ComputeMaxRight(int[] height)
            {
                int n = height.Length;
                int[] maxRight = new int[n];
                maxRight[n - 1] = height[n - 1];
                for (int i = n - 2; i >= 0; i--)
                    maxRight[i] = Math.Max(maxRight[i + 1], height[i]);
                return maxRight;
            }

        }
}
