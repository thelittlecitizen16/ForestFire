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
            RunForset runForset = new RunForset(forsetHandler);

            runForset.Bootstrapping();
            Console.ReadLine();
        }   
    }
}
