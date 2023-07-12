using Codehouse.Automation.Common.Extensions;
using OpenQA.Selenium;

namespace Codehouse.Automation.MainSite.PageObjects;

internal class Header
{
    private static readonly By HeaderLogoLocator = By.XPath("//a[@aria-label='Codehouse logo']//*[name()='svg']");
    private readonly IWebDriver _webDriver;

    public Header(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public void VerifyHeaderLogo()
    {
        _webDriver.WaitForAndFindElement(HeaderLogoLocator);
    }
}