﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LeetCodePractice_2025
{
    class SlidingWindow
    {
        // 2, 6, 5, 1, 4, 3, 10, 7 , [3] 
        /// <summary>
        /// Find out the maximum sum of window size
        /// </summary>
        /// <param name="windowSize"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string MaxSumOfWindowSize_Practice(int windowSize, int[] numbers)
        {
            int maxSum = int.MinValue;
            int runningSum = 0;
            int start = 0;

            for (int end = 0; end < numbers.Length; end++)
            {
                runningSum += numbers[end];

                if (end - start + 1 == windowSize)
                {
                    maxSum = Math.Max(maxSum, runningSum);
                    //maxSum = maxSum > runningSum ? maxSum : runningSum;
                    runningSum -= numbers[start];
                    start++;
                }

            }
            return maxSum.ToString();
        }

        // 2, 6, 5, 1, 4, 3, 10, 7 , [3] 
        /// <summary>
        /// Find out the minimum sum of window size
        /// </summary>
        /// <param name="windowSize"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static string MinSumOfWindowSize_Practice(int windowSize, int[] numbers)
        {
            int minSum = int.MaxValue;
            int runningSum = 0;
            int start = 0;

            for (int end = 0; end < numbers.Length; end++)
            {
                runningSum += numbers[end];

                if (end - start + 1 == windowSize)
                {
                    minSum = Math.Min(minSum, runningSum);
                    //minSum = maxSum < runningSum ? minSum: runningSum;
                    runningSum -= numbers[start];
                    start++;
                }

            }
            return minSum.ToString();
        }

        //{ 12, -1, -7, 8, -15, 30, 16, 28 }
        /// <summary>
        /// Find the first negative numbers in a window of size N
        /// </summary>
        /// <param name="windowSize"></param>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public static List<int> FirstNegativeNumbersInWindowSize_Practice(int windowSize, int[] numbers)
        {
            List<int> negatives = new List<int>();
            Queue<int> tempHolder = new Queue<int>();
            int start = 0;

            for (int end = 0; end < numbers.Length; end++)
            {
                if (numbers[end] < 0)
                    tempHolder.Enqueue(numbers[end]);

                if (end - start + 1 == windowSize)
                {
                    //checking Count > 0 is an edge case
                    if (tempHolder.Count > 0)
                        negatives.Add(tempHolder.Peek());
                    //edge case
                    else
                        negatives.Add(0);

                    //checking Count > 0 is an edge case
                    if (tempHolder.Count > 0 && numbers[start] == tempHolder.Peek())
                        tempHolder.Dequeue();

                    start++;
                }
            }
            return negatives;
        }

        /// <summary>
        /// Find the count of anagrams present in a string
        /// </summary>
        /// <returns></returns>
        //"aabaabaa", "aaba"
        public static int OccurrenceOfAnagram_Practice(string value, string pattern)
        {
            int dictCount = 0;
            int count = 0;
            int start = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (!dict.ContainsKey(pattern[i]))
                    dict.Add(pattern[i], 1);
                else
                    dict[pattern[i]]++;
            }

            dictCount = dict.Count;

            for (int end = 0; end < value.Length; end++)
            {
                if (dict.ContainsKey(value[end]))
                    dict[value[end]]--;

                if (dict[value[end]] == 0)
                    dictCount--;
                //dict.Remove(value[end]);

                if (end - start + 1 == pattern.Length)
                {
                    if (dictCount == 0)
                    {
                        count++;
                        dict[value[start]]++;
                        dictCount++;
                    }
                    start++;
                }
            }
            return count;
        }

        /// <summary>
        /// Find the length of longest substring which contains K unique characters
        /// </summary>
        /// <param name="value"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static int LongestSubstringWithKUniqueCharacters_Practice(string value, int chars)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int maxLenth = int.MinValue;
            int start = 0;

            for (int end = 0; end < value.Length; end++)
            {
                if (!dict.ContainsKey(value[end]))
                    dict.Add(value[end], 1);
                else
                    dict[value[end]]++;

                //When dict count is 3
                if (dict.Count == chars)
                {
                    maxLenth = Math.Max(maxLenth, end - start + 1);
                }

                //When dict count > 3 
                if (dict.Count > chars)
                {
                    while (dict.Count > chars)
                    {
                        dict[value[start]]--;

                        if (dict[value[start]] == 0)
                            dict.Remove(value[start]);
                        start++;
                    }
                }
            }

            return maxLenth;
        }

        /// <summary>
        /// Find the largest subarray that makes up a sum
        /// </summary>
        /// <param name="array"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        /// { 4, 1, 1, 1, 2, 3, 5 }, 5
        public static int LargestSubArrayOfSum_Practice(int[] array, int target)
        {
            int start = 0;
            int maxLength = int.MinValue;
            int sum = 0;

            for (int end = 0; end < array.Length; end++)
            {
                sum += array[end];

                //If the sum > target
                if (sum > target)
                {
                    while (sum > target)
                    {
                        sum -= array[start];
                        start++;
                    }
                }

                //If the sum == target
                if (sum == target)
                {
                    maxLength = Math.Max(maxLength, end - start + 1);
                }
            }

            return maxLength;
        }

        /// <summary>
        /// Find the maximum values from all the subarray's of window size N
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="windowSize"></param>
        /// <returns></returns>
        public static List<int> MaxOfAllSubArray_Practice(int[] arr, int windowSize)
        {
            int start = 0;
            Queue<int> temp = new Queue<int>();
            List<int> maximums = new List<int>();

            for (int end = 0; end < arr.Length; end++)
            {
                if (temp.Count == 0)
                    temp.Enqueue(arr[end]);

                //If next element is highet than existing element, then replace it as
                //it will be of no use now or in the future
                if (temp.Peek() < arr[end])
                {
                    temp.Dequeue();
                    temp.Enqueue(arr[end]);
                }

                if (end - start + 1 == windowSize)
                {
                    maximums.Add(temp.Peek());

                    //if previous highest element (temp.Peek()) was the first element of the window
                    //then it will be of no use in future. So remove it from the temp queue
                    if (temp.Peek() == arr[start])
                        temp.Dequeue();

                    start++;
                }
            }
            return maximums;
        }

        /// <summary>
        /// Find the maximum number of toys in a sequence of type N
        /// </summary>
        /// <param name="toysSequence"></param>
        /// <param name="windowSize"></param>
        /// <returns></returns>
        public static int PickToysOfNTypeWithSequence_Practice(string toysSequence, int typeLength)
        {
            int start = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();
            int maxToys = 0;

            //Edge case
            if (string.IsNullOrEmpty(toysSequence) || typeLength <= 0)
                return 0;

            for (int end = 0; end < toysSequence.Length; end++)
            {
                if (!dict.ContainsKey(toysSequence[end]))
                    dict.Add(toysSequence[end], 1);
                else
                    dict[toysSequence[end]]++;

                if (dict.Count > typeLength)
                {
                    while (dict.Count > typeLength)
                    {
                        dict[toysSequence[start]]--;

                        if (dict[toysSequence[start]] == 0)
                            dict.Remove(toysSequence[start]);

                        start++;
                    }
                }

                if (dict.Count == typeLength)
                {
                    maxToys = Math.Max(maxToys, end - start + 1);
                }
            }

            return maxToys;
        }

        /// <summary>
        /// Remove duplicates from sorted 
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int RemoveDuplicatesFromSorterArray(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int i = 1;
            bool replaced = false;

            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] != nums[i - 1])
                {
                    nums[i] = nums[j];
                    i++;
                    replaced = true;
                }
            }

            if (!replaced)
                return 0;

            return i;
        }
    }
}
