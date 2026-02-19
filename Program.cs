/*
 Program Title: Codac Logistics Fuel Monitoring Tool
 Developer: Sarina Mae A. Laurel
 Date: February 19, 2026

 Description:
 This console-based application tracks a delivery driver's weekly fuel
 expenses and delivery performance over a 5-day work week.
 It validates total distance input, calculates fuel efficiency,
 and generates a financial audit report for accounting.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        // ================================
        // TASK 1: DRIVER PROFILE & VALIDATION
        // ================================

        // string is used for text-based data like names
        string driverName;

        // decimal is used for money to avoid rounding errors
        decimal weeklyFuelBudget;

        // double is used for distance because it allows decimal values (e.g., 1523.75 km)
        double totalDistance = 0;

        Console.Write("Enter Driver Full Name: ");
        driverName = Console.ReadLine();

        Console.Write("Enter Weekly Fuel Budget: ");
        weeklyFuelBudget = decimal.Parse(Console.ReadLine());

        // while loop is used instead of if because we must repeatedly
        // ask the user until a valid distance is entered
        while (totalDistance < 1.0 || totalDistance > 5000.0)
        {
            Console.Write("Enter Total Distance Traveled (1 - 5000 km): ");
            totalDistance = double.Parse(Console.ReadLine());

            if (totalDistance < 1.0 || totalDistance > 5000.0)
            {
                Console.WriteLine("Invalid distance. Please enter a value between 1 and 5000.");
            }
        }

        // ================================
        // TASK 2: FUEL EXPENSE TRACKING
        // ================================

        // 1D array to store 5 days of fuel expenses
        decimal[] fuelExpenses = new decimal[5];

        // This variable accumulates total fuel spent
        decimal totalFuelSpent = 0;

        // for loop is used because we know exactly 5 days
        for (int i = 0; i < 5; i++)
        {
            // (i + 1) is used because array index starts at 0
            // but we want to display Day 1 instead of Day 0
            Console.Write($"Enter fuel expense for Day {i + 1}: ");
            fuelExpenses[i] = decimal.Parse(Console.ReadLine());

            // Add each day's expense to total
            totalFuelSpent += fuelExpenses[i];
        }

        // ================================
        // TASK 3: PERFORMANCE ANALYSIS
        // ================================

        // Calculate average daily expense
        decimal averageFuelExpense = totalFuelSpent / 5;

        // Cast decimal to double for proper division
        double fuelEfficiency = totalDistance / (double)totalFuelSpent;

        string efficiencyRating;

        // if/else is used for decision-making logic
        if (fuelEfficiency > 15)
        {
            efficiencyRating = "High Efficiency";
        }
        else if (fuelEfficiency >= 10)
        {
            efficiencyRating = "Standard Efficiency";
        }
        else
        {
            efficiencyRating = "Low Efficiency / Maintenance Required";
        }

        // bool stores true or false result
        bool isUnderBudget = totalFuelSpent <= weeklyFuelBudget;

        // ================================
        // TASK 4: AUDIT REPORT
        // ================================

        Console.WriteLine("\n===== WEEKLY AUDIT REPORT =====");
        Console.WriteLine($"Driver Name: {driverName}");
        Console.WriteLine($"\nWeekly Fuel Budget: {weeklyFuelBudget:C}");
        Console.WriteLine($"Total Distance Traveled: {totalDistance} km");

        Console.WriteLine("\nFuel Expense Breakdown:");

        // Reuse for loop to display breakdown
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Day {i + 1}: {fuelExpenses[i]:C}");
        }

        Console.WriteLine($"\nTotal Fuel Spent: {totalFuelSpent:C}");
        Console.WriteLine($"Average Daily Fuel Expense: {averageFuelExpense:C}");
        Console.WriteLine($"Fuel Efficiency: {fuelEfficiency:F2} km per unit");
        Console.WriteLine($"Efficiency Rating: {efficiencyRating}");
        Console.WriteLine($"Stayed Under Budget: {isUnderBudget}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
