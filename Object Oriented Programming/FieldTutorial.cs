using System;

namespace Object_Oriented_Programming
{
    public class FieldStudent
    {
        // Fields
        public string Name;
        public int Age;
    }

    internal class FieldTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Fields ----------------");

            FieldStudent student = new FieldStudent();

            student.Name = "Vikas";
            student.Age = -10;

            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Age: {student.Age}");

            Console.WriteLine();
            Console.WriteLine("Fields store data directly.");
            Console.WriteLine("Since Age is a public field, it allows invalid values like -10.");
            Console.WriteLine("To add validation, we use Properties instead of public fields.");
        }
    }
}