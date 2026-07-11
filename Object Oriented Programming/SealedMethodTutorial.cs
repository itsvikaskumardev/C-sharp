using System;

namespace Object_Oriented_Programming
{
    public class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Employee is working.");
        }
    }

    public class Manager : Employee
    {
        public sealed override void Work()
        {
            Console.WriteLine("Manager is managing the team.");
        }
    }

    public class SeniorManager : Manager
    {
        // Not Allowed

        //public override void Work()
        //{
        //    Console.WriteLine("Senior Manager Working");
        //}
    }

    internal class SealedMethodTutorial
    {
        public static void Run()
        {
            Console.WriteLine("-------------SealedMethodTutorial---------------");
            Employee employee = new Employee();
            employee.Work();

            Manager manager = new Manager();
            manager.Work();
        }
    }
}