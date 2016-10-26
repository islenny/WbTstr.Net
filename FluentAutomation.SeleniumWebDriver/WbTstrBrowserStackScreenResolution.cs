using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.Interfaces;
using FluentAutomation.WebDrivers;

namespace FluentAutomation
{
    public class WbTstrBrowserStackScreenResolution : IWbTstrBrowserStackScreenResolution
    {
        private readonly BrowserStackWebDriverConfig _browserStack;

        public WbTstrBrowserStackScreenResolution(BrowserStackWebDriverConfig browserStack)
        {
            _browserStack = browserStack;
        }

        /*-------------------------------------------------------------------*/

        public BrowserStackWebDriverConfig IsAny()
        {
            _browserStack.RemoveCapability("resolution");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig Is1024x768()
        {
            _browserStack.AddOrSetCapability("resolution", "1024x768");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig Is1280x800()
        {
            _browserStack.AddOrSetCapability("resolution", "1280x800");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig Is1280x1024()
        {
            _browserStack.AddOrSetCapability("resolution", "1280x1024");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig Is1366x768()
        {
            _browserStack.AddOrSetCapability("resolution", "1366x768");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig Is1440x900()
        {
            _browserStack.AddOrSetCapability("resolution", "1440x900");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig Is1680x1050()
        {
            _browserStack.AddOrSetCapability("resolution", "1680x1050");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig Is1600x1200()
        {
            _browserStack.AddOrSetCapability("resolution", "1600x1200");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig Is1920x1200()
        {
            _browserStack.AddOrSetCapability("resolution", "1920x1200");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig Is1920x1080()
        {
            _browserStack.AddOrSetCapability("resolution", "1920x1080");

            return _browserStack;
        }

        public BrowserStackWebDriverConfig Is2048x1536()
        {
            _browserStack.AddOrSetCapability("resolution", "2048x1536");

            return _browserStack;
        }
    }
}
