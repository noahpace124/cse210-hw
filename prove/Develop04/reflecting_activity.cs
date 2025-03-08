namespace activity
{
    class ReflectingActivity : Activity
    {
        private string[] prompts = 
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private string[] questions = 
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        private Random random = new Random();

        public ReflectingActivity() 
            : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

        protected override void PerformActivity()
        {
            string prompt = prompts[random.Next(prompts.Length)];

            Console.WriteLine();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            Console.WriteLine($" --- {prompt} --- ");
            Console.WriteLine();
            Console.WriteLine("When you have something in mind, press enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
            Console.Write("You may begin in: ");
            for (int j = 0; j < 5; j++) {
                Console.Write($"{5 - j}");
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }

            Console.Clear();

            int intervals = Duration / 10; // 10 second intervals

            for (int i = 0; i < intervals; i++)
            {
                string question = questions[random.Next(questions.Length)];
                Console.Write($"> {question} ");
                for (int j = 0; j < 5; j++) { // 10 seconds
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
                Console.Write("\n");
            }
        }
    }
}
