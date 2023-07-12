namespace Codehouse.Automation.Common.Support;

public class WaitSettings
{
    public TimeSpan? TimeoutOverride { get; init; } = null;

    public TimeSpan? PollingIntervalOverride { get; init; } = null;

    public Type[] AdditionalIgnoredExceptionTypes { get; init; } = Array.Empty<Type>();
}