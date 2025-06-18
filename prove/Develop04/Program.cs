using activity;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start stretching activity");
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");
            
            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new StretchingActivity();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }

            activity.Start();
        }
    }
}