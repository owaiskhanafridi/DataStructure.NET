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

        /// <summary>
        /// Simple Binary Search method with specified start and end index
        /// This method can be used for other complex questions.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int BinarySearchWithSpecifiedPoints(int[] nums, int target, int start, int end)
        {
            if (nums.Length == 0)
                return -1;

            int mid;

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (nums[mid] == target)
                    return mid;

                else if (nums[mid] > target)
                    end = mid - 1;

                else
                    start = mid + 1;
            }

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

        /// <summary>
        /// Count of occurence of a number, 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int CountOfOccurences(int[] nums, int target)
        {
            if (nums.Length == 0)
                return 0;

            int firstOccurenceIndex = FirstOccurenceOfTarget(nums, target);
            int lastOccurenceIndex = LastOccurenceOfTarget(nums, target);

            if (firstOccurenceIndex < 0 || lastOccurenceIndex < 0)
                return 0;

            return lastOccurenceIndex - firstOccurenceIndex + 1;
        }

        /// <summary>
        /// Find the number of time an array is rotated
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int NumberOfTimesArrayIsRotated(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int n = nums.Length;
            int start = 0;
            int end = n - 1;
            int mid;

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                //If the middle element is smaller than both it's previous and next element, then it's the smallest
                //element hence the point where rotation started.
                //the length - this index would be the answer.
                //previous= [mid-1+n%n] because the mid could be nums[0] => nums[-1] (out of bound error)
                //next= [mid+1%n] because the mid could be nums[nums.Length - 1] => nums[nums.Length +1] (out of bound error)

                if (nums[mid] <= nums[mid - 1 + n % n] && nums[mid] <= nums[mid + 1 % n])
                    return n - mid;
                else if (nums[0] <= nums[mid])
                    start = mid + 1;
                else if (nums[mid] <= nums[n - 1])
                    end = mid - 1;
            }
            return 0;
        }

        /// <summary>
        /// Find the index of element in rotated array.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int FindTargetInRotatedArray(int[] nums, int target)
        {
            //First we calculate the number of times an array is rotated to get the 
            //middle element index so we can divide the array into two sub arrays
            //for searching the target element in both
            int arrayRotated = NumberOfTimesArrayIsRotated(nums);

            if (arrayRotated != 0)
            {
                int n = nums.Length;
                
                //rotationCount = n - smallestElementIndex. So smallestElementIndex= n - rotationCount.
                //smallestElementIndex is basically the middle element through which we can divide the array
                //into two subarrays because both the left and right subarrays of this element are sorted.
                int smallestElementIndex = n - arrayRotated;


                //find the target in both left and right array using regular binary search with specified start and end index
                int leftArray = BinarySearchWithSpecifiedPoints(nums, target, 0, smallestElementIndex - 1);
                int rightArray = BinarySearchWithSpecifiedPoints(nums, target, smallestElementIndex, n - 1);

                return leftArray == -1 ? rightArray == -1 ? -1 : rightArray : leftArray;
            }
            else
            {
                return -1;
            }

            return -1;
        }

    }
}
