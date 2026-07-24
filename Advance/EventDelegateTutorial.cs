using System;

namespace Advance
{
    // Step 1: Create a delegate
    public delegate void Notify(); // I can point to any method that has no parameters and returns void

    // Publisher
    public class Order
    {
        // Step 2: Create an event based on the delegate
        public event Notify OrderPlaced; // The event uses the Notify delegate.

        public void PlaceOrder()
        {
            Console.WriteLine("Order has been placed.");

            // Step 3: Raise the event
            OrderPlaced?.Invoke();
        }
    }

    internal class EventDelegateTutorial
    {
        // Subscriber 1
        public static void SendEmail()
        {
            Console.WriteLine("Email sent to customer.");
        }

        // Subscriber 2
        public static void SendSMS()
        {
            Console.WriteLine("SMS sent to customer.");
        }

        // Subscriber 3
        public static void GenerateInvoice()
        {
            Console.WriteLine("Invoice generated.");
        }

        public static void Run()
        {
            Console.WriteLine("--------------- Events with Delegates ----------------");

            Order order = new Order();

            // Subscribe methods to the event
            order.OrderPlaced += SendEmail;
            order.OrderPlaced += SendSMS;
            order.OrderPlaced += GenerateInvoice;

            // Raise the event
            order.PlaceOrder();
        }
    }
}