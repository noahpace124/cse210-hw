using System;
using Journal;

class Program
{
    static void Main(string[] args)
    {
        List<Entry> entries = new List<Entry>();

        string[] prompts = new string[] { "What's one thing I did today?", "Did I hang out with anybody today?", "What did I accomplish today?", "What am I grateful for today?", "What do I need to work on?" };

        bool loop = true;
        while(loop) 
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1: //Write
                    Random rand = new Random();
                    int randomPrompt = rand.Next(prompts.Length);
                    Console.WriteLine(prompts[randomPrompt]);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    Journal.Entry curEntry = new Journal.Entry(DateTime.Now.ToString("MM/dd/yyyy"), prompts[randomPrompt], response);
                    entries.Add(curEntry);
                    break;
                case 2:
                    for (int i = 0; i < entries.Count; i++)
                    {
                        Console.WriteLine($"Date: {entries[i].Date} - Prompt: {entries[i].Prompt}");
                        Console.WriteLine($"{entries[i].Response}");
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    Console.Write("What is the filename: ");
                    string loadFilename = Console.ReadLine();
                    if (File.Exists(loadFilename))
                    {
                        entries.Clear();
                        string[] lines = File.ReadAllLines(loadFilename);
                        foreach (string line in lines)
                        {
                            string[] parts = line.Split('|');
                            if (parts.Length == 3)
                            {
                                string date = parts[0];
                                string prompt = parts[1];
                                string answer = parts[2];
                                entries.Add(new Journal.Entry(date, prompt, answer));
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("File not found.");
                    }
                    break;
                case 4:
                    Console.Write("What is the filename: ");
                    string filename = Console.ReadLine();
                    using (StreamWriter writer = new StreamWriter(filename))
                    {
                        foreach (var entry in entries)
                        {
                            writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                        }
                    }
                    break;
                case 5:
                    loop = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}