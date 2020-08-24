using System;
using Timer = System.Timers.Timer;

namespace ForestFire
{
    class Program
    {

        static void Main(string[] args)
        {
            ForestFactory forestFactory = new ForestFactory();
            ForsetHandler forsetHandler = new ForsetHandler(forestFactory);
        

            forsetHandler.Bootstrapping();
            Console.ReadLine();
        }
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine("......");     
        }
       
    }
}
