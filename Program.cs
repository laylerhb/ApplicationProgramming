// See https://aka.ms/new-console-template for more information

using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Prompt the user to input their name and birthdate.
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            string birthdateInput;
            DateTime birthdate;

            // Step 2: Validate the birthdate format using a regular expression (MM/dd/yyyy).
            do
            {
                Console.Write("Enter your birthdate (MM/dd/yyyy): ");
                birthdateInput = Console.ReadLine();

                if (!Regex.IsMatch(birthdateInput, @"^(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}$"))
                {
                    Console.WriteLine("Invalid date format. Please use MM/dd/yyyy.");
                }
                else if (!DateTime.TryParseExact(birthdateInput, "MM/dd/yyyy", null, DateTimeStyles.None, out birthdate))
                {
                    Console.WriteLine("Invalid date. Please enter a valid birthdate.");
                }
                else
                {
                    break;
                }
            } while (true);

            // Step 3: Calculate and display the user's age.
            int age = DateTime.Now.Year - birthdate.Year;
            if (DateTime.Now < birthdate.AddYears(age)) age--; // Adjust age if the birthday hasn't occurred yet this year.
            Console.WriteLine($"Hello, {name}! You are {age} years old.");

            // Step 4: Save the user's information to a file named "userinfo.txt".
            string filePath = "userinfo.txt";
            File.WriteAllText(filePath, $"Name: {name}\nBirthdate: {birthdateInput}\nAge: {age}");

            // Step 5: Read and display the contents of the "userinfo.txt" file.
            Console.WriteLine("\nSaved user information:");
            Console.WriteLine(File.ReadAllText(filePath));

            // Step 6: Prompt the user to enter a directory path.
            Console.Write("\nEnter a directory path to list all files: ");
            string directoryPath = Console.ReadLine();

            // Step 7: List all files within the specified directory.
            if (Directory.Exists(directoryPath))
            {
                string[] files = Directory.GetFiles(directoryPath);
                Console.WriteLine("\nFiles in directory:");
                foreach (var file in files)
                {
                    Console.WriteLine(file);
                }
            }
            else
            {
                Console.WriteLine("Directory not found.");
            }

            // Step 8: Prompt the user to input a string.
            Console.Write("\nEnter a string to format as title case: ");
            string inputString = Console.ReadLine();

            // Step 9: Format the string to title case.
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string titleCaseString = textInfo.ToTitleCase(inputString.ToLower());
            Console.WriteLine($"Formatted string (Title Case): {titleCaseString}");

            // Step 10: Explicitly trigger garbage collection.
            Console.WriteLine("\nForcing garbage collection...");
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Console.WriteLine("Garbage collection completed.");
        }
    }
}
        
                  