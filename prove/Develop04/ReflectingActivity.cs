using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> Prompts { get; set; }
    private List<string> Questions { get; set; }

    public ReflectingActivity()
        : base("Reflecting Exercise", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        Questions = new List<string>
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
    }

    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(Prompts.Count);
        return Prompts[index];
    }

    private string GetRandomQuestion()
    {
        Random random = new Random();
        int index = random.Next(Questions.Count);
        return Questions[index];
    }

    public override void Run()
    {
        try
        {
            DisplayStartMessage();
            string prompt = GetRandomPrompt();
            Console.WriteLine($"Reflect on the following: {prompt}");
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.WriteLine(question);
                ShowCountdown(3);
            }
            DisplayEndMessage();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during the reflecting exercise: {ex.Message}");
        }
    }
}
