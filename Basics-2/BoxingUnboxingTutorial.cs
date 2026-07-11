using System;

namespace Basics_2
{
    internal class BoxingUnboxingTutorial
    {
        /*
         * BOXING
         * -------
         * Boxing is the implicit conversion of a value type to a reference type.
         *
         * Value Types:
         * int, float, double, bool, char, struct, enum
         *
         * During boxing:
         * 1. The value is copied from the stack.
         * 2. A new object is created on the heap.
         * 3. The object reference is stored in the object variable.
         *
         * Stack                  Heap
         * ----------------      -----------------
         * num1 = 10      ----->  Object
         * obj1 ---------┘        Value = 10
         */

        public static void Run()
        {
            Console.WriteLine("--------------- Boxing ----------------");

            int num1 = 10;

            // Boxing (Implicit)
            object obj1 = num1;

            Console.WriteLine($"num1 = {num1}");
            Console.WriteLine($"obj1 = {obj1}");

            Console.WriteLine();

            Console.WriteLine("--------------- Unboxing ----------------");

            // Compile-time Error
            // Cannot implicitly convert object to int.
            // int num2 = obj1;

            // Unboxing (Explicit)
            int num2 = (int)obj1;

            Console.WriteLine($"num2 = {num2}");
        }
    }
}

/*
Memory after Boxing

Stack                           Heap
-------------------             ---------------------
num1 = 10                       +-------------+
obj1 -------------------------> |     10      |
                                +-------------+

Memory after Unboxing

Stack                           Heap
-------------------             ---------------------
num1 = 10                       +-------------+
num2 = 10                       |     10      |
obj1 -------------------------> |             |
                                +-------------+
*/