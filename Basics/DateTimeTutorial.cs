using System;

namespace C__Basics_Tutorial
{
    public class DateTimeTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Date Time ----------------");

            // Current date and time
            var dt = DateTime.Now;

            Console.WriteLine($"Now: {dt}");
            Console.WriteLine($"Today: {DateTime.Today}");

            Console.WriteLine();
        
            Console.WriteLine("--------------- Individual Parts ----------------");

            Console.WriteLine($"Year   : {dt.Year}");
            Console.WriteLine($"Month  : {dt.Month}");
            Console.WriteLine($"Day    : {dt.Day}");
            Console.WriteLine($"Hour   : {dt.Hour}");
            Console.WriteLine($"Minute : {dt.Minute}");
            Console.WriteLine($"Second : {dt.Second}");

            Console.WriteLine();

            Console.WriteLine("--------------- Creating a Date ----------------");

            var birthday = new DateTime(2002, 1, 15);

            Console.WriteLine($"Birthday: {birthday}");

            Console.WriteLine();

            Console.WriteLine("--------------- Add Methods ----------------");

            Console.WriteLine($"Add 1 Day    : {dt.AddDays(1)}");
            Console.WriteLine($"Add 2 Months : {dt.AddMonths(2)}");
            Console.WriteLine($"Add 1 Year   : {dt.AddYears(1)}");
            Console.WriteLine($"Add 3 Hours  : {dt.AddHours(3)}");
            Console.WriteLine($"Add 30 Minutes: {dt.AddMinutes(30)}");

            Console.WriteLine();

            Console.WriteLine("--------------- Formatting ----------------");

            Console.WriteLine(dt.ToString());
            Console.WriteLine("{0:d}", dt); // Short date
            Console.WriteLine("{0:D}", dt); // Long date
            Console.WriteLine("{0:f}", dt); // Full date, short time
            Console.WriteLine("{0:F}", dt); // Full date, full time
            Console.WriteLine("{0:g}", dt); // General date and time

            Console.WriteLine();

            Console.WriteLine("--------------- Custom Formats ----------------");

            Console.WriteLine(dt.ToString("dd/MM/yyyy"));
            Console.WriteLine(dt.ToString("dd-MM-yyyy"));
            Console.WriteLine(dt.ToString("dd MMM yyyy"));
            Console.WriteLine(dt.ToString("hh:mm tt"));
            Console.WriteLine(dt.ToString("dddd, dd MMMM yyyy"));
        }
    }
}