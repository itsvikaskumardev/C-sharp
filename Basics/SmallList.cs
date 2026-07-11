using System;
using System.Collections.Generic;

namespace C_
{
    internal class SmallList
    {
        public static void Run()
        {
            var numbers = new List<int>() { 5, 1, 4, 2, 3 };

            //var correct = GetSmallest(numbers, 3);
            var wrong = GetSmallests(numbers, 3);

            //Console.WriteLine("Correct method:");
            //foreach (var number in correct)
            //    Console.WriteLine(number);

            Console.WriteLine("Wrong method:");
            foreach (var number in wrong)
                Console.WriteLine(number);
        }

        // Correct method
        public static List<int> GetSmallest(List<int> list, int count)
        {
            var temp = new List<int>(list);
            temp.Sort();
            return temp.GetRange(0, count);
        }

        // Intentionally wrong method (for debugging practice)
        public static List<int> GetSmallests(List<int> list, int count)
        {
            var temp = new List<int>(list);
            temp.Sort();
            return temp.GetRange(1, count); // Wrong: starts from index 1
        }
    }
}