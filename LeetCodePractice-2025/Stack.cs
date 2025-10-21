using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025
{
    internal class Stack
    {
        /// <summary>
        /// Find the next closest large element at right side.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] NextClosestLargeElementAtRight(int[] arr)
        {
            if (arr.Length == 0)
                return new int[] { -1 };
            
            var tempStack = new Stack<int>();
            var result = new int[arr.Length];

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                while (tempStack.Count > 0 && arr[i] > tempStack.Peek())
                {
                    tempStack.Pop();
                }

                result[i] = tempStack.Count == 0 ? -1 : tempStack.Peek();

                tempStack.Push(arr[i]);
            }

            return result;
        }
    }
}
