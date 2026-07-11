using System;

namespace Object_Oriented_Programming
{
    /*
     * Abstract Class
     * --------------
     * - Cannot be instantiated (cannot create an object).
     * - Used as a base class.
     * - Can contain both abstract and normal methods.
     */

    public abstract class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }

        // Abstract Method
        // Has no implementation (no method body).
        // Every derived class MUST implement it.
        public abstract void Draw();

        // Normal Method
        public void Copy()
        {
            Console.WriteLine("Shape copied to clipboard.");
        }
    }

    // Derived Class
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Circle.");
        }
    }

    // Derived Class
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Rectangle.");
        }
    }

    internal class AbstractTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Abstract Class ----------------");

            // ❌ Not Allowed
            // Shape shape = new Shape();
            // Abstract classes cannot be instantiated.

            Shape circle = new Circle();
            circle.Draw();
            circle.Copy();

            Console.WriteLine();

            Shape rectangle = new Rectangle();
            rectangle.Draw();
            rectangle.Copy();
        }
    }
}

/*
 


Abstraction is the OOP concept of hiding implementation details and exposing only the essential functionality.

----------------------------------------------

What is an Abstract Class?

An abstract class is a class that cannot be instantiated. It is meant to be inherited by other classes.

public abstract class Shape
{
}

This is not allowed:

Shape shape = new Shape(); // ❌

because Shape is incomplete.

Instead, create an object of a derived class:

Shape shape = new Circle(); // ✅

-----------------------------------------------------
What is an Abstract Method (Abstract Member)?

An abstract method is a method without a body (implementation).

public abstract void Draw();

Notice there is no { }.

The parent class only says:

"Every shape must know how to draw itself."

But it doesn't specify how.

Each child class provides its own implementation.

public override void Draw()
{
    Console.WriteLine("Drawing a Circle.");
}
public override void Draw()
{
    Console.WriteLine("Drawing a Rectangle.");
}

-----------------------------------------------------

Why do we use an Abstract Class?

Suppose every shape has:

Width
Height
Copy()

But every shape draws differently.

Instead of writing Width, Height, and Copy() in every class, we put them in the base class:

              Shape
        ----------------
        Width
        Height
        Copy()
        Draw()  (abstract)
           ▲
      ┌────┴────┐
      │         │
   Circle   Rectangle

The common code is shared, while each derived class provides its own Draw() implementation.



 
 */