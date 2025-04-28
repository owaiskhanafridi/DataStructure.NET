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
        public static int BinarySearch_BasicProgram(int[] nums, int target)
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

                middle = start + (end - start)/2;

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
    }
}
