using System;

namespace Object_Oriented_Programming___2
{
    internal class InterfaceTutorial
    {
        /*
         * Interface
         * ---------
         * An interface is a contract (agreement) between itself and any class
         * that implements it.
         *
         * It specifies WHAT a class must do,
         * but not HOW it should do it.
         *
         * A class that implements an interface
         * MUST implement all required members.
         */

        public interface IEmployee
        {
            // Interface members are public by default.
            // Since C# 8, explicit access modifiers are also allowed.

            void Show();

            // Since C# 8, interfaces can contain methods
            // with a default implementation.
            void PrintCompanyName()
            {
                Console.WriteLine("Company : ABC Pvt Ltd");
            }
        }

        // A class can implement one or more interfaces.
        public class PartTimeEmployee : IEmployee
        {
            // Required implementation
            public void Show()
            {
                Console.WriteLine("Part-Time Employee");
            }

            // Uses the default implementation of PrintCompanyName()
        }

        public class FullTimeEmployee : IEmployee
        {
            public void Show()
            {
                Console.WriteLine("Full-Time Employee");
            }

            // Custom implementation instead of the default one
            public void PrintCompanyName()
            {
                Console.WriteLine("Company : FullTime Pvt Ltd");
            }
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Interface ----------------");

            // Interfaces cannot be instantiated.
            // IEmployee employee = new IEmployee(); // ❌ Compile-time error

            // An interface can have static members,
            // but it cannot have instance fields because
            // interfaces cannot be instantiated.

            // Upcasting:
            // Store a child object in an interface reference.
            IEmployee partTime = new PartTimeEmployee();

            partTime.Show();

            // Calls the default implementation from the interface.
            partTime.PrintCompanyName();

            Console.WriteLine();

            IEmployee fullTime = new FullTimeEmployee();

            fullTime.Show();

            // Calls FullTimeEmployee's implementation.
            fullTime.PrintCompanyName();
        }
    }
}