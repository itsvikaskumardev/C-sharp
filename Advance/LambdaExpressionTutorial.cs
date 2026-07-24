using System;

namespace Advance
{
    // Delegate that does not return a value
    public delegate void PrintDelegate(int num);

    // Delegate that returns an int
    public delegate int ReturnDelegate(int num);

    /*
     * Lambda Expression
     * -----------------
     * A lambda expression is a shorter way of writing an anonymous method.
     *
     * Syntax:
     *      (parameters) => expression
     * or
     *      (parameters) => { statements }
     *
     * Left side  (=>) : Input parameters
     * Right side (=>) : Expression or statements to execute
     *
     * Types of Lambda Expressions
     *
     * 1. Statement Lambda
     *    - Contains one or more statements.
     *    - Uses curly braces { }.
     *    - If it returns a value, use the return keyword.
     *
     *    Syntax:
     *    (parameters) => { statements }
     *
     * 2. Expression Lambda
     *    - Contains only one expression.
     *    - No curly braces.
     *    - The value is returned automatically.
     *
     *    Syntax:
     *    (parameters) => expression
     */

    internal class LambdaExpressionTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Lambda Expressions ----------------");

            // Anonymous Method
            PrintDelegate obj = delegate (int a)
            {
                a += 5;
                Console.WriteLine($"Anonymous Method Result: {a}");
            };

            obj(5);

            Console.WriteLine();

            // Statement Lambda
            PrintDelegate obj2 = (a) =>
            {
                a += 5;
                Console.WriteLine($"Statement Lambda Result: {a}");
            };

            obj2(5);

            Console.WriteLine();

            // Expression Lambda
            ReturnDelegate square = a => a * a;

            Console.WriteLine($"Square = {square(10)}");

            Console.WriteLine();

            // Expression Lambda
            ReturnDelegate cube = a => a * a * a;

            Console.WriteLine($"Cube = {cube(5)}");

            Console.WriteLine();

            // Statement Lambda with return
            ReturnDelegate multiplyBy10 = (a) =>
            {
                return a * 10;
            };

            Console.WriteLine($"Multiply By 10 = {multiplyBy10(8)}");
        }
    }
}