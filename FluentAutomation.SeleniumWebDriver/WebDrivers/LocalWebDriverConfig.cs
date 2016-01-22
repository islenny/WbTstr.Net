using FluentAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.WebDrivers
{
    public class LocalWebDriverConfig : ILocalWebDriverConfig
    {
        public SeleniumWebDriver.Browser Browser
        {
            get;
            protected set;
        }
    }
}
