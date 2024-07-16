using System;

class Program
{
    static void Main(string[] args)
    {
        QuestProgram quest = new QuestProgram();

        while (true)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(quest);
                    break;
                case "2":
                    quest.ListGoals();
                    break;
                case "3":
                    // TODO: Implement save functionality
                    break;
                case "4":
                    // TODO: Implement load functionality
                    break;
                case "5":
                    RecordEvent(quest);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal(QuestProgram quest)
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string goalType = Console.ReadLine();
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int value = int.Parse(Console.ReadLine());

        Goal newGoal;

        switch (goalType)
        {
            case "1":
                newGoal = new SimpleGoal(name, value);
                break;
            case "2":
                newGoal = new EternalGoal(name, value);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, value, targetCount, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        quest.AddGoal(newGoal);
        Console.WriteLine("Goal created successfully!");
    }

    static void RecordEvent(QuestProgram quest)
    {
        Console.WriteLine("The goals are:");
        quest.ListGoals();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        quest.RecordEvent(goalIndex);
    }
}