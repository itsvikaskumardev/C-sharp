using System;

namespace C__Basics_Tutorial
{
    public enum PickListStatus
    {
        NotInitiated = 1,
        InProgress = 2,
        Completed = 3,
        Cancelled = 4,
        ShortPick = 5
    }

    public class EnumsTutorial
    {
        public static void Run()
        {
            Console.WriteLine("--------------- Enums ----------------------"); 

            // Instead of defining multiple constants like this:
            // const int NotInitiated = 1;
            // const int InProgress = 2;
            // const int Completed = 3;
            // const int Cancelled = 4;

            // We can use an enum.

            // Using the enum
            PickListStatus status = PickListStatus.Completed;

            Console.WriteLine(status);       // Output: Completed
            Console.WriteLine((int) status);  // Output: 3
        }
    }
}
