using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        BreathingActivity breathingActivity = new BreathingActivity();
        ReflectingActivity reflectingActivity = new ReflectingActivity();
        ListingActivity listingActivity = new ListingActivity();

        List<Activity> activities = new List<Activity> { breathingActivity, reflectingActivity, listingActivity };

        while (true)
        {
            try
            {
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Exercise");
                Console.WriteLine("2. Reflecting Exercise");
                Console.WriteLine("3. Listing Exercise");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        breathingActivity.Run();
                        break;
                    case "2":
                        reflectingActivity.Run();
                        break;
                    case "3":
                        listingActivity.Run();
                        break;
                    case "4":
                        Console.WriteLine("Exiting the program...");
                        Console.WriteLine("Thank you for using the app!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please choose again.");
                        break;
                }

                Console.WriteLine(new string('-', 50));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
