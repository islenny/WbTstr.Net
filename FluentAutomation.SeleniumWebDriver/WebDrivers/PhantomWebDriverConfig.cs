using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.WebDrivers
{
    public class PhantomWebDriverConfig : LocalWebDriverConfig
    {
        public PhantomWebDriverConfig()
        {
            Browser = SeleniumWebDriver.Browser.PhantomJs;
        }

        /*-------------------------------------------------------------------*/

        public string ProxyHost { get; set; }
        
        public string ProxyAuthentication { get; set; }
    }
}
