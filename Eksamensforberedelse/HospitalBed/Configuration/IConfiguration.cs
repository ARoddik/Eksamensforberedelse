﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBed.Configuration
{
    public interface IConfiguration
    {
        ConfigurationValues Deserialize();
    }
}
