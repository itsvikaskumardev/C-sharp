using System;

namespace Object_Oriented_Programming
{
    public class PropertyStudent
    {
        // Auto-implemented Property
        public string Name { get; set; }

        // Private backing field : The field that actually stores the value for a property.
        private int _age;

        // Property with validation

        // 1) Age → Property  2) _age → Backing field
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                if (value >= 0 && value <= 120)
                {
                    _age = value;
                }
                else
                {
                    Console.WriteLine("Invalid Age! Age must be between 0 and 120.");
                }
            }
        }
    }

    internal class PropertyTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Properties ----------------");

            PropertyStudent student = new PropertyStudent();

            // Calls the set accessor
            student.Name = "Vikas";
            student.Age = 22;

            // Calls the get accessor
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Age: {student.Age}");

            Console.WriteLine();

            Console.WriteLine("Properties use get and set to read and write values.");
            Console.WriteLine("Unlike fields, properties can contain validation logic.");

            Console.WriteLine();

            Console.WriteLine("Trying to assign Age = -10");
            student.Age = -10;

            Console.WriteLine($"Age: {student.Age}");

            Console.WriteLine();

            Console.WriteLine("Trying to assign Age = 200");
            student.Age = 200;

            Console.WriteLine($"Age: {student.Age}");

            Console.WriteLine();

            Console.WriteLine("Trying to assign Age = 25");
            student.Age = 25;

            Console.WriteLine($"Age: {student.Age}");
        }
    }
}
/*
 When we write this :public string Name { get; set; }
the compiler creates something similar to:
private string _name;

public string Name
{
    get
    {
        return _name;
    }

    set
    {
        _name = value;
    }
}
 
 */