using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025
{
    public class Heap
    {

        /// <summary>
        /// Find the K smallest element from an array where K is a given integer
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKSmallestElement(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k == 0 || nums.Length < k)
                return 0;

            var maxHeap = new PriorityQueue<int, int>();

            for (int counter = 0; counter < nums.Length; counter++)
            {
                maxHeap.Enqueue(nums[counter], -nums[counter]);

                if (maxHeap.Count > 3)
                {
                    maxHeap.Dequeue();
                }
            }
            return maxHeap.Peek();
        }

        /// <summary>
        /// Find K highest salary where k is a given integer
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public static int FindKHighestSalary(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k <= 0 || nums.Length < k)
                return 0;

            var minHeap = new PriorityQueue<int, int>();

            for (int counter = 0; counter < nums.Length; counter++)
            {
                minHeap.Enqueue(nums[counter], nums[counter]);

                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            return minHeap.Peek();
        }

        /// <summary>
        /// Sort the K sorted array. An array which is partially sorted with a given K value.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static List<int> SortKSortedArray(int[] nums, int k)
        {
            var minHeap = new PriorityQueue<int, int>();
            var sortedArray = new List<int>();

            //complexty=> nums.Length - O(k log k) => O(N log k)
            foreach (var num in nums)
            {
                minHeap.Enqueue(num, num);

                if (minHeap.Count > k)
                {
                    sortedArray.Add(minHeap.Dequeue());
                }
            }

            // complexity => O(k log k)
            while (minHeap.Count > 0)
            {
                sortedArray.Add(minHeap.Dequeue());
            }

            //final compexity => O(N log k) +  O(k log k) => O(N log k).    Since k < N, O(k log k) is negligible
            return sortedArray;
        }

        /// <summary>
        /// Return K largest elements for a given array of numbers.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static List<int> FindKLargestElements(int[] nums, int k)
        {
            var minHeap = new PriorityQueue<int, int>();
            var largestElements= new List<int>();

            foreach (var num in nums)
            {
                minHeap.Enqueue(num, num);

                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            while (minHeap.Count > 0)
            { 
                largestElements.Add(minHeap.Dequeue());
            }

            return largestElements;
        }


        /// <summary>
        /// Find the K closest elements to X. The array may or may not be sorted
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static List<int> FindKClosestElements(int[] nums, int k, int x)
        {
            var closestElements = new List<int>();
            
            //We need to preserve actual element as well to get in the end.
            var maxHeap = new PriorityQueue<KeyValuePair<int, int>, int>();

            for (int counter = 0; counter < nums.Length; counter++)
            {
                //find the difference of elements and add them to maxHeap so they're added in ascending order.
                var difference = x - nums[counter];
                var element = new KeyValuePair<int, int>(Math.Abs(difference), nums[counter]);
                maxHeap.Enqueue(element, -difference);

                //Since the heap is maxHeap (ascending sorted), remove all higher elements if it exceeds the k limit
                if (maxHeap.Count > k)
                {
                    maxHeap.Dequeue();
                }
            }

            while(maxHeap.Count > 0)
            {
                var element = maxHeap.Dequeue();
                closestElements.Add(element.Value);
            }

            return closestElements;
        }
    }
}
