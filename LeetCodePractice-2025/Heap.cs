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
            var largestElements = new List<int>();

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

            while (maxHeap.Count > 0)
            {
                var element = maxHeap.Dequeue();
                closestElements.Add(element.Value);
            }

            return closestElements;
        }

        /// <summary>
        /// Find the top K frequent numbers where K is given.
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[] FindTopKFrequentNumbers(int[] nums, int k)
        {
            var visited = new Dictionary<int, int>();
            var minHeap = new PriorityQueue<KeyValuePair<int, int>, int>();
            //var topFrequentElements = new List<int>();

            //If we exactly know how many numbers will be returned, we can simply initialize an int[k] and return it.
            //This way we dont need to convert it to a int[] through ToArray() if we take List<int>
            var returningValue = new int[k];

            for (int counter = 0; counter < nums.Length; counter++)
            {
                if (!visited.ContainsKey(nums[counter]))
                    visited.Add(nums[counter], 0);


                visited[nums[counter]]++;
            }

            foreach (var item in visited)
            {
                var element = new KeyValuePair<int, int>(item.Key, item.Value);
                minHeap.Enqueue(element, element.Value);

                if (minHeap.Count > k)
                {
                    minHeap.Dequeue();
                }
            }

            int i = 0;
            while (minHeap.Count > 0)
            {
                var element = minHeap.Dequeue();
                //topFrequentElements.Add(element.Key);
                returningValue[i] = element.Key;
                i++;
            }
            //return topFrequentElements.ToArray();
            return returningValue;
        }

        /// <summary>
        /// Return the list of element based on their higher - lower frequency
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        // Example Input {1,1,1,3,2,2,4}
        // TODO: Try directly using an int[nums.Length] to store element. Use some calculation to analyze the next adding index  
        public static int[] FrequencySort(int[] nums)
        {
            //Intializing a list with hardcoded length slightly improves the efficiency.
            //Default capacity is 4. It becomes double when the capacity is reached. 
            //If a capacity is predefined, we dont need to add more extra memory which might not be consumed.
            //var list = new List<int>(nums.Length);

            //Alternatively, we can directly add numbers to int[nums.Length] variable.
            //This way, we can simply return int[] instead of List<int>.ToArray() and save the program from this loop.
            var result = new int[nums.Length];

            var tempStore = new Dictionary<int, int>();
            var maxHeap = new PriorityQueue<KeyValuePair<int, int>, int>();

            //Build a dictionary
            for (int counter = 0; counter < nums.Length; counter++)
            {
                if (!tempStore.ContainsKey(nums[counter]))
                    tempStore.Add(nums[counter], 0);

                tempStore[nums[counter]]++;
            }

            foreach (var item in tempStore)
            {
                maxHeap.Enqueue(item, -item.Value);
            }

            //This variable decides the next input location for the result
            int nextIndex = 0;

            while (maxHeap.Count > 0)
            {
                var element = maxHeap.Dequeue();
                //list.AddRange(Enumerable.Repeat(element.Key, element.Value));

                //Using a manual for loop instead of above Enumerable.Repeat can give tiny performance gain
                //when using elements in millions.
                for (int i = 0; i < element.Value; i++)
                {
                    // list.Add(element.Key);
                    result[nextIndex] = element.Key;
                    nextIndex++;
                }
            }

            //return list.ToArray();

            //We can also utilize int[] variable and directly return it so we dont have to do .ToArray().
            return result;

        }

        /// <summary>
        /// Find the closest points from the origin when multiple points are given.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int[][] FindKClosestPointsFromOrigin(int[][] arr, int k)
        {
            var result = new int[k][];
            var maxHeap = new PriorityQueue<KeyValuePair<int, int>, double>();

            //Origin points
            int x1 = 0;
            int y1 = 0;

            for (int row = 0; row < arr.GetLength(0); row++)
            {
                var x2 = arr[row][0];
                var y2 = arr[row][1];
                var distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
                maxHeap.Enqueue(new KeyValuePair<int, int>(x2, y2), -distance);

                if (maxHeap.Count > k)
                    maxHeap.Dequeue();
            }

            int r = 0;
            while (maxHeap.Count > 0)
            {
                var element = maxHeap.Dequeue();
                result[r] = new int[2];
                result[r][0] = element.Key;
                result[r][1] = element.Value;
                r++;
            }

            return result;
        }
        
        /// <summary>
        /// Find the total cost of the rope of given length in such a way that it returns minimum cost when adding each other.
        /// Each rope cost something. rope of legth 2 cost $2.
        /// Trick is to add them together in such a way that it returns the minimum cost.
        /// </summary>
        /// <param name="ropes"></param>
        /// <returns></returns>
        public static int ConnectRopesToMinimizeCost(int[] ropes)
        {
            int totalCost = 0;
            var minHeap = new PriorityQueue<int, int>();

            //Creating a minHeap so only minimum length ropes are eliminated to be added.
            for (int counter = 0; counter < ropes.Length; counter++)
            {
                minHeap.Enqueue(ropes[counter], ropes[counter]);
            }

            //Run until the length is less than or equal to 2 because 
            //we add 2 ropes on each iteration. and Add it back to the 
            //minHeap so it checks whether to add it in next iteration
            //(based on it being minimum) or no.

            while (minHeap.Count >= 2)
            {
                int first = minHeap.Dequeue();
                int second = minHeap.Dequeue();
                totalCost += first + second;
                minHeap.Enqueue(first + second, first+second);
            }

            return totalCost;
        }
    }
}
