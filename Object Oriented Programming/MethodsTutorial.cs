using System;

namespace Object_Oriented_Programming
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Move using x and y coordinates
        public void Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Move using another Point object
        public void Move(Point newLocation)
        {
            Move(newLocation.X, newLocation.Y);
        }
    }

    internal class MethodsTutorial
    {
        public static void Run()
        {
            var point = new Point(10, 20);

            point.Move(new Point(40, 60));
            Console.WriteLine("Point is at: {0}, {1}", point.X, point.Y);

            point.Move(100, 200);
            Console.WriteLine("Point is at: {0}, {1}", point.X, point.Y);
        }
    }
}