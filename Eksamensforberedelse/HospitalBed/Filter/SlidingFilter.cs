using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Observer;

namespace HospitalBed.Filter
{
    class SlidingFilter : PresenceSubject, IFilter
    {
        private List<bool> _presenceList;

        public SlidingFilter()
        {
            _presenceList = new List<bool>();
        }
        public void StartFiltering(bool filterData)
        {
            _presenceList.Add(filterData);
            if (_presenceList.Count > 3)
            {
                _presenceList.RemoveAt(0);
                if (_presenceList[0] == _presenceList[1] && _presenceList[2])
                {
                    Notify(_presenceList[0]);
                }
            }
        }
        public void AttachTo(IPresenceObserver observer)
        {
            Attach(observer);
        }

        public void DetachFrom(IPresenceObserver observer)
        {
            Attach(observer);
        }
    }
}
