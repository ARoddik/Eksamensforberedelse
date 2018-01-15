using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalBed
{
    public class Producer
    {
        private ISensor _sensor;
        private ConcurrentQueue<PresenceContainer> _containerQueue;
        public bool IsRunning { get; set; }

        public Producer(ConcurrentQueue<PresenceContainer> containerQueue)
        {
            _sensor = new Sensor();
            _containerQueue = containerQueue;
        }

        public void DataQueue()
        {
            var presence = _sensor.PatientDetected();
            PresenceContainer container = new PresenceContainer();
            container.PresenceDetected = presence;
            _containerQueue.Enqueue(container);
        }

        public void Run()
        {
            IsRunning = true;
            while (IsRunning)
            {
                DataQueue();
                Thread.Sleep(1000);
            }
        }
    }
}
