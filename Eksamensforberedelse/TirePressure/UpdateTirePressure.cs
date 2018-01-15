using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirePressure
{
    class UpdateTirePressure : IObserver
    {
        private PressureSensor _sensor;
        public string PressureData { get; internal set; }

        public void UpdatePressure()
        {
            if (_sensor.PressureAvg < 30)
            {
                PressureData = "Pressure: " + _sensor.PressureAvg + ". Pressure is low";
            }
            else if (_sensor.PressureAvg >= 30)
            {
                PressureData = "Pressure: " + _sensor.PressureAvg + ". Pressure is good";
            }
        }
    }
}
