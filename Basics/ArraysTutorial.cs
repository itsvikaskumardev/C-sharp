using System;

namespace C__Basics_Tutorial
{
    public class ArraysTutorial
    {
        public static void Run()
        {
            Console.WriteLine("-----------------------------ArraysTutorial--------------------------------------------------------------------");
            Console.WriteLine("---------------- Array ----------------");

            int[] arr = new int[3]; //new operaotr for memory allocation 
            arr[0] = 27;
            arr[1] = 55;
            arr[2] = 65;
            //arr[3] = 47;//System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'

            Console.WriteLine(arr[2]);

            string[] names = { "vikas", "Rahul", "vikrant" };
            //Console.WriteLine(names);

            // For loop
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }

            // foreach
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }


            Console.WriteLine("----------------2D Array ----------------");

            //1.Rectangular Array([,]):  All rows have the same number of columns.
            int[,] my_arr = new int[3, 4]
            {
                {12,44,33,55 },
                {23,45,65,34 },
                { 44,23,47,87}
            };

            Console.WriteLine(my_arr[1, 2]);//65
            Console.WriteLine(my_arr.Length);//12
            Console.WriteLine(my_arr.GetLength(0));// return 3 becuause 0th location of [3,4]
            Console.WriteLine(my_arr.GetLength(1));// return  becuause 1st location of [3,4]
            Console.WriteLine("----Printing 2D array-----");

            for (int i = 0; i < my_arr.GetLength(0); i++)
            {
                for (int j = 0; j < my_arr.GetLength(1); j++)
                {
                    Console.Write(my_arr[i, j] + " ");
                }
                Console.WriteLine(); // move to next row
            }
            Console.WriteLine("----Printing 2D array using for Each loop----");

            foreach (int item in my_arr)
            {
                Console.WriteLine(item);
            }

            //2.Jagged Array([][]) :A jagged array is an array of arrays. Each row can have a different number of columns.

            Console.WriteLine("----2D array Jagged Array ----");

            int[][] brr = new int[3][]; // 3 rows, but each row can have a different number of columns.
            brr[0] = new int[] { 1, 2 };
            brr[1] = new int[] { 3, 4, 5 };
            brr[2] = new int[] { 6 };

            Console.WriteLine(brr[1][2]);

            for (int i = 0; i < brr.Length; i++)
            {
                for (int j = 0; j < brr[i].Length; j++)
                {
                    Console.Write(brr[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("----User input in 1D array----");

            Console.WriteLine("Enter the size of array:");
            // Using null-forgiving operator to fix nullable warning!
            int n = int.Parse(Console.ReadLine()!);
            int[] arrr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int val = int.Parse(Console.ReadLine()!);
                arrr[i] = val;
            }

            Console.WriteLine("Printing 1D array");
            for (int i = 0; i < n; i++)
            {
                Console.Write(arrr[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
