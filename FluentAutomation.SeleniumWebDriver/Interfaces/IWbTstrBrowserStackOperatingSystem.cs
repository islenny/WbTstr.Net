using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.WebDrivers;

namespace FluentAutomation.Interfaces
{
    public interface IWbTstrBrowserStackOperatingSystem
    {
        /// <summary>
        /// It doesn't matter which operating system is used.
        /// </summary>
        /// <returns>Current BrowserStack config</returns>
        BrowserStackWebDriverConfig IsAny();

        /// <summary>
        /// Windows is the prefered operating system.
        /// </summary>
        /// <param name="version">Optional version number (see BrowserStack documentation)</param>
        /// <returns>Current BrowserStack config</returns>
        BrowserStackWebDriverConfig IsWindows(string version = null);

        /// <summary>
        /// OS X is the prefered operating system.
        /// </summary>
        /// <param name="version">Optional version number (see BrowserStack documentation)</param>
        /// <returns>Current BrowserStack config</returns>
        BrowserStackWebDriverConfig IsOSX(string version = null);
    }
}
