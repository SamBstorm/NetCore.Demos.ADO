using System;

namespace NetCore.Demos.AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Usine u_charleroi = new UsineAudi();
            Voiture v = u_charleroi.Produire();
            Console.WriteLine($"v est une voiture de chez {v.GetType()}");

            u_charleroi = new UsineRenault();
            Voiture v2 = u_charleroi.Produire();
            Console.WriteLine($"v2 est une voiture de chez {v2.GetType()}");
        }
    }
}
