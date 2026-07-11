using System;

namespace Object_Oriented_Programming___2
{
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Draw()
        {
            Console.WriteLine("Drawing Shape");
        }
    }

    public class Text : Shape
    {
        public int FontSize { get; set; }
        public string FontName { get; set; }
    }

    internal class UpCastingTutorial
    {
        //Upcasting means converting a child class object into a parent class reference.

        public static void Run()
        {
            {
                // ============================
                // BEFORE UPCASTING
                // ============================

                Text text = new Text();

                // Compile-time type of 'text'  : Text
                // Runtime type of 'text'       : Text

                Console.WriteLine("Before Upcasting");
                Console.WriteLine($"text runtime type: {text.GetType().Name}");

                // ============================
                // AFTER UPCASTING
                // ============================

                // Upcasting (implicit conversion)
                Shape shape = text;

                // Compile-time type of 'shape' : Shape
                // Runtime type of 'shape'      : Text

                Console.WriteLine("\nAfter Upcasting");
                Console.WriteLine($"shape runtime type: {shape.GetType().Name}");
                Console.WriteLine($"text runtime type : {text.GetType().Name}");

                // Both references point to the SAME object.
                text.Width = 200;
                shape.Width = 100;

                Console.WriteLine($"\ntext.Width  = {text.Width}");
                Console.WriteLine($"shape.Width = {shape.Width}");

                shape.Draw();

                // ❌ Compile-time Error
                // shape.FontSize = 20;

                // ✅ Allowed
                text.FontSize = 20;
            }
        }
    }
}

/*
 Why is the output 100?
Text text = new Text();
Shape shape = text;
This does not create two objects.

There is only one object in memory.
           Shape Reference
                 |
                 |
Text Reference   |
      |          |
      v          v

   -------------------------
   | Width = 0             |
   | Height                |
   | X                     |
   | Y                     |
   | FontSize              |
   | FontName              |
   -------------------------

When you write: text.Width = 200; the object's Width becomes 200.

Then:shape.Width = 100;

changes the same object's Width to 100.

So:
Both references point to the same object, so both see the latest value.

Important point

During upcasting, only the reference type changes, not the object.

Object type = Text
text reference type = Text
shape reference type = Shape

That's why shape can only access members defined in Shape, even though the actual object is a Text.
 
 
 */