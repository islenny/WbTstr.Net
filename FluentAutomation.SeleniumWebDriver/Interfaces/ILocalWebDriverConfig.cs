using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentAutomation.Interfaces
{
    public interface ILocalWebDriverConfig
    {
        SeleniumWebDriver.Browser Browser { get; }
    }
}
