using System;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int points = 0;
        int level = 1;
        int level_next = 100;
        while (true)
        {
            //LEVEL UP
            while (points > level_next)
            {
                level++;
                Console.WriteLine("Congratulations! You have leveled up!");
                level_next = level_next + 200 * (level - 1);
            }
            //START
            Console.WriteLine();
            Console.WriteLine("You are level " + level + ".");
            Console.WriteLine("You have " + points + " points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine("  1. Simple Goal");
                Console.WriteLine("  2. Eternal Goal");
                Console.WriteLine("  3. Checklist Goal");
                Console.Write("Which type of goal would you like to create? ");
                choice = Console.ReadLine();
                if (choice == "1")
                {
                    SimpleGoal simpleGoal = new SimpleGoal();
                    goals.Add(simpleGoal);
                }
                else if (choice == "2")
                {
                    EternalGoal eternalGoal = new EternalGoal();
                    goals.Add(eternalGoal);
                }
                else if (choice == "3")
                {
                    ChecklistGoal checklistGoal = new ChecklistGoal();
                    goals.Add(checklistGoal);
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("The goals are:");
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goals[i].GetGoal()}");
                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("What is the filename for the goal file? ");
                string filename = Console.ReadLine();
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    foreach (Goal goal in goals)
                    {
                        writer.WriteLine(goal.GetStringRepresentation());
                    }
                }
            }
            else if (choice == "4")
            {
                Console.WriteLine("What is the filename for the goal file? ");
                string filename = Console.ReadLine();
                using (StreamReader reader = new StreamReader(filename))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts[0] == "SimpleGoal")
                        {
                            SimpleGoal simpleGoal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                            goals.Add(simpleGoal);
                            if (parts[4] == "True")
                            {
                                points += int.Parse(parts[3]);
                            }
                        }
                        else if (parts[0] == "EternalGoal")
                        {
                            EternalGoal eternalGoal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                            goals.Add(eternalGoal);
                            if (parts[4] == "True")
                            {
                                points += int.Parse(parts[3]);
                            }
                        }
                        else if (parts[0] == "ChecklistGoal")
                        {
                            ChecklistGoal checklistGoal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]), int.Parse(parts[7]));
                            goals.Add(checklistGoal);
                            points += int.Parse(parts[3]) * int.Parse(parts[7]);
                            if (parts[4] == "True")
                            {
                                points += int.Parse(parts[6]);
                            }
                        }
                    }
                }
                while (points > level_next)
                {
                    level++;
                    level_next = level_next + 200 * (level - 1);
                }
            }
            else if (choice == "5")
            {
                Console.WriteLine("The goals are:");
                for (int i = 0; i < goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {goals[i].GetGoal()}");
                }
                Console.Write("Which goal did you accomplish? ");
                int goalIndex = int.Parse(Console.ReadLine()) - 1;
                if (goalIndex >= 0 && goalIndex < goals.Count)
                {
                    points += goals[goalIndex].Complete();
                }
            }
            else if (choice == "6")
            {
                return;
            }
        }
    }
}