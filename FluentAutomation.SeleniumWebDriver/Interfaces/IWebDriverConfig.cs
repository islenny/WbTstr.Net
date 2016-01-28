using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.Interfaces
{
    public interface IWebDriverConfig : IDisposable
    {
        WebDriverType WebDriverType { get; }

        Dictionary<string, object> Capabilities { get; } 
     
        void AddOrSetCapability(string key, string value);

        void RemoveCapability(string key);

        void Setup();
    }
}
