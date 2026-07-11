using System;

namespace Object_Oriented_Programming___2
{
    internal class DownCastingTutorial
    {
        //Downcasting means converting a parent class reference back into a child class reference.
        public static void Run()
        {
            // Compile-time type of 'shape' is Shape.
            // Runtime type of the object is Text.
            Shape shape = new Text();

            Console.WriteLine("Runtime type of shape: " + shape.GetType().Name);

            // Downcasting: Converting a parent reference back to a child reference.
            Text text = (Text)shape;

            Console.WriteLine("Runtime type of text: " + text.GetType().Name);

            text.FontName = "Arial";
            text.FontSize = 20;

            Console.WriteLine($"Font Name: {text.FontName}");
            Console.WriteLine($"Font Size: {text.FontSize}");
        }
    }
}