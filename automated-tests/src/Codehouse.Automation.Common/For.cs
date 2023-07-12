namespace Codehouse.Automation.Common;

public static class For
{
    public static TimeSpan DefaultTimeout => TimeSpan.FromSeconds(AppSettings.Instance.Defaults.TimeoutInSeconds);

    public static TimeSpan DefaultDelay => TimeSpan.FromSeconds(AppSettings.Instance.Defaults.PollingIntervalInSeconds);

    public static TimeSpan TwoSeconds => TimeSpan.FromSeconds(2);
}