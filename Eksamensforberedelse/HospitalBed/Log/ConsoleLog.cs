using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed.Log
{
    class ConsoleLog : ILog
    {
        public void LogStuff(bool presence)
        {
            if (presence)
            {
                Console.WriteLine(DateTime.Now.ToShortTimeString() + " Patient is in bed");
            }
            else
            {
                Console.WriteLine(DateTime.Now.ToShortTimeString() + " Patient has left the bed");
            }
        }
    }
}
