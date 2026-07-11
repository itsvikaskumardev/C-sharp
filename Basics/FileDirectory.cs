using System;
using System.IO;

namespace C_
{
    internal class FileDirectory
    {
        public static void Run()
        {
            Console.WriteLine("--------------- File and FileInfo ----------------");

            // File: Provides static methods for working with files.
            // FileInfo: Provides instance methods for working with files.

            string sourceFile = @"C:\Temp\myfile.txt";
            string copyFile = @"C:\Temp\myfile-copy.txt";

            // Check if a file exists
            Console.WriteLine($"File Exists: {File.Exists(sourceFile)}");

            // Copy a file
            // File.Copy(sourceFile, copyFile, true);

            // Move a file
            // File.Move(copyFile, @"C:\Temp\moved-file.txt");

            // Delete a file
            // File.Delete(copyFile);

            // Read all text from a file
            // string text = File.ReadAllText(sourceFile);
            // Console.WriteLine(text);

            Console.WriteLine();

            Console.WriteLine("--------------- FileInfo ----------------");

            var fileInfo = new FileInfo(sourceFile);

            Console.WriteLine($"Name: {fileInfo.Name}");
            Console.WriteLine($"Extension: {fileInfo.Extension}");

            Console.WriteLine();

            Console.WriteLine("--------------- Directory and DirectoryInfo ----------------");

            // Directory: Provides static methods.
            // DirectoryInfo: Provides instance methods.

            string directoryPath = @"C:\Temp";

            Console.WriteLine($"Directory Exists: {Directory.Exists(directoryPath)}");

            // Create a directory
            // Directory.CreateDirectory(@"C:\Temp\Test");

            // Get current directory
            Console.WriteLine($"Current Directory: {Directory.GetCurrentDirectory()}");

            // Get all logical drives
            foreach (var drive in Directory.GetLogicalDrives())
            {
                Console.WriteLine(drive);
            }

            // Get files in a directory
            // var files = Directory.GetFiles(directoryPath);
            // foreach (var file in files)
            // {
            //     Console.WriteLine(file);
            // }

            Console.WriteLine();

            Console.WriteLine("--------------- Path ----------------");

            string path = @"C:\Temp\myfile.txt";

            Console.WriteLine($"Directory Name : {Path.GetDirectoryName(path)}");
            Console.WriteLine($"File Name      : {Path.GetFileName(path)}");
            Console.WriteLine($"Extension      : {Path.GetExtension(path)}");
            Console.WriteLine($"Temp Path      : {Path.GetTempPath()}");
        }
    }
}