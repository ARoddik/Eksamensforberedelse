using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed.Observer
{
    public interface ISubject
    {
        void Attach(IPresenceObserver subject);
        void Detach(IPresenceObserver subject);
    }
}
