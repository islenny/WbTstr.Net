using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.WebDrivers
{
    public class FirefoxWebDriverConfig : LocalWebDriverConfig
    {
        public FirefoxWebDriverConfig()
        {
            Browser = SeleniumWebDriver.Browser.Firefox;
        }
    }
}
