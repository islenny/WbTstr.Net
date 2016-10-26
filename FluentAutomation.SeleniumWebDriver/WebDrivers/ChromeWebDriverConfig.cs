using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.WebDrivers
{
    public class ChromeWebDriverConfig : LocalWebDriverConfig
    {
        public ChromeWebDriverConfig()
        {
            Browser = SeleniumWebDriver.Browser.Chrome;
        }
    }
}
