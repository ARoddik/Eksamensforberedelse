using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Enum;

namespace HospitalBed.Filter
{
    public static class FilterFactory 
    {
        public static IFilter CreateFilter(FilterType filterType)
        {
            switch (filterType)
            {
                case FilterType.Raw:
                    return new RawFilter();
                    break;
                case FilterType.Sliding:
                    return new SlidingFilter();
                    break;
            }
            throw new Exception("Filtertype not found. Please check type and try again");
        }
    }
}
