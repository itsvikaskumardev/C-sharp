using System;

namespace C__Basics_Tutorial
{
    public class VariablesAndTypes
    {
        public static void Run()
        {
            Console.WriteLine("--------- Variables and Constants ---------");

            // Variable declaration
            int number;
            number = 1;

            // Constant
            const float Pi = 3.14f; // float literal uses 'f'

            decimal decimalNumber = 1.2m; // decimal literal uses 'm'

            Console.WriteLine("Number = " + number);
            Console.WriteLine("Pi = " + Pi);
            Console.WriteLine("Decimal Number = " + decimalNumber);

            Console.WriteLine("--------- Overflowing ---------");

            byte byteNumber = 255;

            // This will cause an overflow exception
            checked
            {
                try
                {
                    byte result = (byte)(byteNumber + 1);
                    Console.WriteLine(result);
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow occurred!");
                }
            }
            Console.WriteLine("----------- Implicit Type Conversion -----------");

            byte smallNumber = 1; // Binary: 00000001
            int largerNumber = smallNumber;

            Console.WriteLine("----------- Explicit Type Conversion -----------");

            int integerValue = 1;
            // byte byteValue = integerValue; // Won't compile

            byte byteValue = (byte)integerValue;

            float floatValue = 1.0f;
            int convertedInteger = (int)floatValue;

            string text = "1";

            // Using Convert class
            int numberFromConvert = Convert.ToInt32(text);

            // Using Parse method
            int numberFromParse = int.Parse(text);
        }
    }
}
