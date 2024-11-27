using System;
using System.IO;
using OpenQA.Selenium;
using Serilog;

namespace AutomationFramework.Core.Utilities
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string scenarioName)
        {
            try
            {
                // Ensure the screenshot is saved in the "Screenshots" folder inside the project directory
                var screenshotsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Screenshots");

                if (!Directory.Exists(screenshotsFolder))
                {
                    Directory.CreateDirectory(screenshotsFolder);
                }

                // Create a timestamped filename for the screenshot
                var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                var fileName = $"{scenarioName}_{timestamp}.png";
                var filePath = Path.Combine(screenshotsFolder, fileName);

                // Capture and save the screenshot
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filePath);

                // Log the screenshot location
                Log.Information($"Screenshot saved at: {filePath}");
                return filePath;
            }
            catch (Exception ex)
            {
                Log.Error($"Error capturing screenshot: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
