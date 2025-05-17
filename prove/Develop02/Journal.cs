using System.IO; 

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What are you grateful for today?",
        "What did you learn today?",
        "What did you accomplish today?",
        "If I could do one thing differently today, what would it be?"
    };

    public void Run()
    {
        Load();
        while (true)
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
                case 1:
                    Write();
                    break;
                case 2:
                    Display();
                    break;
                case 3:
                    Load();
                    break;
                case 4:
                    Save();
                    break;
                case 5:
                    Save();
                    return;
                default:
                    break;
            }
        }
    }

    public void Write()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();
        DateTime theCurrentTime = DateTime.Now;
        string dateText = theCurrentTime.ToShortDateString();
        Entry entry = new Entry(dateText, prompt, response);
        _entries.Add(entry);
    }

    public void Display()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date: {entry.dateText} - Prompt: {entry.promptText}");
            Console.WriteLine(entry.responseText);
            Console.WriteLine();
        }
    }

    public void Save()
    {
        using (StreamWriter outputFile = new StreamWriter("journal.txt"))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry.dateText}|{entry.promptText}|{entry.responseText}");
            }
        }
    }

    public void Load()
    {
        string[] lines = System.IO.File.ReadAllLines("journal.txt");

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            string dateText = parts[0];
            string promptText = parts[1];
            string responseText = parts[2];
            Entry entry = new Entry(dateText, promptText, responseText);
            _entries.Add(entry);
        }
    }
}