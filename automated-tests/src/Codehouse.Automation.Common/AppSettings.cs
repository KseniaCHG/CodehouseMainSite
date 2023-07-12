using System.Configuration;
using Codehouse.Automation.Common.Configuration;
using Microsoft.Extensions.Configuration;

namespace Codehouse.Automation.Common;

public class AppSettings
{
    static AppSettings()
    {
        Root = new ConfigurationBuilder()
            .AddJsonFile("sharedsettings.json")
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{GetCurrentEnvironment()}.json")
            .Build();
        Instance = new AppSettings();
        Root.Bind(Instance);
    }

    public static IConfiguration Root { get; }

    public static AppSettings Instance { get; }

    public BrowserParamsOptions BrowserParams { get; init; } = new();

    public ScreenshotOptions Screenshot { get; init; } = new();

    public DefaultsOptions Defaults { get; init; } = new();
    private static string GetCurrentEnvironment()
    {
        var path = Path.GetFullPath(Directory.GetCurrentDirectory());
        var reverseList = path.Split(Path.DirectorySeparatorChar).Reverse().ToList();
        var environmentIndex = reverseList.FindIndex(i => i.Equals("bin")) - 1;
        return reverseList[environmentIndex];
    }
}