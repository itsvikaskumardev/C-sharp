using System;
using System.Collections.Generic;

namespace Debugging_Tutorial
{
    internal class DebuggingPractice
    {
        public static void Run()
        {
            Console.WriteLine("Starting Debugging Practice...");
            
            List<int> studentScores = new List<int> { 85, 90, 78, 92, 88 };
            
            // 1. Practice Step Over (F10) & Locals Window
            // Place a Breakpoint (F9) on the line below. Then use F10 to move line by line without going inside.
            int totalScore = CalculateTotal(studentScores);
            Console.WriteLine($"Total Score: {totalScore}");

            // 2. Practice Step Into (F11) & Autos / Watch Window
            // When you reach this line, press F11 to go INSIDE the CalculateAverage method.
            // You can add 'studentScores' or 'averageScore' to the Watch window to track their values.
            double averageScore = CalculateAverage(studentScores);
            Console.WriteLine($"Average Score: {averageScore}");

            // 3. Practice Call Stack & Step Out (Shift + F11)
            // Step Into (F11) this method, look at the Call Stack window to see how you got here.
            // Then press Shift+F11 to immediately finish it and step back out.
            string gradeReport = GenerateGradeReport(totalScore, averageScore);
            Console.WriteLine(gradeReport);
            
            Console.WriteLine("Debugging Practice Finished.");
        }

        private static int CalculateTotal(List<int> scores)
        {
            int total = 0;
            
            // INTENTIONAL BUG 1: Loop starts at 1, skipping the first score (85).
            // Watch 'i', 'total', and 'scores' in the Locals or Autos window to find the problem.
            for (int i = 1; i < scores.Count; i++)
            {
                total += scores[i]; 
            }
            return total;
        }

        private static double CalculateAverage(List<int> scores)
        {
            int total = CalculateTotal(scores);
            
            // INTENTIONAL BUG 2: Dividing by (scores.Count + 1) instead of scores.Count
            // INTENTIONAL BUG 3: Integer division. Because total and count are integers, the decimal part is truncated.
            double avg = total / (scores.Count + 1); 
            
            return avg;
        }

        private static string GenerateGradeReport(int totalScore, double averageScore)
        {
            // Step Into (F11) FormatReport, then press Shift+F11 (Step Out) to come back here.
            return FormatReport(totalScore, averageScore);
        }

        private static string FormatReport(int total, double avg)
        {
            string status;

            // INTENTIONAL BUG 4: Logical error. The conditions are swapped.
            if (avg < 50) 
            {
                status = "Excellent"; 
            }
            else
            {
                status = "Fail";      
            }

            return $"Student Status: {status} | Total: {total} | Average: {avg}";
        }
    }
}
