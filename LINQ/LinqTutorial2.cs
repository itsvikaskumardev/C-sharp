using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal class LinqTutorial2
    {
        public class BookDatabase
        {
            /*
             * IEnumerable<T>
             * --------------
             * IEnumerable is an interface that represents a collection
             * that can be iterated using foreach.
             */

            public static IEnumerable<Book> GetBooksData()
            {
                return new List<Book>
                {
                    new Book(121, "Harry Potter and the Philosopher's Stone", 8000, "J.K. Rowling"),
                    new Book(151, "Tell Me Your Dreams", 600, "Sidney Sheldon"),
                    new Book(152, "If Tomorrow Comes", 550, "Sidney Sheldon"),
                    new Book(153, "The Other Side of Midnight", 700, "Sidney Sheldon"),
                    new Book(154, "Master of the Game", 650, "Sidney Sheldon"),
                    new Book(201, "The Alchemist", 450, "Paulo Coelho"),
                    new Book(202, "The Monk Who Sold His Ferrari", 500, "Robin Sharma"),
                    new Book(203, "Rich Dad Poor Dad", 650, "Robert T. Kiyosaki"),
                    new Book(204, "Atomic Habits", 850, "James Clear"),
                    new Book(205, "Deep Work", 780, "Cal Newport"),
                    new Book(206, "Clean Code", 1200, "Robert C. Martin"),
                    new Book(207, "The Pragmatic Programmer", 1500, "Andrew Hunt"),
                    new Book(208, "Introduction to Algorithms", 3500, "Thomas H. Cormen"),
                    new Book(209, "The Psychology of Money", 650, "Morgan Housel"),
                    new Book(210, "Think and Grow Rich", 550, "Napoleon Hill")
                };
            }
        }

        public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public string Author { get; set; }

            public Book(int id, string name, double price, string author)
            {
                Id = id;
                Name = name;
                Price = price;
                Author = author;
            }
        }

        /*
         * LINQ to SQL
         * -----------
         * LINQ queries are:
         * - Checked at compile time.
         * - Support IntelliSense.
         * - Object-oriented.
         * - Type-safe.
         *
         * ORM (Object Relational Mapping)
         * -------------------------------
         * ORM maps relational database objects to C# objects.
         *
         * Database Table      -> Class
         * Database Row        -> Object
         * Database Column     -> Property
         * Stored Procedure    -> Method
         *
         * Common ORMs:
         * - Entity Framework Core
         * - Dapper
         * - NHibernate
         *
         * LINQ supports:
         * 1. Query Syntax
         * 2. Method (Extension) Syntax
         */

        public static void Run()
        {
            Console.WriteLine("--------------- LINQ Extension Methods ----------------");

            // Get all books
            var books = BookDatabase.GetBooksData();

            //-------------------------------------------------------
            // SELECT
            //-------------------------------------------------------

            Console.WriteLine("\n------ SELECT Operator ------");

            var selectedBooks = books.Select(b => new
            {
                BookName = b.Name,
                BookPrice = b.Price
            });

            // Query Syntax
            /*
            var selectedBooks =
                from b in books
                select new
                {
                    BookName = b.Name,
                    BookPrice = b.Price
                };
            */

            foreach (var item in selectedBooks)
            {
                Console.WriteLine($"{item.BookName} - ₹{item.BookPrice}");
            }

            //-------------------------------------------------------
            // SELECT SINGLE PROPERTY
            //-------------------------------------------------------

            Console.WriteLine("\n------ SELECT Author ------");

            var authors = books.Select(b => b.Author);

            // Query Syntax
            // var authors = from b in books select b.Author;

            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }

            //-------------------------------------------------------
            // WHERE
            //-------------------------------------------------------

            Console.WriteLine("\n------ WHERE Operator ------");

            var cheapBooks = books.Where(b => b.Price < 700);

            // Query Syntax
            // var cheapBooks = from b in books
            //                  where b.Price < 700
            //                  select b;

            foreach (var book in cheapBooks)
            {
                Console.WriteLine($"{book.Name} - ₹{book.Price}");
            }

            //-------------------------------------------------------
            // ORDER BY
            //-------------------------------------------------------

            Console.WriteLine("\n------ ORDER BY Price ------");

            var orderedBooks = books.OrderBy(b => b.Price);

            // Query Syntax
            // var orderedBooks = from b in books
            //                    orderby b.Price
            //                    select b;

            foreach (var book in orderedBooks)
            {
                Console.WriteLine($"{book.Name} - ₹{book.Price}");
            }

            //-------------------------------------------------------
            // ORDER BY DESCENDING
            //-------------------------------------------------------

            Console.WriteLine("\n------ ORDER BY DESCENDING ------");

            var expensiveBooks = books.OrderByDescending(b => b.Price);

            foreach (var book in expensiveBooks)
            {
                Console.WriteLine($"{book.Name} - ₹{book.Price}");
            }

            //-------------------------------------------------------
            // THEN BY
            //-------------------------------------------------------

            Console.WriteLine("\n------ THEN BY Operator ------");

            // First sort by Author, then by Price
            var thenByBooks = books
                .OrderBy(b => b.Author)
                .ThenBy(b => b.Price);

            // Query Syntax
            /*
            var thenByBooks =
                from b in books
                orderby b.Author, b.Price
                select b;
            */

            foreach (var book in thenByBooks)
            {
                Console.WriteLine($"{book.Author} - {book.Name} - ₹{book.Price}");
            }

            //-------------------------------------------------------
            // GROUP BY
            //-------------------------------------------------------

            Console.WriteLine("\n------ GROUP BY Author ------");

            var groupedBooks = books.GroupBy(b => b.Author);

            // Query Syntax
            /*
            var groupedBooks =
                from b in books
                group b by b.Author;
            */

            foreach (var group in groupedBooks)
            {
                Console.WriteLine($"\nAuthor : {group.Key}");

                foreach (var book in group)
                {
                    Console.WriteLine(book.Name);
                }
            }

            //-------------------------------------------------------
            // FIRST
            //-------------------------------------------------------

            Console.WriteLine("\n------ FIRST ------");

            var firstBook = books.First();

            Console.WriteLine(firstBook.Name);

            //-------------------------------------------------------
            // FIRST OR DEFAULT
            //-------------------------------------------------------

            Console.WriteLine("\n------ FIRST OR DEFAULT ------");

            var firstExpensiveBook = books.FirstOrDefault(b => b.Price > 7000);

            if (firstExpensiveBook != null)
            {
                Console.WriteLine(firstExpensiveBook.Name);
            }

            //-------------------------------------------------------
            // COUNT
            //-------------------------------------------------------

            Console.WriteLine("\n------ COUNT ------");

            Console.WriteLine($"Total Books : {books.Count()}");

            //-------------------------------------------------------
            // ANY
            //-------------------------------------------------------

            Console.WriteLine("\n------ ANY ------");

            Console.WriteLine(books.Any(b => b.Price > 5000));

            //-------------------------------------------------------
            // ALL
            //-------------------------------------------------------

            Console.WriteLine("\n------ ALL ------");

            Console.WriteLine(books.All(b => b.Price > 100));

            //-------------------------------------------------------
            // MAX
            //-------------------------------------------------------

            Console.WriteLine("\n------ MAX ------");

            Console.WriteLine($"Highest Price : ₹{books.Max(b => b.Price)}");

            //-------------------------------------------------------
            // MIN
            //-------------------------------------------------------

            Console.WriteLine("\n------ MIN ------");

            Console.WriteLine($"Lowest Price : ₹{books.Min(b => b.Price)}");

            //-------------------------------------------------------
            // AVERAGE
            //-------------------------------------------------------

            Console.WriteLine("\n------ AVERAGE ------");

            Console.WriteLine($"Average Price : ₹{books.Average(b => b.Price)}");

            //-------------------------------------------------------
            // SUM
            //-------------------------------------------------------

            Console.WriteLine("\n------ SUM ------");

            Console.WriteLine($"Total Price : ₹{books.Sum(b => b.Price)}");

            //-------------------------------------------------------
            // TAKE
            //-------------------------------------------------------

            Console.WriteLine("\n------ TAKE ------");

            var firstThree = books.Take(3);

            foreach (var book in firstThree)
            {
                Console.WriteLine(book.Name);
            }

            //-------------------------------------------------------
            // SKIP
            //-------------------------------------------------------

            Console.WriteLine("\n------ SKIP ------");

            var skipThree = books.Skip(3);

            foreach (var book in skipThree)
            {
                Console.WriteLine(book.Name);
            }

            //-------------------------------------------------------
            // DISTINCT
            //-------------------------------------------------------

            Console.WriteLine("\n------ DISTINCT Authors ------");

            var uniqueAuthors = books
                .Select(b => b.Author)
                .Distinct();

            foreach (var author in uniqueAuthors)
            {
                Console.WriteLine(author);
            }
        }
    }
}