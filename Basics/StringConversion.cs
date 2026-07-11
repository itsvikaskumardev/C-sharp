using System;
using System.Collections.Generic;
using System.Text;

namespace C_
{
    internal class StringConversion
    {
        public static void Run()
        {
            Console.WriteLine("--------------- String Methods ----------------");

            string str = "   Hello Vikas   ";

            Console.WriteLine($"Original String : '{str}'");

            Console.WriteLine();
            Console.WriteLine("--------------- Formatting ----------------");

            Console.WriteLine($"ToLower : {str.ToLower()}");
            Console.WriteLine($"ToUpper : {str.ToUpper()}");
            Console.WriteLine($"Trim    : '{str.Trim()}'");

            Console.WriteLine();

            Console.WriteLine("--------------- Searching ----------------");

            string name = "Vikas Kumar";

            Console.WriteLine($"IndexOf('a')      : {name.IndexOf('a')}");
            Console.WriteLine($"LastIndexOf('a')  : {name.LastIndexOf('a')}");

            Console.WriteLine();

            Console.WriteLine("--------------- Substring ----------------");

            Console.WriteLine($"Substring(2)      : {name.Substring(2)}");
            Console.WriteLine($"Substring(2, 3)   : {name.Substring(2, 3)}");

            Console.WriteLine();

            Console.WriteLine("--------------- Replace ----------------");

            Console.WriteLine($"Replace('a', 'i') : {name.Replace('a', 'i')}");
            Console.WriteLine($"Replace(\"Vikas\", \"Mosh\") : {name.Replace("Vikas", "Mosh")}");

            Console.WriteLine();

            Console.WriteLine("--------------- Null Checking ----------------");

            string empty = "";
            string whiteSpace = "   ";

            Console.WriteLine($"IsNullOrEmpty(empty)      : {string.IsNullOrEmpty(empty)}");
            Console.WriteLine($"IsNullOrWhiteSpace(empty) : {string.IsNullOrWhiteSpace(empty)}");
            Console.WriteLine($"IsNullOrWhiteSpace(whiteSpace) : {string.IsNullOrWhiteSpace(whiteSpace)}");

            Console.WriteLine();

            Console.WriteLine("--------------- Splitting ----------------");

            string fullName = "Vikas Kumar Sharma";

            string[] parts = fullName.Split(' ');

            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }

            Console.WriteLine();

            Console.WriteLine("--------------- String to Number ----------------");

            string number = "123";

            int num1 = int.Parse(number);
            int num2 = Convert.ToInt32(number);

            Console.WriteLine($"int.Parse : {num1}");
            Console.WriteLine($"Convert.ToInt32 : {num2}");

            Console.WriteLine();

            Console.WriteLine("--------------- Number to String ----------------");

            int age = 23;

            string age1 = age.ToString();
            string age2 = Convert.ToString(age);

            Console.WriteLine($"ToString : {age1}");
            Console.WriteLine($"Convert.ToString : {age2}");
        }
    }
}