using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.WebDrivers;

namespace FluentAutomation.Interfaces
{
    public interface IWbTstrBrowserStackScreenResolution
    {
        /// <summary>
        /// It doesn't matter which screen resolution is used.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig IsAny();

        /// <summary>
        /// The prefered screen resolution is 1024x768.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig Is1024x768();

        /// <summary>
        /// The prefered screen resolution is 1280x800.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig Is1280x800();

        /// <summary>
        /// The prefered screen resolution is 1280x1024.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig Is1280x1024();

        /// <summary>
        /// The prefered screen resolution is 1366x768.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig Is1366x768();

        /// <summary>
        /// The prefered screen resolution is 1440x900.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig Is1440x900();

        /// <summary>
        /// The prefered screen resolution is 1680x1050.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig Is1680x1050();

        /// <summary>
        /// The prefered screen resolution is 1600x1200.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig Is1600x1200();

        /// <summary>
        /// The prefered screen resolution is 1920x1200.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig Is1920x1200();

        /// <summary>
        /// The prefered screen resolution is 1920x1080.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig Is1920x1080();

        /// <summary>
        /// The prefered screen resolution is 2048x1536.
        /// </summary>
        /// <returns>Current WbTstr instance</returns>
        BrowserStackWebDriverConfig Is2048x1536();
    }
}
