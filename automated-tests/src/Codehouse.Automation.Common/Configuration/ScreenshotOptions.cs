namespace Codehouse.Automation.Common.Configuration;

public record ScreenshotOptions
{
    public static readonly string SectionName = "screenshot";

    public string Directory { get; init; } = string.Empty;

    public string ArchiveDirectory { get; init; } = string.Empty;
}