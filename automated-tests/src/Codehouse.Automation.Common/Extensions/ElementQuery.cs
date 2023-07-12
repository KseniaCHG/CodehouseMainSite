using OpenQA.Selenium;

namespace Codehouse.Automation.Common.Extensions;

public record ElementQuery
{
    public static ElementQuery Clickable => new()
    {
        Displayed = true,
        Enabled = true
    };

    public bool? Displayed { get; init; }

    public bool? Enabled { get; init; }

    public bool Compare(IWebElement element)
    {
        if (Displayed is not null && !element.Displayed.Equals(Displayed))
        {
            return false;
        }

        if (Enabled is not null && !element.Enabled.Equals(Enabled))
        {
            return false;
        }

        return true;
    }
}