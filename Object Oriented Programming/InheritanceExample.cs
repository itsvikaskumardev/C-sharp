using System;

namespace Object_Oriented_Programming
{
    // Base Class
    public class InheritancePerson
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }

        public void Walk()
        {
            Console.WriteLine($"{Name} is walking.");
        }
    }

    // Child Class
    public class InheritanceStudent : InheritancePerson
    {
        public string Course { get; set; }

        public void Study()
        {
            Console.WriteLine($"{Name} is studying {Course}.");
        }
    }

    // Child Class
    public class InheritanceTeacher : InheritancePerson
    {
        public string Subject { get; set; }

        public void Teach()
        {
            Console.WriteLine($"{Name} is teaching {Subject}.");
        }
    }

    internal class InheritanceExample
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Student ----------------");

            InheritanceStudent student = new InheritanceStudent();

            student.Name = "Vikas";
            student.Age = 22;
            student.Course = "Computer Science";

            student.Walk();     // Inherited
            student.Eat();      // Inherited
            student.Study();    // Student's own method

            Console.WriteLine();

            Console.WriteLine("--------------- Teacher ----------------");

            InheritanceTeacher teacher = new InheritanceTeacher();

            teacher.Name = "Rahul";
            teacher.Age = 35;
            teacher.Subject = "C#";

            teacher.Walk();     // Inherited
            teacher.Eat();      // Inherited
            teacher.Teach();    // Teacher's own method
        }
    }
}

/*
 
                   Person
          ----------------------
          Name
          Age
          Eat()
          Walk()
             ▲
      ┌──────┴──────┐
      │             │
   Student       Teacher
   --------      --------
   Course        Subject
   Study()       Teach()



| Type               | Supported in C#?        | Example                                |
| ------------------ | ----------------------- | -------------------------------------- |
| Single             | ✅ Yes                   | `Person → Student`                     |
| Hierarchical       | ✅ Yes                   | `Person → Student`, `Person → Teacher` |
| Multilevel         | ✅ Yes                   | `Person → Student → GraduateStudent`   |
| Multiple (classes) | ❌ No                    | `Student : Person, Employee`           |
| Hybrid             | ⚠️ Only with interfaces | Combination using interfaces           |

 */