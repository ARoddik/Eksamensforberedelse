using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirePressure
{
    class PressureFilter : Filter
    {
        public int ApplyFilter(List<int> tirePressure)
        {
            int avgPressure = Convert.ToInt32(tirePressure.Average());
            return avgPressure;
        }
    }
}
