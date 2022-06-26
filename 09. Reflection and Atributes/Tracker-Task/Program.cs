using System;

namespace Tracker_Task
{
    [Author("Rado")]
    public class Program
    {
        [Author("Deni")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor("Deni");
        }


        [Author("Rado", Description = "Eat class")]
        public void Eat()
        {
            Console.WriteLine("Eating...");
        }

        [Author("Rado")]
        public void Talk()
        {
            Console.WriteLine("Talking...");
        }

        [Author("Deni")]
        public void Walk()
        {
            Console.WriteLine("Walking...");
        }
    }
}
