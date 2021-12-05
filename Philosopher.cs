using System.Diagnostics;
using System.Threading;
using ChopstickNS;
using System;

namespace PhilosopherNS
{
    class Philosopher
    {
        private readonly Random rand = new Random();
        private Chopstick left;
        private Chopstick right;
        private int eaten = 0;
        private bool isEating = false;
        private int index;

        public Philosopher(int id, Chopstick lk, Chopstick rt)
        {
            // set identifier, left and right chopstick of the philosopher
            index = id;
            left = lk;
            right = rt;
        }


        private void eat()
        {
            // philosopher tries to start eating and access left and right chopstick
            Debug.Assert(!isEating, "Philosopher can't eat when he's eating already!");

            if (left.grab())
            {
                if (right.grab())
                {
                    isEating = true;
                }
                else
                {
                    // drop the chopstick if we failed to grab both of them
                    left.release();

                }
            }
        }

        private void think()
        {
            /* 
            As the philosopher finished eating and starts thinking, we increment the ammount of times he has eaten, 
            stop eating and drop the chopsticks 
            */
            Debug.Assert(isEating, "Philosopher is not allowed to think unless he was previously eating!");

            eaten += 1;
            left.release();
            right.release();
            isEating = false;
        }
        private void waitRandom()
        {
            // randomized delay unil the thread proceeds
            int waitTime = rand.Next(10000);
            Thread.CurrentThread.Join(waitTime);
        }

        public void dine(object o)
        {   
            int count = (int) o;
            /*
            philosopher tries to eat "count" times, if he successfully eats, he thinks afterwards
            eating and thinking takes him random  ammounts of time
            */
            waitRandom();
            for (int i = 0; i < count; i++)
            {
                eat();
                waitRandom();
                if (isEating)
                { //thinking only allowed directly after eating
                    think();
                    waitRandom();
                }

            }
            Console.WriteLine("Philosopher {0} finished and ate {1} times.", index, eaten);
        }
    }
}