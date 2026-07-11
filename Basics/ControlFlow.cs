using System;

namespace C__Basics_Tutorial
{
    public class ControlFlow
    {
        public static void Run()
        {
            Console.WriteLine("--------------- If-Else ----------------");

            int age = 20;

            if (age >= 18)
            {
                Console.WriteLine("You are an adult.");
            }
            else
            {
                Console.WriteLine("You are a minor.");
            }

            Console.WriteLine();

            Console.WriteLine("--------------- If-Else If ----------------");

            int marks = 85;

            if (marks >= 90)
            {
                Console.WriteLine("Grade A");
            }
            else if (marks >= 75)
            {
                Console.WriteLine("Grade B");
            }
            else if (marks >= 50)
            {
                Console.WriteLine("Grade C");
            }
            else
            {
                Console.WriteLine("Fail");
            }

            Console.WriteLine();

            Console.WriteLine("--------------- Boolean Check ----------------");

            bool isLoggedIn = true;
            bool isAdmin = false;

            if (isLoggedIn)
            {
                Console.WriteLine("User is logged in.");
            }

            if (isLoggedIn && isAdmin)
            {
                Console.WriteLine("Welcome Admin.");
            }
            else
            {
                Console.WriteLine("You are not an admin.");
            }

            Console.WriteLine();

            Console.WriteLine("--------------- Ternary Operator ----------------");

            int number = 10;

            string result = (number % 2 == 0)
                ? "Even Number"
                : "Odd Number";

            Console.WriteLine(result);

            Console.WriteLine();

            Console.WriteLine("--------------- Switch Case ----------------");

            Console.WriteLine("Enter week number (1-7):");

            // int weekNumber = int.Parse(Console.ReadLine());
            int weekNumber = 2;

            switch (weekNumber)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;

                case 2:
                    Console.WriteLine("Tuesday");
                    break;

                case 3:
                    Console.WriteLine("Wednesday");
                    break;

                case 4:
                    Console.WriteLine("Thursday");
                    break;

                case 5:
                    Console.WriteLine("Friday");
                    break;

                case 6:
                    Console.WriteLine("Saturday");
                    break;

                case 7:
                    Console.WriteLine("Sunday");
                    break;

                default:
                    Console.WriteLine("Invalid Week Number");
                    break;
            }
        }
    }
}