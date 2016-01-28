using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.Interfaces;
using FluentAutomation.WebDrivers;

namespace FluentAutomation
{
    public class WbTstrBrowserStackBrowser : IWbTstrBrowserStackBrowser
    {
        private readonly BrowserStackWebDriverConfig _browserStack;

        public WbTstrBrowserStackBrowser(BrowserStackWebDriverConfig browserStack)
        {
            _browserStack = browserStack;
        }

        /*-------------------------------------------------------------------*/

        public BrowserStackWebDriverConfig IsAny()
        {
            _browserStack.RemoveCapability("browser");
            _browserStack.RemoveCapability("browser_version");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig IsChrome(string version = null)
        {
            _browserStack.AddOrSetCapability("browser", "Chrome");
            SetBrowserVersion(version);

            return _browserStack;
        }

        public BrowserStackWebDriverConfig IsInternetExplorer(string version = null)
        {
            _browserStack.AddOrSetCapability("browser", "IE");
            SetBrowserVersion(version);

            return _browserStack;
        }

        public BrowserStackWebDriverConfig IsFirefox(string version = null)
        {
            _browserStack.AddOrSetCapability("browser", "Firefox");
            SetBrowserVersion(version);

            return _browserStack;
        }

        private void SetBrowserVersion(string version)
        {
            if (version != null)
            {
                _browserStack.AddOrSetCapability("browser_version", version);
            }
            else
            {
                _browserStack.RemoveCapability("browser_version");
            }
        }
    }
}
