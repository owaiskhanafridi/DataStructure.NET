using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeetCodePractice_2025
{
    internal class AmazonTopQuestions
    {
        /// <summary>
        /// Find the indices of two numbers which makes whose sum is equal to the target.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            var visited = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int difference = target - nums[i];

                if (visited.ContainsKey(difference))
                {
                    return new int[] { i, visited[difference] };
                }
                else
                {
                    visited[nums[i]] = i;
                }
            }

            var test = new int[nums.Length];
            test.All(x => x != 0);

            return new int[] { };
        }

        /// <summary>
        /// You are given a non-negative integer array nums.In one operation, you must:
        /// Choose a positive integer x such that x is less than or equal to the smallest non-zero element in nums.
        /// Subtract x from every positive element in nums.
        /// Return the minimum number of operations to make every element in nums equal to 0.
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static int MinimumOperations(int[] values)
        {
            var visited = new HashSet<int>();

            foreach (var value in values)
            {
                if (value != 0)
                    visited.Add(value);
            }
            return visited.Count();
        }

        public static IList<IList<int>> ThreeSum(int[] nums, int target)
        {
            var triplets = new List<IList<int>>();

            List<int> test = new();

            Array.Sort(nums);

            for (int counter = 0; counter < nums.Length - 2; counter++)
            {
                if (counter > 0 && nums[counter] == nums[counter - 1])
                    continue;

                int left = counter + 1;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int sum = nums[counter] + nums[left] + nums[right];

                    if (sum == target)
                    {
                        triplets.Add(new List<int> { nums[counter], nums[left], nums[right] });

                        left++;
                        right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return triplets;
        }
    }
}
