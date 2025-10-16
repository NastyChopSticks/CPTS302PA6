using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PA6._2
{
    internal class Naive
    {
        public int NaiveSolution(int[] height) 
        {
            //height = new int[] { 0, 2, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            int totalWater = 0;
            Console.WriteLine("Array: [" + string.Join(", ", height) + "]\n");

            if (height.Length < 3)
            {
                Console.WriteLine("Array too short to trap any water.");
            }
            else
            {
                int left = 0;

                while (left < height.Length - 1)
                {
                    // Skip zeros for left wall
                    while (left < height.Length - 1 && height[left] == 0) left++;

                    // If left reaches the end, stop
                    if (left >= height.Length - 1)
                        break;

                    int right = left + 1;
                    int maxRight = right;

                    // Find a suitable right wall
                    while (right < height.Length && height[right] < height[left])
                    {
                        if (height[right] >= height[maxRight])
                            maxRight = right; // track tallest if no >= left
                        right++;
                    }

                    // If right goes out of bounds, use maxRight
                    if (right >= height.Length)
                    {
                        right = maxRight;
                        if (left == right) // no bucket possible
                            break;
                        Console.WriteLine($"Bucket found (no taller right): left index = {left} (value={height[left]}), right index = {right} (value={height[right]})");
                    }
                    else
                    {
                        Console.WriteLine($"Bucket found: left index = {left} (value={height[left]}), right index = {right} (value={height[right]})");
                    }

                    // Compute water for this bucket
                    for (int middle = left + 1; middle < right; middle++)
                    {
                        int minWall = Math.Min(height[left], height[right]);
                        int waterHere = Math.Max(0, minWall - height[middle]);
                        totalWater += waterHere;
                        Console.WriteLine($"  Middle index {middle} (value={height[middle]}), min(left,right)={minWall}, water added={waterHere}, running total={totalWater}");
                    }

                    left = right; // move left pointer to next bucket
                }

                Console.WriteLine($"\nTotal trapped water: {totalWater}");
            }
            return totalWater;
        }
    }
}
