using System;

namespace Advance
{
    // Delegate that does not return a value
    delegate void PrintDelegate(int num);

    // Delegate that returns an int
    delegate int ReturnDelegate(int num);

    internal class AnonymousFunctionTutorial
    {
        /*
         * Anonymous Method
         * ----------------
         * An anonymous method is a method without a name.
         *
         * It is written using the delegate keyword.
         *
         * Anonymous methods are usually assigned to a delegate.
         *
         * They are useful when a method is needed only once,
         * so there is no need to create a separate named method.
         */

        // Normal method
        public static void Method(int a)
        {
            a += 10;
            Console.WriteLine($"Value of a: {a}");
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Anonymous Methods ----------------");

            // Delegate pointing to a normal method
            PrintDelegate obj = Method;

            obj(20);

            Console.WriteLine();

            // Delegate pointing to an anonymous method
            obj = delegate (int a)
            {
                a += 10;
                Console.WriteLine($"Value of a: {a}");
            };

            obj(20);

            Console.WriteLine();

            Console.WriteLine("--------------- Anonymous Method with Return Value ----------------");

            // Anonymous method that returns a value
            ReturnDelegate obj2 = delegate (int a)
            {
                return a * a;
            };

            int result = obj2(10);

            Console.WriteLine($"Square = {result}");

            Console.WriteLine();

            // Another example
            ReturnDelegate cube = delegate (int a)
            {
                return a * a * a;
            };

            Console.WriteLine($"Cube = {cube(5)}");
        }
    }
}