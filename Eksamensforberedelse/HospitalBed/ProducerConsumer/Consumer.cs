using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalBed
{
    public class Consumer
    {
        private ConcurrentQueue<PresenceContainer> _dataQueue;
        private AutoResetEvent _dataEvent;
        public PresenceContainer Container { get; set; }
        public bool IsRunning { get; set; }

        public Consumer(ConcurrentQueue<PresenceContainer> dataQueue, AutoResetEvent dataEvent)
        {
            _dataQueue = dataQueue;
            _dataEvent = dataEvent;
        }

        public void ConsumePresence()
        {
            PresenceContainer data;
            while (!_dataQueue.TryDequeue(out data))
            {
                Thread.Sleep(0);
            }
            Container = data;
        }

        public void Run()
        {
            IsRunning = true;
            while (IsRunning)
            {
                ConsumePresence();
                _dataEvent.Set();
            }
        }

    }
}
