using System;

namespace Debugging_Tutorial
{
    internal class WatchWindow
    {
        public static void Run()
        {
            TestEmployee employeeTest = new TestEmployee();

            Console.WriteLine($"Total Employees: {Employee.TotalEmployees}");
        }

        class TestEmployee
        {
            public TestEmployee()
            {
                Employee emp1 = new Employee()
                {
                    Id = 101,
                    Name = "TestEmp1",
                    Designation = "Account Manager",
                    BasicSalary = 21500M
                };

                decimal netSal1 = emp1.NetSalary();

                Employee emp2 = new Employee()
                {
                    Id = 102,
                    Name = "TestEmp2",
                    Designation = "Production Engineer",
                    BasicSalary = 305500M
                };

                decimal netSal2 = emp2.NetSalary();

                Console.WriteLine($"{emp1.Name} Net Salary: {netSal1}");
                Console.WriteLine($"{emp2.Name} Net Salary: {netSal2}");
            }
        }

        class Employee
        {
            private static int count;

            public int Id { get; set; }
            public string Name { get; set; }
            public string Designation { get; set; }
            public decimal BasicSalary { get; set; }

            public Employee()
            {
                count++;
            }

            public static int TotalEmployees
            {
                get { return count; }
            }

            // Calculate net salary
            public decimal NetSalary()
            {
                decimal HRA, DA, PF;
                decimal ProfTax = 200M;

                // Calculate allowances
                HRA = BasicSalary * 0.2M;
                DA = BasicSalary * 0.5M;

                // Calculate PF deduction
                if (BasicSalary <= 1000M)
                {
                    PF = BasicSalary * 0.11M;
                }
                else if (BasicSalary < 2000M)
                {
                    PF = BasicSalary * 0.13M;
                }
                else
                {
                    PF = BasicSalary * 0.15M;
                }

                // Calculate total allowances
                decimal Allowances = HRA + DA;

                // Calculate total deductions
                decimal Deductions = PF + ProfTax;

                // Calculate net salary
                decimal NetSal = BasicSalary + Allowances - Deductions;

                return NetSal;
            }

            public void Quit()
            {
                count--;
            }
        }
    }
}