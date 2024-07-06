using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> Prompts { get; set; }

    public ListingActivity()
        : base("Listing Exercise", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        Prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(Prompts.Count);
        return Prompts[index];
    }

    public override void Run()
    {
        try
        {
            DisplayStartMessage();
            string prompt = GetRandomPrompt();
            Console.WriteLine($"List as many items as you can for the following: {prompt}");
            ShowCountdown(3);
            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                string item = Console.ReadLine();
                items.Add(item);
            }
            Console.WriteLine($"You listed {items.Count} items.");
            DisplayEndMessage();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during the listing exercise: {ex.Message}");
        }
    }
}
