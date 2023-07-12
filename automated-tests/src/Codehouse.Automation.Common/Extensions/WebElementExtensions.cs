using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Codehouse.Automation.Common.Extensions;
public static class WebElementExtensions
{
    public static IWebElement Scroll(this IWebElement element)
    {
        var driver = ((IWrapsDriver)element).WrappedDriver;
        new Actions(driver).ScrollToElement(element).Perform();
        return element;
    }
}
