using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.WebDrivers
{
    public class InternetExplorerWebDriverConfig : LocalWebDriverConfig
    {
        public InternetExplorerWebDriverConfig()
        {
            Browser = SeleniumWebDriver.Browser.InternetExplorer;
        }
    }
}
