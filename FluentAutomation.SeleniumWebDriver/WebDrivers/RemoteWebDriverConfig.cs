using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.Interfaces;

namespace FluentAutomation.WebDrivers
{
    public class RemoteWebDriverConfig : WebDriverConfig, IRemoteWebDriverConfig
    {
        public Uri DriverUri
        {
            get;
            internal set;
        }

        public override void Setup()
        {
                        
        }
    }
}
