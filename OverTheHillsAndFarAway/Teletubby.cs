using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTheHillsAndFarAway
{
    public class Teletubby : IObserver
    {
        public string Name { get; set; }

        public void Update(string task)
        {
            switch (task)
            {
                case "WakeUp":
                    Console.WriteLine("\n{0} says: Tubby wakey", Name);
                    break;
                case "Television":
                    Console.WriteLine("\n{0} says:Tubby watchy-watchy", Name);
                    break;
                case "Dinner":
                    Console.WriteLine("\n{0} says:Tubby eatytime", Name);
                    break;
                case "Bye":
                    Console.WriteLine("\n{0} says:Tubby sleepy", Name);
                    break;
            }
        }
    }
}
