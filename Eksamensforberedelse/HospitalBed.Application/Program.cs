using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HospitalBed.Alarm;
using HospitalBed.Configuration;
using HospitalBed.Filter;
using HospitalBed.Log;

namespace HospitalBed.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new ConcurrentQueue<PresenceContainer>();
            var dataEvent = new AutoResetEvent(false);
            var config = new XmlConfiguration();
            var configValues = config.Deserialize();

            var alarm = AlarmFactory.CreateAlarm(configValues.Alarm);
            var filter = FilterFactory.CreateFilter(configValues.Filter);
            var log = LogFactory.CreateLog(configValues.Log);

            var producer = new Producer(queue);
            var consumer = new Consumer(queue, dataEvent);
            var controller = new CtrlHospitalBed(dataEvent, consumer, alarm, filter, log);

            var consumerThread = new Thread(consumer.Run);
            var producerThread = new Thread(producer.Run);
            var controllerThread = new Thread(controller.RunSystem);
            var checkThread = new Thread(controller.CheckKeyChar);
            
            consumerThread.Start();
            producerThread.Start();
            controllerThread.Start();
            checkThread.Start();
        }
    }
}
