using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.Interfaces;
using FluentAutomation.WebDrivers;

namespace FluentAutomation
{
    public class WbTstrBrowserStackOperatingSystem : IWbTstrBrowserStackOperatingSystem
    {
        private readonly BrowserStackWebDriverConfig _browserStack;

        public WbTstrBrowserStackOperatingSystem(BrowserStackWebDriverConfig browserStack)
        {
            _browserStack = browserStack;
        }

        /*-------------------------------------------------------------------*/

        public BrowserStackWebDriverConfig IsAny()
        {
            _browserStack.RemoveCapability("os");
            _browserStack.RemoveCapability("os_version");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig IsWindows(string version = null)
        {
            _browserStack.AddOrSetCapability("os", "Windows");
            SetOperatingSystemVersion(version);

            return _browserStack;
        }

        public BrowserStackWebDriverConfig IsOSX(string version = null)
        {
            _browserStack.AddOrSetCapability("os", "OS X");
            SetOperatingSystemVersion(version);

            return _browserStack;
        }

        private void SetOperatingSystemVersion(string version)
        {
            if (version != null)
            {
                _browserStack.AddOrSetCapability("os_version", version);
            }
            else
            {
                _browserStack.RemoveCapability("os_version");
            }
        }
    }
}