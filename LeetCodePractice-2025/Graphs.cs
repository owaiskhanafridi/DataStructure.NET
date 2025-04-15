using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025
{
    class Graphs
    {
        public static void ReorderRoute()
        {
            List<int[]> edgeList = new List<int[]>()
            {
                new int[] {0,1},
                new int[] {1,3},
                new int[] {2,3},
                new int[] {4,0},
                new int[] {4,5}
            };

            Dictionary<int, List<int>> forwardList = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> backwardList = new Dictionary<int, List<int>>();

            foreach (int[] edge in edgeList)
            {
                if (!forwardList.ContainsKey(edge[0]))
                    forwardList[edge[0]] = new List<int>();

                if (!backwardList.ContainsKey(edge[1]))
                    backwardList[edge[1]] = new List<int>();

                forwardList[edge[0]].Add(edge[1]);
                backwardList[edge[1]].Add(edge[0]);
            }
             
            //foreach (var item in forwardList)
            //{
            //    Console.WriteLine($"Node {item.Key.ToString()} has neighbors: ");
            //    foreach(var value in item.Value)
            //    {
            //        Console.WriteLine(value.ToString());
            //    }
            //}
        }
    }
}
