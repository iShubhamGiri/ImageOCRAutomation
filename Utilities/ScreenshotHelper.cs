using OpenQA.Selenium;
using System;
using System.IO;

namespace ImageOCRAutomation.Utilities
{
    public static class ScreenshotHelper
    {
        public static string CaptureScreenshot(IWebDriver driver, string fileNamePrefix)
        {
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            string directory = ConfigReader.ScreenshotPath;

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string filePath = Path.Combine(directory, $"{fileNamePrefix}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            ss.SaveAsFile(filePath, ScreenshotImageFormat.Png);

            return filePath;
        }
    }
}
