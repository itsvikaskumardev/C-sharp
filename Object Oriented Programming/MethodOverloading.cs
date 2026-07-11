using System;

namespace Object_Oriented_Programming
{
    internal class MethodOverloading
    {
        public static void Run()
        {
            Calculator calculator = new Calculator();

            Console.WriteLine("Add(int, int): " + calculator.Add(10, 20));

            Console.WriteLine("Add(int, int, int): " + calculator.Add(10, 20, 30));

            Console.WriteLine("Add(double, double): " + calculator.Add(10.5, 20.5));
        }
    }

    public class Calculator
    {
        // Method 1
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Method 2 (Overloaded)
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // Method 3 (Overloaded)
        public double Add(double a, double b)
        {
            return a + b;
        }
    }
}