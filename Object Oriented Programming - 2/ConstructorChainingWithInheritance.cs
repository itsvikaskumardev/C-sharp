using System;

namespace Object_Oriented_Programming___2
{
    internal class ConstructorChainingWithInheritance
    {
        /*
         * Constructor Inheritance
         *
         * 1. Base class constructors always execute first.
         * 2. Constructors are NOT inherited.
         * 3. If the base class does not have a parameterless constructor,
         *    the derived class must call one of the base class constructors
         *    using the base keyword.
         */

        // Base Class
        public class Vehicle
        {
            public string RegistrationNumber { get; }

            public Vehicle(string registrationNumber)
            {
                RegistrationNumber = registrationNumber;
                Console.WriteLine("Vehicle constructor executed.");
            }
        }

        // Derived Class
        public class Car : Vehicle
        {
            // Calling the base class constructor
            public Car(string registrationNumber)
                : base(registrationNumber)
            {
                Console.WriteLine("Car constructor executed.");
            }
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Constructor Inheritance ----------------");

            Car car = new Car("UP16AB1234");

            Console.WriteLine($"Registration Number: {car.RegistrationNumber}");
        }
    }
}

/*
 --------------------------------------------------------------------
 Why do we use base()?

Suppose the parent class is:

public class Vehicle
{
    public Vehicle(string registrationNumber)
    {
    }
}

Now you write:

public class Car : Vehicle
{
    public Car()
    {
    }
}

❌ This gives a compile-time error.
 --------------------------------------------------------------------


Why?

Because when a Car object is created, C# must create the Vehicle part first.

But Vehicle says:

"I need a registrationNumber."

The Car constructor didn't provide one.

So you must write:

public Car(string registrationNumber)
    : base(registrationNumber)
{
}

This tells C#:

"Before creating the Car, call the Vehicle constructor and pass it the registration number."

Execution order

When you run:

Car car = new Car("UP16AB1234");

C# executes:

Car()
   │
   ▼
base("UP16AB1234")
   │
   ▼
Vehicle()
   │
   ▼
Vehicle constructor finishes
   │
   ▼
Car constructor runs

So the output is:

Vehicle constructor executed.
Car constructor executed.

 --------------------------------------------------------------------

Are constructors inherited?

No.

Suppose:

public class Vehicle
{
    public Vehicle()
    {
    }
}

and

public class Car : Vehicle
{
}

Can you do this?

Car car = new Car();

Yes.

But Car does not inherit Vehicle's constructor.

Instead, the compiler automatically creates a constructor like this:

public Car()
    : base()
{
}

So it calls the base constructor—it does not inherit it.
 */