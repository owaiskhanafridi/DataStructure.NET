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

            //Using ValueTuple as it's a value type and compares content instead of the object in case of reference type int[]
            var visited = new HashSet<(int, int)>();

            //Its okay to use int[] in Queue since we're not checking it for comparison like in case of visited variable above.
            var points = new Queue<int[]>();

            int steps = 0;
            int pointSize = 0;

            points.Enqueue(knightPosition);
            visited.Add((knightPosition[0], knightPosition[1]));

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
                            !visited.Contains((newPointX, newPointY)))
                        {
                            points.Enqueue(new int[] { newPointX, newPointY });
                            visited.Add((newPointX, newPointY));
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

        public static HashSet<int> BFS(int source, Dictionary<int, List<int>> adjacencyList, HashSet<int> visited)
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


        #region Final Preparation


        /// <summary>
        /// Create adjacency list with actual int[][] typed parameters
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static Dictionary<int, List<int>> CreateAdjacencyList_Practice(int[][] edges)
        {
            var adjacencyList = new Dictionary<int, List<int>>();
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                int a = edges[i][0];
                int b = edges[i][1];

                if (!adjacencyList.ContainsKey(a))
                    adjacencyList.Add(a, new List<int>());

                if (!adjacencyList.ContainsKey(b))
                    adjacencyList.Add(b, new List<int>());

                adjacencyList[a].Add(b);
                adjacencyList[b].Add(a);
            }
            return adjacencyList;
        }


        public static int NumIslands_chars(char[][] grid)
        {

            Dictionary<string, bool> dict = new Dictionary<string, bool>();
            int count = 0;

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == '0')
                        continue;
                    else if (!dict.ContainsKey(i + "," + j))
                        BFS_chars(grid, i, j, dict, ref count);
                }
            return count;
        }

        public static void BFS_chars(char[][] grid, int startingX, int startingY, Dictionary<string, bool> dict, ref int count)
        {
            Points point = new Points(startingX, startingY);
            Queue<Points> que = new Queue<Points>();
            que.Enqueue(point);
            dict.Add(startingX + "," + startingY, true);

            int gridX_length = grid.Length;
            int gridY_length = grid[0].Length;
            var direction = new int[][] {
                new int[] { -1, 0 },
                new int[] { 1, 0 },
                new int[] { 0, 1 },
                new int[] { 0, -1 }
            };

            while (que.Count != 0)
            {
                Points currentPoint = que.Dequeue();
                int x = currentPoint.x;
                int y = currentPoint.y;

                for (int i = 0; i < direction.GetLength(0); i++)
                {
                    int newX = x + direction[i][0];
                    int newY = y + direction[i][1];

                    if (newX >= 0
                    && newY >= 0
                    && newX < gridX_length
                    && newY < gridY_length
                    && !dict.ContainsKey(newX + "," + newY)
                    && grid[newX][newY] == '1')
                    {
                        que.Enqueue(new Points(newX, newY));
                        dict.Add(newX + "," + newY, true);
                    }
                }

            }
            count++;
        }

        public static int NumberOfIslands_Chars(char[][] grid)
        {
            int count = 0;
            var visited = new HashSet<string>();

            for (int i = 0; i < grid.Length; i++)
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (!visited.Contains($"{i},{j}") && grid[i][j] == '1')
                        BFS_Chars(i, j, visited, grid, ref count);


        }

            return count;
        }

        public static void BFS_Chars(int pointX, int pointY, HashSet<string> visited, char[][] grid, ref int count)
        {
            visited.Add($"{pointX},{pointY}");
            var queue = new Queue<Points>();
            queue.Enqueue(new Points(pointX, pointY));

            int lengthX = grid.Length;
            int lengthY = grid[0].Length;

            var coordinates = new int[][] {
            new int[2] {1, 0},
            new int[2] {0, 1},
            new int[2] {-1, 0},
            new int[2] {0, -1},
            };

            while (queue.Count != 0)
            {
                Points points = queue.Dequeue();

                for (int i = 0; i < coordinates.Length; i++)
                {
                    int newX = points.x + coordinates[i][0];
                    int newY = points.y + coordinates[i][1];

                    if (newX >= 0 && newY >= 0 &&
                        newX < lengthX && newY < lengthY &&
                        !visited.Contains($"{newX},{newY}")
                        && grid[newX][newY] == '1')
                    {
                        visited.Add($"{newX},{newY}");
                        queue.Enqueue(new Points(newX, newY));
                    }
                }
            }
            count++;
        }



        public class Points
        {
            public int x;
            public int y;

            public Points(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        #endregion
    }
}


