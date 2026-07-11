using System;

namespace C_
{
     class ReferenceTypeAndValue

    {
        class Student
        {
            public string Name;
        }
        public static void Run()
        {
            // ================= Value Type =================
            // Examples: int, double, bool, char, struct, enum

            int x = 10;
            int y = x;

            y = 20;

            Console.WriteLine(x); // 10
            Console.WriteLine(y); // 20

            // What happened?
            // y = x made a copy of the value 10.
            // Changing y does not change x.

            // Memory picture:
            // x ---> 10
            // y ---> 20

            Console.WriteLine();

            // ================= Reference Type =================

            Student s1 = new Student();
            s1.Name = "Vikas";

            Student s2 = s1;

            s2.Name = "Rahul";

            Console.WriteLine(s1.Name); // Rahul
            Console.WriteLine(s2.Name); // Rahul

            // What happened?
            // s2 = s1 did not create another object.
            // Both variables point to the same object in memory.

            // Memory picture:
            // s1 ----\
            //         ---> Student object { Name = "Rahul" }
            // s2 ----/

            // Changing s2.Name also changes s1.Name.
        }
    }

    // A class is a Reference Type
    
}