using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Enum;

namespace HospitalBed.Configuration
{
    public class ConfigurationValues
    {
        public FilterType Filter { get; set; }
        public AlarmType Alarm { get; set; }
        public LogType Log { get; set; }


    }
}
