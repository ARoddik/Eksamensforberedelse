using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HospitalBed.Alarm;
using HospitalBed.Configuration;
using HospitalBed.Enum;
using HospitalBed.Filter;
using HospitalBed.Log;

namespace HospitalBed
{
    public class CtrlHospitalBed
    {
        private AutoResetEvent _dataEvent;
        private Consumer _consumer;
        private PresenceContainer _container;
        private IAlarm _alarm;
        private IFilter _filter;
        private ILog _log;
        public bool IsSystemRunning { get; set; }
        public bool IsReading { get; set; }

        public CtrlHospitalBed(AutoResetEvent dataEvent, Consumer consumer,
                                IAlarm alarm, IFilter filter, ILog log)
        {
            _dataEvent = dataEvent;
            _consumer = consumer;
            _alarm = alarm;
            _filter = filter;
            _log = log;
            _container = new PresenceContainer();
        }

        private void GetData()
        {
            _dataEvent.WaitOne();
            _container.PresenceDetected = _consumer.Container.PresenceDetected;
        }

        public void ChooseFilter(FilterType filterType)
        {
            _filter.Detach(_alarm);
            _filter.Detach(_log);
            _filter = FilterFactory.CreateFilter(filterType);
            _filter.Attach(_alarm);
            _filter.Attach(_log);
        }

        public void ChooseLog(LogType logType)
        {
            _log.DetachFrom(_filter);
            _log = LogFactory.CreateLog(logType);
            _log.AttachTo(_filter);
        }

        public void ChooseAlarm(AlarmType alarmType)
        {
            _alarm.DetachFrom(_filter);
            _alarm = AlarmFactory.CreateAlarm(alarmType);
            _alarm.AttachTo(_filter);
        }

        public void RunSystem()
        {
            IsSystemRunning = true;
            while (IsSystemRunning)
            {
                GetData();
                _filter.StartFiltering(_container.PresenceDetected);
            }
        }

        public void CheckKeyChar()
        {
            IsReading = true;
            Console.WriteLine("Choose filter type:\n    Press 1 for RawFilter\n    Press 2 for SlidingFilter");
            Console.WriteLine("\nChoose alarm type:\n   Press 3 for BuzzerAlarm\n   Press 4 for LightAlarm");
            Console.WriteLine("\nChoose log type:\n    Press 5 for FileLog\n    Press 6 for ConsoleLog");
            while (IsReading)
            {
                var keyChar = Console.ReadKey();
                switch (keyChar.KeyChar)
                {
                    case '1':
                        ChooseFilter(FilterType.Raw);
                        break;
                    case '2':
                        ChooseFilter(FilterType.Sliding);
                        break;
                    case '3':
                        ChooseAlarm(AlarmType.Buzzer);
                        break;
                    case '4':
                        ChooseAlarm(AlarmType.Light);
                        break;
                    case '5':
                        ChooseLog(LogType.File);
                        break;
                    case '6':
                        ChooseLog(LogType.Console);
                        break;
                }
            }
        }

    }
}
