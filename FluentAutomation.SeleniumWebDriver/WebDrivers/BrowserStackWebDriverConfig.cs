using FluentAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.WebDrivers
{
    public class BrowserStackWebDriverConfig : RemoteWebDriverConfig
    {
        private string _browserStackUsername;
        private string _browserStackPassword;
        private bool _browserStackLocalEnabled;
        private bool _browserStackUseProxy;
        private string _browserStackLocalFolder;
        private bool _browserStackOnlyAutomate;
        private bool _browserStackForceLocal;
        private string _browserStackProxyHost;
        private int? _browserStackProxyPort;
        private string _browserStackProxyUser;
        private string _browserStackProxyPassword;

        public BrowserStackWebDriverConfig()
        {
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
            _browserStackUseProxy = true;
            _browserStackProxyHost = host;
            return this;
        }

        public BrowserStackWebDriverConfig SetBrowserStackProxyPort(int port)
        {
            _browserStackUseProxy = true;
            _browserStackProxyPort = port;
            return this;
        }

        public BrowserStackWebDriverConfig SetBrowserStackProxyUser(string user)
        {
            _browserStackUseProxy = true;
            _browserStackProxyUser = user;
            return this;
        }

        public BrowserStackWebDriverConfig SetBrowserStackProxyPassword(string password)
        {
            _browserStackUseProxy = true;
            _browserStackProxyPassword = password;
            return this;
        }

        public BrowserStackWebDriverConfig DisableBrowserStackProxy()
        {
            _browserStackUseProxy = false;
            return this;
        }

        public BrowserStackWebDriverConfig UseBrowserStackAsRemoteDriver()
        {
            //UseRemoteWebDriver("http://hub.browserstack.com/wd/hub/");

            // Try to get browserstack username and password from configuration
            if (_browserStackUsername == null && _browserStackPassword == null)
            {
                string username = ConfigReader.GetSetting("BrowserStackUsername");
                string password = ConfigReader.GetSetting("BrowserStackPassword");

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    SetBrowserStackCredentials(username, password);
                }
            }
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
    }
}
