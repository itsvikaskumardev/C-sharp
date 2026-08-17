using System;
using System.Collections.Generic;

namespace Debugging_Tutorial
{
    internal class DataTips
    {
        public static void Run()
        {
            int num1 = 10, num2 = 20;

            Swap(num1, num2);

            string text = "I am Learning Debugging";
            SplitText(text);

            List<Course> listCourse = new List<Course>()
            {
                new Course { ID = 1, Name = "ASP.NET MVC", Duration = 60, Fees = 16000 },
                new Course { ID = 2, Name = "C# Programming", Duration = 45, Fees = 12000 },
                new Course { ID = 3, Name = "ASP.NET Core Web API", Duration = 50, Fees = 18000 },
                new Course { ID = 4, Name = "Entity Framework Core", Duration = 35, Fees = 14000 },
                new Course { ID = 5, Name = "SQL and Database", Duration = 25, Fees = 9000 },
                new Course { ID = 6, Name = "React JS", Duration = 40, Fees = 15000 },
                new Course { ID = 7, Name = "JavaScript", Duration = 30, Fees = 10000 },
                new Course { ID = 8, Name = "Data Structures and Algorithms", Duration = 80, Fees = 20000 }


            };

            CourseAbove30Hrs(listCourse);

            BankAccount b = new BankAccount(10000)
            {
                AccountNo = 123321,
                AccountHolder = "TestCustomer",
                Type = "Saving"
            };

            b.Deposit(5000);
            b.Withdraw(7000);
        }

        static void Swap(int num1, int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }

        static void SplitText(string text)
        {
            string[] words = text.Split(' ');

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
        }

        static void CourseAbove30Hrs(List<Course> courses)
        {
            foreach (Course course in courses)
            {
                if (course.Duration > 30)
                {
                    Console.WriteLine(course.Name);
                }
            }
        }
    }

    class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public decimal Fees { get; set; }
    }

    class BankAccount
    {
        public int AccountNo { get; set; }
        public string AccountHolder { get; set; }
        public string Type { get; set; }

        private decimal _balance;

        public decimal Balance
        {
            get
            {
                return _balance;
            }
        }

        public BankAccount(decimal initialAmount)
        {
            _balance = initialAmount;
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (_balance - amount > 1000)
            {
                _balance -= amount;
            }
        }
    }
}