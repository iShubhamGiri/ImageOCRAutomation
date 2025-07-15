using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace ImageOCRAutomation.Utilities
{
    public static class DriverFactory
    {
        [ThreadStatic]
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            return driver ??= CreateDriver();
        }

        private static IWebDriver CreateDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            var driverPath = ConfigReader.Get("DriverPath") ?? Directory.GetCurrentDirectory();
            var timeout = TimeSpan.FromSeconds(Convert.ToInt32(ConfigReader.Get("ImplicitWait") ?? "10"));

            var chromeDriver = new ChromeDriver(driverPath, options);
            chromeDriver.Manage().Timeouts().ImplicitWait = timeout;
            return chromeDriver;
        }

        public static void QuitDriver()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
