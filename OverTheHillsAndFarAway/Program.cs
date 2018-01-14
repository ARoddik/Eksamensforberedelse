using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace OverTheHillsAndFarAway
{
    class Program
    {
        static void Main(string[] args)
        {
            BigTelephone telephone = new BigTelephone();
            List<Teletubby> teletubbies = new List<Teletubby>()
            {
                new Teletubby() {Name = "Tinky-Winky"},
                new Teletubby() {Name = "Dipsy"},
                new Teletubby() {Name = "La-La"},
                new Teletubby() {Name = "Po"}
            };

            foreach (var teletubby in teletubbies)
            {
                telephone.Attach(teletubby);
            }

            Console.WriteLine("Press 1 to wake the tubbies\nPress 2 to make the tubbies watch tv\n" +
                              "Press 3 to serve dinner for the tubbies\nPress 4 to say bye to the tubbies");

            while (true)
            {
                var input = Console.ReadKey(true);

                switch (input.KeyChar)
                {
                    case '1':
                        telephone.WakeUp();
                        break;
                    case '2':
                        telephone.WatchTelevision();
                        break;
                    case '3':
                        telephone.Dinner();
                        break;
                    case '4':
                        telephone.TubbieByeBye();
                        break;
                    case 'e':
                        Environment.Exit(0);
                        break;
                }

            }

        }
    }
}
