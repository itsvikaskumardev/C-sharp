# OCP – Open/Closed Principle (SOLID Principles)

OCP is the second principle of SOLID. Let's understand it from the beginning using your `OCP_Violated` and `OCP_Followed` shopping cart examples.

## 1. What is OCP?

OCP stands for Open/Closed Principle.

It was introduced by Bertrand Meyer.

The principle states:

> Software entities (classes, modules, functions, etc.) should be open for extension but closed for modification.

Let's understand these two terms.

1\. Open for Extension

It means we should be able to add new functionality to our existing application.

For example:

- Initially, save shopping cart data to SQL Server.
- Later, add MongoDB support.
- Later, add File storage.
- Later, add Cloud storage.

We should be able to add these features.

2\. Closed for Modification

It means we should not need to modify existing, working code whenever we introduce new functionality.

For example:

Suppose you already have a `ShoppingCartRepository` class that saves data to SQL Server.

Tomorrow, your manager asks you to add MongoDB support.

You should not have to keep modifying the existing repository class to support every new storage type.

In simple words:

We should be able to add new functionality by adding new code instead of repeatedly changing existing code.

## 2. Understand OCP with a real-world example

Imagine you are developing an e-commerce application.

Initially, your application supports only SQL Server.

[Microservice Architecture Patterns and Principles](https://images.openai.com/static-rsc-4/K9k6uRH6Lk4m9FRI7y7xw2qo9DlMahzTUlsVa7ZYFDi7BpJeXyyxwU950npTH7MbrS4I3_FQgLT10f5AAlOSwV7gcKAisjhIr_GTb3p-0HWQ9JKX66ueQTOkVzw2JmPlJ7weRXKwJObz38FAlXmSjZA2K_xO0qOqj-sUrJ9afJw?purpose=inline)

[thetechplatform.com](https://www.thetechplatform.com/post/design-microservices-architecture-with-patterns-and-principles?utm_source=chatgpt.com)

Your code looks like this:

```
public class ShoppingCartRepository
{
    public void SaveToDB(ShoppingCart cart)
    {
        Console.WriteLine("Saving to SQL Database...");
    }
}
```

Everything works fine.

Now requirements start changing.

| Requirement | What manager asks       |
| ----------- | ----------------------- |
| First       | Save data to SQL Server |
| Second      | Add MongoDB support     |
| Third       | Add File storage        |
| Fourth      | Add Cloud storage       |

The problem starts when you try to support all these requirements by modifying the same class.

## 3. OCP Violated – Understand the problem

Let's use your `OCP_Violated.cs` code.

```
public class ShoppingCartRepository
{
    public void SaveToDB(ShoppingCart cart)
    {
        Console.WriteLine("Saving to SQL Database...");
    }

    public void SaveToMongoDB(ShoppingCart cart)
    {
        Console.WriteLine("Saving to MongoDB...");
    }

    public void SaveToFile(ShoppingCart cart)
    {
        Console.WriteLine("Saving to File...");
    }
}
```

### How does the flow work?

Step 1: Initially, we have SQL Server support.

```
repository.SaveToDB(cart);
```

Step 2: Manager asks to add MongoDB support.

You modify the existing `ShoppingCartRepository` class and add:

```
public void SaveToMongoDB(ShoppingCart cart)
{
    Console.WriteLine("Saving to MongoDB...");
}
```

Step 3: Manager asks to add File storage.

Again, you modify the same class:

```
public void SaveToFile(ShoppingCart cart)
{
    Console.WriteLine("Saving to File...");
}
```

Step 4: Manager asks to add Cloud storage.

Again, you modify the same class.

OCP Violated

Existing ShoppingCartRepository

`SaveToDB()`

Add MongoDB method

Add File method

Add Cloud method

Add another method for every new storage type

What is the problem?

- Existing class keeps changing.
- More conditions or methods may make it difficult to maintain.
- Changes can accidentally break existing functionality.

### Why is this a violation?

Because `ShoppingCartRepository` is responsible for handling all storage mechanisms.

Whenever a new storage requirement comes, we have to modify this existing class.

This is the main problem OCP tries to solve.

Important: Having multiple methods alone does not automatically violate OCP. The problem is that the design forces modification of existing code to add new storage functionality.

## 4. OCP Followed – How do we solve it?

Now let's understand your `OCP_Followed.cs` code.

Instead of creating separate methods for SQL, MongoDB and File storage inside one repository, we introduce an interface.

### Step 1: Create an interface

```
public interface IShoppingCartStorage
{
    void Save(ShoppingCart cart);
}
```

What is the purpose of this interface?

It defines a common contract.

Any class that implements `IShoppingCartStorage` must provide its own implementation of `Save()`.

### Step 2: Create separate storage classes

SQL Storage

```
public class SQLStorage : IShoppingCartStorage
{
    public void Save(ShoppingCart cart)
    {
        Console.WriteLine("Saving to SQL Database...");
    }
}
```

MongoDB Storage

```
public class MongoDBStorage : IShoppingCartStorage
{
    public void Save(ShoppingCart cart)
    {
        Console.WriteLine("Saving to MongoDB...");
    }
}
```

File Storage

```
public class FileStorage : IShoppingCartStorage
{
    public void Save(ShoppingCart cart)
    {
        Console.WriteLine("Saving to File...");
    }
}
```

Notice something important:

All three classes implement the same interface, but each class has its own implementation of `Save()`.

### Step 3: Create ShoppingCartRepository

```
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
```

Now our repository doesn't need to know whether the data is being saved to SQL, MongoDB or File storage.

It only knows about the interface.

OCP Followed

IShoppingCartStorage

`Save(cart)`

SQLStorage

Implements interface

MongoDBStorage

Implements interface

FileStorage

Implements interface

ShoppingCartRepository

`SaveToStorage(cart)`

Repository depends on the abstraction, not on a particular storage implementation.

## 5. Understand the complete execution flow

This is the most important part. Let's understand what happens when you execute:

```
IShoppingCartStorage sqlStorage = new SQLStorage();

ShoppingCartRepository repository =
    new ShoppingCartRepository(sqlStorage);

repository.SaveToStorage(cart);
```

Step 1: Create SQLStorage object

```
IShoppingCartStorage sqlStorage = new SQLStorage();
```

- `IShoppingCartStorage` is an interface.
- `SQLStorage` is a class implementing that interface.
- `new SQLStorage()` creates an SQLStorage object.
- The interface reference points to that object.

Step 2: Pass the object to the constructor

```
ShoppingCartRepository repository =
    new ShoppingCartRepository(sqlStorage);
```

The SQLStorage object is passed to the `ShoppingCartRepository` constructor.

Inside the constructor:

```
public ShoppingCartRepository(IShoppingCartStorage storage)
{
    this.storage = storage;
}
```

The repository stores the reference to the SQLStorage object.

Step 3: Call SaveToStorage()

```
repository.SaveToStorage(cart);
```

Inside this method:

```
public void SaveToStorage(ShoppingCart cart)
{
    storage.Save(cart);
}
```

Since `storage` currently refers to a SQLStorage object, C# executes:

```
SQLStorage.Save(cart);
```

This is called runtime polymorphism.

The actual method that executes depends on which object was passed.

### Visualize the execution

1\. Create SQLStorage object

`new SQLStorage()`

2\. Constructor Injection

`new ShoppingCartRepository(sqlStorage)`

3\. Call

`repository.SaveToStorage(cart)`

Runtime Polymorphism

4\. SQLStorage.Save(cart)

The actual object's implementation executes.

## 6. What happens when a new requirement comes?

Suppose your manager says:

"Now we also want to save shopping cart data to Cloud Storage."

With OCP, you simply create a new class.

```
public class CloudStorage : IShoppingCartStorage
{
    public void Save(ShoppingCart cart)
    {
        Console.WriteLine("Saving to Cloud Storage...");
    }
}
```

Then use it:

```
IShoppingCartStorage cloudStorage = new CloudStorage();

ShoppingCartRepository repository =
    new ShoppingCartRepository(cloudStorage);

repository.SaveToStorage(cart);
```

Notice what we did NOT change:

- `ShoppingCartRepository` — unchanged.
- `SQLStorage` — unchanged.
- `MongoDBStorage` — unchanged.
- `FileStorage` — unchanged.
- `IShoppingCartStorage` — unchanged.

We only added a new class.

This is OCP

We extended the application without modifying the existing repository.

## 7. OCP Violated vs OCP Followed

| Comparison          | OCP Violated                | OCP Followed       |
| ------------------- | --------------------------- | ------------------ |
| SQL support         | Method in repository        | Separate class     |
| MongoDB support     | Add another method          | New implementation |
| File support        | Add another method          | New implementation |
| Cloud support       | Modify repository           | New implementation |
| Interface           | Not required in this design | Common abstraction |
| Existing repository | Keeps changing              | Remains unchanged  |

## 8. Important concepts used in OCP

You have actually learned four important concepts while implementing OCP.

| Concept              | Where you used it                                    |
| -------------------- | ---------------------------------------------------- |
| Interface            | `IShoppingCartStorage`                               |
| Abstraction          | Repository depends on interface                      |
| Polymorphism         | SQL, MongoDB and File implement `Save()` differently |
| Dependency Injection | Passing storage object through constructor           |

One more important connection: OCP is closely related to the Dependency Inversion Principle (DIP). Both encourage depending on abstractions rather than concrete implementations.

However, they are not the same principle:

- OCP focuses on extending functionality without repeatedly modifying existing code.
- DIP focuses on how high-level and low-level modules depend on abstractions.

## 9. Interview-ready answer

If an interviewer asks, "What is the Open/Closed Principle?", you can answer:

> The Open/Closed Principle states that software entities should be open for extension but closed for modification. It means we should be able to introduce new functionality without modifying existing, tested code. We can achieve this using interfaces, abstraction and polymorphism. For example, in a shopping cart application, instead of creating separate SQL, MongoDB and File methods inside one repository, we create an interface called IShoppingCartStorage and implement it separately for each storage mechanism.

## 10. Test your understanding

OCP knowledge check

3/3 answered

1\. Your application supports SQL Server. Now you want to add MongoDB. With OCP, what should you do?

Modify SQLStorage to support MongoDB

Create a new MongoDBStorage class implementing the interface

Add MongoDB conditions inside ShoppingCartRepository

Correct!

Correct! Add a new implementation without changing existing storage classes or the repository.

2\. Why does ShoppingCartRepository use IShoppingCartStorage instead of SQLStorage directly?

To depend on an abstraction instead of a concrete class

Because interfaces create database connections

Because SQLStorage cannot create objects

Correct!

Correct! The repository can work with any class implementing the interface.

3\. If tomorrow you add CloudStorage, which existing class should you modify?

ShoppingCartRepository

SQLStorage

None of these; create a new CloudStorage class

Correct!

Correct! You extend the application by adding a new implementation.

Check my answers

## Score: 3/3

Try again

My suggestion: Before moving to LSP (the third SOLID principle), make sure you can explain why `IShoppingCartStorage` is needed and how `ShoppingCartRepository` works with SQL, MongoDB and File storage without knowing their concrete classes. That's the core of understanding OCP.