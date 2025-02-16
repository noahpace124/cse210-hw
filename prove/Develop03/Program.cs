using System;
using scripture;
using verse_word;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>();

        //Load all premade scriptures
        if (File.Exists("Scriptures.txt"))
        {
            using (StreamReader reader = new StreamReader("Scriptures.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new[] { ", " }, StringSplitOptions.None);
                    string book = parts[0].Split(':')[1].Trim();
                    int chapter = int.Parse(parts[1].Split(':')[1].Trim());
                    int startVerse = int.Parse(parts[2].Split(':')[1].Split('-')[0].Trim());
                    int count = int.Parse(parts[3].Split(':')[1].Trim());

                    List<List<Verse_Word>> verses = new List<List<Verse_Word>>();
                    for (int i = 0; i < count; i++)
                    {
                        string verseText = reader.ReadLine();
                        string[] rawWords = verseText.Split(' ');

                        List<Verse_Word> verseWords = new List<Verse_Word>();
                        foreach (var word in rawWords)
                        {
                            string wordText = word;
                            string punctuation = "";

                            if (char.IsPunctuation(word[^1]))
                            {
                                wordText = word.Substring(0, word.Length - 1);
                                punctuation = word[^1].ToString();
                            }

                            verseWords.Add(new Verse_Word(wordText, punctuation));
                        }

                        verses.Add(verseWords);
                    }

                    scriptures.Add(new Scripture(book, chapter, startVerse, count, verses));
                }
            }
        }

        Console.Clear();
        Scripture currentScripture = null;
        Console.WriteLine("Would you like to create a new scripture?");
        string answer = Console.ReadLine();
        if (answer == "yes")
        {
            Console.Write("What book is your scripture? ");
            string book = Console.ReadLine();
            Console.Write("What chapter is your scripture? ");
            int chapter = int.Parse(Console.ReadLine());
            Console.Write("What verse does your scripture start in? ");
            int verse = int.Parse(Console.ReadLine());
            Console.Write("How many verses are in your scripture? ");
            int count = int.Parse(Console.ReadLine());

            List<List<Verse_Word>> verses = new List<List<Verse_Word>>();

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter verse {verse + i} text: ");
                string rawText = Console.ReadLine();

                string[] rawWords = rawText.Split(' ');

                List<Verse_Word> verseWords = new List<Verse_Word>();

                foreach (var word in rawWords)
                {
                    string wordText = word;
                    string punctuation = "";

                    if (char.IsPunctuation(word[^1]))
                    {
                        wordText = word.Substring(0, word.Length - 1);
                        punctuation = word[^1].ToString();
                    }

                    verseWords.Add(new Verse_Word(wordText, punctuation));
                }

                verses.Add(verseWords);
            }

            currentScripture = new Scripture(book, chapter, verse, count, verses);

            scriptures.Add(currentScripture);

            //save the new scripture
            using (StreamWriter writer = new StreamWriter("Scriptures.txt", false))
            {
                foreach (var scripture in scriptures)
                {
                    writer.WriteLine(scripture);
                }
            }
        }
        else
        {
            var random = new Random();
            if (scriptures.Count > 0)
            {
                int randomIndex = random.Next(scriptures.Count);
                currentScripture = scriptures[randomIndex];
            }
            else
            {
                Console.WriteLine("No scriptures available. Please create a new scripture.");
                return;
            }
        }

        //Start the Program
        do
        {
            Console.Clear();
            Console.WriteLine(currentScripture.GetScripture());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue or type 'quit' to finish: ");
            string response = Console.ReadLine().Trim();
            if (response == "quit")
            {
                break;
            }
            else
            {

            }
        } while (currentScripture.HideWords());
    }
}

