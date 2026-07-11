using System;
using System.Collections.Generic;
using System.Text;

namespace C_
{
    internal class ListTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- List ----------------");

            //"A List is a dynamic collection.
            //"Unlike an array, its size can grow or shrink."

            Console.WriteLine("Creating an empty list.");
            var numbers = new List<int>(); // List is a generic type

            Console.WriteLine("Creating and initializing a list.");
            var plumbers = new List<int>() { 1, 2, 3, 4, 5 };

            Console.WriteLine("--------------- Add ----------------");

            numbers.Add(10);
            numbers.Add(20);
            numbers.Add(30);

            Console.WriteLine("After Add:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            Console.WriteLine("--------------- AddRange ----------------");

            numbers.AddRange(new List<int> { 40, 50, 60 });

            Console.WriteLine("After AddRange:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            Console.WriteLine("--------------- Count ----------------");
            Console.WriteLine($"Count: {numbers.Count}");

            Console.WriteLine();

            Console.WriteLine("--------------- Contains ----------------");
            Console.WriteLine($"Contains 20: {numbers.Contains(20)}");
            Console.WriteLine($"Contains 100: {numbers.Contains(100)}");

            Console.WriteLine();

            Console.WriteLine("--------------- IndexOf ----------------");
            Console.WriteLine($"Index of 30: {numbers.IndexOf(30)}");

            Console.WriteLine();

            Console.WriteLine("--------------- Remove ----------------");

            numbers.Remove(20);

            Console.WriteLine("After Remove(20):");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            Console.WriteLine("--------------- RemoveAll ----------------");

            numbers.Add(10);
            numbers.Add(10);

            Console.WriteLine("Before RemoveAll:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            numbers.RemoveAll(n => n == 10);

            Console.WriteLine();

            Console.WriteLine("After RemoveAll(n => n == 10):");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}