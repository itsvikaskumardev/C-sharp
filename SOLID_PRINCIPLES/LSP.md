# LSP – Liskov Substitution Principle

Let's understand LSP from the beginning using your Banking Application example.

Before understanding the code, you need to understand what problem LSP solves, why we need it, and what happens when we don't follow it.

LSP is the L – third letter? No: it is the L – third? Actually, LSP stands for Liskov Substitution Principle, the third principle in SOLID.

Its definition is:

> Objects of a parent class should be replaceable with objects of its child classes without breaking the correctness of the program.

This definition might sound complicated. Let's simplify it.

Simple meaning:

If a child class inherits from a parent class, you should be able to use that child object wherever the parent object is expected, and the program should still work correctly.

In other words:

- A child class should properly support the behavior promised by its parent.
- It should not unexpectedly remove or break the functionality expected from the parent.
- Code using the parent type should not need special checks or exceptions for particular child types.

## 1. First understand inheritance

Suppose you have a parent class called `Account`.

```
public class Account
{
    public void Deposit(double amount)
    {
        Console.WriteLine("Money deposited");
    }

    public void Withdraw(double amount)
    {
        Console.WriteLine("Money withdrawn");
    }
}
```

Now you create two child classes:

```
public class SavingAccount : Account
{
}

public class CurrentAccount : Account
{
}
```

Because both classes inherit from `Account`, they get its methods:

- `Deposit()`
- `Withdraw()`

You can create their objects:

```
Account account1 = new SavingAccount();

Account account2 = new CurrentAccount();
```

Notice something:

```
Account account1 = new SavingAccount();
```

Here:

- `Account` is the parent type.
- `new SavingAccount()` creates a child object.
- `account1` refers to that child object.

This is allowed because `SavingAccount` inherits from `Account`.

This is an example of substituting a child object in place of its parent type.

This is the basic idea behind LSP.

But there is a problem when a child class cannot support all the behavior of its parent.

## 2. What problem does LSP solve?

Let's take your banking example.

Imagine your bank has three types of accounts:

[The concept of saving or save money or open a bank deposit ,piggy bank,money bag,bank illustration vector](https://images.openai.com/static-rsc-4/u1lP13tCa5Q6IkNjedJ9-vs4XDRq_U0JxrCQ71Kgsku055OhLYsibjHR5BTDWN2lvrZjpXRcPVzBFTnvQmoaXFWLbv4I-HsxeXZGat2moXj6giddNYrjdXN89NDnIdnJMyG1i4f0fLsXBF9zXmIyDXcOup0m9cpg5N3xYueQIRrUMRyUeqw-dkZ1t7shKWCL?purpose=inline)

1\. Saving Account

- Deposit money.
- Withdraw money.

[Tài khoản vãng lai là gì? Tìm hiểu chi tiết khái niệm, lợi ích và cách sử dụng](https://images.openai.com/static-rsc-4/U32_7Ary1cqBvJcwJ3B83-Tj_fQi-mNHmwtIezILJ_Z_ZZHacuYaZJPTJDtjPG5qhKjleQv_xDS3eTz08Xpc4wqfKhDv5QvnAozU4WupJpN7b5229nZPTAolTFi_79L8xgLqXZnfTGjufoSOsZ6VjAAKXMnhOkwc4lm3xlqR9mI?purpose=inline)

2\. Current Account

- Deposit money.
- Withdraw money.

[Deven Choksey](https://images.openai.com/static-rsc-4/LyVtonTFpxPigVXv3bL4RBrXemM_8pE72YJMVCaGiBEeKl7hq9fCts47y5uO_yEmx2AV_vz_gCjhuV__lMBp07Gl42RRcMBj7J2iygYswFRVbujZZmgZ7CZNEJb6WMBpE2qXSLdrOr-foxBVKONdug23B_woywr3ZoA8OQW9rKc?purpose=inline)

3\. Fixed Deposit Account

- Deposit money.
- Withdrawal is not allowed before maturity (according to this example's rules).

Now, suppose you create a parent class:

```
public class Account
{
    public virtual void Deposit(double amount)
    {
    }

    public virtual void Withdraw(double amount)
    {
    }
}
```

And all three account classes inherit from it:

```
public class SavingAccount : Account
{
}

public class CurrentAccount : Account
{
}

public class FixedDepositAccount : Account
{
}
```

What is the problem?

The parent class promises that every account supports two operations:

1. Deposit
2. Withdraw

But FixedDepositAccount does not support withdrawal.

The parent class promises something that one of its child classes cannot properly deliver.

That is where LSP becomes important.

## 3. Understanding the LSP violation in your code

Look at your FixedDepositAccount:

```
public class FixedDepositAccount : Account
{
    public override void Withdraw(double amount)
    {
        throw new InvalidOperationException(
            "Withdrawal is not allowed in Fixed Deposit Account");
    }
}
```

What does this code do?

When somebody calls:

```
FixedDepositAccount account = new FixedDepositAccount();

account.Withdraw(500);
```

It throws an exception.

But why is that a problem?

Because the parent class `Account` provides a `Withdraw()` method, so the code using an `Account` may reasonably expect withdrawal to work.

For example:

```
public class BankClient
{
    public void ProcessTransaction(Account account)
    {
        account.Deposit(1000);
        account.Withdraw(500);
    }
}
```

Now let's call this method with different account objects.

Case 1: Saving Account

```
Account account = new SavingAccount();

BankClient client = new BankClient();

client.ProcessTransaction(account);
```

Works

The SavingAccount supports both operations.

Case 2: Current Account

```
Account account = new CurrentAccount();

BankClient client = new BankClient();

client.ProcessTransaction(account);
```

Works

The CurrentAccount also supports both operations.

Case 3: Fixed Deposit Account

```
Account account = new FixedDepositAccount();

BankClient client = new BankClient();

client.ProcessTransaction(account);
```

Fails

Why?

Because when this line executes:

```
account.Withdraw(500);
```

The actual object is a FixedDepositAccount, and its implementation throws an exception.

Notice something important:

We did not change the BankClient code.

We only changed the object passed to it.

Yet the program stopped working correctly.

This is exactly the problem LSP tries to prevent.

## 4. What exactly does LSP break when we violate it?

When LSP is violated, you can face several problems.

### Problem 1: Unexpected exceptions

Your parent class provides a method:

```
public virtual void Withdraw(double amount)
{
}
```

But one child class throws an exception when that method is called.

This means code that was working with one child object may fail when you replace it with another child object.

### Problem 2: You need to write special conditions

Suppose you have 10 different account types.

Some support withdrawal and some don't.

You might end up writing code like this:

```
public void ProcessTransaction(Account account)
{
    account.Deposit(1000);

    if (account is SavingAccount)
    {
        account.Withdraw(500);
    }
    else if (account is CurrentAccount)
    {
        account.Withdraw(500);
    }
    else if (account is FixedDepositAccount)
    {
        Console.WriteLine("Withdrawal not allowed");
    }
}
```

Now imagine adding five more account types.

You have to keep modifying this method.

Your code becomes difficult to maintain.

### Problem 3: Parent class becomes unreliable

Imagine another developer sees this method:

```
public void ProcessTransaction(Account account)
{
    account.Withdraw(500);
}
```

They expect that passing any `Account` object will work.

But they don't know that some child classes throw exceptions.

The parent class is no longer a reliable contract for all its children.

LSP helps prevent these problems by ensuring that child classes behave consistently with the promises made by their parent types.

## 5. How do we solve this problem?

Now let's look at your LSP_Followed example.

Instead of putting both methods into one parent class, we separate the capabilities.

First, create two interfaces:

```
public interface IDeposit
{
    void Deposit(double amount);
}

public interface IWithdraw
{
    void Withdraw(double amount);
}
```

Why two interfaces?

Because not every account supports the same operations.

| Interface   | Responsibility                          |
| ----------- | --------------------------------------- |
| `IDeposit`  | Account must support depositing money.  |
| `IWithdraw` | Account must support withdrawing money. |

Now implement them according to each account's capabilities.

Saving Account

```
public class SavingAccount : IDeposit, IWithdraw
{
    public void Deposit(double amount)
    {
        Console.WriteLine("Money deposited in Saving Account");
    }

    public void Withdraw(double amount)
    {
        Console.WriteLine("Money withdrawn from Saving Account");
    }
}
```

Current Account

```
public class CurrentAccount : IDeposit, IWithdraw
{
    public void Deposit(double amount)
    {
        Console.WriteLine("Money deposited in Current Account");
    }

    public void Withdraw(double amount)
    {
        Console.WriteLine("Money withdrawn from Current Account");
    }
}
```

Fixed Deposit Account

```
public class FixedDepositAccount : IDeposit
{
    public void Deposit(double amount)
    {
        Console.WriteLine("Money deposited in Fixed Deposit Account");
    }
}
```

Notice that FixedDepositAccount does not implement `IWithdraw`.

Why?

Because it does not support withdrawal in our example.

We are no longer forcing it to implement a method it cannot properly support.

## 6. How does BankClient work now?

Previously, BankClient accepted a general `Account` object and assumed every account supported withdrawal.

Now we separate the operations.

```
public class BankClient
{
    public void ProcessDeposit(IDeposit account)
    {
        account.Deposit(1000);
    }

    public void ProcessWithdrawal(IWithdraw account)
    {
        account.Withdraw(500);
    }
}
```

Now look at how we call it:

```
BankClient client = new BankClient();

SavingAccount saving = new SavingAccount();
CurrentAccount current = new CurrentAccount();
FixedDepositAccount fixed = new FixedDepositAccount();

// Deposits
client.ProcessDeposit(saving);
client.ProcessDeposit(current);
client.ProcessDeposit(fixed);

// Withdrawals
client.ProcessWithdrawal(saving);
client.ProcessWithdrawal(current);
```

We don't pass FixedDepositAccount to `ProcessWithdrawal()`.

Why?

Because FixedDepositAccount does not implement `IWithdraw`.

C# prevents us from passing it to that method.

Which objects can be passed?

ProcessDeposit(IDeposit)

All 3 accounts

ProcessWithdrawal(IWithdraw)

Only 2 accounts

FixedDepositAccount is excluded from withdrawal because it doesn't implement IWithdraw.

This is the benefit: the code only accepts objects that can actually perform the requested operation.

## 7. Why do we use LSP?

Here are the main reasons:

| Reason                    | How LSP helps                                                                                                  |
| ------------------------- | -------------------------------------------------------------------------------------------------------------- |
| Avoid unexpected errors   | Child classes don't break behavior expected from parent types.                                                 |
| Improve code reliability  | Code can safely work with different implementations of an abstraction.                                         |
| Reduce special conditions | You don't need to check every child type before calling a method.                                              |
| Make code extensible      | New implementations can be introduced without breaking existing client code, provided they honor the contract. |
| Improve maintainability   | Responsibilities and supported behaviors are clearer.                                                          |

## 8. What is the relationship between inheritance and LSP?

This is important.

LSP does not mean:

- Never use inheritance.
- Never create parent classes.
- Every child class must have exactly the same implementation.
- Every method must behave identically internally.

It means:

When you use inheritance or an abstraction, the child must honor the behavior expected from that abstraction.

For example:

```
Account account = new SavingAccount();
```

This is fine if SavingAccount behaves as an Account promises.

But:

```
Account account = new FixedDepositAccount();
account.Withdraw(500);
```

is a problem in our original design because FixedDepositAccount cannot honor the withdrawal behavior promised by Account.

Also, remember that LSP is not only about exceptions. A child class can violate LSP by returning unexpected results, changing expected behavior, or strengthening preconditions or weakening postconditions.

## 9. LSP Violated vs LSP Followed – Final comparison

| LSP Violated                                            | LSP Followed                                                  |
| ------------------------------------------------------- | ------------------------------------------------------------- |
| Parent class promises Deposit and Withdraw.             | Separate interfaces define Deposit and Withdraw capabilities. |
| Every child inherits both operations.                   | Each class implements only supported capabilities.            |
| FixedDepositAccount throws an exception for withdrawal. | FixedDepositAccount has no withdrawal method.                 |
| BankClient may fail at runtime.                         | The type system prevents unsupported withdrawal calls.        |
| Child cannot properly honor the parent's contract.      | Implementations honor the contracts they implement.           |

## 10. Interview-ready answer

If someone asks you, "What is Liskov Substitution Principle?", you can answer:

> Liskov Substitution Principle is the third principle of SOLID. It states that objects of a parent class should be replaceable with objects of its child classes without changing the correctness of the program.
>
> It helps us avoid situations where a child class cannot properly support the behavior provided by its parent class.
>
> For example, if we have a Bank Account parent class with Deposit and Withdraw methods, but a Fixed Deposit Account does not support withdrawal, inheriting both methods creates an LSP problem. We can solve this by separating deposit and withdrawal capabilities into different interfaces.

## 11. Check your understanding

Try these three questions. They will help you know whether you've understood the actual concept rather than just memorized the definition.

1\. What is the main purpose of LSP?

To make every class inherit from a parent

To ensure child objects can replace parent objects without breaking expected behavior

To avoid using interfaces



2\. Why does FixedDepositAccount violate LSP in our original example?

Because it has a different class name

Because it has no constructor

Because it cannot support the Withdraw behavior promised by Account



3\. Why did we create IDeposit and IWithdraw?

To separate capabilities so classes only implement operations they support

To create more objects

To make all accounts inherit from the same class



Check my answers

One sentence to remember forever:

LSP means a child class should never promise less than what its parent class or interface promises.