using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TirePressure
{
    public partial class Form1 : Form, IObserver
    {
        private PressureSensor _sensor;

        public Form1(PressureSensor sensor)
        {
            InitializeComponent();
            _sensor = sensor;
            _sensor.Attach(this);
        }
        public string _pressureData { get; internal set; }

        public void UpdatePressure()
        {
            if (_sensor.PressureAvg < 30)
            {
                _pressureData = "Pressure: " + _sensor.PressureAvg + ". Pressure is low";
                textBox1.Text = _pressureData;
                label1.Text = _pressureData;
            }
            else if (_sensor.PressureAvg >= 30)
            {
                _pressureData = "Pressure: " + _sensor.PressureAvg + ". Pressure is good";
                textBox1.Text = _pressureData;
                label1.Text = _pressureData;
            }
        }
    }
}
