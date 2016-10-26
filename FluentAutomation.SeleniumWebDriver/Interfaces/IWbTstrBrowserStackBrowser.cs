using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.WebDrivers;

namespace FluentAutomation.Interfaces
{
    public interface IWbTstrBrowserStackBrowser
    {
        /// <summary>
        /// It doesn't matter which browser is used.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig IsAny();

        /// <summary>
        /// Chrome is the prefered browser
        /// </summary>
        /// <param name="version">Optional version number (see BrowserStack documentation)</param>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig IsChrome(string version = null);

        /// <summary>
        /// Internet Explorerer is the prefered browser.
        /// </summary>
        /// <param name="version">Optional version number (see BrowserStack documentation)</param>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig IsInternetExplorer(string version = null);

        /// <summary>
        /// Firefox is the prefered browser
        /// </summary>
        /// <param name="version">Optional version number (see BrowserStack documentation)</param>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig IsFirefox(string version = null);
    }
}