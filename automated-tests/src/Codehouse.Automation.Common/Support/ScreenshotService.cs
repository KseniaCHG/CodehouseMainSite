using OpenQA.Selenium;
using TechTalk.SpecFlow.Infrastructure;

namespace Codehouse.Automation.Common.Support;
public class ScreenshotService
{
    private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
    private readonly IWebDriver _webDriver;

    public ScreenshotService(IWebDriver webDriver, ISpecFlowOutputHelper specFlowOutputHelper)
    {
        _webDriver = webDriver;
        _specFlowOutputHelper = specFlowOutputHelper;
    }

    public void Screenshot()
    {
        string screenshotFolderName = AppSettings.Instance.Screenshot.Directory;
        string archivedScreenshotFolderName = AppSettings.Instance.Screenshot.ArchiveDirectory;

        var screenshot = ((ITakesScreenshot)_webDriver).GetScreenshot();
        var screenshotId = $"{Guid.NewGuid():D}";
        var fileName = Path.ChangeExtension(screenshotId, "png");
        var currentDirectory = Directory.GetCurrentDirectory();

        var screenshotDirectoryPath = Path.Combine(currentDirectory, screenshotFolderName);
        Directory.CreateDirectory(screenshotDirectoryPath);
        var screenshotFullPath = Path.Combine(screenshotDirectoryPath, fileName);
        SaveScreenshot(screenshot, screenshotFullPath);
        var screenshotRelativePath = Path.GetRelativePath(currentDirectory, screenshotFullPath);
        _specFlowOutputHelper.AddAttachment(screenshotRelativePath);

        var archiveScreenshotDirectoryPath = Path.Combine(currentDirectory, archivedScreenshotFolderName);
        Directory.CreateDirectory(archiveScreenshotDirectoryPath);
        var archiveScreenshotFullPath = Path.Combine(archiveScreenshotDirectoryPath, fileName);
        SaveScreenshot(screenshot, archiveScreenshotFullPath);
        _specFlowOutputHelper.WriteLine($"Screenshot '{new Uri(archiveScreenshotFullPath)}'");
    }

    private static void SaveScreenshot(Screenshot screenshot, string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
    }
}