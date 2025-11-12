using System.Text;

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

                //Better than .ContainsKey because .ContainsKey() involves 2 lookups,
                //first seen.ContainsKey(..) and then seen[value]. while tryGetValue can do it in single lookup.
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
                patternSeen[pattern[i]] = patternSeen.GetValueOrDefault(pattern[i]) + 1;

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

        //Find the maximum numbers from each sub array of given windowSize 
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
        public static int BestTimeToBuyOrSellStocks(int[] prices)
        {
            int maxProfit = 0;
            int buyDay = 0;

            for (int sellDay = buyDay + 1; sellDay < prices.Length; sellDay++)
            {
                var runningProfit = prices[sellDay] - prices[buyDay];
                if (runningProfit < 0)
                {
                    buyDay = sellDay;
                }
                else
                    maxProfit = Math.Max(maxProfit, runningProfit);
            }
            return maxProfit;
        }

        //Remove Duplicates from the array and return unique numbers count;
        public static int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int left = 1;

            for (int right = 1; right < nums.Length; right++)
            {
                if (nums[right] != nums[right - 1])
                {
                    nums[left] = nums[right];
                    left++;
                }

            }
            return left;
        }
        
        //Check if any duplicates are present in the array
        public static bool ContainsDuplicate(int[] nums)
        {
            var seen = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!seen.Contains(nums[i]))
                    seen.Add(nums[i]);
                else
                    return true;
            }

            return false;
        }

        //Convert Roman number to Integer
        public static int RomanToInt(string s)
        {
            var symbols = new Dictionary<char, int>();
            symbols.Add('I', 1);
            symbols.Add('V', 5);
            symbols.Add('X', 10);
            symbols.Add('L', 50);
            symbols.Add('C', 100);
            symbols.Add('D', 500);
            symbols.Add('M', 1000);
            int runningSum = 0;

            for (int i = 0; i < s.Length; i++)
            {
                //first check makes sure the other check doesn't throw out of bound error.
                //second check ensures if the pre no is lesser then next, decrement the total
                if (i < s.Length - 1 && symbols[s[i]] < symbols[s[i + 1]])
                    runningSum -= symbols[s[i]];
                else
                    runningSum += symbols[s[i]];
            }
            return runningSum;
        }

        //Convert Int to Roman
        public static string IntToRoman(int number)
        {
            var symbols = new Dictionary<string, int>()
            {
                ["I"] = 1,
                ["IV"] = 4,
                ["V"] = 5,
                ["IX"] = 9,
                ["X"] = 10,
                ["XL"] = 40,
                ["L"] = 50,
                ["XC"] = 90,
                ["C"] = 100,
                ["CD"] = 400,
                ["D"] = 500,
                ["CM"] = 900,
                ["M"] = 1000,
            };
            var sb = new StringBuilder();

            foreach (var item in symbols.Reverse())
            {
                var quotient = number / item.Value;

                if (quotient != 0)
                {
                    while (quotient > 0)
                    {
                        sb.Append(item.Key);
                        quotient--;
                    }
                    number = number % item.Value;
                }
            }

            return sb.ToString();
        }

        //Find the length of longest substring with K unique characters
        public static int LongestSubstringWithKUniqueCharacters(string s, int uniques)
        {
            if (string.IsNullOrEmpty(s) || uniques == 0)
                return 0;

            var elements = new Dictionary<char, int>();
            int runningLength = 0;
            int maxLength = 0;
            int start = 0;

            for (int end = 0; end < s.Length; end++)
            {
                if (elements.Count < uniques)
                {
                    runningLength++;

                    if (!elements.ContainsKey(s[end]))
                        elements.Add(s[end], 1);
                    else
                        elements[s[end]]++;
                }
                else if (elements.Count > uniques)
                {
                    while (elements.Count > uniques)
                    {
                        elements[s[start]]--;

                        if (elements[s[start]] == 0)
                            elements.Remove(s[start]);

                        start++;
                    }
                }

                else if (elements.Count == uniques)
                {
                    maxLength = Math.Max(maxLength, runningLength);
                }
            }

            return maxLength;
        }

        //Find the length of Largest Sub Array which makes up to a given sum
        //If there are -ve numbers, this can be handled with prefix-sum + earliest index map
        public static int LargestSubArrayOfSum(int[] numbers, int target)
        {
            if (numbers.Length == 0 || target == 0)
                return 0;

            int maxSizeOfArray = 0;
            int runningSum = 0;
            int start = 0;

            for (int end = 0; end < numbers.Length; end++)
            {
                runningSum += numbers[end];

                while (runningSum > target && start <= end)
                    runningSum -= numbers[start++];

                if (runningSum == target)
                    maxSizeOfArray = Math.Max(maxSizeOfArray, end - start + 1);
            }

            return maxSizeOfArray;
        }
    }
}
