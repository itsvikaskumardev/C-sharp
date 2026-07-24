using System;

namespace Basics_2
{
    internal class NullableTypes
    {
        public static void Run()
        {
            /*
             * Nullable Types
             * --------------
             * Value types (int, double, bool, DateTime, etc.)
             * cannot store null by default.
             *
             * To allow a value type to store null,
             * use Nullable<T> or the shorthand T?.
             *
             * Example:
             * Nullable<DateTime> date = null;
             * DateTime? date = null;
             */

            // Nullable DateTime
            DateTime? date1 = null;

            Console.WriteLine("Default Value : " + date1.GetValueOrDefault());
            Console.WriteLine("Has Value     : " + date1.HasValue);

            // Don't access .Value if HasValue is false.
            if (date1.HasValue)
            {
                Console.WriteLine("Value         : " + date1.Value);
            }
            else
            {
                Console.WriteLine("Value         : null");
            }

            Console.WriteLine();
            Console.WriteLine("------------ DateTime Example ------------");

            DateTime? date2 = new DateTime(2014, 1, 1);

            Console.WriteLine("Date2 : " + date2);

            // GetValueOrDefault()
            DateTime date3 = date2.GetValueOrDefault();

            Console.WriteLine("Date3 : " + date3);

            Console.WriteLine();

            /*
             * Null-Coalescing Operator (??)
             * -----------------------------
             * If the left side is NOT null,
             * return the left value.
             *
             * Otherwise, return the right value.
             */

            DateTime? date4 = null;

            DateTime result = date4 ?? DateTime.Today;

            Console.WriteLine("Result : " + result);
        }
    }
}

/*
 | Member                | Purpose                                                                                                 |
| --------------------- | ------------------------------------------------------------------------------------------------------- |
| `HasValue`            | Returns `true` if the nullable variable contains a value.                                               |
| `Value`               | Returns the stored value. Throws an exception if the value is `null`.                                   |
| `GetValueOrDefault()` | Returns the stored value, or the default value of the type if it is `null`.                             |
| `??`                  | Null-coalescing operator. Returns the left value if it isn't `null`; otherwise returns the right value. |

 
 
 */