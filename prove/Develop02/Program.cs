using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    // JournalEntry Class
    public class JournalEntry
    {
        public string Date { get; set; }
        public string Prompt { get; set; }
        public string Response { get; set; }

        public JournalEntry(string prompt, string response)
        {
            Date = DateTime.Now.ToShortDateString();
            Prompt = prompt;
            Response = response;
        }

        public override string ToString()
        {
            return $"{Date}|{Prompt}|{Response}";
        }
    }

    // Journal Class
    public class Journal
    {
        public List<JournalEntry> Entries { get; set; }

        public Journal()
        {
            Entries = new List<JournalEntry>();
        }

        public void AddEntry(string prompt, string response)
        {
            Entries.Add(new JournalEntry(prompt, response));
        }

        public void DisplayEntries()
        {
            foreach (var entry in Entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }

        public void SaveToFile(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (var entry in Entries)
                {
                    outputFile.WriteLine(entry.ToString());
                }
            }
        }

        public void LoadFromFile(string filename)
        {
            Entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    Entries.Add(new JournalEntry(prompt, response) { Date = date });
                }
            }
        }
    }

    // Program Class
    class Program
    {
        static List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        static void DisplayMenu()
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Select an option: ");
        }

        static string GetPrompt()
        {
            Random random = new Random();
            int index = random.Next(prompts.Count);
            return prompts[index];
        }

        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = GetPrompt();
                        Console.WriteLine(prompt);
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();
                        journal.AddEntry(prompt, response);
                        break;
                    case "2":
                        journal.DisplayEntries();
                        break;
                    case "3":
                        Console.Write("Enter filename to save to: ");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;
                    case "4":
                        Console.Write("Enter filename to load from: ");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}

    
    
