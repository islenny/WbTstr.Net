using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.Interfaces
{
    public interface IWebDriverConfig
    {
        void AddOrSetCapability(string key, string value);

        void RemoveCapability(string key);
    }
}
