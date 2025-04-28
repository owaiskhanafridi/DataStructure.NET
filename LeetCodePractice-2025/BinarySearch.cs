using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025
{
    public class BinarySearch
    {
        /// <summary>
        /// Find the index of a given number using sorted array. 
        /// Return -1 if the number is not found.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BasicProgram(int[] nums, int target)
        {
            //Edge case
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;

            //Edge case
            if (nums.Length == 0)
                return -1;

            int start = 0;
            int end = nums.Length - 1;
            int middle;
            while (start <= end)
            {
                //Following logic doesn't let the number to overflow.
                //older logic was middle = (start + end) / 2. But the if the sum of start and end exceeds the integer limit,
                //It would overflow. to prevent this, we are doing middle = start + (end - start) / 2. Which is mathematically
                //equal to the risky expression, but safer to execute.

                middle = start + (end - start) / 2;

                if (nums[middle] == target)
                {
                    return middle;
                }
                else if (nums[middle] < target)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            //Return -1 if the number is not found.
            return -1;
        }

        public static int SortedReverse(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            int middle;
            while (start <= end)
            {
                //Following logic doesn't let the number to overflow.
                //older logic was middle = (start + end) / 2. But the if the sum of start and end exceeds the integer limit,
                //It would overflow. to prevent this, we are doing middle = start + (end - start) / 2. Which is mathematically
                //equal to the risky expression, but safer to execute.

                middle = start + (end - start) / 2;

                if (nums[middle] == target)
                {
                    return middle;
                }
                else if (nums[middle] > target)
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            //Return -1 if the number is not found.
            return -1;
        }

        /// <summary>
        /// Find the location of the number in array when it is not defined if the array is sorted in ascending or descending
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int OrderIsNotGiven(int[] nums, int target)
        {
            //Edge case
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;

            //Edge case
            if (nums.Length == 0)
                return -1;

            int start = 0;
            int end = nums.Length - 1;
            int middle;

            while (start <= end)
            {
                middle = start + (end - start) / 2;

                if (nums[middle] == target)
                {
                    return middle;
                }

                //Check if its Ascending Array (Sorted)
                if (nums[0] < nums[1])
                {
                    if (target > nums[middle])
                    {
                        start = middle + 1;
                    }
                    else
                    {
                        end = middle - 1;

                    }
                }
                //Check if its Descending Array (Reverse Sorted)
                else
                {
                    if (target > nums[middle])
                    {
                        end = middle - 1;
                    }
                    else
                    {
                        start = middle + 1;
                    }
                }
            }

            //Return -1 if the number is not found.
            return -1;
        }

        public static int FirstOccurenceOfTarget(int[] nums, int target)
        {
            //Edge case
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;

            //Edge case
            if (nums.Length == 0)
                return -1;

            int start = 0;
            int end = nums.Length - 1;
            int startIndex = -1;
            int middle;

            while (start <= end)
            {
                middle = start + (end - start) / 2;

                if (nums[middle] == target)
                {
                    startIndex = middle;
                    end = middle - 1;
                }
                else if (target > nums[middle])
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return startIndex;
        }

        public static int LastOccurenceOfTarget(int[] nums, int target)
        {
            //Edge case
            if (nums.Length == 1)
                return nums[0] == target ? 0 : -1;

            //Edge case
            if (nums.Length == 0)
                return -1;

            int start = 0;
            int end = nums.Length - 1;
            int lastIndex = -1;
            int middle;

            while (start <= end)
            {
                middle = start + (end - start) / 2;

                if (nums[middle] == target)
                {
                    lastIndex = middle;
                    start = middle + 1;
                }
                else if (target > nums[middle])
                {
                    start = middle + 1;
                }
                else
                {
                    end = middle - 1;
                }
            }

            return lastIndex;
        }
    }
}
