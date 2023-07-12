using Codehouse.Automation.Common;
using Codehouse.Automation.MainSite.PageObjects;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Codehouse.Automation;

[Binding]
internal class CookieBannerSteps
{
    private readonly CookieBanner _cookieBanner;
    private readonly IWebDriver _webDriver;

    public CookieBannerSteps(CookieBanner cookieBanner, IWebDriver webDriver)
    {
        _cookieBanner = cookieBanner;
        _webDriver = webDriver;
    }

    [Given(@"the user is on the homepage")]
    public void GivenTheUserIsOnTheHomepage()
    {
        var url = AppSettings.Root.GetValue<string>("homePage");
        _webDriver.Navigate().GoToUrl(url);
    }

    [Then(@"the user accepts cookies")]
    public void ThenTheUserAcceptsCookies()
    {
        _cookieBanner.Accept();
    }
    [Then(@"the cookie banner appears")]
    [Given(@"the cookie banner appears")]
    public void GivenTheCookieBannerAppears()
    {
       _cookieBanner.VerifyCookieBannerAppears();
    }
    [When(@"they refresh the page")]
    [Given(@"they refresh the page")]
    [Then(@"they refresh the page")]
    public void ThenTheyRefreshThePage()
    {
        _webDriver.Navigate().Refresh();
    }

    [Then(@"the cookie banner disappears")]
    public void ThenTheCookieBannerDisappears()
    {
        _cookieBanner.VerifyCookieBannerDisappears();
    }
    [Then(@"the user closes cookie banner")]
    public void ThenTheUserClosesCookieBanner()
    {
       _cookieBanner.Close();
    }
    [When(@"a user clicks on customize the cookies CTA")]
    public void WhenAUserClicksOnCustomizeTheCookiesCTA()
    {
        _cookieBanner.Customize();
    }

    [When(@"a user toggles on all cookies preferences")]
    public void WhenAUserTogglesOnAllCookiesPreferences()
    {
        _cookieBanner.ToggleOnOffCookies();
    }

    [When(@"the user saves its preferences")]
    public void WhenTheUserSavesItsPreferences()
    {
        _cookieBanner.SavePreferences();
    }

    [Then(@"the user clicks on Cookie policy")]
    public void ThenTheUserClicksOnCookiePolicy()
    {
        _cookieBanner.ClickCookiePolicyLink();
    }

    [Then(@"the user clicks on Cookie Settings")]
    public void ThenTheUserClicksOnCookieSettings()
    {
       _cookieBanner.ClickCookieSettings();
    }

    [Then(@"the cookie preferences should be all toggled on")]
    public void ThenTheCookiePreferencesShouldBeAllToggledOn()
    {
        _cookieBanner.VerifyToggleOnCookies();
    }
    [When(@"a user toggles off all cookies preferences")]
    public void WhenAUserTogglesOffAllCookiesPreferences()
    {
        _cookieBanner.ToggleOnOffCookies();
    }

    [Then(@"the cookie preferences should be all toggled off")]
    public void ThenTheCookiePreferencesShouldBeAllToggledOff()
    {
        _cookieBanner.VerifyToggleOffCookies();
    }

}