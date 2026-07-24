using System;

namespace Basics_2
{
    internal class ThrowKeyword
    {
        /*
         * Throw Keyword
         * -------------
         * The throw keyword is used to explicitly (manually) throw an exception.
         *
         * We use throw when we detect an invalid condition in our code
         * and want to stop the current execution by raising an exception.
         *
         * Syntax:
         * throw new ExceptionType("Error message");
         *
         * Yes, throw is related to exceptions.
         * It does not create a new type of error.
         * Instead, it throws an exception object that can be caught
         * by a try-catch block.
         */

        public static void ValidateAge(int age)
        {
            // Business validation
            if (age < 18)
            {
                throw new ArgumentException("Age must be 18 or above.");
            }

            Console.WriteLine("Age is valid.");
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Throw Keyword ----------------");

            try
            {
                Console.Write("Enter your age: ");

                int age = int.Parse(Console.ReadLine());

                ValidateAge(age);

                Console.WriteLine("Registration Successful.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Validation Error: " + ex.Message);
            }

            Console.WriteLine();
            Console.WriteLine("Program continues...");
        }
    }
}