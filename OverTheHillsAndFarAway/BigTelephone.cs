using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverTheHillsAndFarAway
{
    class BigTelephone : TimeSubject
    {

        public void WakeUp()
        {
            Notify("WakeUp");
        }

        public void Dinner()
        {
            Notify("Dinner");
        }

        public void WatchTelevision()
        {
            Notify("Television");
        }

        public void TubbieByeBye()
        {
            Notify("Bye");
        }

    }
}
