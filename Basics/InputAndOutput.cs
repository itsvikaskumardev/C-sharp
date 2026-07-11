using System;

namespace C__Basics_Tutorial
{
    public class InputAndOutput
    {
        public static void Run()
        {
            Console.WriteLine("----------- BASIC INPUT -----------");

            // Console.Write("Enter your name: ");
            // string name = Console.ReadLine();
            // Console.WriteLine("Hello " + name);

            Console.WriteLine();

            Console.WriteLine("----------- NUMBER ADDITION -----------");

            // Console.Write("Enter First Number: ");
            // int num1 = int.Parse(Console.ReadLine());

            // Console.Write("Enter Second Number: ");
            // int num2 = int.Parse(Console.ReadLine());

            // Console.WriteLine("Sum = " + (num1 + num2));

            Console.WriteLine();

            Console.WriteLine("----------- FLOAT INPUT -----------");

            // Console.Write("Enter a decimal number: ");
            // float number = float.Parse(Console.ReadLine());

            // Console.WriteLine("You entered: " + number);

            Console.WriteLine();

            Console.WriteLine("----------- STRING CONCATENATION -----------");

            // Console.Write("Enter First Name: ");
            // string firstName = Console.ReadLine();

            // Console.Write("Enter Last Name: ");
            // string lastName = Console.ReadLine();

            // Console.WriteLine("Full Name: " + firstName + " " + lastName);

            Console.WriteLine();

            Console.WriteLine("----------- STRING INTERPOLATION -----------");

            string course = "C#";
            int duration = 30;

            Console.WriteLine($"Course: {course}");
            Console.WriteLine($"Duration: {duration} Days");

            Console.WriteLine();

            Console.WriteLine("----------- FORMATTED OUTPUT -----------");

            int marks = 95;
            Console.WriteLine("Marks = {0}", marks);
            Console.WriteLine("Marks = {0}, Course = {1}", marks, course);

            Console.WriteLine();

            Console.WriteLine("----------- SAFE NUMBER INPUT -----------");

            // Console.Write("Enter your age: ");
            // string input = Console.ReadLine();

            // if (int.TryParse(input, out int age))
            // {
            //     Console.WriteLine($"Your age is {age}");
            // }
            // else
            // {
            //     Console.WriteLine("Invalid number.");
            // }

            Console.WriteLine();

            Console.WriteLine("----------- TYPE CONVERSION -----------");

            int x = 10;
            string str = x.ToString();

            Console.WriteLine($"Integer : {x}");
            Console.WriteLine($"String  : {str}");

            string numberText = "100";
            int y = Convert.ToInt32(numberText);

            Console.WriteLine($"Converted back to int : {y}");

            Console.WriteLine();

            Console.WriteLine("----------- ESCAPE SEQUENCES -----------");

            Console.WriteLine("Hello\nVikas");
            Console.WriteLine("C:\\Users\\Vikas\\Documents");
            Console.WriteLine("She said \"Hello\".");

            Console.WriteLine();

            Console.WriteLine("----------- READKEY EXAMPLE -----------");

            // Console.WriteLine("Press any key to continue...");
            // Console.ReadKey();
        }
    }
}