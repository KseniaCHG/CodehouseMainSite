namespace Codehouse.Automation.Common.Configuration;

public record DefaultsOptions
{
    public double TimeoutInSeconds { get; init; }

    public double PollingIntervalInSeconds { get; init; }
}