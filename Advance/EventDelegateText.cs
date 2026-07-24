/*
 **Yes.** In C#, **events are built on top of delegates**.

Think of it like this:

```text
Method
   ↓
Delegate
   ↓
Event
```

An **event cannot exist without a delegate** because the delegate defines **what kind of methods can subscribe** to the event.

---

## Without an Event (Only Delegate)

```csharp
public delegate void Notify();

Notify notify;

notify += Email;
notify += SMS;

notify?.Invoke();
```

Here you're using a delegate directly.

**Problem:** Anyone can do this:

```csharp
notify = null;      // Remove all methods
notify();           // Invoke it from anywhere
```

This is unsafe.

---

## With an Event

```csharp
public delegate void Notify();

public event Notify OrderPlaced;
```

Now:

```csharp
OrderPlaced += Email;
OrderPlaced += SMS;
```

Inside the same class:

```csharp
OrderPlaced?.Invoke();
```

Outside the class:

```csharp
order.OrderPlaced?.Invoke(); // ❌ Not Allowed

order.OrderPlaced = null;    // ❌ Not Allowed
```

Only the class that owns the event can raise it.

---

# Visual Example

Without an event:

```text
Customer

Delegate
   │
   ├── Email()
   ├── SMS()
   └── Invoice()

Anyone can call it ❌
Anyone can remove subscribers ❌
```

---

With an event:

```text
Customer
      │
      ▼
OrderPlaced Event
      │
      ├── Email()
      ├── SMS()
      └── Invoice()

Only Customer can raise the event ✅
Other classes can only subscribe/unsubscribe ✅
```

---

# What actually happens?

When you write:

```csharp
public event Action OrderPlaced;
```

`Action` is itself a **delegate**.

It's equivalent to:

```csharp
public delegate void Action();
```

So:

```csharp
public event Action OrderPlaced;
```

means:

* `Action` → defines the method signature.
* `event` → restricts access so only the owning class can raise the notification.

---

# Can we create an event without a delegate?

**No.**

An event must be based on a delegate.

You can use:

Your own delegate:

```csharp
public delegate void Notify();

public event Notify OrderPlaced;
```

or a built-in delegate like `Action`:

```csharp
public event Action OrderPlaced;
```

or `EventHandler` (the most common .NET pattern):

```csharp
public event EventHandler OrderPlaced;
```

---

## Easy way to remember

| Delegate                                       | Event                                             |
| ---------------------------------------------- | ------------------------------------------------- |
| Stores references to methods.                  | Uses a delegate to notify subscribers.            |
| Can be invoked by anyone who has access to it. | Can only be raised by the class that declares it. |
| Can exist without an event.                    | **Cannot exist without a delegate.**              |

### One sentence to remember

> **Every event uses a delegate, but not every delegate is used as an event.**

 */