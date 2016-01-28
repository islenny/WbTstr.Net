using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using FluentAutomation.Interfaces;
using FluentAutomation.Wrappers;

using OpenQA.Selenium;

namespace FluentAutomation
{
    public class WbTstr : IWbTstr, IDisposable
    {
        private static readonly object _mutex = new object();
        private static IWbTstr _instance;
        private bool _disposed;

        private WbTstr()
        {
        }

        ~WbTstr()
        {
            Dispose(false);
        }

        /* Properties -------------------------------------------------------*/

        internal static IWbTstr Instance
        {
            get
            {
                return _instance;
            }
        }

        public IWebDriverConfig WebDriverConfig
        {
            get;
            private set;
        }

        /* Initialization ---------------------------------------------------*/

        public static IWbTstr Defaults()
        {
            return CreateInstance(false);
        }

        public static IWbTstr Configure()
        {
            return CreateInstance();
        }

        public static IWbTstr Configure(IWebDriverConfig webDriverConfig)
        {
            return Defaults().SetWebDriverConfig(webDriverConfig);
        }

        private static IWbTstr CreateInstance(bool loadFromConfig = true)
        {
            if (_instance != null)
            {
                throw new InvalidOperationException("Can't reconfigure WbTstr once started. Change settings manually.");
            }

            lock (_mutex)
            {
                if (_instance == null)
                {
                    _instance = new WbTstr();
                    if (loadFromConfig)
                    {
                        _instance.SetWebDriverConfig(WbTstrWebDriverConfigs.LoadFromConfigurationFile());
                    }
                }
            }

            return _instance;
        }

        /*-------------------------------------------------------------------*/

        public IWbTstr Start()
        {
            return BootstrapInstance();
        }

        public IWbTstr EnableDebug()
        {
            FluentSettings.Current.InDebugMode = true;
            return this;
        }

        public IWbTstr DisableDebug()
        {
            FluentSettings.Current.InDebugMode = false;
            return this;
        }

        public IWbTstr EnableDryRun()
        {
            FluentSettings.Current.InDryRunMode = true;
            return this;
        }

        public IWbTstr DisableDryRun()
        {
            FluentSettings.Current.InDryRunMode = false;
            return this;
        }

        public IWbTstr SetWebDriverConfig(IWebDriverConfig webDriverConfig)
        {
            if (webDriverConfig == null) throw new ArgumentNullException("webDriverConfig");

            WebDriverConfig = webDriverConfig;
            return this;
        }

        private IWbTstr BootstrapInstance()
        {
            if (FluentSettings.Current.InDryRunMode)
            {
                SeleniumWebDriver.DryRunBootstrap();
            }

            if (WebDriverConfig == null)
            {
                return this;
            }

            var localWebDriverConfig = WebDriverConfig as ILocalWebDriverConfig;
            if (localWebDriverConfig != null)
            {
                BootstrapWithLocalWebDriver(localWebDriverConfig);
            }

            var remoteWebDriverConfig = WebDriverConfig as IRemoteWebDriverConfig;
            if (remoteWebDriverConfig != null)
            {
                BootstrapWithRemoteWebDriver(remoteWebDriverConfig);
            }
            
            // Webdriver specific setup
            WebDriverConfig.Setup();

            return this;
        }

        private void BootstrapWithLocalWebDriver(ILocalWebDriverConfig localWebDriverConfig)
        {
            SeleniumWebDriver.Bootstrap(localWebDriverConfig.Browser);
        }

        private void BootstrapWithRemoteWebDriver(IRemoteWebDriverConfig remoteWebDriverConfig)
        {

            SeleniumWebDriver.Bootstrap(remoteWebDriverConfig.DriverUri, remoteWebDriverConfig.Capabilities);
        }

        /* Destruction ------------------------------------------------------*/

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose any managed objects
                    if (WebDriverConfig != null)
                    {
                        WebDriverConfig.Dispose();
                    }
                }

                // Dispose any unmanged objects
                _disposed = true;
            }
        }
    }
}