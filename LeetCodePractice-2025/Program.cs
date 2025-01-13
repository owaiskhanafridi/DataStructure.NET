using System;
using System.ComponentModel.Design;
using System.Dynamic;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting application...");

            //Console.WriteLine(LeetCode.MaxSumOfWindowSize_BF(3, new int[] { 2, 6, 5, 1, 4, 3, 10, 7 }));
            //Console.WriteLine(LeetCode.MaxSumOfWindowSize(3, new int[] { 2, 6, 5, 1, 4, 3, 10, 7 }));
            //Console.WriteLine(LeetCode.MinSumOfWindowSize(3, new int[] { 2, 6, 5, 1, 4, 3, 10, 7 }));
            //Console.WriteLine(LeetCode.FirstNegativeNumberInWindow(3, new int[] { 12, -1, -7, 8, -15, 30, 16, 28 }));
            //Console.WriteLine(LeetCode.OccurrenceOfAnagram("aabaabaa", "aaba"));
            //LeetCode.MaxOfAllSubArray(new int[] {1,3,-1,-3,5,3,6,7}, 3);
            Console.WriteLine(LeetCode.LargestSubArrayOfSum(new int[] { 4, 1, 1, 1, 2, 3, 5 }, 5));


        }
    }

    public static class LeetCode
    {

        #region SlidingWindow

        // Find the maximum of window size size n in the number array
        public static string MaxSumOfWindowSize_BF(int windowSize, int[] numbers)
        {
            int currentSum = 0;
            int maxSum = int.MinValue;

            for (int i = 0; i <= numbers.Length - windowSize; i++)
            {
                // Restarting the sum
                currentSum = 0;

                for (int j = 0; j < windowSize; j++)
                {
                    currentSum += numbers[i + j];
                }

                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum.ToString();
        }


        public static string MaxSumOfWindowSize(int windowSize, int[] numbers)
        {
            int currentSum = 0;
            int maxSum = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                currentSum += numbers[i];
                if (i >= windowSize - 1)
                {
                    maxSum = Math.Max(maxSum, currentSum);

                    // Remove first element from window's sum
                    currentSum -= numbers[i - windowSize + 1];
                }
            }

            return maxSum.ToString();

        }

        public static string MinSumOfWindowSize(int windowSize, int[] numbers)
        {
            int currentSum = 0;
            int minSum = int.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                currentSum += numbers[i];
                if (i >= windowSize - 1)
                {
                    minSum = Math.Min(minSum, currentSum);

                    // Remove first element from window's sum
                    currentSum -= numbers[i - windowSize + 1];
                }
            }
            return minSum.ToString();
        }

        public static List<int> FirstNegativeNumberInWindow(int windowSize, int[] numbers)
        {
            int start = 0;
            int end = 0;
            Queue<int> tempQueue = new Queue<int>();
            List<int> firstNegatives = new List<int>();

            for (end = 0; end < numbers.Length; end++)
            {
                if (numbers[end] < 0)
                    tempQueue.Enqueue(numbers[end]);

                // Run until window size is reached
                if (end - start + 1 == windowSize)
                {
                    // The first number in the queue will be the first -ve number in the window
                    if (tempQueue.Count > 0)
                    {
                        firstNegatives.Add(tempQueue.Peek());

                        // Remove 
                        if (tempQueue.Peek() == numbers[start])
                            tempQueue.Dequeue();
                    }
                    else
                        // Add zero to the list if none of the numbers are -ve in a window
                        firstNegatives.Add(0);

                    start++;
                }
            }
            return firstNegatives;
        }


        public static int OccurrenceOfAnagram(string stringValue, string pattern)
        {
            Dictionary<char, int> occurences = new Dictionary<char, int>();
            int start = 0, end = 0, ans = 0, count = 0;


            // Build a dictionary                                 a=3, b= 1
            for (int i = 0; i < pattern.Length; i++)
            {
                if (occurences.ContainsKey(stringValue[i]))
                    occurences[stringValue[i]]++;
                else
                    occurences.Add(stringValue[i], 1);
            }

            count = occurences.Count;

            for (end = 0; end < stringValue.Length; end++)
            {
                // Decrement value of key, if it is present in dictionary
                if (occurences.ContainsKey(stringValue[end]))
                    occurences[stringValue[end]]--;

                // Decrement counter if one of the key matches the anagram
                if (occurences[stringValue[end]] == 0)
                    count--;

                if (end >= pattern.Length - 1)
                {
                    //Check the count of dictionary
                    //If == 0, ans++
                    //Slide window, increment start element's count.

                    if (count == 0)
                    {
                        //Increment answer if all the element of anagram were found in the substring
                        ans++;

                        //Increment value of first element in dictionary to accomodate the next element.
                        occurences[stringValue[start]]++;
                        count++;
                    }

                    start++;
                }

            }

            return ans;
        }

        public static List<int> MaxOfAllSubArray(int[] array, int windowSize)
        {
            List<int> maximums = new List<int>();

            int start = 0, end;
            LinkedList<int> list = new LinkedList<int>();

            for (end = 0; end < array.Length; end++)
            {
                while (list.Count > 0 && list.Last.Value < array[end])
                {
                    list.RemoveLast();
                }

                list.AddLast(array[end]);

                if (end - start + 1 == windowSize)
                {
                    maximums.Add(list.First.Value);
                    if (list.First.Value == array[start])
                        list.RemoveFirst();

                    start++;
                }
            }
            return maximums;
        }

        // Variable Window Size
        // Find the largest window size whose sum is equal to given value
        public static int LargestSubArrayOfSum(int[] array, int sum)
        {
            int start = 0, end = 0;
            int maxSubarray = int.MinValue;
            int runningSum = 0;

            for (end = 0; end < array.Length; end++)
            {
                runningSum += array[end];

                if (runningSum > sum)
                {
                    while (runningSum >= sum)
                    {
                        runningSum -= array[start];
                        start++;
                    }
                }

                if (runningSum == sum)
                {
                    maxSubarray = Math.Max(maxSubarray, end - start + 1);
                }
            }
            return maxSubarray;
        }

        //Test comment

        #endregion SlidingWindow
    }
}
