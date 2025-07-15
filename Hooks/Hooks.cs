using System.IO;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using ImageOCRAutomation.Utilities;

namespace ImageOCRAutomation.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            string screenshotPath = ConfigReader.ScreenshotPath;
            if (!Directory.Exists(screenshotPath))
                Directory.CreateDirectory(screenshotPath);

            ContextManager.ClearContext();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (ScenarioContext.Current.TryGetValue("driver", out object driverObj))
            {
                ((IWebDriver)driverObj).Quit();
            }
        }
    }
}
