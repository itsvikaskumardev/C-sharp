using Debugging_Tutorial;
using System;


//PermutationCombination.Run();

//DataTips.Run();

//WatchWindow.Run();

DebuggingPractice.Run();








/*
 Yes 👍 Let’s learn **Visual Studio debugging shortcuts step by step.

### 🔴 F9 — Breakpoint

-----------------------------------------------------------------------------------------------

### 🟢 F10 — Step Over : 

**F10 = execute the current line and move to the next line ie. Do this line, don't go inside.

Example:

var student = await GetStudent();  // ← currently here
var name = student.Name;            // ← next
return Ok(name);


Press **F10** → `GetStudent()` executes, but Visual Studio **doesn't enter inside `GetStudent()`**.


------------------------------------------------------------------------------------------------

### 🔵 F11 — Step Into:

**F11 = go inside the function/method being called.**



Think: F11 = "Show me what this function is doing internally."**

------------------------------------------------------------------------------------------------


### 🟡 Shift + F11 — Step Out

If you are already inside a method:

public async Task<Student> GetStudent()
{
    var student = await db.Students.FindAsync(id); // 👈 here
    return student;
}


Press **Shift + F11** → finish the current method and return to the line that called it.

Think: Shift + F11 = "I'm done looking inside this function; take me back."**

------------------------------------------------------------------------------------------------


### 🟢 Locals

**Definition:**

Locals shows the local variables that are currently available in the current method/scope.

So Locals is basically asking:

> **"What local variables exist in this scope?"

Example : 

public void Calculate()
{
    int price = 100;
    int quantity = 5;

    int total = price * quantity;

    string message = "Calculation complete";

    Console.WriteLine(message);  // 🔴 Breakpoint
}

Now you're stopped here: Console.WriteLine(message); // 🔴


Locals can show **all local variables still in scope**:

Locals
────────────────────────
price       100
quantity      5
total       500
message     "Calculation complete"

------------------------------------------------------------------------------------------------

### 🔵 Autos

Autos automatically shows variables that are relevant to the current statement and the statement immediately before it.**

For example, when stopped here:

Console.WriteLine(message); // 🔴


Autos focuses on variables related to the **current/nearby statements**:

Autos
────────────────────────
message     "Calculation complete"


------------------------------------------------------------------------------------------------


   



 
 */