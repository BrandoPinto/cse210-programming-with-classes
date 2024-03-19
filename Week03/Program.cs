using System;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private string reference;
        private string text;
        private bool[] hiddenWords;

        private Random random = new Random();

        public Scripture(string reference, string text)
        {
            this.reference = reference;
            this.text = text;
            hiddenWords = new bool[text.Split(' ').Length];
        }

        public void Display()
        {
            Console.WriteLine(reference);

            string[] words = text.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                if (hiddenWords[i])
                {
                    Console.Write("_ ");
                }
                else
                {
                    Console.Write(words[i] + " ");
                }
            }

            Console.WriteLine();
        }

        public bool HideRandomWord()
        {
            bool allWordsHidden = true;

            for (int i = 0; i < hiddenWords.Length; i++)
            {
                if (!hiddenWords[i])
                {
                    allWordsHidden = false;
                    break;
                }
            }

            if (allWordsHidden)
            {
                return true;
            }

            int index;
            do
            {
                index = random.Next(hiddenWords.Length);
            } while (hiddenWords[index]);

            hiddenWords[index] = true;
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture("John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

            Console.WriteLine("Welcome to Scripture Memorizer!");
            Console.WriteLine("The scripture to memorize is:");
            scripture.Display();
            Console.WriteLine();

            bool allWordsHidden = false;

            while (!allWordsHidden)
            {
                Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                    break;

                Console.Clear();

                allWordsHidden = scripture.HideRandomWord();
                scripture.Display();
                Console.WriteLine();
            }

            Console.WriteLine("All words in the scripture are now hidden. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}