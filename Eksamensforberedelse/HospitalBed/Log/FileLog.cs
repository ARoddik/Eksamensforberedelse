using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed.Log
{
    class FileLog : ILog
    {
        private string _path;

        public FileLog()
        {
            _path = @"D:\Programs\Google Drive\ST3\PRG\Files\HospitalBedLogFiles";
        }
        public void LogStuff(bool presence)
        {
            using (StreamWriter writeText = new StreamWriter(_path, true))
            {
                if (presence)
                {
                    writeText.WriteLine("Patient is in bed " + DateTime.Now.ToShortTimeString());
                }
                else
                {
                    writeText.WriteLine("Patient has left the bed " + DateTime.Now.ToShortTimeString());
                }
            }
        }
    }
}
