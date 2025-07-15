using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ImageOCRAutomation.Utilities
{
    public static class DriverFactory
    {
        public static IWebDriver InitializeDriver()
        {
            var options = new ChromeOptions();
            string driverPath = ConfigReader.Get("DriverPath");
            var driver = new ChromeDriver(driverPath, options);

            if (bool.Parse(ConfigReader.Get("MaximizeWindow")))
                driver.Manage().Window.Maximize();

            return driver;
        }
    }
}
