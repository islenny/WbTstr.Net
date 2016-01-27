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
        private readonly ConcurrentDictionary<string, object> _capabilities;
        private readonly string _uniqueIdentifier;
        private SeleniumWebDriver.Browser _localWebDriver;

        private bool _disposed;

        private WbTstr(Guid guid)
        {
            _uniqueIdentifier = string.Format("{0}", guid);
            _capabilities = new ConcurrentDictionary<string, object>();
            _localWebDriver = SeleniumWebDriver.Browser.Chrome;
        }

        ~WbTstr()
        {
            Dispose(false);
        }

        /* Initialization ---------------------------------------------------*/

        private static readonly object _mutex = new object();
        private static IWbTstr _instance;

        public static IWbTstr Defaults()
        {
            return CreateInstance(loadFromConfig: false);
        }

        public static IWbTstr Configure()
        {
            return CreateInstance(loadFromConfig: true);
        }

        public static IWbTstr Configure(IWebDriverConfig webDriverConfig)
        {
            return Defaults().SetWebDriverConfig(webDriverConfig);
        }

        private static IWbTstr CreateInstance(bool loadFromConfig = true)
        {
            if (_instance != null)
            {
                throw new InvalidOperationException("Can't reconfigure WbTstr after first initialization. Change settings manually.");
            }

            lock (_mutex)
            {
                if (_instance == null)
                {
                    _instance = new WbTstr(Guid.NewGuid());
                    if (loadFromConfig)
                    {
                        _instance.SetWebDriverConfig(WbTstrWebDriverConfigs.LoadFromConfigurationFile());
                    }
                }
            }

            return _instance;
        }

        /* Properties -------------------------------------------------------*/

        internal Dictionary<string, object> Capabilities
        {
            get
            {
                return _capabilities.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
        }

        internal Uri RemoteDriverUri { get; private set; }

        /*-------------------------------------------------------------------*/

        public IWbTstr Start()
        {
            return BootstrapInstance();
        }

        public IWbTstr EnableDryRun()
        {
            FluentSettings.Current.IsDryRun = true;
            return this;
        }

        public IWbTstr DisableDryRun()
        {
            FluentSettings.Current.IsDryRun = false;
            return this;
        }

        public IWbTstr SetCapability(string key, string value)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("key is null or empty");
            if (string.IsNullOrEmpty(value)) throw new ArgumentException("value is null or empty");

            _capabilities[key] = value;
            return this;
        }

        public IWbTstr RemoveCapability(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("key is null or empty");

            if (_capabilities.ContainsKey(key))
            {
                object removed = null;
                _capabilities.TryRemove(key, out removed);
            }

            return this;
        }

        public IWbTstr UseWebDriver(SeleniumWebDriver.Browser browser)
        {
            //DisableBrowserStackLocal();

            RemoteDriverUri = null;
            _localWebDriver = browser;
            return this;
        }

        public IWbTstr UseRemoteWebDriver(string remoteWebDriver)
        {
            if (remoteWebDriver == null) throw new ArgumentException("remoteWebDriver");

            RemoteDriverUri = new Uri(remoteWebDriver);
            return this;
        }

        public IWbTstrBrowserStackOperatingSystem PreferedBrowserStackOperatingSystem()
        {
            return new WbTstrBrowserStackOperatingSystem(this);
        }

        public IWbTstrBrowserStackScreenResolution PreferedBrowserStackScreenResolution()
        {
            return new WbTstrBrowserStackScreenResolution(this);
        }

        public IWbTstrBrowserStackBrowser PreferedBrowserStackBrowser()
        {
            return new WbTstrBrowserStackBrowser(this);
        }

        public IWbTstr SetWebDriverConfig(IWebDriverConfig webDriverConfig)
        {
            var localWebDriverConfig = webDriverConfig as ILocalWebDriverConfig;
            if (localWebDriverConfig != null)
            {
                return SetLocalWebDriverConfig(localWebDriverConfig);
            }

            var remoteWebDriverConfig = webDriverConfig as IRemoteWebDriverConfig;
            if (remoteWebDriverConfig != null)
            {
                return SetRemoteWebDriverConfig(remoteWebDriverConfig);
            }

            throw new InvalidOperationException("Not a supported WebDriver config.");
        }

        private IWbTstr SetLocalWebDriverConfig(ILocalWebDriverConfig localWebDriverConfig)
        {
            UseWebDriver(localWebDriverConfig.Browser);

            return this;
        }

        private IWbTstr SetRemoteWebDriverConfig(IRemoteWebDriverConfig remoteWebDriverConfig)
        {
            return this;
        }

        private IWbTstr BootstrapInstance()
        {
            if (FluentSettings.Current.IsDryRun)
            {
                SeleniumWebDriver.DryRunBootstrap();
            }
            else if (RemoteDriverUri != null)
            {
                //if (_browserStackLocalEnabled)
                //{
                //    string arguments = BrowserStackLocal.Instance.BuildArguments(_browserStackPassword,
                //        _browserStackLocalFolder,
                //        _browserStackOnlyAutomate,
                //        _browserStackForceLocal,
                //        _browserStackUseProxy,
                //        _browserStackProxyHost,
                //        _browserStackProxyPort,
                //        _browserStackProxyUser,
                //        _browserStackProxyPassword);

                //    BrowserStackLocal.Instance.Start(_uniqueIdentifier, arguments);
                //}

                SeleniumWebDriver.Bootstrap(RemoteDriverUri, Capabilities);
            }
            else
            {
                SeleniumWebDriver.Bootstrap(_localWebDriver);
            }

            return this;
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
                    // ...
                }

                // Now disposed of any unmanaged objects
                BrowserStackLocal.Instance.Stop(_uniqueIdentifier);

                _disposed = true;
            }
        }
    }
}