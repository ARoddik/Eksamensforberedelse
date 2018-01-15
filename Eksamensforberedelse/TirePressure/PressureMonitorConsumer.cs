using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TirePressure
{
    class PressureMonitorConsumer
    {
        private ConcurrentQueue<PressureContainer> _containerQueue;
        private PressureContainer _pressureContainer;
        private AutoResetEvent _autoResetEvent;

        public PressureMonitorConsumer(ConcurrentQueue<PressureContainer> containerQueue, AutoResetEvent autoResetEvent,
            PressureContainer container)
        {
            _containerQueue = containerQueue;
            _autoResetEvent = autoResetEvent;
            _pressureContainer = container;
        }

        public void ConsumePressure()
        {
            PressureContainer container;
            while (!_containerQueue.TryDequeue(out container))
            {
                Thread.Sleep(0);
            }

            _pressureContainer.TirePressure = container.TirePressure;
            _autoResetEvent.Set();
        }
    }
}
