Yes! Your code is now correct and should compile successfully. You can call it from `Program.cs` using:

```
SRP_Violated.Run();
```

Now let's understand the most important part: Why does this code violate the Single Responsibility Principle (SRP)?

## 1. What is SRP?

SRP stands for Single Responsibility Principle.

It says:

> A class should have only one reason to change.

In simple words, one class should have one responsibility.

For example:

- `ShoppingCart` should manage shopping cart operations.
- `InvoicePrinter` should handle invoice printing.
- `ShoppingCartRepository` should handle database operations.

## 2. Where does your code violate SRP?

Look at your `ShoppingCart` class. It currently performs four different responsibilities.

| Method             | Responsibility          |
| ------------------ | ----------------------- |
| `AddProduct()`     | Adding products to cart |
| `CalculateTotal()` | Calculating cart total  |
| `PrintInvoice()`   | Printing invoice        |
| `SaveToDB()`       | Saving data to database |

Let's understand why this is a problem.

### Scenario 1: Invoice format changes

Suppose your manager says:

"Change the invoice format. Add GST, company address and invoice number."

What will you change?

You will modify:

```
public void PrintInvoice()
{
    // Change invoice format
}
```

But this method is inside `ShoppingCart`.

Problem: Your shopping cart class now needs to change because of an invoice-format requirement.

### Scenario 2: Database changes

Suppose your company initially uses SQL Server but later decides to use PostgreSQL.

You need to modify:

```
public void SaveToDB()
{
    Console.WriteLine("Saving Shopping Cart to Database...\n");
}
```

Again, you are modifying the `ShoppingCart` class.

Problem: Your shopping cart class now needs to change because of a database requirement.

This means the class has multiple reasons to change. That's why it violates SRP.

## 3. How do we follow SRP?

We separate responsibilities into different classes.

SRP Violated

ShoppingCart

- AddProduct()
- CalculateTotal()
- PrintInvoice()
- SaveToDB()

Separate responsibilities

SRP Followed

ShoppingCart

- AddProduct()
- GetProducts()
- CalculateTotal()

InvoicePrinter

\- PrintInvoice()

ShoppingCartRepository

\- SaveToDB()

## 4. Example of SRP Followed

Here is how you can separate your existing code.

Product.cs

```
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
```

ShoppingCart.cs

```
public class ShoppingCart
{
    List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

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
```

InvoicePrinter.cs

```
public class InvoicePrinter
{
    public void PrintInvoice(ShoppingCart cart)
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
```

ShoppingCartRepository.cs

```
public class ShoppingCartRepository
{
    public void SaveToDB(ShoppingCart cart)
    {
        Console.WriteLine("Saving Shopping Cart to Database...");
    }
}
```

## 5. How to call these classes in Program.cs?

```
ShoppingCart cart = new ShoppingCart();

Product p1 = new Product("Laptop", 50000);
Product p2 = new Product("Mouse", 500);
Product p3 = new Product("Keyboard", 1500);

cart.AddProduct(p1);
cart.AddProduct(p2);
cart.AddProduct(p3);

// Invoice responsibility
InvoicePrinter printer = new InvoicePrinter();
printer.PrintInvoice(cart);

// Database responsibility
ShoppingCartRepository repository = new ShoppingCartRepository();
repository.SaveToDB(cart);
```

## 6. Remember this for interviews

SRP Violated:

One class handles multiple responsibilities. Changes in invoice formatting or database operations require modifying the same class.

SRP Followed:

Each class has one responsibility and one primary reason to change.

Important interview point

SRP does NOT mean that a class should have only one method.

It means that a class should have one cohesive responsibility.

Check your understanding:

Suppose you add a new method `SendEmail()` inside `ShoppingCart` to email the invoice. Does this violate SRP?

No, because it is just another method.

Yes, because sending emails is another responsibility.

No, because ShoppingCart already prints invoices.

Check answer

&#x20;Correct! Sending emails should generally be handled by a separate class.