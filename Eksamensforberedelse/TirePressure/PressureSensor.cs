using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TirePressure
{
    public class PressureSensor : PressureSubject
    {
        private PressureContainer _pressureContainer;
        private AutoResetEvent _autoResetEvent;
        private PressureFilter _filter = new PressureFilter();
        private int _pressure;
        public int PressureAvg { get; internal set; }
        private List<int> _tirePressure = new List<int>();

        public PressureSensor(PressureContainer pressureContainer, AutoResetEvent autoResetEvent)
        {
            _pressureContainer = pressureContainer;
            _autoResetEvent = autoResetEvent;
        }

        public void CheckPressure()
        {
            while (true)
            {
                _autoResetEvent.WaitOne();
                _pressure = _pressureContainer.TirePressure;

                if (_tirePressure.Count > 15)
                {
                    _tirePressure.RemoveAt(0);
                }
                _tirePressure.Add(_pressure);

                PressureAvg = _filter.ApplyFilter(_tirePressure);
                Notify();
            }
        }
    }
}
