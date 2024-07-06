using System;
using System.Threading;

public abstract class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void GetDuration()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter the duration in seconds: ");
                Duration = int.Parse(Console.ReadLine());
                if (Duration <= 0)
                {
                    throw new ArgumentOutOfRangeException("Duration must be a positive integer.");
                }
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"\nStarting {Name}. {Description}");
        GetDuration();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine($"Ending {Name}. Well done!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        ShowSpinner(3);
    }

    public abstract void Run();

    public void ShowSpinner(int seconds)
    {
        string[] spinnerChars = { "/", "-", "\\", "|" };
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write(spinnerChars[i % 4]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
    }

    public void ShowBreathingAnimation(bool isInhale, int seconds)
    {
        string message = isInhale ? "Breathe in..." : "Breathe out...";
        Console.WriteLine(message);
        ShowCountdown(seconds);
    }
}
