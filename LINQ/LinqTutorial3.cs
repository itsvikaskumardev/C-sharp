using System;
using System.Linq;

namespace LINQ
{
    internal partial class LinqTutorial3
    {
        /*
         Join(
            innerCollection,
            outerKeySelector,
            innerKeySelector,
            resultSelector
       )
         */

        public static void Run()
        {
            Console.WriteLine("--------------- JOIN Operator ----------------");

            var students = StudentDatabase.GetStudents();
            var classes = StandardDatabase.GetClasses();

            // Method Syntax
            var data = students.Join(
                classes,                    // Inner collection
                s => s.Standard,            // Outer key
                c => c.Id,                  // Inner key
                (s, c) => new              // Result selector
                {
                    StudentName = s.Name,
                    Teacher = c.ClassTeacher,
                    Standard = c.Id,
                    Gender = s.Gender
                });

            // Query Syntax
            /*
            var data =
                from s in students
                join c in classes
                on s.Standard equals c.Id
                select new
                {
                    StudentName = s.Name,
                    Teacher = c.ClassTeacher,
                    Standard = c.Id,
                    Gender = s.Gender
                };
            */

            Console.WriteLine("Student\t\tStandard\tTeacher\t\tGender");
            Console.WriteLine("-----------------------------------------------------------");

            foreach (var item in data)
            {
                Console.WriteLine($"{item.StudentName}\t\t{item.Standard}\t\t{item.Teacher}\t\t{item.Gender}");
            }
        }
    }
}