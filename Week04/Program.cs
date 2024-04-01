using System;
using System.Collections.Generic;
using System.Threading;

namespace ProgramWithClasses
{
    // Base Activity class that contains common attributes and behaviors
    public abstract class Activity
    {
        protected string name;
        protected string description;
        protected int duration;

        public Activity(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public abstract void Start();

        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
            }
        }

        public void Finish()
        {
            Console.WriteLine("\nGreat job!");
            Console.WriteLine($"You have completed the {name} activity.");
            Console.WriteLine($"Duration: {duration} seconds.");
            Console.WriteLine("Pausing for a few seconds...");
            Thread.Sleep(3000);
        }
    }

    // Breathing activity class
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing", "This activity will help you relax by focusing on your breath.")
        {
        }

        public override void Start()
        {
            Console.WriteLine(description);
            Console.Write("Enter the duration of the activity (in seconds): ");
            duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Get ready to start...");
            Thread.Sleep(2000);

            Console.WriteLine("Starting activity...\n");

            for (int i = 0; i < duration; i += 2)
            {
                ShowMessage("Breathe in...");
                ShowCountdown(2);

                ShowMessage("Breathe out...");
                ShowCountdown(2);
            }

            Finish();
        }
    }

    // Reflection activity class
    public class ReflectionActivity : Activity
    {
        private List<string> prompts = new List<string>()
        {
            "Think about a time when you stood up for someone else.",
            "Think about a time when you did something really challenging.",
            "Think about a time when you helped someone in need.",
            "Think about a time when you did something truly selfless."
        };

        private List<string> questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "Have you ever done something like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different from other times when you weren't as successful?",
            "What is your favorite thing about this experience?",
            "What can you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you take this experience into account in the future?"
        };

        public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you showed strength and resilience.")
        {
        }

        public override void Start()
        {
            Console.WriteLine(description);
            Console.Write("Enter the duration of the activity (in seconds): ");
            duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Get ready to start...");
            Thread.Sleep(2000);

            Console.WriteLine("Starting activity...\n");

            Random random = new Random();

            for (int i = 0; i < duration; i += 5)
            {
                string prompt = prompts[random.Next(prompts.Count)];
                ShowMessage(prompt);

                Thread.Sleep(2000);

                foreach (string question in questions)
                {
                    ShowMessage(question);
                    ShowCountdown(3);
                }
            }

            Finish();
        }
    }

    // Listing activity class
    public class ListingActivity : Activity
    {
        private List<string> prompts = new List<string>()
        {
            "Who are the people you appreciate?",
            "What are your personal strengths?",
            "Who are the people you have helped this week?",
            "When have you felt the Holy Spirit this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many items as you can in a given area.")
        {
        }

        public override void Start()
        {
            Console.WriteLine(description);
             Console.Write("Enter the duration of the activity (in seconds): ");
            duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Get ready to start...");
            Thread.Sleep(2000);

            Console.WriteLine("Starting activity...\n");

            Random random = new Random();
            string prompt = prompts[random.Next(prompts.Count)];
            ShowMessage(prompt);

            Thread.Sleep(2000);
        
            List<string> items = new List<string>();

            while (duration > 0)
            {
                Console.Write("Enter an item: ");
                string item = Console.ReadLine();
                items.Add(item);
                duration -= 5;
            }

            Console.WriteLine("\nActivity complete! Here's your list of items:");
            foreach (string item in items)
            {
                Console.WriteLine("- " + item);
            }

            Finish();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Activity Program!");

            while (true)
            {
                Console.WriteLine("\nPlease select an activity:");
                Console.WriteLine("1. Breathing");
                Console.WriteLine("2. Reflection");
                Console.WriteLine("3. Listing");
                Console.WriteLine("4. Exit");

                Console.Write("\nEnter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                Activity activity;

                switch (choice)
                {
                    case 1:
                        activity = new BreathingActivity();
                        break;
                    case 2:
                        activity = new ReflectionActivity();
                        break;
                    case 3:
                        activity = new ListingActivity();
                        break;
                    case 4:
                        Console.WriteLine("\nThank you for using the Activity Program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        continue;
                }

                activity.Start();
            }
        }
    }
}