using Codehouse.Automation.Common;
using Codehouse.Automation.Common.Extensions;
using FluentAssertions;
using OpenQA.Selenium;

namespace Codehouse.Automation.MainSite.PageObjects;

internal class CookieBanner
{
    private const int TotalToggles = 4;
    private static readonly By CookieContainerLocator = By.CssSelector("div.cky-consent-container");

    private static readonly By CookieAcceptButtonLocator =
        By.CssSelector("div.cky-consent-container button.cky-btn-accept");

    private static readonly By CookieCloseButtonLocator =
        By.CssSelector("div.cky-consent-container button.cky-banner-btn-close");

    private static readonly By CustomizeCookiesLocator =
        By.CssSelector("button.cky-btn.cky-btn-customize");

    private static readonly By SaveMyPreferencesCta = By.CssSelector("button.cky-btn.cky-btn-preferences");
    private static readonly By CookiePolicyLink = By.XPath("//a[normalize-space()='Cookie policy']");
    private static readonly By CookieSettingsCta = By.XPath("//a[@class='cky-banner-element']");
    private static readonly By CookieCheckboxLocator = By.XPath("//input[@type='checkbox']");
    private static readonly By ToggledOnCookiesLocator = By.CssSelector("div.cky-switch [aria-label*='Disable']");
    private static readonly By ToggledOffCookiesLocator = By.CssSelector("div.cky-switch [aria-label*='Enable']");

    private readonly IWebDriver _webDriver;

    public CookieBanner(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public void Accept()
    {
        _webDriver.Click(CookieAcceptButtonLocator);
    }

    public void ClickCookiePolicyLink()
    {
        _webDriver.Click(CookiePolicyLink);
    }

    public void ClickCookieSettings()
    {
        
        _webDriver.Click(CookieSettingsCta);
    }

    public void Close()
    {
        _webDriver.Click(CookieCloseButtonLocator);
    }

    public void Customize()
    {
        _webDriver.Click(CustomizeCookiesLocator);
    }

    public void SavePreferences()
    {
        _webDriver.Click(SaveMyPreferencesCta);
    }

    public void ToggleOnOffCookies()
    {
        _webDriver.BrowserSleep(For.TwoSeconds);
        var checklist = _webDriver.WaitForAndFindElements(CookieCheckboxLocator);
        foreach (var element in checklist)
        {
            _webDriver.ScrollDownPopUpModal(checklist[2]);
            element.Scroll().Click();
        }
    }

    public void VerifyCookieBannerAppears()
    {
        _webDriver.WaitForElementToBePresent(CookieContainerLocator, 2);
    }

    public void VerifyCookieBannerDisappears()
    {
        _webDriver.WaitForElementToBeInvisible(CookieContainerLocator);
    }

    public void VerifyToggleOffCookies()
    {
        var numberOfTicks = _webDriver.WaitForAndFindElements(ToggledOffCookiesLocator).Count;
        numberOfTicks.Should().Be(TotalToggles);
    }

    public void VerifyToggleOnCookies()
    {
        var numberOfTicks = _webDriver.WaitForAndFindElements(ToggledOnCookiesLocator).Count;
        numberOfTicks.Should().Be(TotalToggles);
    }
}