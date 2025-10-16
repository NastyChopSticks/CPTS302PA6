using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA6._2
{
    internal class Modular_Naive
    {
        public int Modular_NaiveSolution(int[] height)
        {
            if (height.Length < 3)
            {
                Console.WriteLine("Array too short to trap any water.");
                return 0;
            }

            int total = 0;
            int left = 0;

            while (left < height.Length - 1)
            {
                left = FindNextLeftWall(height, left);
                if (left >= height.Length - 1) break;

                int right = FindRightWall(height, left, out bool noTallerRight);

                if (noTallerRight)
                    Console.WriteLine($"Bucket found (no taller right): left index={left}, right index={right}");
                else
                    Console.WriteLine($"Bucket found: left index={left}, right index={right}");

                total += ComputeBucketWater(height, left, right);

                left = right; // move to next bucket
            }

            return total;
        }

        int FindNextLeftWall(int[] height, int start)
        {
            while (start < height.Length - 1 && height[start] == 0)
                start++;
            return start;
        }

        // Find right wall for a given left wall
        int FindRightWall(int[] height, int left, out bool noTallerRight)
        {
            int right = left + 1;
            int maxRight = right;

            while (right < height.Length && height[right] < height[left])
            {
                if (height[right] >= height[maxRight])
                    maxRight = right;
                right++;
            }

            if (right >= height.Length)
            {
                noTallerRight = true;
                return maxRight;
            }

            noTallerRight = false;
            return right;
        }

        // Compute trapped water for a bucket
        int ComputeBucketWater(int[] height, int left, int right)
        {
            int water = 0;
            for (int middle = left + 1; middle < right; middle++)
            {
                int minWall = Math.Min(height[left], height[right]);
                int waterHere = Math.Max(0, minWall - height[middle]);
                water += waterHere;
                Console.WriteLine($"  Middle index={middle}, water added={waterHere}, running bucket total={water}");
            }
            return water;
        }
    }
}
