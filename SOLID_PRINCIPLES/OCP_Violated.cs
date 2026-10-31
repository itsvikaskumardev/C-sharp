
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SOLID_PRINCIPLES
{
    internal class OCP_Violated
    {
        public class Product
        {
            public string name;
            public double price;

            public Product(string name, double price)
            {
                this.name = name;
                this.price = price;
            }
        }

        public class ShoppingCart
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
        }

        public class ShoppingCartInvoicePrinter
        {
            ShoppingCart cart;

            public ShoppingCartInvoicePrinter(ShoppingCart cart) // is ti object or whch is object or instance 
            {
                this.cart = cart;
            }

            public void PrintInvoice()
            {
                Console.WriteLine("Shopping Cart Invoice:\n");

                foreach (Product p in cart.GetProducts())
                {
                    Console.WriteLine(
                        $"Product Name: {p.name}, Product Price: {p.price}");
                }

                Console.WriteLine($"Total is: {cart.CalculateTotal()}");
            }
        }

        public class ShoppingCartRepository
        {
            public void SaveToDB(ShoppingCart cart)
            {
                Console.WriteLine("Saving Shopping Cart to Database...");
            }

            public void SaveToMongoDB(ShoppingCart cart)
            {
                Console.WriteLine("Saving Shopping Cart to MongoDB...");
            }

            public void SaveToFile(ShoppingCart cart)
            {
                Console.WriteLine("Saving Shopping Cart to File...");
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

            // Creating Invoice Printer Object
            ShoppingCartInvoicePrinter printer =
                new ShoppingCartInvoicePrinter(cart);

            // Calling Methods
            printer.PrintInvoice();

            // Creating Repository Object
            ShoppingCartRepository repository =
                new ShoppingCartRepository();

            repository.SaveToDB(cart);
            repository.SaveToMongoDB(cart);
            repository.SaveToFile(cart);
        }
    }
}
