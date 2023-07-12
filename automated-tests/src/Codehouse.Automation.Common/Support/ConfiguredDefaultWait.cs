using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Codehouse.Automation.Common.Support;

internal class ConfiguredDefaultWait<T> : DefaultWait<T>
{
    public ConfiguredDefaultWait(T source)
        : this(new SystemClock(), source, new WaitSettings())
    {
    }

    public ConfiguredDefaultWait(T source, WaitSettings settings)
        : this(new SystemClock(), source, settings)
    {
    }

    private ConfiguredDefaultWait(
        IClock clock,
        T source,
        WaitSettings settings)
        : base(source, clock)
    {
        Timeout = For.DefaultTimeout;
        PollingInterval = For.DefaultDelay;
        var ignoredExceptions = new[] { typeof(NotFoundException) };
        ignoredExceptions = ignoredExceptions.Concat(settings.AdditionalIgnoredExceptionTypes).ToArray();
        IgnoreExceptionTypes(ignoredExceptions);
    }
}