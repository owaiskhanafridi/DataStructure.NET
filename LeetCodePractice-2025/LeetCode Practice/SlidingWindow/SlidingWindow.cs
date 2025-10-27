using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025.LeetCode_Practice.SlidingWindow
{
    public static class SlidingWindow_Practice
    {
        public static int MaxSumOfWindowSize(int windowSize, int[] numbers)
        {
            int runningSum = 0;
            int maxSum = int.MinValue;
            int start = 0;

            for (int end = 0; end < numbers.Length; end++)
            {
                runningSum += numbers[end];

                if (end - start + 1 == windowSize)
                {
                    maxSum = Math.Max(maxSum, runningSum);
                    runningSum -= numbers[start];
                    start++;
                }
            }

            return maxSum;
        }

        public static int MinSumOfWindowSize(int windowSize, int[] numbers)
        {
            int runningSum = 0;
            int minSum = int.MaxValue;
            int start = 0;

            for (int end = 0; end < numbers.Length; end++)
            {
                runningSum += numbers[end];

                if (end - start + 1 == windowSize)
                {
                    minSum = Math.Min(minSum, runningSum);
                    runningSum -= numbers[start];
                    start++;
                }
            }

            return minSum;
        }

        // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        // You may assume that each input would have exactly one solution, and you may not use the same element twice.
        // You can return the answer in any order.
        public static int[] TwoSum_BruteForce(int[] numbers, int target)
        {
            if (numbers.Length < 2)
                return null;

            var indices = new int[2];
            int start = 0;
            int end = 0;

            while (start != numbers.Length - 1)
            {
                end += 1;
                if (target == numbers[start] + numbers[end])
                {
                    indices[0] = start;
                    indices[1] = end;

                    return indices;
                }
                //end++;

                if (end == numbers.Length - 1)
                {
                    start++;
                    end = start;
                }
            }

            return null;
        }

        // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        // You may assume that each input would have exactly one solution, and you may not use the same element twice.
        // You can return the answer in any order.

        //Used Capacity to avoid resizing. 
        //Used TryGetValue to avoid ContainsKey lookups.
        public static int[] TwoSum(int[] numbers, int target)
        {
            if (numbers.Length < 2)
                return Array.Empty<int>();

            var seen = new Dictionary<int, int>(capacity: numbers.Length);

            for (int i = 0; i < numbers.Length; i++)
            {
                var value = target - numbers[i];
                //As problem states: "...and you may not use the same element twice";
                var difference = target - numbers[i];

                if (seen.TryGetValue(value, out int j))
                    return new int[] { i, j };

                seen[numbers[i]] = i;
            }

            return Array.Empty<int>();
            }

            return new int[] { };
        }

    }
}
