﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Observer;

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

        public void Update(bool presence)
        {
            LogStuff(presence);
        }

        public void AttachTo(ISubject subject)
        {
            subject.Attach(this);
        }

        public void DetachFrom(ISubject subject)
        {
            subject.Attach(this);
        }
    }
}
