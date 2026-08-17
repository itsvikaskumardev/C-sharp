using System;
using System.Collections.Generic;
using System.Text;

namespace Debugging_Tutorial
{
    internal class PermutationCombination
    {
        public static void Run()
        {

            int n, r;
            float res;

            Console.WriteLine("Enter the value of n:");
            n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the value of r:");
            r = Convert.ToInt32(Console.ReadLine());

            res = nCr(n, r);

            Console.WriteLine("Result is: " + res);


            static float nCr(int n, int r)
            {
                int x = fact(n);
                int y = fact(n - r);
                int z = fact(r);

                return (float)x / (y * z);
            }


            static int fact(int n)
            {
                int f = 1;

                for (int i = 2; i <= n; i++)
                {
                    f = f * i;
                }

                return f;
            }
        }
    }
}
