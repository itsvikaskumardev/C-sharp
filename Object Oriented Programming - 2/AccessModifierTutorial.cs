using System;

namespace Object_Oriented_Programming___2
{
    internal class AccessModifierTutorial
    {
        // Parent Class
        public class Customer
        {
            // Public Properties
            public int Id { get; set; }
            public string Name { get; set; }

            // Public Method
            // Can be called from anywhere.
            public void Promote()
            {
                Console.WriteLine("Customer Promoted.");

                // Allowed because CalculateRating is inside the same class.
                int rating = CalculateRating(true);

                Console.WriteLine($"Rating: {rating}");

                // Allowed because PrintCustomerDetails is inside the same class.
                PrintCustomerDetails();
            }

            // Protected Method
            // Accessible only inside this class and derived classes.
            protected void PrintCustomerDetails()
            {
                Console.WriteLine($"Customer Id: {Id}");
                Console.WriteLine($"Customer Name: {Name}");
            }

            // Private Method
            // Accessible only inside the Customer class.
            private int CalculateRating(bool excludeOrders)
            {
                Console.WriteLine("Calculating Rating...");
                return 5;
            }
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Access Modifiers ----------------");

            Customer customer = new Customer();

            customer.Id = 1;
            customer.Name = "Vikas";

            Console.WriteLine();

            Console.WriteLine("Calling Public Method");
            customer.Promote();

            Console.WriteLine();

            // ❌ Compile-time Error
            // Private methods cannot be accessed outside Customer.
            // customer.CalculateRating(true);

            // ❌ Compile-time Error
            // Protected methods cannot be accessed outside Customer
            // or a derived class.
            // customer.PrintCustomerDetails();

            Console.WriteLine("Cannot call CalculateRating() because it is private.");
            Console.WriteLine("Cannot call PrintCustomerDetails() because it is protected.");
        }

        // Child Class
        public class GoldCustomer : Customer
        {
            public void OfferVoucher()
            {
                Console.WriteLine();
                Console.WriteLine("--------------- Gold Customer ----------------");

                Id = 100;
                Name = "Rahul";

                // ✅ Allowed because this class inherits from Customer.
                PrintCustomerDetails();

                // ❌ Compile-time Error
                // Private methods are NOT inherited.
                // CalculateRating(true);

                Console.WriteLine("Cannot call CalculateRating() because it is private.");
            }
        }
    }
}


/*
 
 | Access Modifier      | Accessible From                                                          |
| -------------------- | ------------------------------------------------------------------------ |
| `public`             | Anywhere (any class, any assembly)                                       |
| `private`            | Only inside the same class                                               |
| `protected`          | Inside the same class and its derived (child) classes                    |
| `internal`           | Anywhere within the same assembly (project)                              |
| `protected internal` | Inside the same assembly **or** from derived classes in another assembly |
| `private protected`  | Inside the same assembly **and** only from derived classes               |

-------------------------------------------------
 
 1. Public

Everyone can use it.

Customer customer = new Customer();

customer.Promote();      ✅
-------------------------------------------------
2. Private

Only the Customer class itself can use it.

Customer
{
    CalculateRating();    ✅
}

GoldCustomer
{
    CalculateRating();    ❌
}

Run()
{
    customer.CalculateRating(); ❌
}

-------------------------------------------------
3. Protected

The Customer class and any class that inherits from it can use it.

Customer
{
    PrintCustomerDetails();   ✅
}

GoldCustomer
{
    PrintCustomerDetails();   ✅
}

Run()
{
    customer.PrintCustomerDetails(); ❌
}


 */