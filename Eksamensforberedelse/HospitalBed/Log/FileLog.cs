using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Observer;

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

        public void Update(bool presence)
        {
            LogStuff(presence);
        }

        public void AttachTo(ISubject subject)
        {
            subject.Attach(this);
        }

        public void DetachFrom(ISubject subject)
        {
            subject.Detach(this);
        }
    }
}
