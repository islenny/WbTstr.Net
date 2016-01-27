using FluentAutomation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.WebDrivers
{
    public class WebDriverConfig : IWebDriverConfig
    {
        private readonly Dictionary<string, string> _capabilities;

        public WebDriverConfig()
        {
            _capabilities = new Dictionary<string, string>();
        }

        /*-------------------------------------------------------------------*/

        public void AddOrSetCapability(string key, string value)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Capability key may not be null or empty.");
            }

            _capabilities[key] = value ?? string.Empty;
        }

        public void RemoveCapability(string key)
        {
            if (!string.IsNullOrEmpty(key))
            {
                _capabilities.Remove(key);
            }
        }
    }
}
