using System;
using System.Collections.Generic;

namespace COMP003A.Assignment7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> expenses = new List<double>();
            expenses.Add(13.50);
            expenses.Add(5.99);
            expenses.Add(12.25);
            expenses.Add(8.75);
            expenses.Add(20.10);

            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("1. Display Values");
                Console.WriteLine("2. Show Total");
                Console.WriteLine("3. Show Average");
                Console.WriteLine("4 Update an Expense");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter choice: ");

                string choiceInput = Console.ReadLine();

                int choice;
                bool menu = int.TryParse(choiceInput, out choice);

                if(!menu || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid menu choice. Enter a number 1-5.");
                }
                else if (choice == 1)
                {
                    Console.WriteLine();
                    Console.WriteLine("Values:");
                    for (int i = 0; i < expenses.Count; i++)
                    {
                        Console.WriteLine(expenses[i]);
                    }
                }
                else if (choice == 2)
                {
                    double total = 0.0;
                    foreach (double value in expenses) 
                    {
                        total = total + value;
                    }
                    Console.WriteLine("Total: " + total);
                }
                else if (choice == 3)
                {
                    // Part 6 Debugging
                    // I encounterd a bug where my average was wrong when the expenses had decimals
                    // This was because I used an int total which cut off the decimals 
                    // and it wasn't averaging the numbers anymore
                    int total = 0;  // This is the bug that removes the decimals, the answer
                                    // I got was 11.6 when it was supposed to be 12.118
                    foreach (double value in expenses)
                    {
                        total = total + (int)value;
                    }
                    double average = (double)total / expenses.Count;
                    Console.WriteLine("Average: " + average);
                }
            }
        }
    }
}
