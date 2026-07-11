using System;
using System.Collections.Generic;
using System.Text;

namespace C_
{
    internal class Iterations
    {
        public static void Run()
        {
            Console.WriteLine("--------------- For Loop ----------------");

            // Print numbers from 1 to 5
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            Console.WriteLine("--------------- ForEach Loop ----------------");

            string[] fruits = { "Apple", "Banana", "Mango", "Orange" };

            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            Console.WriteLine();

            Console.WriteLine("--------------- While Loop ----------------");

            int count = 1;

            while (count <= 5)
            {
                Console.WriteLine(count);
                count++;
            }

            Console.WriteLine();

            Console.WriteLine("--------------- Do While Loop ----------------");

            int number = 1;

            do
            {
                Console.WriteLine(number);
                number++;
            }
            while (number <= 5);
        }
    }
}