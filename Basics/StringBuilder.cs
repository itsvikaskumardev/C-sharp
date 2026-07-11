using System;
using System.Text;

namespace C_
{
    internal class StringBuilderTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- StringBuilder ----------------");

            //"Strings are immutable
            //Every time you modify a string, a new string object is created
            //StringBuilder is mutable, meaning its contents can be changed without creating a new object

            Console.WriteLine();

            // Creating a StringBuilder
            var sb = new StringBuilder();

            Console.WriteLine("--------------- Append ----------------");

            sb.Append("Hello");
            sb.Append(" ");
            sb.Append("Vikas");

            Console.WriteLine(sb);

            Console.WriteLine();

            Console.WriteLine("--------------- Insert ----------------");

            sb.Insert(6, "Mr. ");

            Console.WriteLine(sb);

            Console.WriteLine();

            Console.WriteLine("--------------- Replace ----------------");

            sb.Replace("Mr.", "Dr.");

            Console.WriteLine(sb);

            Console.WriteLine();

            Console.WriteLine("--------------- Remove ----------------");

            sb.Remove(6, 4); // Removes "Dr. "

            Console.WriteLine(sb);

            Console.WriteLine();

            Console.WriteLine("--------------- Length ----------------");

            Console.WriteLine($"Length: {sb.Length}");

            Console.WriteLine();

            Console.WriteLine("--------------- Clear ----------------");

            sb.Clear();

            Console.WriteLine($"After Clear: '{sb}'");
            Console.WriteLine($"Length: {sb.Length}");
        }
    }
}