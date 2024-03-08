using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("What is your first name?");
        string? firstName = Console.ReadLine();

        Console.WriteLine("What is your last name?");
        string? lastName = Console.ReadLine();

        string fullName = $"{lastName}, {firstName} {lastName}";

        Console.WriteLine($"Your name is {fullName}.");

        Console.ReadLine();
    }
}