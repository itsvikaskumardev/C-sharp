Let's understand this from zero, because the confusion is mainly about three things:

1. Why do we write `new SQLStorage()`?
2. How does `sqlStorage` get passed to the constructor?
3. Why do we call `SaveToStorage()` instead of directly calling `Save()`?

First, forget SQL, MongoDB, and File for a moment. Let's understand how objects and constructors work.

## 1. What does `new SQLStorage()` mean?

Look at your class:

```
public class SQLStorage : IShoppingCartStorage
{
    public void Save(ShoppingCart cart)
    {
        Console.WriteLine("Saving Shopping Cart to SQL Database...");
    }
}
```

This is just a class definition. It describes what a SQLStorage object can do.

When you write:

```
SQLStorage sql = new SQLStorage();
```

You are creating an actual object of the `SQLStorage` class.

Think of it this way:

- Class = Blueprint of a house.
- Object = Actual house created using that blueprint.
- `new` = Creates the object.

Class (Blueprint)

`SQLStorage`

Contains the Save() method

new SQLStorage()

Object (Created instance)

`sql`

An actual SQLStorage object

So, `new SQLStorage()` creates an object that can execute the `Save()` method.

## 2. What does `IShoppingCartStorage sqlStorage = new SQLStorage();` mean?

This is probably the most confusing line:

```
IShoppingCartStorage sqlStorage = new SQLStorage();
```

Let's break it into two parts:

```
IShoppingCartStorage sqlStorage
```

This means:

- `IShoppingCartStorage` = Interface (a contract).
- `sqlStorage` = Variable name.

And:

```
new SQLStorage()
```

This creates an actual `SQLStorage` object.

But why can an interface variable hold a SQLStorage object?

Because your SQLStorage class implements that interface:

```
public class SQLStorage : IShoppingCartStorage
```

Your interface says:

```
public interface IShoppingCartStorage
{
    void Save(ShoppingCart cart);
}
```

It means every class implementing this interface must provide a `Save()` method.

Therefore, SQLStorage, MongoDBStorage, and FileStorage can all be stored in an `IShoppingCartStorage` variable.

For example:

```
IShoppingCartStorage sqlStorage = new SQLStorage();

IShoppingCartStorage mongoStorage = new MongoDBStorage();

IShoppingCartStorage fileStorage = new FileStorage();
```

All three are valid!

Remember: The variable's type is the interface, but the actual object is the class you create using `new`.

## 3. How does the object pass to the constructor?

Now look at this code:

```
ShoppingCartRepository sqlRepository =
    new ShoppingCartRepository(sqlStorage);
```

First, understand your repository class:

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

Let's understand it step by step.

Step 1: You create a SQLStorage object.

```
IShoppingCartStorage sqlStorage = new SQLStorage();
```

Now `sqlStorage` refers to a SQLStorage object.

Step 2: You pass that object to the constructor.

```
ShoppingCartRepository sqlRepository =
    new ShoppingCartRepository(sqlStorage);
```

Notice this part:

```
new ShoppingCartRepository(sqlStorage)
```

You are doing two things:

- `new ShoppingCartRepository` creates a repository object.
- `(sqlStorage)` passes your SQLStorage object to its constructor.

Step 3: The constructor receives that object.

```
public ShoppingCartRepository(IShoppingCartStorage storage)
{
    this.storage = storage;
}
```

Here is what is happening:

| Code                           | Meaning                                                 |
| ------------------------------ | ------------------------------------------------------- |
| `IShoppingCartStorage storage` | Receives the object passed by the caller.               |
| `this.storage`                 | The class-level variable of ShoppingCartRepository.     |
| `storage`                      | The constructor parameter.                              |
| `this.storage = storage`       | Stores the received object in the class-level variable. |

Think of it like this:

How the SQLStorage object reaches the repository

SQLStorage object

Created by `new SQLStorage()`

`sqlStorage`

Passed as constructor argument

ShoppingCartRepository constructor\
`ShoppingCartRepository(IShoppingCartStorage storage)`

Receives the SQLStorage object

this.storage = storage

Repository object\
`this.storage`

Now holds the SQLStorage object reference

Now the repository remembers which storage object it received.

## 4. What happens when we call `SaveToStorage(cart)`?

Now look at this method:

```
public void SaveToStorage(ShoppingCart cart)
{
    storage.Save(cart);
}
```

And you call:

```
sqlRepository.SaveToStorage(cart);
```

Let's trace what happens:

1. `sqlRepository` is a ShoppingCartRepository object.
2. It already holds the SQLStorage object in its `storage` variable.
3. `SaveToStorage(cart)` executes.
4. Inside that method, `storage.Save(cart)` executes.
5. Since `storage` refers to a SQLStorage object, C# executes the SQLStorage class's `Save()` method.

So this:

```
storage.Save(cart);
```

actually executes:

```
SQLStorage.Save(cart);
```

This is called runtime polymorphism.

## 5. Then why MongoDB and File work with the same repository?

Look at the difference:

For SQL:

```
IShoppingCartStorage sqlStorage = new SQLStorage();

ShoppingCartRepository sqlRepository =
    new ShoppingCartRepository(sqlStorage);

sqlRepository.SaveToStorage(cart);
```

For MongoDB:

```
IShoppingCartStorage mongoStorage = new MongoDBStorage();

ShoppingCartRepository mongoRepository =
    new ShoppingCartRepository(mongoStorage);

mongoRepository.SaveToStorage(cart);
```

For File:

```
IShoppingCartStorage fileStorage = new FileStorage();

ShoppingCartRepository fileRepository =
    new ShoppingCartRepository(fileStorage);

fileRepository.SaveToStorage(cart);
```

The only difference is which object you pass to the repository constructor.

| Storage object passed  | Method that executes    |
| ---------------------- | ----------------------- |
| `new SQLStorage()`     | `SQLStorage.Save()`     |
| `new MongoDBStorage()` | `MongoDBStorage.Save()` |
| `new FileStorage()`    | `FileStorage.Save()`    |

The repository code remains exactly the same.

## 6. Your question: Can't we directly call the Save() method?

Yes! Absolutely. You can directly call it.

For example:

```
SQLStorage sql = new SQLStorage();
sql.Save(cart);

MongoDBStorage mongo = new MongoDBStorage();
mongo.Save(cart);

FileStorage file = new FileStorage();
file.Save(cart);
```

This works perfectly.

But then why are we using `ShoppingCartRepository`?

Because we want the repository to handle the saving operation through a common interface.

Compare the two approaches:

| Direct method call                                       | Repository approach                            |
| -------------------------------------------------------- | ---------------------------------------------- |
| You call each storage class directly.                    | You call the repository.                       |
| Your calling code knows SQLStorage, MongoDBStorage, etc. | Your repository depends only on the interface. |
| Saving logic is spread across callers.                   | Saving is handled through one common method.   |
| Less abstraction.                                        | Easier to extend and maintain in this example. |

The repository approach is useful when your application grows and you want other classes to use storage without knowing the specific database implementation.

## 7. Let's understand OCP with a real example

Suppose tomorrow you want to add Cloud Storage.

You create a new class:

```
public class CloudStorage : IShoppingCartStorage
{
    public void Save(ShoppingCart cart)
    {
        Console.WriteLine("Saving Shopping Cart to Cloud...");
    }
}
```

Now you can use the same repository:

```
IShoppingCartStorage cloudStorage = new CloudStorage();

ShoppingCartRepository cloudRepository =
    new ShoppingCartRepository(cloudStorage);

cloudRepository.SaveToStorage(cart);
```

You did not change the existing `ShoppingCartRepository` class!

That's the main benefit of this design and how it supports the Open/Closed Principle.

## 8. Test your understanding

1\. What does \`new SQLStorage()\` do?

Calls the Save() method automatically

Creates an SQLStorage object

Creates an interface



2\. What happens in \`new ShoppingCartRepository(sqlStorage)\`?

It creates a repository and passes sqlStorage to its constructor

It creates another SQLStorage object

It directly saves the cart



3\. Why does \`storage.Save(cart)\` execute SQLStorage.Save() in the SQL example?

Because storage is always SQLStorage

Because the interface contains SQL code

Because storage currently refers to a SQLStorage object



Check answers

The one thing I want you to remember:

`new SQLStorage()` creates the storage object → `new ShoppingCartRepository(sqlStorage)` gives that object to the repository through its constructor → `SaveToStorage(cart)` asks the repository to use that stored object to save the cart.

Once this flow is clear, constructor injection and dependency injection will become much easier to understand.