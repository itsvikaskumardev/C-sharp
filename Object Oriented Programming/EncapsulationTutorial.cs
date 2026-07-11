using System;

namespace Object_Oriented_Programming
{
    internal class EncapsulationTutorial
    {
        public class Person
        {
            // Private field (cannot be accessed directly from outside the class)
            private string _name;

            // Setter Method
            public void SetName(string name)
            {
                // We use string.IsNullOrEmpty() to make sure a string is not null and not empty ("") before using it.
                if (!string.IsNullOrWhiteSpace(name))
                {
                    _name = name;
                }
            }

            // Getter Method
            public string GetName()
            {
                return _name;
            }
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Encapsulation ----------------");

            var person = new Person();

            person.SetName("Vikas");

            Console.WriteLine("Name: " + person.GetName());

            // Not allowed because _name is private
            // person._name = "Rahul"; // Compile-time error
        }
    }
}