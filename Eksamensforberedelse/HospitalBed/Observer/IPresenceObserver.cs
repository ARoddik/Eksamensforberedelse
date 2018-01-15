using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed.Observer
{
    public interface IPresenceObserver
    {
        void Update(bool presence);
        void AttachTo(ISubject subject);
        void DetachFrom(ISubject subject);
    }
}
