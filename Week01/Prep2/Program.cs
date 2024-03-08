using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the percentage grade:");
        string input = Console.ReadLine();

        int percentage;
        if (!int.TryParse(input, out percentage))
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
            return;
        }

        string letter;
        string sign = "";

        if (percentage >= 90)
        {
            letter = "A";
            if (percentage >= 97)
                sign = "+";
            else if (percentage <= 93)
                sign = "-";
        }
        else if (percentage >= 80)
        {
            letter = "B";
            if (percentage >= 87)
                sign = "+";
            else if (percentage <= 83)
                sign = "-";
        }
        else if (percentage >= 70)
        {
            letter = "C";
            if (percentage >= 77)
                sign = "+";
            else if (percentage <= 73)
                sign = "-";
        }
        else if (percentage >= 60)
        {
            letter = "D";
            if (percentage >= 67)
                sign = "+";
            else if (percentage <= 63)
                sign = "-";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Grade: {letter}{sign}");

        if (letter != "F")
        {
            Console.WriteLine("Congratulations, you have passed the course!");
        }
        else
        {
            Console.WriteLine("Better luck next time.");
        }

        Console.ReadLine();
    }
}