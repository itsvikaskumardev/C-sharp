using SOLID_PRINCIPLES;


/*
 
 1. Why do we use internal?
internal is an access modifier in C#.

It controls where a class, method, or other member can be accessed.

Meaning: An internal class can be accessed only within the same project (assembly).

For example, suppose your project structure is:
SOLID_PRINCIPLES (Project)
│
├── Program.cs
├── SRP_Violated.cs
└── SRP_Followed.cs


Both Program.cs and SRP_Violated.cs belong to the same project.

Therefore, you can access:
internal class SRP_Violated
{
}


from Program.cs.

But another project cannot directly access this class.
Access modifiers comparison
Modifier	Accessibility
public	Accessible from anywhere (subject to containing type accessibility)
private	Only inside the containing class/type
protected	Inside the class and its derived classes
internal	Within the same assembly/project
protected internal	Same assembly OR derived classes
private protected	Same assembly AND derived classes

Remember: internal is commonly used for classes that should be available throughout your project but not exposed to other projects.
 
 
 */

SRP_Violated.Run();