using System;
using System.Collections.Generic;
using System.Text;

namespace Object_Oriented_Programming___2
{
    /*
     * ==================================================================
     * ABSTRACT CLASS vs INTERFACE - Difference
     * ==================================================================
     *
     * 1) INSTANTIATION
     *    - Abstract class: Cannot be instantiated directly (needs a derived class object).
     *    - Interface: Cannot be instantiated at all (no object, ever).
     *
     * 2) FIELDS / PROPERTIES (STATE)
     *    - Abstract class: CAN have instance fields/properties.
     *         Example: public int Width { get; set; }
     *    - Interface: CANNOT have instance fields.
     *         Only static members are allowed (rarely used).
     *
     * 3) METHOD IMPLEMENTATION
     *    - Abstract class: Can have BOTH abstract methods (no body) 
     *                      AND normal methods (full body).
     *         Example: abstract void Draw();   +   void Copy() { ... }
     *    - Interface: Traditionally only method signatures (no body).
     *                 Since C# 8.0, default implementations are allowed too.
     *         Example: void Show();  +  void PrintCompanyName() { ... }
     *
     * 4) CONSTRUCTOR
     *    - Abstract class: CAN have a constructor (called by derived class via base()).
     *    - Interface: CANNOT have a constructor. Never.
     *
     * 5) INHERITANCE (MULTIPLE OR SINGLE)
     *    - Abstract class: A class can inherit from ONLY ONE abstract class.
     *         Example: class Circle : Shape   // only one base class
     *    - Interface: A class CAN implement MULTIPLE interfaces.
     *         Example: class Manager : Person, IEmployee, IManageable
     *
     * 6) ACCESS MODIFIERS
     *    - Abstract class: Members can be public, protected, private, internal, etc.
     *    - Interface: Members are public by default.
     *                 (C# 8.0+ allows explicit modifiers, but rarely used)
     *
     * 7) PURPOSE / RELATIONSHIP TYPE
     *    - Abstract class: Used for "IS-A" relationship between CLOSELY RELATED classes
     *                       that share some common code/behavior.
     *         Example: Circle IS-A Shape, Rectangle IS-A Shape (both share Copy())
     *    - Interface: Used for "CAN-DO" contract between UNRELATED classes
     *                 that just need to guarantee certain behavior.
     *         Example: IEmployee, IDisposable, IComparable - any class can implement.
     *
     * 8) WHEN TO USE
     *    - Abstract class: When classes are related and share common implementation.
     *    - Interface: When you just want to enforce a contract/capability,
     *                 regardless of class hierarchy.
     *
     * ==================================================================
     * QUICK MEMORY TRICK
     * ==================================================================
     *   Abstract Class → "Ye SHAPE hai, common code share hota hai"
     *   Interface      → "Jo bhi IEmployee hai, usme Show() hona hi chahiye"
     * ==================================================================
     */
    internal class InterfaceAbstractionDifference
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Abstract vs Interface (Notes Only) ----------------");
            Console.WriteLine("Check the comments above this class for full comparison.");
        }
    }
}