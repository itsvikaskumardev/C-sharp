using System;

namespace Advance
{
    // Declare a delegate.
    // Any method assigned to this delegate must have
    // the same signature: void Method(int, int)
    public delegate void Calculation(int a, int b);

    internal class DelegatesTutorial
    {
        /*
         * Delegate
         * --------
         * A delegate is a reference type that stores the reference
         * (address) of one or more methods.
         *
         * It is similar to a function pointer in C/C++, but it is
         * type-safe.
         *
         * The delegate signature must match the method signature.
         *
         * Delegate Signature:
         *      void(int, int)
         *
         * So only methods returning void and accepting
         * two int parameters can be assigned to it.
         */

        public static void Addition(int a, int b)
        {
            Console.WriteLine($"Addition = {a + b}");
        }

        public static void Subtraction(int a, int b)
        {
            Console.WriteLine($"Subtraction = {a - b}");
        }

        public static void Multiply(int a, int b)
        {
            Console.WriteLine($"Multiplication = {a * b}");
        }

        public static void Divide(int a, int b)
        {
            Console.WriteLine($"Division = {a / b}");
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Delegates ----------------");

            // Store the reference of Addition() inside the delegate.
            Calculation calc = Addition;

            // Invoke the delegate.
            calc(20, 10);

            Console.WriteLine();

            // Now point to another method.
            calc = Subtraction;
            calc(20, 10);

            Console.WriteLine();

            calc = Multiply;
            calc(20, 10);

            Console.WriteLine();

            calc = Divide;
            calc(20, 10);

            Console.WriteLine();

            // Multicast Delegate
            // One delegate can point to multiple methods.
            calc = Addition;
            calc += Subtraction;
            calc += Multiply;

            Console.WriteLine("Multicast Delegate:");

            calc(10, 5);
        }
    }
}