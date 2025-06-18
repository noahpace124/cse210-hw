namespace activity
{
    abstract class Activity
    {
        protected string Name { get; }
        protected string Description { get; }
        protected int Duration { get; private set; }

        protected Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {Name}.");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            Console.Write("How long, in seconds, would you like for your session? ");
            Duration = int.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Get ready...");
            for (int i = 0; i < 3; i++) {
                Console.Write("|");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("/");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(500);
                Console.Write("\b \b");
            }

            PerformActivity();

            Console.WriteLine();
            Console.WriteLine("Well done!!");
            for (int i = 0; i < 3; i++) {
                Console.Write("|");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("/");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(500);
                Console.Write("\b \b");
            }

            Console.WriteLine();

            Console.WriteLine($"You have completed another {Duration} seconds of the {Name}.");
            for (int i = 0; i < 3; i++) {
                Console.Write("|");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("/");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(500);
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
        }

        protected abstract void PerformActivity();
    }
}

