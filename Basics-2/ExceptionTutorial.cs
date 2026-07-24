using System;

namespace Basics_2
{
    internal class ExceptionTutorial
    {
        /*
         * Exception
         * ---------
         * An exception is a runtime error (an abnormal event) that occurs
         * while a program is executing.
         *
         * An exception interrupts the normal flow of the program.
         *
         * In C#, every exception is an object derived from the Exception class.
         *
         * If an exception is NOT handled:
         * 1. The program terminates (crashes).
         * 2. An error message is displayed.
         * 3. The remaining statements are not executed.
         *
         * Examples:
         * - DivideByZeroException
         * - IndexOutOfRangeException
         * - NullReferenceException
         * - FormatException
         * - OverflowException
         * - FileNotFoundException
         */

        public static void Run()
        {
            Console.WriteLine("--------------- Exception Handling ----------------");

            try
            {
                Console.Write("Enter the first number: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Enter the second number: ");
                int num2 = int.Parse(Console.ReadLine());

                int result = num1 / num2;

                Console.WriteLine($"Division Result = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("You cannot divide a number by zero.");
                Console.WriteLine("Exception: " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter only numeric values.");
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Program continues after exception handling.");

            Console.WriteLine("Remaining Statement 1");
            Console.WriteLine("Remaining Statement 2");
            Console.WriteLine("Remaining Statement 3");

            Console.WriteLine();

            //-------------------------------------------------------
            // IndexOutOfRangeException Example
            //-------------------------------------------------------

            Console.WriteLine("------ IndexOutOfRangeException Example ------");

            try
            {
                int[] numbers = { 10, 20, 30 };

                // Valid indexes are 0, 1, and 2
                Console.WriteLine(numbers[5]);   // Exception
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Index is outside the bounds of the array.");
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.WriteLine();

            Console.WriteLine("Program finished successfully.");

            //-------------------------------------------------------
            // NullReferenceException Example
            //-------------------------------------------------------

            Console.WriteLine();
            Console.WriteLine("------ NullReferenceException Example ------");

            try
            {
                string name = null;// we can use "vikas 

                // Throws NullReferenceException because
                // name does not refer to any object.
                Console.WriteLine(name.Length);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("You are trying to access an object that is null.");
                Console.WriteLine("Exception: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}