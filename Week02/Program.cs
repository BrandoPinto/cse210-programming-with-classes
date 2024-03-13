using System;
using System.Collections.Generic;
using System.IO;
//Week 02 Develop: Journal Program
class Entry
{
    public string Prompt { get; set; } // Prompt for the journal entry
    public string Response { get; set; } // Response for the journal entry
    public DateTime Date { get; set; } // Date and time of the journal entry
}

class Journal
{
    private List<Entry> entries; // List to store journal entries

    public Journal()
    {
        entries = new List<Entry>(); // Initialize the list of entries
    }

    public void AddEntry(string prompt, string response)
    {
        Entry entry = new Entry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        };

        entries.Add(entry); // Add the new entry to the list
    }

    public List<Entry> GetEntries()
    {
        return entries; // Return the list of entries
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string fileName)
    {
        entries.Clear(); // Clear the existing entries list

        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3 && DateTime.TryParse(parts[0], out DateTime date))
                {
                    Entry entry = new Entry
                    {
                        Date = date,
                        Prompt = parts[1],
                        Response = parts[2]
                    };
                    entries.Add(entry); // Add the loaded entry to the list
                }
            }
        }

        Console.WriteLine("Journal loaded successfully.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal(); // Create a new journal object

        string[] prompts = {
            "Who was the most interesting person you interacted with today?",
            "What was the best part of your day?",
            "How did you see God's hand in your life today?",
            "What was the strongest emotion you felt today?",
            "If you could do one thing today, what would it be?"
        };

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Add new entry");
            Console.WriteLine("2. Show all entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": // Add new entry
                    int randomIndex = new Random().Next(prompts.Length); // Select a random prompt
                    string prompt = prompts[randomIndex];
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    journal.AddEntry(prompt, response); // Add the new entry to the journal
                    Console.WriteLine("Entry added successfully.");
                    Console.WriteLine();
                    break;
                case "2": // Show all entries
                    List<Entry> entries = journal.GetEntries(); // Get the list of entries
                    Console.WriteLine("Journal Entries:");
                    foreach (Entry entry in entries)
                    {
                        Console.WriteLine($"Date: {entry.Date}");
                        Console.WriteLine($"Prompt: {entry.Prompt}");
                        Console.WriteLine($"Response: {entry.Response}");
                        Console.WriteLine();
                    }
                    break;
                case "3": // Save journal to file
                    Console.Write("Enter file name to save journal: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName); // Save the journal to a file
                    Console.WriteLine();
                    break;
                case "4": // Load journal from file
                    Console.Write("Enter file name to load journal: ");
                    string loadFileName = Console.ReadLine();
                    journal.LoadFromFile(loadFileName); // Load the journal from a file
                    Console.WriteLine();
                    break;
                case "5": // Exit the program
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }

        Console.WriteLine("Exiting the program. Goodbye!");
    }
}