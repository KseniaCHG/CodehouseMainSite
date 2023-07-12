using Codehouse.Automation.MainSite.PageObjects;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Codehouse.Automation;

[Binding]
internal class HeaderSteps
{
    private readonly Header _header;
    private readonly IWebDriver _webDriver;

    public HeaderSteps(Header header, IWebDriver webDriver)
    {
        _header = header;
        _webDriver = webDriver;
    }

    [Then(@"the logo should be displayed in the header")]
    public void ThenTheLogoShouldBeDisplayedInTheHeader()
    {
        _header.VerifyHeaderLogo();
    }

    [Then(@"the Services link is displayed on the header")]
    public void ThenTheServicesLinkIsDisplayedOnTheHeader()
    {
        throw new PendingStepException();
    }

}