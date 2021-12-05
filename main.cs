using System.Diagnostics;
using System.Threading;
using ChopstickNS;
using PhilosopherNS;

namespace Main
{
    class main
    {

        static void Main(string[] args)
        {
            // main method for running the dining philosophers with args beeing the ammount of philosophers "n" and how often they should try to eat "m"
           // Debug.Assert(args.Length > 0);

            //int n = Int32.Parse(args[0]);
            //int m = Int32.Parse(args[1]);

            int n = 20;
            int m = 5;

            Chopstick[] sticks = new Chopstick[n];
            Philosopher[] philosophers = new Philosopher[n];
            Thread[] threads = new Thread[n];

            // create n Chopsticks
            for (int i = 0; i < n; i++)
            {
                sticks[i] = new Chopstick();
            }

            // create n philosophers and create a thread for their dine method
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    // first philosopher has the last stick as his left stick
                    philosophers[i] = new Philosopher(i + 1, sticks[n - 1], sticks[i]);
                }
                else if (i == n - 1)
                {
                    // last philosopher has the first stick as his right stick
                    philosophers[i] = new Philosopher(i + 1, sticks[i - 1], sticks[0]);
                }
                else
                {
                    // all other philosophers have the stick with their index as their right and index-1 as their left stick
                    philosophers[i] = new Philosopher(i + 1, sticks[i - 1], sticks[i]);
                }
                threads[i] = new Thread(new ParameterizedThreadStart(philosophers[i].dine));
            }

            //starts thread with parameter m for dine()
            for (int i = 0; i < n; i++)
            {
                threads[i].Start(m);
            }
        }
    }
}