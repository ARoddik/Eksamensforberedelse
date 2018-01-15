using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TirePressure
{
    class TirePressureProducer
    {
        private Random _pressureGenerator = new Random();
        private ConcurrentQueue<PressureContainer> _containerQueue;
        private PressureContainer _pressureContainer;
        public bool IsRunning { get; set; }

        public TirePressureProducer(ConcurrentQueue<PressureContainer> containerqueue)
        {
            _containerQueue = containerqueue;
            _pressureContainer = new PressureContainer();
        }

        public int GetPressure()
        {
            return _pressureGenerator.Next(20, 41);
        }

        public void GeneratePressure()
        {
            _pressureContainer.TirePressure = GetPressure();
            _containerQueue.Enqueue(_pressureContainer);
        }

        public void Run()
        {
            IsRunning = true;
            while (IsRunning)
            {
                GeneratePressure();
                Thread.Sleep(1000);
            }
        }
    }
}
