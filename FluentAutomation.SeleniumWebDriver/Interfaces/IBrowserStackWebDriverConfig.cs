using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.WebDrivers;

namespace FluentAutomation.Interfaces
{
    public interface IBrowserStackWebDriverConfig : IRemoteWebDriverConfig
    {
        BrowserStackWebDriverConfig SetBrowserStackLocalFolder(string path);

        BrowserStackWebDriverConfig DisableBrowserStackLocalFolder();

        BrowserStackWebDriverConfig EnableBrowserStackOnlyAutomate();

        BrowserStackWebDriverConfig DisableBrowserStackOnlyAutomate();

        BrowserStackWebDriverConfig EnableBrowserStackForceLocal();

        BrowserStackWebDriverConfig DisableBrowserStackForceLocal();

        BrowserStackWebDriverConfig SetBrowserStackProxyHost(string host);

        BrowserStackWebDriverConfig SetBrowserStackProxyPort(int port);

        BrowserStackWebDriverConfig SetBrowserStackProxyUser(string user);

        BrowserStackWebDriverConfig SetBrowserStackProxyPassword(string password);

        BrowserStackWebDriverConfig EnableBrowserStackLocalKillOthers();

        BrowserStackWebDriverConfig DisableBrowserStackLocalKillOthers();

        BrowserStackWebDriverConfig EnableBrowserStackLocalRestrictToLocalOnly();

        BrowserStackWebDriverConfig DisableBrowserStackLocalRestrictToLocalOnly();

        BrowserStackWebDriverConfig SetBrowserStackCredentials(string username, string password);

        BrowserStackWebDriverConfig EnableBrowserStackLocal();

        BrowserStackWebDriverConfig DisableBrowserStackLocal();

        BrowserStackWebDriverConfig EnableBrowserStackProjectGrouping(string projectName);

        BrowserStackWebDriverConfig DisableBrowserStackProjectGrouping();

        BrowserStackWebDriverConfig SetBrowserStackBuildIdentifier(string buildName);

        BrowserStackWebDriverConfig EnableDebug();

        BrowserStackWebDriverConfig DisableDebug();
    }
}
