using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.Interfaces;
using FluentAutomation.WebDrivers;

namespace FluentAutomation
{
    public static class WbTstrWebDriverConfigs
    {
        private const string SettingValue_UseWebDriver_BrowserStack = "BROWSERSTACK";

        public static ChromeWebDriverConfig DefaultChromeWebDriverConfig
        {
            get
            {
                return new ChromeWebDriverConfig();
            }
        }

        public static PhantomWebDriverConfig DefaultPhantomJsWebDriverConfig
        {
            get
            {
                return new PhantomWebDriverConfig();
            }
        }

        public static FirefoxWebDriverConfig DefaultFirefoxWebDriverConfig
        {
            get
            {
                return new FirefoxWebDriverConfig();
            }
        }

        public static IBrowserStackWebDriverConfig DefaultBrowserStackWebDriverConfig
        {
            get
            {
                return new BrowserStackWebDriverConfig();
            }
        }

        public static IWebDriverConfig LoadFromConfigurationFile()
        {
            IWebDriverConfig webDriverConfig = null;

            string useWebDriver = ConfigReader.GetSetting("UseWebDriver");
            if (string.IsNullOrEmpty(useWebDriver))
            {
                throw new ArgumentException("Please specify at least the WbTstr:UseWebDriver setting.");
            }

            if (useWebDriver.ToUpper() == SettingValue_UseWebDriver_BrowserStack)
            {
                webDriverConfig = DefaultBrowserStackWebDriverConfig;
            }
            else
            {
                SeleniumWebDriver.Browser browser;
                if (Enum.TryParse(useWebDriver, true, out browser))
                {
                    webDriverConfig = GetDefaultWebDriver(browser);
                }
            }

            if (webDriverConfig == null)
            {
                throw new ArgumentException("Invalid or unsupported web driver specified (WbTstr:UseWebDriver).");
            }

            return webDriverConfig;
        }

        private static ILocalWebDriverConfig GetDefaultWebDriver(SeleniumWebDriver.Browser browser)
        {
            switch (browser)
            {
                case SeleniumWebDriver.Browser.Chrome:
                    return DefaultChromeWebDriverConfig;
                case SeleniumWebDriver.Browser.PhantomJs:
                    return DefaultPhantomJsWebDriverConfig;
                case SeleniumWebDriver.Browser.Firefox:
                    return DefaultFirefoxWebDriverConfig;
            }

            throw new NotSupportedException("The specified browser isn't supported.");
        }
    }
}
