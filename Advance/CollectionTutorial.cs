using System;
using System.Collections;

namespace Advance
{
    internal class CollectionTutorial
    {
        /*
         * Collections
         * -----------
         * A collection is used to store multiple objects.
         * Unlike arrays, many collections can grow or shrink at runtime.
         *
         * Collections provide methods to:
         * - Add
         * - Insert
         * - Remove
         * - Search
         * - Sort
         * - Iterate over elements
         *
         * There are two types of collections:
         *
         * 1. Non-Generic Collections
         *    - ArrayList
         *    - Hashtable
         *    - Stack
         *    - Queue
         *    - SortedList
         *
         * 2. Generic Collections
         *    - List<T>
         *    - Dictionary<TKey, TValue>
         *    - Queue<T>
         *    - Stack<T>
         *    - LinkedList<T>
         *    - HashSet<T>
         */

        public static void Run()
        {
            Console.WriteLine("--------------- Non-Generic Collection : ArrayList ----------------");

            // ArrayList can store different data types.
            ArrayList list = new ArrayList();

            list.Add(10);
            list.Add("Vikas Kumar");
            list.Add(true);
            list.Add(15.5);

            Console.WriteLine($"Count: {list.Count}");
            Console.WriteLine($"Capacity: {list.Capacity}");

            Console.WriteLine();

            Console.WriteLine("--------------- Elements ----------------");

            foreach (object item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("--------------- Insert ----------------");

            list.Insert(1, "Inserted Value");

            foreach (object item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("--------------- Remove ----------------");

            list.Remove(true);

            foreach (object item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine("--------------- RemoveAt ----------------");

            list.RemoveAt(0);

            foreach (object item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            Console.WriteLine($"Contains \"Vikas Kumar\": {list.Contains("Vikas Kumar")}");
            Console.WriteLine($"IndexOf \"Inserted Value\": {list.IndexOf("Inserted Value")}");

            Console.WriteLine();

            Console.WriteLine("--------------- Clear ----------------");

            list.Clear();

            Console.WriteLine($"Count after Clear(): {list.Count}");
        }
    }
}