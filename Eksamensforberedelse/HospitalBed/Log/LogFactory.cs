using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Enum;

namespace HospitalBed.Log
{
    public static class LogFactory
    {
        public static ILog CreateLog(LogType logType)
        {
            switch (logType)
            {
                case LogType.Console:
                    return new ConsoleLog();
                    break;
                case LogType.File:
                    return new FileLog();
                    break;
            }
            throw new Exception("Logtype not found. Please check type and try again");
        }
    }
}
