using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Observer;

namespace HospitalBed.Filter
{
    class RawFilter : PresenceSubject, IFilter
    {
        public void StartFiltering(bool filter)
        {
            Notify(filter);
        }

        public void AttachTo(IPresenceObserver observer)
        {
            Attach(observer);
        }

        public void DetachFrom(IPresenceObserver observer)
        {
            Detach(observer);
        }
    }
}
