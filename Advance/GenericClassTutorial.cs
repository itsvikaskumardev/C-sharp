using System;

namespace Advance
{
    internal class GenericClassTutorial
    {
        /*
         * Generic Class
         * -------------
         * A generic class is a class that can work with different
         * data types by using a type parameter (T).
         *
         * Syntax:
         * class ClassName<T>
         * {
         * }
         */

        public class Employee<T>
        {
            // Generic property
            public T Id { get; set; }

            // Normal property
            public string Name { get; set; }

            public Employee(T id, string name)
            {
                Id = id;
                Name = name;
            }

            public void Display()
            {
                Console.WriteLine($"Employee Id   : {Id}");
                Console.WriteLine($"Employee Name : {Name}");
            }
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Generic Class ----------------");

            // T becomes int
            Employee<int> emp1 = new Employee<int>(101, "Vikas");

            emp1.Display();

            Console.WriteLine();

            // T becomes string
            Employee<string> emp2 = new Employee<string>("EMP-102", "Rahul");

            emp2.Display();

            Console.WriteLine();

            // T becomes Guid
            Employee<Guid> emp3 =
                new Employee<Guid>(Guid.NewGuid(), "Aman");

            emp3.Display();
        }
    }
}