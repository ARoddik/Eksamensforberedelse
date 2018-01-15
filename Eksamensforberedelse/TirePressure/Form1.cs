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
    public partial class Form1 : Form
    {
        private UpdateTirePressure _update;

        public Form1(PressureSensor sensor)
        {
            InitializeComponent();
        }
    }
}
