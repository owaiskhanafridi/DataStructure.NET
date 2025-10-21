using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodePractice_2025
{
    class DataStructures
    {
        enum Day
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }

        enum Size
        {
            Small = 0,
            Medium = 1,
            Large = 2,
    

        }

        public static void List()
        {
            var list = new List<int>();
            list.Add(1);

            list.AddRange(new int[] { 2, 3, 4, 5 });

            bool even = list.Any(x => x % 2 == 0);
            Console.WriteLine($"Contains some numbers: {even.ToString()}");

            var evenList = list.Where(x => x % 2 == 0);
            Console.WriteLine($"even number count is {evenList.Count()}");

            var firstEven = list.FirstOrDefault(x => x % 2 != 0);

            Console.WriteLine($"First even number {firstEven}");

            //list.Clear();

            list.ForEach(x => Console.WriteLine($"Printing Item: {x.ToString()}"));

            //Both of these operations have O(n) complexity as it first perform a linear search,
            //and then shifts the element one side forward or backward
            list.RemoveAt(0);
            list.Remove(10);

            //inserts 10 at index:3 and shifts other elements 1 index further. O(n)
            list.Insert(3, 10);

            var list2 = new List<int>();

            //Return 0 if the sequence is empty or no result is found
            var checkFirstOrDefault = list2.FirstOrDefault(x => x == 0);

            list2.Add(1);

            //Crashes when empty sequence or condition not meeting the criteria
            var checkFirst = list2.First(x => x == 0);




        }

        public static void LinkedList()
        {
            var linkedList = new LinkedList<int>();

            //Adds in the start [0]
            linkedList.AddFirst(1);

            //Adds in the end
            linkedList.AddLast(2);

            //adds element after finding 2. if 2 was at [1], new element goes to [2]
            linkedList.AddAfter(linkedList.Find(2), 100);

            //adds element before finding 2. if 2 was at [1], new element goes to [1] and 2 moves to [2]
            linkedList.AddBefore(linkedList.Find(2), 100);

            //Removes from front
            linkedList.RemoveFirst();

            //Removes from end
            linkedList.RemoveLast();

            //Returns first element
            var firstElement = linkedList.First();

            //Returns last element (actual typed value like 2 if its a int)
            var lastElement = linkedList.Last();

            //Finds element (returns actual node with next/previous nodes, value  and list)
            var findElement = linkedList.Find(100);
        }

        public static void Queue()
        {
            var que = new Queue<string>();

            //Add item to the start of the queue
            que.Enqueue("A");
            que.Enqueue("B");
            que.Enqueue("C");

            string eliminatedValue;

            //Remove item from the start of the queue
            que.Dequeue();

            //Safe version of Deque in case elements i empty
            que.TryDequeue(out eliminatedValue);

            //return first (actual) value
            string firstValue = que.Peek();

            //Safe version of Peek. return boolean but outs actual value
            que.TryPeek(out firstValue);

            que.Clear();

        }

        public static void Stack()
        {
            var stack = new Stack<int>();

            //Add Item to the start
            stack.Push(1);
            stack.Push(2);

            int eliminatedValue;

            //Remove Item from the end
            stack.Pop();

            //Safe version of Pop
            stack.TryPop(out eliminatedValue);

            //return first (actual) value
            var firstValue = stack.Peek();

        }

        public static void Dictionary()
        {
            var dict = new Dictionary<int, int>();

            dict.Add(1, 2);
            dict.Add(2, 3);

            //adds only if the key does not exist
            dict.TryAdd(3, 10);

            dict[1]++;
            dict[2] = 10;

            dict.ContainsKey(1);
            dict.ContainsValue(2);
            dict.Remove(2);

            int outValue;
            dict.TryGetValue(1, out outValue);

        }

        public static void ConcurrentDictionary()
        {
            var conDict = new ConcurrentDictionary<int, int>();

            //Adds only if key does not exist. It doesn't have a regular Add() method
            conDict.TryAdd(1, 2);

            //It adds value if key doesn't exist OR updates value if key exists
            conDict.AddOrUpdate(1, 2, (key, oldVal) => oldVal + 1);

            //
            conDict.TryRemove(1, out int removedValue);
        }

        public static void HashSet()
        {
            var set = new HashSet<string>();

            //Add into set
            set.Add("Apple");
            set.Add("Banana");

            //Ignores the addition since it already exist
            set.Add("Apple");

            //Check if it exists
            var containsBanana = set.Contains("Banana");

            //Count the elements
            var count = set.Count();

            //Remove from Set
            set.Remove("Banana");

            //Removes all items
            set.Clear();

            var one = new HashSet<string> { "A", "B", "C" };
            var two = new HashSet<string> { "C", "D", "E" };

            var min = one.Min(); //A
            var max = one.Max(); //B

            //Removes common elements found in other set and all other elements of other set while 
            //keep elements for first set.
            one.ExceptWith(two);

            //Removes elements found in other set
            one.ExceptWith(two);

            //Checks if one is equal to two
            one.SetEquals(two);

            //Keeps only common items
            one.IntersectWith(two);

            //Combines other hashSet avoiding duplications
            one.UnionWith(two);

        }

        public static void SortedSet()
        {
            var setA = new SortedSet<int> { 1, 2, 3, 4 };
            var setB = new SortedSet<int> { 3, 4, 5, 6 };

            setA.IntersectWith(setB); // setA = { 3, 4 }
            setA.UnionWith(setB);     // setA = { 1, 2, 3, 4, 5, 6 }
            setA.ExceptWith(setB);    // removes 3, 4, 5, 6 from setA


            var sortedSet = new SortedSet<int>();

            sortedSet.Add(5);
            sortedSet.Add(1);
            sortedSet.Add(3);
            sortedSet.Add(3); // ignored — duplicate

            foreach (var item in sortedSet)
            {
                Console.Write(item + " ");
            }
        }

        public static void BitArray()
        {
            var bits1 = new BitArray(8);                      // All bits = false
            var bits2 = new BitArray(new bool[] { true, false, true });
            var bits3 = new BitArray(8, true);                // All bits = true

            //Can only add bit arrays of the same length
            bits1.And(bits3);

            var bits = new BitArray(4); // [false, false, false, false]

            bits[0] = true;
            bits[2] = true;             // [true, false, true, false]

            //Reverse the bit
            var notBits = bits.Not();   // [false, true, false, true]

            var a = new BitArray(new bool[] { true, false, true });
            var b = new BitArray(new bool[] { false, true, true });

            //And operation
            var resultAnd = a.And(b); // [false, false, true]

            //OR operation
            var resultOr = a.Or(b); // [false, true, true]

            //XOR operation
            var resultXor = a.Or(b);

            //Set all true/false
            a.SetAll(true);
            a.SetAll(false);

            //Set specific bit true/false based on index
            a.Set(1, false);

        }

        /// <summary>
        /// PriorityQueue is the data structure used for heap in c#
        /// by default, priorityQueue is minHeap --> minHeap.Enqueue(item,item)
        /// for maxHeap --> maxHeap.Enqueue(item, -item)
        /// </summary>
        public static void PriorityQueueAndHeap()
        {
            var pq = new PriorityQueue<string, int>();

            pq.Enqueue("Clean room", 2);
            pq.Enqueue("Do homework", 1);
            pq.Enqueue("Play games", 3);


            //Stores with the same priority
            pq.Enqueue("Do Nothing", 1);

            //In case it has multiple elements with same priority, it will deque based on the order they were added.
            while (pq.Count > 0)
            {
                //Deque operation crashes on emply queue. Use TryDeque()
                Console.WriteLine(pq.Dequeue());
            }
            //Output:
            //Do homework
            //Do nothing    
            //Clean room
            //Play games

            //Peek operation crashes on empty queue. Use TryPeek()
            //pq.Peek();


            //PriorityQueue are used for heap in C#
            PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();
            PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();


            var array = new int[] { 7, 10, 4, 3, 20, 15 };

            for (int counter = 0; counter < array.Length; counter++)
            {
                minHeap.Enqueue(array[counter], array[counter]);
            }

            for (int counter = 0; counter < array.Length; counter++)
            {
                maxHeap.Enqueue(array[counter], -array[counter]);
            }



        }

        public static void MultiDimenstionArrays()
        {
            //Option 1: int[][]

            //rows must be defined
            int[][] arr1 = new int[2][];

            //initializing first array of arr to contain an array of size 2. Example: [2,3
            arr1[0] = new int[2];

            //This operation cannot happen directly without initializing the array in above line.
            arr1[0][0] = 2;
            arr1[0][1] = 3;

            //Option 2: int[,]

            //Both row and columns must be defined
            int[,] arr2 = new int[4, 2];

            arr2[0, 0] = 1;
            arr2[0, 1] = 2;

            //Will crash because max row length is 4 (max row: 3).
            //arr2[4, 0] = 3;
            //arr2[4, 1] = 7;

        }

        public static void Enums()
        {

        }


    }
}
