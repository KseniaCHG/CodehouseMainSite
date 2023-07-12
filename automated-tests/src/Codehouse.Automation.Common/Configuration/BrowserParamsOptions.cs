namespace Codehouse.Automation.Common.Configuration;

public record BrowserParamsOptions
{
    public static readonly string SectionName = "browserParams";

    public string TargetBrowser { get; init; } = string.Empty;

    public bool Headless { get; init; }
}
