using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PressureMonitor
{
    abstract class PressureSubject
    {
        List<IPressureObserver> _observers = new List<IPressureObserver>();

        public void Attach(IPressureObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IPressureObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }
}
