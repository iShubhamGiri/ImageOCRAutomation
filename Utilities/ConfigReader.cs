using System.Configuration;

namespace ImageOCRAutomation.Utilities
{
    public static class ConfigReader
    {
        public static string Get(string key) =>
            ConfigurationManager.AppSettings[key];

        public static string ScreenshotPath =>
            ConfigurationManager.AppSettings["ScreenshotPath"];
    }
}
