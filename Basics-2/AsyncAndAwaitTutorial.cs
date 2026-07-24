using System;
using System.Threading;
using System.Threading.Tasks;

namespace Basics_2
{
    internal class AsyncAndAwaitTutorial
    {
        /*
         * Synchronous vs Asynchronous Programming
         * ---------------------------------------
         *
         * Synchronous:
         * One task executes after another.
         * The next task waits until the current task finishes.
         *
         * Asynchronous:
         * A task can run without blocking the current thread.
         * While one task is waiting (for example, downloading data,
         * reading a file, or calling a web API), other work can continue.
         *
         * async
         * -----
         * The async keyword marks a method as asynchronous.
         *
         * await
         * -----
         * The await keyword waits for an asynchronous operation to finish
         * WITHOUT blocking the current thread.
         *
         * Note:
         * Thread.Sleep() blocks the thread.
         * Task.Delay() does NOT block the thread.
         */

        //---------------------------------------------------
        // Synchronous Methods
        //---------------------------------------------------

        public static void Task1()
        {
            Console.WriteLine("Task 1 Started");

            Thread.Sleep(1000);

            Console.WriteLine("Task 1 Completed");
        }

        public static void Task2()
        {
            Console.WriteLine("Task 2 Started");

            Thread.Sleep(1000);


            Console.WriteLine("Task 2 Completed");
        }

        public static void Task3()
        {
            Console.WriteLine("Task 3 Started");

            Thread.Sleep(1000);


            Console.WriteLine("Task 3 Completed");
        }

        //---------------------------------------------------
        // Asynchronous Methods
        //---------------------------------------------------

        public static async Task AsyncTask1()
        {
            Console.WriteLine("Async Task 1 Started");

            await Task.Delay(2000);

            Console.WriteLine("Async Task 1 Completed");
        }

        public static async Task AsyncTask2()
        {
            Console.WriteLine("Async Task 2 Started");

            await Task.Delay(2000);

            Console.WriteLine("Async Task 2 Completed");
        }

        public static async Task AsyncTask3()
        {
            Console.WriteLine("Async Task 3 Started");

            await Task.Delay(2000);

            Console.WriteLine("Async Task 3 Completed");
        }

        public static async Task Run()
        {
            Console.WriteLine("----------- Synchronous -----------");

            Task1();
            Task2();
            Task3();

            Console.WriteLine();
            Console.WriteLine("----------- Asynchronous -----------");

            Task t1 = AsyncTask1();
            Task t2 = AsyncTask2();
            Task t3 = AsyncTask3();

            await Task.WhenAll(t1, t2, t3);
        }
    }
}