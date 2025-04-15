using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025
{
    public class DepthFirstSearch
    {
    
        public static HashSet<int> DFS(int source, Dictionary<int, List<int>> adjacencyList, HashSet<int> visited)
        {
            visited.Add(source);

            if (adjacencyList.ContainsKey(source))
            {
                foreach (var nbr in adjacencyList[source])
                {
                    if (!visited.Contains(nbr))
                    {
                        DFS(nbr, adjacencyList, visited);
                    }
                }
            }
            return visited;
        }

        public static Dictionary<int, List<int>> CreateAdjacencyList(List<int[]> edgeList)
        {
            var adjacencyList = new Dictionary<int, List<int>>();

            foreach (var edge in edgeList)
            {
                if (!adjacencyList.ContainsKey(edge[0]))
                    adjacencyList[edge[0]] = new List<int>();

                if (!adjacencyList.ContainsKey(edge[1]))
                    adjacencyList[edge[1]] = new List<int>();

                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }

            return adjacencyList;
        }

        public static void CheckIfPathExist(Func<int, Dictionary<int, List<int>>, HashSet<int>, HashSet<int>> Action, List<int[]> edgeList, int source, int destination)
        {
            var adjacencyList = CreateAdjacencyList(edgeList);
            var visited = new HashSet<int>();
            visited = Action(source, adjacencyList, visited);
            
            Console.WriteLine($"Path between {source} --> {destination} Exists: {visited.Contains(destination)}");
        }
    }
}
