using System;

namespace Advance
{
    /*
     Delegate = "Who should be called?"
Event = "When should they be called?"
     */
    // Publisher
    public class DoorBell
    {
        // Declare an event
        public event Action? BellRang; // Event name : BellRang

        public void PressBell()
        {
            Console.WriteLine("Someone pressed the door bell.");

            // Raise the event
            BellRang?.Invoke(); // The event automatically calls: Momd(). Dad(),Dog()
        }
    }

    internal class EventTutorial
    {
        // Subscriber 1
        public static void Mom()
        {
            Console.WriteLine("Mom opened the door.");
        }

        // Subscriber 2
        public static void Dad()
        {
            Console.WriteLine("Dad looked outside.");
        }

        // Subscriber 3
        public static void Dog()
        {
            Console.WriteLine("Dog started barking.");
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Events ----------------");

            DoorBell bell = new DoorBell();

            // Subscribe methods to the event
            bell.BellRang += Mom;
            bell.BellRang += Dad;
            bell.BellRang += Dog;

            // Raise the event
            bell.PressBell();
        }
    }
}