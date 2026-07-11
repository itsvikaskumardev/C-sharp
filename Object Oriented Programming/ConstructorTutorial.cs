using System;
using System.Collections.Generic;

namespace Object_Oriented_Programming
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // <> contains the generic type parameter
        public List<Order> Orders { get; set; }

        // Default Constructor
        public Customer()
        {
            Console.WriteLine("----- Default Customer Constructor -----");

            // Initialize with an empty list
            Orders = new List<Order>();
        }

        // Constructor with one parameter
        public Customer(int id)
            : this() // Calls the parameterless constructor
        {
            Console.WriteLine("----- Customer(int id) Constructor -----");

            Id = id;
        }

        // Constructor with two parameters
        // This is called Constructor Overloading.
        public Customer(int id, string name)
            : this(id) // Calls Customer(int id)
        {
            Console.WriteLine("----- Customer(int id, string name) Constructor -----");

            Name = name;
        }
    }

    internal class ConstructorTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Constructors ----------------");

            var customer1 = new Customer(1, "Vikas");

            Console.WriteLine($"Customer Id: {customer1.Id}");
            Console.WriteLine($"Customer Name: {customer1.Name}");

            Console.WriteLine();

            var customer2 = new Customer();

            customer2.Id = 2;
            customer2.Name = "Rahul";

            Console.WriteLine($"Customer Id: {customer2.Id}");
            Console.WriteLine($"Customer Name: {customer2.Name}");

            Console.WriteLine();

            // No need to do:
            // customer1.Orders = new List<Order>();
            // because the constructor already initialized it.

            var order = new Order();
            customer1.Orders.Add(order);

            Console.WriteLine($"Total Orders: {customer1.Orders.Count}");
        }
    }

    public class Order
    {
    }
}

/*
 
 Constructor call order

When you do: var customer = new Customer(1, "Vikas");

The constructors execute in this order:

Customer()-> Customer(int id) -> Customer(int id, string name)

because:

Customer(int id, string name)
    : this(id)

Customer(int id)
    : this()

This is called Constructor Chaining. It helps avoid repeating code, such as:

Orders = new List<Order>();

in every constructor.
 */