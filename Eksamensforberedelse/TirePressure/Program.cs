using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TirePressure
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AutoResetEvent _dataReady = new AutoResetEvent(false);
            ConcurrentQueue<PressureContainer> _containerqueue = new ConcurrentQueue<PressureContainer>();
            PressureContainer _pressureContainer = new PressureContainer();

            TirePressureProducer _producer = new TirePressureProducer(_containerqueue);
            PressureMonitorConsumer _consumer = new PressureMonitorConsumer(_containerqueue, _dataReady, _pressureContainer);
            PressureSensor _sensor = new PressureSensor(_pressureContainer, _dataReady);

            Thread _producerThread = new Thread(_producer.Run);
            Thread _consumerThread = new Thread(_consumer.ConsumePressure);
            Thread _sensorThread = new Thread(_sensor.CheckPressure);

            _consumerThread.Start();
            _producerThread.Start();
            _sensorThread.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(_sensor));
        }
    }
}
