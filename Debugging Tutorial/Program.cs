using System;

Console.WriteLine("Hello, World!");

int n, r;
float res;

Console.WriteLine("Enter the value of n:");
n = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter the value of r:");
r = Convert.ToInt32(Console.ReadLine());

res = nCr(n, r);

Console.WriteLine("Result is: " + res);


static float nCr(int n, int r)
{
    int x = fact(n);
    int y = fact(n - r);
    int z = fact(r);

    return (float)x / (y * z);
}


static int fact(int n)
{
    int f = 1;

    for (int i = 2; i <= n; i++)
    {
        f = f * i;
    }

    return f;
}

/*
 Yes 👍 Let’s learn **Visual Studio debugging shortcuts** step by step.

### 🔴 F9 — Breakpoint



Example:

```csharp
var student = await db.Students.FindAsync(id); // F9 here
var name = student.Name;
return Ok(name);
```

---

### 🟢 F10 — Step Over

**F10 = execute the current line and move to the next line.**

Example:

```csharp
var student = await GetStudent();  // ← currently here
var name = student.Name;            // ← next
return Ok(name);
```

Press **F10** → `GetStudent()` executes, but Visual Studio **doesn't enter inside `GetStudent()`**.

Think:

> **F10 = "Do this line, don't go inside."**

---

### 🔵 F11 — Step Into

**F11 = go inside the function/method being called.**

```csharp
var student = await GetStudent();
```

Press **F11** → Visual Studio goes inside:

```csharp
public async Task<Student> GetStudent()
{
    var student = await db.Students.FindAsync(id);
    return student;
}
```

Think:

> **F11 = "Show me what this function is doing internally."**

---

### 🟡 Shift + F11 — Step Out

If you are already inside a method:

```csharp
public async Task<Student> GetStudent()
{
    var student = await db.Students.FindAsync(id); // 👈 here
    return student;
}
```

Press **Shift + F11** → finish the current method and return to the line that called it.

Think:

> **Shift + F11 = "I'm done looking inside this function; take me back."**

---

### 🧠 Easy way to remember

| Shortcut        | Meaning    | Think                        |
| --------------- | ---------- | ---------------------------- |
| **F9**          | Breakpoint | 🛑 Stop here                 |
| **F10**         | Step Over  | ➡️ Next line                 |
| **F11**         | Step Into  | 🔍 Go inside function        |
| **Shift + F11** | Step Out   | ⬅️ Get out of function       |
| **F5**          | Continue   | ▶️ Run until next breakpoint |

### Real example

```csharp
public async Task<IResult> GetStudent(int id)
{
    var student = await GetStudentFromDb(id);  // F11 → go inside
    var result = MapStudent(student);           // F10 → execute, don't enter
    return Results.Ok(result);                  // F10
}
```

So while debugging:

**F9 → F5 → F10/F11 → Shift+F11**

These are the core Visual Studio debugging shortcuts you'll use most often.

 
 */