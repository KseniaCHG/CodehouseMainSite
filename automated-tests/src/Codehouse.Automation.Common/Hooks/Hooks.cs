using BoDi;
using Codehouse.Automation.Common.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace Codehouse.Automation.Common.Hooks;

[Binding]
public class Hooks
{
    private readonly IObjectContainer _container;
    private IWebDriver? _webDriver;

    public Hooks(IObjectContainer container)
    {
        _container = container;
    }

    [AfterScenario(Order = 2000)]
    public void AfterScenario()
    {
        _webDriver?.Quit();
        _webDriver = null;
    }

    [BeforeScenario(Order = 2000)]
    public void BeforeTestRun()
    {
        var selectedDriver = AppSettings.Instance.BrowserParams.TargetBrowser;
        var isHeadless = AppSettings.Instance.BrowserParams.Headless;

        if (string.IsNullOrEmpty(selectedDriver))
        {
            throw new ArgumentException("Selected web driver could not be found");
        }

        switch (selectedDriver.ToLowerInvariant())
        {
            case "chrome":
            {
                if (isHeadless)
                {
                    var chromeOption = new ChromeOptions();
                    chromeOption.AddArguments(Constants.ChromeHeadlessArgs);
                    _webDriver = new ChromeDriver(chromeOption);
                }
                else
                {
                    _webDriver = new ChromeDriver();
                    _webDriver.Manage().Window.Maximize();
                }

                break;
            }

            case "firefox":
                _webDriver = new FirefoxDriver();
                break;


            default:
            {
                throw new ArgumentException("Could not find selected web driver");
            }
        }

        _container.RegisterInstanceAs(_webDriver);
        _container.RegisterInstanceAs(AppSettings.Root);
    }

    [AfterScenario(Order = 1000)]
    public void TakeScreenshot(ScenarioContext scenarioContext, ScreenshotService screenshotService)
    {
        if (scenarioContext.TestError is not null)
        {
            screenshotService.Screenshot();
        }
    }
}