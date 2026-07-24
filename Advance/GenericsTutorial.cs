using System;

namespace Advance
{
    /*
     * Generics
     * --------
     * Generics allow us to write classes and methods
     * that work with any data type.
     *
     * Benefits:
     * 1. Code Reusability
     * 2. Type Safety
     * 3. Better Performance (no boxing/unboxing)
     * 4. No need to write the same code multiple times.
     */

    public class Example
    {
        // Generic Method
        // T is called a Type Parameter.
        // It will be replaced by the actual data type
        // (int, string, double, etc.) when the method is called.
        public void ShowArray<T>(T[] arr)
        {
            Console.WriteLine($"Displaying {typeof(T).Name} Array:");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Array Value: {arr[i]}");
            }

            Console.WriteLine();
        }

        /*
         * Without Generics, we would have to write
         * separate overloaded methods like these:
         *
         * public void ShowArray(int[] arr) { ... }
         * public void ShowArray(string[] arr) { ... }
         * public void ShowArray(double[] arr) { ... }
         * public void ShowArray(bool[] arr) { ... }
         *
         * The logic is exactly the same.
         * Generics let us write it only once.
         */
    }

    internal class GenericsTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Generics ----------------");

            Example example = new Example();

            int[] numbers = { 10, 20, 30 };

            string[] names =
            {
                "Vikas",
                "Rahul",
                "Aman"
            };

            double[] marks =
            {
                87.5,
                91.2,
                78.6
            };

            // The compiler automatically determines T.
            example.ShowArray(numbers);   // T becomes int
            example.ShowArray(names);     // T becomes string
            example.ShowArray(marks);     // T becomes double

            // You can also specify T explicitly.
            example.ShowArray<int>(numbers);
            example.ShowArray<string>(names);
        }
    }
}