using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.Interfaces;

namespace FluentAutomation.WebDrivers
{
    public abstract class WebDriverConfig : IWebDriverConfig
    {
        private readonly Dictionary<string, string> _capabilities;
        private bool _disposed;

        protected WebDriverConfig()
        {
            _capabilities = new Dictionary<string, string>();
        }

        /*-------------------------------------------------------------------*/

        public WebDriverType WebDriverType { get; protected set; }

        public Dictionary<string, object> Capabilities { get; protected set; }

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

        public abstract void Setup();

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
                }

                // Dispose any unmanaged objects
                _disposed = true;
            }
        }
    }
}
