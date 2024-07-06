using System;

public class BreathingActivity : Activity
{
    public int InhaleDuration { get; set; }
    public int ExhaleDuration { get; set; }

    public BreathingActivity()
        : base("Breathing Exercise", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        InhaleDuration = 4;
        ExhaleDuration = 4;
    }

    public override void Run()
    {
        try
        {
            DisplayStartMessage();
            for (int i = 0; i < Duration / (InhaleDuration + ExhaleDuration); i++)
            {
                ShowBreathingAnimation(true, InhaleDuration);
                ShowBreathingAnimation(false, ExhaleDuration);
            }
            DisplayEndMessage();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during the breathing exercise: {ex.Message}");
        }
    }
}
