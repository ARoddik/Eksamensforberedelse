using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Enum;

namespace HospitalBed.Alarm
{
    public static class AlarmFactory
    {
        public static IAlarm CreateAlarm(AlarmType alarmType)
        {
            switch (alarmType)
            {
                case AlarmType.Buzzer:
                    return new BuzzerAlarm();
                    break;
                case AlarmType.Light:
                    return new LightAlarm();
                    break;
            }
            throw new Exception("Alarmtype not found. Please check type and try again");
        }
    }
}
