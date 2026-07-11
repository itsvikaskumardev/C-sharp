using System;

namespace Object_Oriented_Programming
{
    public class Person
    {
        // Property
        //get → Read the value
        //set → Assign a value
        public string Name { get; set; }

        // Instance Method
        public void Introduce(string to)
        {
            Console.WriteLine($"Hi {to}, I am {Name}.");
        }

        // Static Method
        /*The Parse method :takes a string and creates a Person object from it.
         Take data in one format (usually a string) and convert it into another object or data type.
        It is equivalent to 
        var person = new Person();
        person.Name = "Vikas";
         */

        public static Person Parse(string str)
        {
            var person = new Person();
            person.Name = str;

            return person;
        }
    }

    internal class ClassTutorial
    {
        // public is an access modifier
        public static void Run()
        {
            Console.WriteLine("--------------- Classes ----------------");

            // Instance members: accessible from an object
            var person = new Person();
            person.Name = "Vikas"; // Calls set
            person.Introduce("Pranshu");

            Console.WriteLine(person.Name); // Calls get

            Console.WriteLine();

            Console.WriteLine("--------------- Object Initializer ----------------");

            // Object Initializer
            var person3 = new Person
            {
                Name = "Aman"
            };

            person3.Introduce("Vikas");

            // This is equivalent to:
            // var person3 = new Person();
            // person3.Name = "Aman";

            Console.WriteLine();

            Console.WriteLine("--------------- Static Method ----------------");

            // Static members: accessible from the class
            var person2 = Person.Parse("Rahul");
            person2.Introduce("Vikas");
        }
    }
}