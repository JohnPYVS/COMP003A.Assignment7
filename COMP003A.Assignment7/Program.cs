using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace COMP003A.Assignment7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* This programs purpose is about having a menu for daily expense tracker that shows
             * the values, total, and average
             */
           // This is the Collection Declaration, which can store 5 expense values
            List<double> expenses = new List<double>();
            expenses.Add(13.50);
            expenses.Add(5.99);
            expenses.Add(12.25);
            expenses.Add(8.75);
            expenses.Add(20.10);

            // Menu
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("1. Display Values");
                Console.WriteLine("2. Show Total");
                Console.WriteLine("3. Show Average");
                Console.WriteLine("4 Exit");
                Console.WriteLine("Enter choice:");

                string choiceInput = Console.ReadLine();

                // Input Validation for the menu choices
                int choice;
                bool menu = int.TryParse(choiceInput, out choice);

                if (!menu || choice < 1 || choice > 5)
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
                    
                    Console.Write("Enter a new expense to add or press enter to skip: ");
                    string newExpenseInput = Console.ReadLine();
                    
                    if (newExpenseInput != "")
                    {   // Try catch block, which will handle the invalid inputs
                        try
                        {
                            double newExpense = Convert.ToDouble(newExpenseInput);
                            expenses.Add(newExpense);
                            Console.WriteLine("Added: " + newExpense);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid number entered. Nothing has been added");
                        }
                    }
                }
                else if (choice == 2)
                {
                    double total = 0;
                    foreach (double value in expenses)
                    {
                        total = total + value;
                    }
                    Console.WriteLine("Total: " + total);
                }
                else if (choice == 3)
                {
                    /* Part 6 Debugging
                     * I encounterd a bug where my average was wrong when the expenses had decimals
                     * This was because I used an int total which cut off the decimals 
                     * and it wasn't averaging the numbers anymore
                     */
                    double total = 0;  // I figured using the double total will keep the decimals

                    foreach (double value in expenses)
                    {
                        total = total + value;
                    }
                    double average = total / expenses.Count;
                    Console.WriteLine("Average: " + average);
                }
                else if (choice == 4)
                {
                    running = false;
                    Console.WriteLine("Program ended.");
                }
            }
        }
    }
}
