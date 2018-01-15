using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed
{
    class Sensor : ISensor
    {
        private Random _rand = new Random();
        public bool PatientDetected()
        {
            bool presence;
            var outPresence = _rand.Next(0, 2);

            if (outPresence == 0)
            {
                presence = true;
            }
            else
            {
                presence = false;
            }

            return presence;
        }
    }
}
