using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Observer;

namespace HospitalBed.Alarm
{
    class BuzzerAlarm : IAlarm
    {
        public void StartAlarm(bool presence)
        {
            if (presence)
            {
                Console.WriteLine("Patient is in bed");
            }
            else
            {
                Console.WriteLine("BZZ BZZ BZZ! Patient has left the bed!");
            }
        }

        public void Update(bool presence)
        {
            StartAlarm(presence);
        }

        public void AttachTo(ISubject subject)
        {
            subject.Attach(this);
        }

        public void DetachFrom(ISubject subject)
        {
            subject.Detach(this);
        }
    }
}
