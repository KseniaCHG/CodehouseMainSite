﻿using Codehouse.Automation.MainSite.PageObjects;
using Codehouse.Automation.MainSite.Services;
using FluentAssertions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Codehouse.Automation.MainSite.Steps;

[Binding]
internal class CookieBannerSteps
{
    private readonly CookieBanner _cookieBanner;
    private readonly SleepService _sleepService;

    public CookieBannerSteps(CookieBanner cookieBanner, SleepService sleepService)
    {
        _cookieBanner = cookieBanner;
        _sleepService = sleepService;
    }
    
    [Then(@"the cookie banner appears")]
    public void ThenTheCookieBannerAppears()
    {
        _cookieBanner.ValidateIsDisplayed();
    }

    [When(@"a user accepts the cookies")]
    public void WhenAUserAcceptsTheCookies()
    {
        _cookieBanner.Accept();
    }

    [Then(@"the cookie banner disappears")]
    public void ThenTheCookieBannerDisappears()
    {
        _cookieBanner.ValidateIsNotDisplayed();
    }

    [Then(@"the cookie banner does not appear")]
    public void ThenTheCookieBannerDoesNotAppear()
    {
        _sleepService.ThreadSleep(TimeSpan.FromSeconds(3));
        _cookieBanner.ValidateIsNotDisplayed();
    }

    [Then(@"the correct cookie banner cookies are received")]
    public void ThenTheCorrectCookieBannerCookiesAreReceived()
    {
        _cookieBanner.ValidateCorrectCookies();
    }

    [When(@"a user closes the cookies")]
    public void WhenAUserClosesTheCookies()
    {
        _cookieBanner.Close();
    }

    [Then(@"the correct cookie banner cookies are not received")]
    public void ThenTheCorrectCookieBannerCookiesAreNotReceived()
    {
        _cookieBanner.ValidateNotCorrectCookies();
    }

}