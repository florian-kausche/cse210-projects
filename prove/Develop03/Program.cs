using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask for user's name
            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();

            // Initialize a library of scriptures
            List<Scripture> scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
                new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
                new Scripture(new Reference("Philippians", 4, 13), "I can do all this through him who gives me strength."),
                new Scripture(new Reference("Psalm", 23, 1, 4), "The Lord is my shepherd, I lack nothing. He makes me lie down in green pastures, he leads me beside quiet waters, he refreshes my soul. He guides me along the right paths for his name’s sake. Even though I walk through the darkest valley, I will fear no evil, for you are with me; your rod and your staff, they comfort me."),
                new Scripture(new Reference("Romans", 8, 28), "And we know that in all things God works for the good of those who love him, who have been called according to his purpose."),
                new Scripture(new Reference("Jeremiah", 29, 11), "For I know the plans I have for you, declares the Lord, plans to prosper you and not to harm you, plans to give you hope and a future.")
            };

            // Select a random scripture from the library
            Random random = new Random();
            Scripture scripture = scriptures[random.Next(scriptures.Count)];

            while (true)
            {
                ClearConsole();

                Console.WriteLine(scripture.Display());

                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                {
                    break;
                }

                scripture.HideRandomWords();
                if (scripture.IsFullyHidden())
                {
                    ClearConsole();
                    Console.WriteLine($"Congratulations {userName}! You have fully memorized the scripture!");
                    break;
                }
            }
        }

        static void ClearConsole()
        {
            // Clearing the console in a try-catch block to avoid IOException
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
                // Handling the case where Console.Clear() fails
                Console.WriteLine("\nConsole.Clear() failed. Continuing without clearing the console...\n");
            }
        }
    }

    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public override string ToString()
        {
            return _isHidden ? "_____" : _text;
        }
    }

    class Reference
    {
        public string Book { get; }
        public int Chapter { get; }
        public int StartVerse { get; }
        public int EndVerse { get; }

        public Reference(string book, int chapter, int startVerse, int endVerse = -1)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse == -1 ? startVerse : endVerse;
        }

        public override string ToString()
        {
            return $"{Book} {Chapter}:{StartVerse}" + (StartVerse != EndVerse ? $"-{EndVerse}" : "");
        }
    }

    class Scripture
    {
        private Reference _reference;
        private List<Word> _words;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(word => new Word(word)).ToList();
        }

        public void HideRandomWords()
        {
            Random random = new Random();
            int wordsToHide = random.Next(1, Math.Max(1, _words.Count / 10));

            for (int i = 0; i < wordsToHide; i++)
            {
                var wordsToChooseFrom = _words.Where(word => !word.ToString().Equals("_____")).ToList();
                if (wordsToChooseFrom.Count == 0)
                {
                    break;
                }
                wordsToChooseFrom[random.Next(wordsToChooseFrom.Count)].Hide();
            }
        }

        public bool IsFullyHidden()
        {
            return _words.All(word => word.ToString().Equals("_____"));
        }

        public string Display()
        {
            return $"{_reference}\n\n" + string.Join(" ", _words);
        }
    }
}
