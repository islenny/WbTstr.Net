using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.Interfaces
{
    public interface ILocalWebDriverConfig : IWebDriverConfig
    {
        bool GenerateUniqueExecutableFilename { get; set; }

        SeleniumWebDriver.Browser Browser { get; }

        IEnumerable<string> Arguments { get; }

        ILocalWebDriverConfig AddOrSetArgument(string key, object value = null);

        ILocalWebDriverConfig RemoveArgument(string key);
    }
}
