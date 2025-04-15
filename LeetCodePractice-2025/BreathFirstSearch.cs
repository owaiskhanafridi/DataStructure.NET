using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025
{
    public class BreathFirstSearch
    {
        public static void InitialSetup()
        {
            var edgeList = new List<int[]>
                {
                new int[] {0, 1},
                new int[] {1, 4},
                new int[] {1, 2},
                new int[] {2, 3},
                };

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

            foreach (var item in adjacencyList)
            {
                Console.WriteLine($"Node {item.Key.ToString()} has Neighbors: ");

                foreach (var value in item.Value)
                {
                    Console.WriteLine($"{value.ToString()}");
                }
            }

        }

        /// <summary>
        /// Find the number of steps a knight need to from reaching to Target (x,y) from a source (x,y)
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns>steps</returns>
        public static int StepsOfKnight(int[] source, int[] target, int dimension)
        {
            {
                //i,j => (1,3)
                var coordinates = new List<int[]>() {
                    new int[] {1,2},
                    new int[] {2, 1},
                    new int[] {-1, -2},
                    new int[] {-2, -1},
                    new int[] {-1, 2},
                    new int[] {2, -1},
                    new int[] {1, -2},
                    new int[] {-2, 1}
                    };


                //Change the source and target to matrix system
                var knightPosition = new int[2] { dimension - source[1], source[0] - 1 };
                var knightTarget = new int[2] { dimension - target[1], target[0] - 1 };

                var steps = BreathFirstSearch.CalculateStep(knightPosition, knightTarget, dimension);

                Console.WriteLine($"From source ({source[0]}, {source[1]}) to target ({target[0]}, {target[1]}) the steps: {steps}");
                return steps;
            }
        }

        public static int CalculateStep(int[] knightPosition, int[] knightTarget, int dimension)
        {
            //i,j => (1,3)
            var coordinates = new List<int[]>() {
                new int[] {1,2},
                new int[] {2, 1},
                new int[] {-1, -2},
                new int[] {-2, -1},
                new int[] {-1, 2},
                new int[] {2, -1},
                new int[] {1, -2},
                new int[] {-2, 1}
            };

            var visited = new Dictionary<int[], bool>();
            var points = new Queue<int[]>();
            int steps = 0;
            int pointSize = 0;

            points.Enqueue(knightPosition);
            visited.Add(knightPosition, true);

            while (points.Count() > 0)
            {
                pointSize = points.Count();

                while (pointSize > 0)
                {
                    var firstValue = points.Dequeue();

                    if (firstValue[0] == knightTarget[0] && firstValue[1] == knightTarget[1])
                        return steps;

                    foreach (var coordinate in coordinates)
                    {
                        var newPointX = firstValue[0] + coordinate[0];
                        var newPointY = firstValue[1] + coordinate[1];

                        if (newPointX >= 0 && newPointY >= 0 &&
                            newPointX < dimension &&
                            newPointY < dimension &&
                            !visited.ContainsKey([newPointX, newPointY]))
                        {
                            visited.Add(new int[] { newPointX, newPointY }, true);
                            points.Enqueue(new int[] { newPointX, newPointY });
                        }
                    }
                    pointSize--;
                }
                steps++;
            }
            return steps;
        }

        public static void CheckIfPathExist(Func<int, Dictionary<int, List<int>>, HashSet<int>, HashSet<int>> Action, List<int[]> edgeList, int source, int destination)
        {
            var visited = new HashSet<int>();
            var adjacencyList = CreateAdjacencyList(edgeList);
            
            visited = Action(source, adjacencyList, visited);
            Console.WriteLine($"Path between {source} --> {destination} Exists: {visited.Contains(destination)}");
        }

        public static HashSet<int> BFS(int source, Dictionary<int,List<int>> adjacencyList, HashSet<int> visited)
        {
            //var visited = new HashSet<int>();
            var nodes = new Queue<int>();

            nodes.Enqueue(source);
            visited.Add(source);

            while (nodes.Count() > 0)
            {
                var currentNode = nodes.Dequeue();

                if (adjacencyList.ContainsKey(currentNode))
                    foreach (var nbr in adjacencyList[currentNode])
                        if (!visited.Contains(nbr))
                        {
                            nodes.Enqueue(nbr);
                            visited.Add(nbr);
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



    }
}
