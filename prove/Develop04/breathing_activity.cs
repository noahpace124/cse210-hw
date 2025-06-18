namespace activity
{
    class BreathingActivity : Activity
    {
        public BreathingActivity() 
            : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

        protected override void PerformActivity()
        {
            int intervals = Duration / 10; // 10 second intervals

            for (int i = 0; i < intervals; i++)
            {
                Console.WriteLine();

                Console.Write("Breath in...");
                for (int j = 0; j < 5; j++) {
                    Console.Write($"{5 - j}");
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                }

                Console.Write("\n");

                Console.Write("Now breath out...");
                for (int j = 0; j < 5; j++) {
                    Console.Write($"{5 - j}");
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                }

                Console.Write("\n");
            }
        }
    }
}
