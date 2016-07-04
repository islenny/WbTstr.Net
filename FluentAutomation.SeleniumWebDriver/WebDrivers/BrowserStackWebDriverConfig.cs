using FluentAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.Wrappers;

namespace FluentAutomation.WebDrivers
{
    public class BrowserStackWebDriverConfig : RemoteWebDriverConfig, IBrowserStackWebDriverConfig
    {
        private string _browserStackUsername;
        private string _browserStackPassword;
        private bool _browserStackLocalEnabled;
        private string _browserStackLocalFolder;
        private bool _browserStackOnlyAutomate;
        private bool _browserStackForceLocal;
        private string _browserStackProxyHost;
        private int? _browserStackProxyPort;
        private string _browserStackProxyUser;
        private string _browserStackProxyPassword;
        private bool _browserStackLocalKillOthers;
        private bool _browserStackLocalRestrictToLocalOnly;

        public BrowserStackWebDriverConfig()
        {
            DriverUri = new Uri("http://hub.browserstack.com/wd/hub/");
        }

        public BrowserStackWebDriverConfig SetBrowserStackLocalFolder(string path)
        {
            _browserStackLocalFolder = path;
            return this;
        }

        public BrowserStackWebDriverConfig DisableBrowserStackLocalFolder()
        {
            _browserStackLocalFolder = null;
            return this;
        }

        public BrowserStackWebDriverConfig EnableBrowserStackOnlyAutomate()
        {
            _browserStackOnlyAutomate = true;
            return this;
        }

        public BrowserStackWebDriverConfig DisableBrowserStackOnlyAutomate()
        {
            _browserStackOnlyAutomate = false;
            return this;
        }

        public BrowserStackWebDriverConfig EnableBrowserStackForceLocal()
        {
            _browserStackForceLocal = true;
            return this;
        }

        public BrowserStackWebDriverConfig DisableBrowserStackForceLocal()
        {
            _browserStackForceLocal = false;
            return this;
        }

        public BrowserStackWebDriverConfig SetBrowserStackProxyHost(string host)
        {
            _browserStackProxyHost = host;
            return this;
        }

        public BrowserStackWebDriverConfig SetBrowserStackProxyPort(int port)
        {
            _browserStackProxyPort = port;
            return this;
        }

        public BrowserStackWebDriverConfig SetBrowserStackProxyUser(string user)
        {
            _browserStackProxyUser = user;
            return this;
        }

        public BrowserStackWebDriverConfig SetBrowserStackProxyPassword(string password)
        {
            _browserStackProxyPassword = password;
            return this;
        }

        public BrowserStackWebDriverConfig EnableBrowserStackLocalKillOthers()
        {
            _browserStackLocalKillOthers = true;
            return this;
        }

        public BrowserStackWebDriverConfig DisableBrowserStackLocalKillOthers()
        {
            _browserStackLocalKillOthers = false;
            return this;
        }

        public BrowserStackWebDriverConfig EnableBrowserStackLocalRestrictToLocalOnly()
        {
            _browserStackLocalRestrictToLocalOnly = true;
            return this;
        }

        public BrowserStackWebDriverConfig DisableBrowserStackLocalRestrictToLocalOnly()
        {
            _browserStackLocalRestrictToLocalOnly = false;
            return this;
        }

        public BrowserStackWebDriverConfig SetBrowserStackCredentials(string username, string password)
        {
            if (string.IsNullOrEmpty(username)) throw new ArgumentException("username is null or empty");
            if (string.IsNullOrEmpty(password)) throw new ArgumentException("password is null or empty");

            // We might need this later, so make local reference
            _browserStackUsername = username;
            _browserStackPassword = password;

            AddOrSetCapability("browserstack.user", username);
            AddOrSetCapability("browserstack.key", password);
            return this;
        }

        public BrowserStackWebDriverConfig EnableBrowserStackLocal()
        {
            _browserStackLocalEnabled = true;
            AddOrSetCapability("browserstack.local", "true");
            AddOrSetCapability("browserstack.localIdentifier", "?????");
            return this;
        }

        public BrowserStackWebDriverConfig DisableBrowserStackLocal()
        {
            _browserStackLocalEnabled = false;
            AddOrSetCapability("browserstack.local", "false");
            RemoveCapability("browserstack.localIdentifier");
            return this;
        }

        public BrowserStackWebDriverConfig EnableBrowserStackProjectGrouping(string projectName)
        {
            AddOrSetCapability("project", projectName);

            return this;
        }

        public BrowserStackWebDriverConfig DisableBrowserStackProjectGrouping()
        {
            RemoveCapability("project");

            return this;
        }

        public BrowserStackWebDriverConfig SetBrowserStackBuildIdentifier(string buildName)
        {
            AddOrSetCapability("build", buildName);

            return this;
        }

        public BrowserStackWebDriverConfig EnableDebug()
        {
            FluentSettings.Current.InDebugMode = true;
            AddOrSetCapability("browserstack.debug", "true");
            return this;
        }

        public BrowserStackWebDriverConfig DisableDebug()
        {
            FluentSettings.Current.InDebugMode = false;
            AddOrSetCapability("browserstack.debug", "false");
            return this;
        }

        /*-------------------------------------------------------------------*/

        public override void Setup()
        {
            base.Setup();
            
            if (_browserStackLocalEnabled)
            {
                // start browserstack with arguments
                string browserStackArguments = BrowserStackLocal.Instance.BuildArguments(
                    _browserStackPassword,                           
                    _browserStackLocalFolder,
                    _browserStackOnlyAutomate,
                    _browserStackForceLocal,
                    _browserStackProxyHost,
                    _browserStackProxyPort,
                    _browserStackProxyUser,
                    _browserStackProxyPassword,
                    _browserStackLocalKillOthers,
                    _browserStackLocalRestrictToLocalOnly
                );
                
                BrowserStackLocal.Instance.Start(UniqueIdentifier, browserStackArguments);
            }
        }
    }
}
