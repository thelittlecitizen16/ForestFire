using System;

namespace ForestFire
{
    class Program
    {
        static void Main(string[] args)
        {
            ForestFactory forestFactory = new ForestFactory();
            ForsetHandler forsetHandler = new ForsetHandler(forestFactory);
            forsetHandler.Bootstrapping();
            Console.WriteLine("Hello World!");
        }
    }
}
