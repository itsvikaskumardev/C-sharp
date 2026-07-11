using System;

namespace Object_Oriented_Programming___2
{
    public sealed class Employee
    {
        //sealed class: A sealed class is a class that cannot be inherited.
        public string Name { get; set; }

        public void Work()
        {
            Console.WriteLine($"{Name} is working.");
        }
    }


    /*
     Now this is not allowed:❌ Compile-time Error
 Cannot derive from sealed type 'Employee'
     
     public class Manager : Employee
     {
      
     }
     
     */

    internal class SealedClassTutorial
    {
        public static void Run()
        {
            Console.WriteLine("-----------------------Sealed class Tutorial------------");
            Employee employee = new Employee();

            employee.Name = "Vikas";
            employee.Work();
        }
    }
}