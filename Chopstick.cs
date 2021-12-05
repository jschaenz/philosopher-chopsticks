namespace ChopstickNS
{
    class Chopstick
    {
        /*
        class representing the chopstick inbetween the philosophers
        chopsticks can only be picked up if not already held by a philosopher using grab()
        the philosopher holding the chopstick can drop it using release()
        */
        private bool InUse;

        public Chopstick()
        {
            // chopstick starts "on the table" and is therefore not yet possessed by anybody
            InUse = false;
        }

        public bool grab()
        {
            /*
            user tries to grab the chopstick and holds on to it as soon if it is not in use
            returns false boolean if chopstick coudln't be grabbed
            returns true if he successfully grabbed the chopstick
            */
            bool success = false;
            if (!InUse)
            {
                InUse = true;
                success = true;
            }
            return success;
        }

        public void release()
        {
            // makes the chopstick available for grabbing again
            InUse = false;
        }
    }
}