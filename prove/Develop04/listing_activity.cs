namespace activity
{
    class ListingActivity : Activity
    {
        private string[] prompts = 
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        private Random random = new Random();

        public ListingActivity() 
            : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

        protected override void PerformActivity()
        {
            string prompt = prompts[random.Next(prompts.Length)];

            Console.WriteLine();
            Console.WriteLine("List as many responses you can to the following prompt:");
            Console.WriteLine($" --- {prompt} --- ");
            Console.Write("You may begin in: ");
            for (int j = 0; j < 5; j++) {
                Console.Write($"{5 - j}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.Write("\n");

            DateTime startTime = DateTime.Now;

            int count = 0;

            while ((DateTime.Now - startTime).TotalSeconds < Duration)
            {
                Console.Write("> ");
                Console.ReadLine();
                count++;
            }
            Console.WriteLine($"You listed {count} items!");

        }
    }
}