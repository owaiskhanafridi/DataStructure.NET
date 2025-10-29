using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                return Array.Empty<int>();

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

                if (seen.TryGetValue(value, out int j))
                    return new int[] { i, j };

                seen[numbers[i]] = i;
            }

            return Array.Empty<int>();
        }

        //Find the List of First Negative Numbers from the Window of Size N
        public static List<int> FirstNegativeNumberOfWindow(int[] numbers, int windowSize)
        {
            if (numbers is null || numbers.Length == 0 || windowSize == 0)
                return new List<int>();

            var queue = new Queue<int>();
            var negatives = new List<int>();
            int start = 0;

            for (int end = 0; end < numbers.Length; end++)
            {
                if (numbers[end] < 0)
                    queue.Enqueue(numbers[end]);

                if (end - start + 1 == windowSize)
                {
                    negatives.Add(queue.Count > 0 ? queue.Peek() : 0);

                    if (queue.Count > 0 && queue.Peek() == numbers[start])
                        queue.Dequeue();

                    start++;
                }
            }

            return negatives;
        }


        /// Find the count of anagrams present in a string
        public static int OccurrenceOfAnagram(string values, string pattern)
        {
            if (values == null || values.Length == 0 || pattern == null || pattern.Length == 0)
                return 0;

            int start = 0;
            int dictCount = 0;
            int count = 0;
            var patternSeen = new Dictionary<char, int>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (!patternSeen.ContainsKey(pattern[i]))
                    patternSeen.Add(pattern[i], 1);
                else
                    patternSeen[pattern[i]]++;
            }

            dictCount = patternSeen.Count;

            for (int end = 0; end < values.Length; end++)
            {
                if (patternSeen.ContainsKey(values[end]))
                    patternSeen[values[end]]--;

                if (patternSeen.ContainsKey(values[end]) && patternSeen[values[end]] == 0)
                    dictCount--;

                if (end - start + 1 == pattern.Length)
                {
                    if (dictCount == 0)
                        count++;

                    if (patternSeen.ContainsKey(values[start]))
                    {
                        if (patternSeen[values[start]] == 0)
                            dictCount++;
                        patternSeen[values[start]]++;
                    }
                    start++;
                }
            }

            return count;
        }

        public static List<int> MaximumsOfSubArray(int[] numbers, int windowSize)
        {
            if (numbers == null || numbers.Length == 0 || windowSize == 0)
                return new List<int>();

            var tempMax = new Queue<int>();
            var maximums = new List<int>();
            int start = 0;

            for (int end = 0; end < numbers.Length; end++)
            {
                if (tempMax.Count == 0)
                    tempMax.Enqueue(numbers[end]);

                if (tempMax.Peek() < numbers[end])
                {
                    tempMax.Dequeue();
                    tempMax.Enqueue(numbers[end]);
                }

                if (end - start + 1 == windowSize)
                {
                    maximums.Add(tempMax.Peek());

                    if (numbers[start] == tempMax.Peek())
                        tempMax.Dequeue();

                    start++;
                }
            }

            return maximums;
        }


        //Best time to buy and sell stocks
    }
}
