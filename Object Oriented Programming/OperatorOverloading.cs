using System;

namespace Object_Oriented_Programming
{
    internal class OperatorOverloading
    {
        /*
         * Operator Overloading
         * --------------------
         * Operator overloading allows us to define how operators
         * (+, -, *, ==, etc.) work for our own classes or structs.
         *
         * Without operator overloading:
         *      Point p3 = Add(p1, p2);
         *
         * With operator overloading:
         *      Point p3 = p1 + p2;
         *
         * This makes the code cleaner, easier to read, and more intuitive.
         */

        public class Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            // Overloading the + operator
            // This tells C# how to add two Point objects.
            public static Point operator +(Point p1, Point p2)
            {
                return new Point(
                    p1.X + p2.X,
                    p1.Y + p2.Y
                );
            }
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Operator Overloading ----------------");

            Point p1 = new Point(2, 3);
            Point p2 = new Point(4, 5);

            // Instead of writing:
            // Point p3 = Point.Add(p1, p2);

            // We can simply use the + operator.
            Point p3 = p1 + p2;

            Console.WriteLine($"Point 1 : ({p1.X}, {p1.Y})");
            Console.WriteLine($"Point 2 : ({p2.X}, {p2.Y})");
            Console.WriteLine($"Point 3 : ({p3.X}, {p3.Y})");
        }
    }
}