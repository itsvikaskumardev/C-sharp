using System;

namespace Object_Oriented_Programming
{
    // Base class (Parent Class)
    public class PresentationObject
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public void Copy()
        {
            Console.WriteLine("Object copied to clipboard.");
        }

        public void Duplicate()
        {
            Console.WriteLine("Object was duplicated.");
        }
    }

    // Derived class (Child Class)
    public class Text : PresentationObject
    {
        // Properties specific to Text
        public int FontSize { get; set; }
        public string FontName { get; set; }

        // Method specific to Text
        public void AddHyperLink(string url)
        {
            Console.WriteLine("Added a hyperlink: " + url);
        }
    }

    internal class InheritanceTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Inheritance ----------------");

            Text text = new Text();

            // Inherited properties
            text.Width = 100;
            text.Height = 50;

            // Properties of Text class
            text.FontSize = 16;
            text.FontName = "Arial";

            Console.WriteLine($"Width: {text.Width}");
            Console.WriteLine($"Height: {text.Height}");
            Console.WriteLine($"Font Size: {text.FontSize}");
            Console.WriteLine($"Font Name: {text.FontName}");

            Console.WriteLine();

            // Inherited methods
            text.Copy();
            text.Duplicate();

            Console.WriteLine();

            // Method of Text class
            text.AddHyperLink("https://google.com");
        }
    }
}