namespace activity
{
    class StretchingActivity : Activity
    {
        private string[] stretches = 
        {
            "Neck Stretch: Gently tilt your head to one side, bringing your ear towards your shoulder.",
            "Shoulder Stretch: Extend one arm straight in front of you, and then pull the elbow across your chest with the opposite hand.",
            "Triceps Stretch: Reach one arm overhead and bend the elbow so that your hand touches the opposite shoulder blade. Use the opposite hand to gently push on the bent elbow.",
            "Chest Stretch: Stand tall and clasp your hands behind your back. Gently straighten your arms and lift them upwards, opening up your chest.",
            "Forward Fold (Hamstring Stretch): Stand with your feet hip-width apart, then slowly hinge at your hips and fold forward, reaching towards your toes.",
            "Standing Quad Stretch: Stand on one leg and grab the opposite ankle with your hand, pulling it toward your glutes.",
            "Seated Forward Fold: Sit on the floor with your legs extended straight in front of you. Hinge at the hips and reach forward towards your toes, keeping your back straight.",
            "Butterfly Stretch: Sit with your feet together and knees bent outward. Hold your feet with your hands and gently press your knees toward the floor.",
            "Calf Stretch: Stand facing a wall with one foot forward and the other foot extended back. Keep your back leg straight and press your heel into the ground while leaning toward the wall."
        };

        private Random random = new Random();

        public StretchingActivity() 
            : base("Stretching Activity", "This activity will help you relax by loosening your muscles. Clear your mind and unwind. Each stretch takes 30 seconds.") { }

        protected override void PerformActivity()
        {
            int intervals = Duration / 30; // 30 second intervals

            Console.WriteLine();
            Console.WriteLine("Complete the following stretches, switching sides when prompted.");
            Console.WriteLine("When you have an open area, press enter to continue.");
            Console.ReadLine();

            for (int i = 0; i < intervals; i++)
            {
                string stretch = stretches[random.Next(stretches.Length)];

                Console.WriteLine($"{stretch}");
                Console.Write("Get ready to start in: ");
                for (int j = 0; j < 10; j++) {
                    Console.Write($"{10 - j}");
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                    if (j == 0) {
                        Console.Write("\b \b");
                    }
                }

                Console.Write("\n");

                Console.Write("Begin stretching... ");
                for (int j = 0; j < 10; j++) {
                    Console.Write($"{10 - j}");
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                    if (j == 0) {
                        Console.Write("\b \b");
                    }
                }

                Console.Write("\n");

                Console.Write("Switch sides... ");
                for (int j = 0; j < 10; j++) {
                    Console.Write($"{10 - j}");
                    Thread.Sleep(1000);
                    Console.Write("\b \b");
                    if (j == 0) {
                        Console.Write("\b \b");
                    }
                }

                Console.Write("\n");
            }
        }
    }
}
