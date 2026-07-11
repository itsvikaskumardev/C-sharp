using System;

namespace Object_Oriented_Programming___2
{
    // Parent Class
    public class Parent
    {
        // Virtual method - can be overridden by child classes
        public virtual void Print()
        {
            Console.WriteLine("This is the Parent class method.");
        }
    }

    // Child Class
    public class Child : Parent
    {
        // Override the parent method
        public override void Print()
        {
            Console.WriteLine("This is the Child class method.");
        }
    }

    internal class MethodOverriding
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Method Overriding ----------------");

            Parent parent = new Parent();
            parent.Print();

            Console.WriteLine();

            Child child = new Child();
            child.Print();

            Console.WriteLine();

            // Upcasting // method overriding 
            Parent obj = new Child(); // Child inherits from Parent.
            obj.Print(); // Calls Child's overridden method


            // Example:Person person = new Student();//A Student is a Person. class student: Person{}
        }
    }
}

/*
 
 
 Method Overriding (Simple Definition)

Method overriding is an Object-Oriented Programming (OOP) feature where a child class provides its own implementation of a method that is already defined in the parent class.

The parent method must be marked with virtual (or abstract), and the child method must use the override keyword.

Technical Definition

Method overriding allows a derived (child) class to replace the implementation of a virtual or abstract method inherited from its base (parent) class. The method is selected at runtime based on the actual object's type (runtime polymorphism).



We use virtual to tell C#:

"This method can be overridden (replaced) by a child class."

Without virtual, a child class cannot override the method.

 */