using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TirePressure
{
    interface Filter
    {
        int ApplyFilter(List<int> tirePressure);
    }
}
