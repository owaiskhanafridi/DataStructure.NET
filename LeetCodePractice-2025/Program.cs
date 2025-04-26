using LeetCodePractice_2025;
using System;
using System.ComponentModel.Design;
using System.Dynamic;
using System.Linq.Expressions;
using System.Xml;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting application...");

            #region Sliding_Window_Callings

            //Console.WriteLine(SlidingWindow.MaxSumOfWindowSize_Practice(3, new int[] { 2, 6, 5, 1, 4, 3, 10, 7 }));
            //Console.WriteLine(SlidingWindow.MinSumOfWindowSize_Practice(3, new int[] { 2, 6, 5, 1, 4, 3, 10, 7 }));
            //Console.WriteLine(SlidingWindow.FirstNegativeNumbersInWindowSize_Practice(3, new int[] { 12, -1, -7, 8, -15, 30, 16, 28 }));
            //Console.WriteLine(SlidingWindow.OccurrenceOfAnagram_Practice("aabaabaa", "aaba"));
            //Console.WriteLine(SlidingWindow.LongestSubstringWithKUniqueCharacters_Practice("aabacbebebe", 3));
            //Console.WriteLine(SlidingWindow.LargestSubArrayOfSum_Practice(new int[] { 4, 1, 1, 1, 2, 3, 5 }, 5));
            //SlidingWindow.MaxOfAllSubArray_Practice(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
            //Console.WriteLine(SlidingWindow.PickToysOfNTypeWithSequence_Practice("abaccab", 2));
            Console.WriteLine(SlidingWindow.RemoveDuplicatesFromSorterArray(new int[] { 0, 0, 1, 1, 2, 2, 3, 3, 4 }));

            #endregion Sliding_Window_Callings

            #region DataStructure

            //DataStructures.List();
            //DataStructures.LinkedList();
            //DataStructures.Queue();
            //DataStructures.HashSet();
            //DataStructures.BitArray();
            //DataStructures.PriorityQueueAndHeap();


            #endregion

            #region BreathFirstSearch - Callings

            //BreathFirstSearch.InitialSetup();
            //BreathFirstSearch.StepsOfKnight(new int[] { 4, 5 }, new int[] { 1, 1 }, 6);
            //BreathFirstSearch.StepsOfKnight(new int[] { 4, 5 }, new int[] { 6, 1 }, 6);
            //BreathFirstSearch.CheckIfPathExist(BreathFirstSearch.BFS,
            //    new List<int[]>() {
            //        new int[] { 1,0},
            //        new int[] { 1,2},
            //        new int[] { 3,5},
            //        new int[] { 3,4},
            //    }, 1, 3);

            //DepthFirstSearch.CheckIfPathExist(DepthFirstSearch.DFS,
            //    new List<int[]>() {
            //    new int[] { 1,0},
            //    new int[] { 1,2},
            //    new int[] { 3,5},
            //    new int[] { 3,4},
            //    }, 1, 3);

            //DepthFirstSearch.CheckIfPathExist(DepthFirstSearch.DFS,
            //    new List<int[]>() {
            //        new int[] { 1,2 },
            //        new int[] { 1,3 },
            //        new int[] { 2,4 },
            //        new int[] { 2,5 },
            //        new int[] { 3,6 },
            //    }, 1, 3);
            #endregion

            #region Amazon Top Questions - Callings

            var indices = AmazonTopQuestions.TwoSum(new int[] { 1, 3, 3, 4 }, 5);
            Console.WriteLine($"Target: 5, indices: {indices[0]} ,{indices[1]}");

            indices = AmazonTopQuestions.TwoSum(new int[] { 1, 3, 3, 4 }, 6);
            Console.WriteLine($"Target: 5, indices: {indices[0]} ,{indices[1]}");

            Console.WriteLine($"Minimum Operations Required to make all element Zero is: " +
                $"{AmazonTopQuestions.MinimumOperations(new int[] { 1, 5, 0, 3, 5 })}");


            AmazonTopQuestions.ThreeSum(new int[] { -1, -1, -1, 0, 1, 1, 1, 2 }, 0);
            #endregion

            #region Heap

            Heap.FindKSmallestElement(new int[] { 7, 10, 4, 3, 20, 15 }, 3);
            Heap.FindKHighestSalary(new int[] { 2000, 5000, 1000, 6000, 7000, 3000 }, 3);
            Heap.SortKSortedArray(new int[] { 6, 5, 3, 2, 8, 10, 9 }, 3);
            Heap.FindKLargestElements(new int[] { 7, 10, 4, 3, 20, 15 }, 3);
            Heap.FindKLargestElements(new int[] { 7, 10, 4, 3, 20, 15, 21, 1, 2 }, 2);
            Heap.FindKClosestElements(new int[] { 5, 6, 7, 8, 9 }, 3, 7);
            Heap.FindKClosestElements(new int[] { 9, 6, 7, 8, 5 }, 3, 7);

            #endregion

            Console.ReadLine();
        }
    }

    public static class LeetCode
    {

        #region SlidingWindow

        // Find the maximum of window size n in the number array
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

        //Print the length of longest substring which has 3 unique characters
        public static int LongestSubstringWithKUniqueCharacters(string str, int length)
        {
            int start = 0, end = 0, maximum = int.MinValue;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (end = 0; end < str.Length; end++)
            {
                if (dict.ContainsKey(str[end]))
                    dict[str[end]]++;
                else
                    dict.Add(str[end], 1);

                if (dict.Count() == length)
                {
                    maximum = Math.Max(maximum, end - start + 1);
                }

                else if (dict.Count() > length)
                {
                    //Remove elements from starting window until the substring contains 3 uniques again
                    while (dict.Count() > length)
                    {
                        dict[str[start]]--;

                        if (dict[str[start]] == 0)
                            dict.Remove(str[start]);

                        start++;
                    }
                }
            }

            return maximum;
        }

        public static int LongestSubstringWithoutRepeatingCharacters(string str)
        {
            int max = int.MinValue;
            int start = 0, end = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            for (end = 0; end < str.Length; end++)
            {
                if (!dict.ContainsKey(str[end]))
                    dict.Add(str[end], 1);
                else
                    dict[str[end]]++;

                if (dict.All(x => x.Value == 1))
                {
                    max = Math.Max(max, end - start + 1);
                }
                else
                {
                    while (dict.Any(x => x.Value > 1))
                    {
                        dict[str[start]]--;
                    }
                    start++;
                }
            }

            return max;
        }

        //Find the maximum number of toys of type N kept in sequence in a shelf.
        public static int PickToysOfNTypeWithSequence(string str, int typeLength)
        {
            int max = int.MinValue;
            int start = 0, end = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            //Edge case
            if (string.IsNullOrEmpty(str) || typeLength <= 0)
                return 0;

            for (end = 0; end < str.Length; end++)
            {
                if (!dict.ContainsKey(str[end]))
                    dict.Add(str[end], 1);
                else
                    dict[str[end]]++;

                if (dict.Count > typeLength)
                {
                    //Start Removing elements until the dictionary size becomes typeLength
                    while (dict.Count > typeLength)
                    {
                        dict[str[start]]--;

                        //If a character is value is decremented to 0, remove it entirely from the dictonary
                        if (dict[str[start]] == 0)
                            dict.Remove(str[start]);

                        start++;
                    }
                }
                max = Math.Max(max, end - start + 1);
            }
            return max;

            #endregion SlidingWindow
        }
    }
}
