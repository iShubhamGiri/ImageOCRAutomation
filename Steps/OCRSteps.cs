using TechTalk.SpecFlow;
using ImageOCRAutomation.Models;
using ImageOCRAutomation.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Tesseract;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ImageOCRAutomation.Steps
{
    [Binding]
    public class OCRSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;
        private string currentAlias;
        private string capturedText;

        public OCRSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the following OCR test data")]
        public void GivenTheFollowingOCRTestData(Table table)
        {
            foreach (var row in table.Rows)
            {
                string alias = row["Alias"];
                var testData = OCRHelper.PopulateModelFromResx<OCRModel>("TestData", alias);
                ContextManager.AddToCollection(alias, testData);
            }
        }

        [Given(@"I launch the browser")]
        public void GivenILaunchTheBrowser()
        {
            driver = DriverFactory.InitializeDriver();
            _scenarioContext["driver"] = driver;
        }

        [Given(@"I navigates to the Invoice Page")]
        public void GivenINavigatesToTheInvoicePage()
        {
            if (currentAlias == null)
                currentAlias = "OCR1"; // Default first alias

            var testData = ContextManager.GetFromCollection<OCRModel>(currentAlias);
            driver.Navigate().GoToUrl(testData.URL);
        }

        [When(@"I capture the invoice image on the page")]
        public void WhenICaptureTheInvoiceImage()
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string filePath = $"{ConfigReader.ScreenshotPath}Invoice_{currentAlias}.png";
            screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            _scenarioContext["screenshotPath"] = filePath;
        }

        [When(@"I extract text from the captured image")]
        public void WhenIExtractTextFromTheCapturedImage()
        {
            var filePath = _scenarioContext["screenshotPath"].ToString();
            using var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default);
            using var img = Pix.LoadFromFile(filePath);
            using var page = engine.Process(img);
            capturedText = page.GetText();
        }

        [Then(@"the extracted text should contain `([^`]*)`")]
        public void ThenTheExtractedTextShouldContain(string token)
        {
            var parts = token.Split('.');
            string alias = parts[0];
            string property = parts[1];

            currentAlias = alias;

            var model = ContextManager.GetFromCollection<OCRModel>(alias);
            var expected = model.GetType().GetProperty(property).GetValue(model).ToString();

            Assert.IsTrue(capturedText.Contains(expected), $"Expected '{expected}' but found '{capturedText}'");
        }
    }
}
