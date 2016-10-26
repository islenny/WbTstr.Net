using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FluentAutomation.Interfaces;

namespace FluentAutomation.WebDrivers
{
    public class LocalWebDriverConfig : WebDriverConfig, ILocalWebDriverConfig
    {
        private readonly Dictionary<string, object> _arguments; 

        public LocalWebDriverConfig()
        {
            _arguments = new Dictionary<string, object>();
        }

        /*-------------------------------------------------------------------*/

        public bool GenerateUniqueExecutableFilename { get; set; }

        public SeleniumWebDriver.Browser Browser
        {
            get;
            internal set;
        }

        public IEnumerable<string> Arguments
        {
            get
            {
                var withValues = _arguments.Where(a => a.Value != null).Select(a => string.Format("{0}={1}", a.Key, a.Value));
                var withoutValues = _arguments.Where(a => a.Value == null).Select(a => a.Key);

                return Enumerable.Concat(withValues, withoutValues).Where(a => !string.IsNullOrEmpty(a)).Select(a => a.ToLower());
            }
        }

        public ILocalWebDriverConfig AddOrSetArgument(string key, object value = null)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key may not be null or empty.");
            }

            _arguments[key] = value;
            return this;
        }

        public ILocalWebDriverConfig RemoveArgument(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key may not be null or empty.");
            }

            _arguments.Remove(key);
            return this;
        }

        public override void Setup()
        {
            
        }
    }
}
