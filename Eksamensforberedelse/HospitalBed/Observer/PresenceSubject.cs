using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed.Observer
{
    public abstract class PresenceSubject : ISubject
    {
        private List<IPresenceObserver> _observers = new List<IPresenceObserver>();

        public void Attach(IPresenceObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IPresenceObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(bool presence)
        {
            foreach (var observer in _observers)
            {
                observer.Update(presence);
            }
        }
    }
}
