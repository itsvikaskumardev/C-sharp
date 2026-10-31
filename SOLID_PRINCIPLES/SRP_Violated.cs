
using System;
using System.Collections.Generic;

namespace SOLID_PRINCIPLES
{
    //SRP stands for Single Responsibility Principle.
    internal class SRP_Violated
    {
        class Product
        {
            public string name;
            public double price;

            public Product(string name, double price)
            {
                this.name = name;
                this.price = price;
            }
        }

        class ShoppingCart
        {
            List<Product> products = new List<Product>();

            // if we dont initiased it  List<Product> products we got 
            /// If you call products.Add(product), you will get a NullReferenceException.
            public void AddProduct(Product product)
            // Here Product is class and product is its object 
            {
                products.Add(product);
            }

            // getter
            public List<Product> GetProducts()
            {
                return products;
            }

            public double CalculateTotal()
            {
                double total = 0;

                foreach (Product p in products)
                {
                    total += p.price;
                }

                return total;
            }

            //2. Violating SRP- Print invoices (Should Be in a Separate Class)

            public void PrintInvoice()
            {
                Console.WriteLine("Shopping Cart Invoice :\n");

                foreach (Product p in products)
                {
                    Console.WriteLine($"Product Name: {p.name}, Product Price: {p.price}");
                }

                Console.WriteLine($"Total is: {CalculateTotal()}");
            }

            public void SaveToDB()
            {
                Console.WriteLine("Saving Shopping Cart to Database...\n");
            }
        }

        // Main Function
        public static void Run()
        {
            // Creating Product Objects
            Product p1 = new Product("Laptop", 50000);
            Product p2 = new Product("Mouse", 500);
            Product p3 = new Product("Keyboard", 1500);

            // Creating ShoppingCart Object
            ShoppingCart cart = new ShoppingCart();

            // Adding Products
            cart.AddProduct(p1);
            cart.AddProduct(p2);
            cart.AddProduct(p3);

            // Calling Methods
            cart.PrintInvoice();
            cart.SaveToDB();
        }
    }
}
