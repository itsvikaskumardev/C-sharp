
using System;
using System.Collections.Generic;

namespace SOLID_PRINCIPLES
{
    internal class OCP_Followed
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

            // Adding products
            public void AddProduct(Product product)
            {
                products.Add(product);
            }

            // getter
            public List<Product> GetProducts()
            {
                return products;
            }

            // Calculate total
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

        // Print Invoice
        public class ShoppingCartInvoicePrinter
        {
            ShoppingCart cart;

            public ShoppingCartInvoicePrinter(ShoppingCart cart)
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

        // Interface for different storage mechanisms
        public interface IShoppingCartStorage
        {
            void Save(ShoppingCart cart);
        }

        // SQL Database
        public class SQLStorage : IShoppingCartStorage
        {
            public void Save(ShoppingCart cart)
            {
                Console.WriteLine("Saving Shopping Cart to SQL Database...");
            }
        }

        // MongoDB
        public class MongoDBStorage : IShoppingCartStorage
        {
            public void Save(ShoppingCart cart)
            {
                Console.WriteLine("Saving Shopping Cart to MongoDB...");
            }
        }

        // File Storage
        public class FileStorage : IShoppingCartStorage
        {
            public void Save(ShoppingCart cart)
            {
                Console.WriteLine("Saving Shopping Cart to File...");
            }
        }

        // Shopping Cart Repository
        public class ShoppingCartRepository
        {
            IShoppingCartStorage storage;

            public ShoppingCartRepository(IShoppingCartStorage storage)
            {
                this.storage = storage;
            }

            public void SaveToStorage(ShoppingCart cart)
            {
                storage.Save(cart);
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

            // Saving to SQL Database
            IShoppingCartStorage sqlStorage = new SQLStorage();

            ShoppingCartRepository sqlRepository =
                new ShoppingCartRepository(sqlStorage);

            sqlRepository.SaveToStorage(cart);

            // Saving to MongoDB
            IShoppingCartStorage mongoStorage = new MongoDBStorage();

            ShoppingCartRepository mongoRepository =
                new ShoppingCartRepository(mongoStorage);

            mongoRepository.SaveToStorage(cart);

            // Saving to File
            IShoppingCartStorage fileStorage = new FileStorage();

            ShoppingCartRepository fileRepository =
                new ShoppingCartRepository(fileStorage);

            fileRepository.SaveToStorage(cart);
        }
    }
}
