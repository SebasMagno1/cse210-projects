using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    // Base class for all activities
    abstract class Activity
    {
        private string _name;
        private string _description;
        private int _duration; // duration in seconds

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void StartActivity()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name}!");
            Console.WriteLine(_description);
            Console.Write("Enter duration of the activity in seconds: ");
            _duration = int.Parse(Console.ReadLine() ?? "30");
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
            RunActivity();
            EndActivity();
        }

        protected abstract void RunActivity(); // implemented by derived classes

        private void EndActivity()
        {
            Console.WriteLine("\nWell done!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed the activity: {_name} for {_duration} seconds.\n");
            Thread.Sleep(2000);
        }

        // Utility: spinner animation
        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            for (int i = 0; i < seconds * 4; i++)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(250);
                Console.Write("\b");
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected int Duration => _duration;
    }

    class BreathingActivity : Activity
    {
        public BreathingActivity() 
            : base("Breathing Activity", 
                  "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") 
        { }

        protected override void RunActivity()
        {
            int elapsed = 0;
            while (elapsed < Duration)
            {
                Console.WriteLine("\nBreathe in...");
                Countdown(4);
                elapsed += 4;

                if (elapsed >= Duration) break;

                Console.WriteLine("Breathe out...");
                Countdown(6);
                elapsed += 6;
            }
        }
    }

    class ReflectionActivity : Activity
    {
        private readonly List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private readonly List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
            : base("Reflection Activity", 
                  "This activity will help you reflect on times in your life when you have shown strength and resilience.") { }

        protected override void RunActivity()
        {
            Random rnd = new Random();
            string prompt = prompts[rnd.Next(prompts.Count)];
            Console.WriteLine("\n" + prompt);
            ShowSpinner(3);

            int elapsed = 0;
            while (elapsed < Duration)
            {
                string question = questions[rnd.Next(questions.Count)];
                Console.WriteLine(question);
                ShowSpinner(4);
                elapsed += 4;
            }
        }
    }

    class ListingActivity : Activity
    {
        private readonly List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity", 
                  "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

        protected override void RunActivity()
        {
            Random rnd = new Random();
            string prompt = prompts[rnd.Next(prompts.Count)];
            Console.WriteLine("\n" + prompt);
            Console.WriteLine("Get ready...");
            Countdown(5);

            int elapsed = 0;
            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                    items.Add(input);
            }
            Console.WriteLine($"\nYou listed {items.Count} items!");
        }
    }

    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

                Activity? activity = choice switch
                {
                    "1" => new BreathingActivity(),
                    "2" => new ReflectionActivity(),
                    "3" => new ListingActivity(),
                    "4" => null,
                    _ => null
                };

                if (choice == "4") break;

                if (activity != null)
                    activity.StartActivity();
                else
                    Console.WriteLine("Invalid choice. Try again.");
            }
        }
    }
}