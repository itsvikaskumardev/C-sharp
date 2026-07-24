using System;
using System.Linq;

namespace LINQ
{
    internal class LinqTutorial1
    {
        /*
         * LINQ (Language Integrated Query)
         * --------------------------------
         * LINQ is used to query and manipulate data from different data sources
         * such as arrays, lists, databases, XML, etc.
         *
         * Query Syntax (Query Expression)
         * -------------------------------
         * from variable in collection
         * where condition
         * orderby variable
         * select variable;
         *
         * A LINQ query must end with either:
         * 1. select
         * 2. group
         *
         * Query syntax is similar to SQL, so it is easy for SQL developers to learn.
         *
         * SQL Equivalent:
         * SELECT * FROM Table WHERE Age > 20 ORDER BY Age;
         */

        public static void Run()
        {
            Console.WriteLine("--------------- LINQ Query Syntax ----------------");

            int[] ages = { 12, 16, 17, 23, 21, 22, 45, 33, 26, 55, 66 };

            // Filter values greater than 20
            var result = from age in ages
                         where age > 20
                         select age;

            Console.WriteLine("------- Age > 20 -------");

            foreach (int item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // Sort in Ascending Order
            var ascending = from age in ages
                            orderby age
                            select age;

            Console.WriteLine("------- Ascending Order -------");

            foreach (int item in ascending)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            // Sort in Descending Order
            var descending = from age in ages
                             orderby age descending
                             select age;

            Console.WriteLine("------- Descending Order -------");

            foreach (int item in descending)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            string[] names = { "Vikas", "Amit", "Surya", "Rahul", "Ankit" };

            // Filter names starting with 'A'
            var nameResult = from name in names
                             where name.StartsWith("A")
                             select name;

            Console.WriteLine("------- Names Starting With A -------");

            foreach (string name in nameResult)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            // Project (Select) only the length of each name
            var lengths = from name in names
                          select name.Length;

            Console.WriteLine("------- Length of Each Name -------");

            foreach (int length in lengths)
            {
                Console.WriteLine(length);
            }

            Console.WriteLine();

            // let keyword - create a temporary variable
            var upperNames = from name in names
                             let upper = name.ToUpper()
                             select upper;

            Console.WriteLine("------- Uppercase Names (let) -------");

            foreach (string name in upperNames)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            // group by example
            var groupedNames = from name in names
                               group name by name[0];

            Console.WriteLine("------- Group By First Character -------");

            foreach (var group in groupedNames)
            {
                Console.WriteLine($"Group {group.Key}");

                foreach (var name in group)
                {
                    Console.WriteLine($"  {name}");
                }
            }
        }
    }
}