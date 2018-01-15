using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Observer;

namespace HospitalBed
{
    public interface IAlarm : IPresenceObserver
    {
        void StartAlarm(bool presence);
    }
}
