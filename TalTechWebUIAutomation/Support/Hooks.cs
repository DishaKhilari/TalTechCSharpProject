using System;
using System.IO;
using System.Reflection;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Drawing.Imaging;
using OpenQA.Selenium.Interactions;


namespace TalTechWebUIAutomation.Support
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "TestResults"));
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            GetDriver();
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null)
            {
                TakeScreenshot(scenarioContext);
            }

            _driver?.Dispose();
        }

        /// <summary>
        /// Take screenshot of the page when test script is failing
        /// </summary>
        /// <param name="scenarioContext"></param>
        private void TakeScreenshot(ScenarioContext scenarioContext)
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
                byte[] screenshotAsByteArray = ss.AsByteArray;
                string screenshotFileName = $"{scenarioContext.ScenarioInfo.Title}.png";
                string screenshotFilePath = Path.Combine(Environment.CurrentDirectory, screenshotFileName);
                File.WriteAllBytes(screenshotFilePath, screenshotAsByteArray);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        /// <summary>
        /// Create and initialize driver
        /// </summary>
        /// <returns></returns>

        public IWebDriver GetDriver()
        {
            // Get browser to be used for testing from appsettings.json
            var browser = TestConfiguration.GetSectionAndValue("BrowserOptions", "Browser");
            if (_driver == null)
            {
                switch (browser)//test

                {
                    case "Chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--window-size=1920,1080");
                        chromeOptions.AddArgument("--user-agent={}");
                        chromeOptions.AddArgument("start-maximized"); // open Browser in maximized mode
                        chromeOptions.AddArgument("disable-infobars"); // disabling infobars
                        chromeOptions.AddArgument("--disable-extensions"); // disabling extensions
                        chromeOptions.AddArgument("--disable-gpu"); // applicable to windows os only
                        chromeOptions.AddArgument("--disable-dev-shm-usage"); // overcome limited resource problems
                        chromeOptions.AddArgument("--no-sandbox");


                        // Get value for headless option from appsettings.json

                        var headless = TestConfiguration.GetSectionAndValue("BrowserOptions", "Headless");

                        if (headless == "true")
                        {
                            chromeOptions.AddArgument("--headless");
                        }

                        _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),chromeOptions);
                        break;
                }

                try
                {
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    _driver.Manage().Cookies.DeleteAllCookies();
                    _driver.Manage().Window.Maximize();
                    _objectContainer.RegisterInstanceAs(_driver);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message + " Driver failed to initialize");
                }
            }

            return _driver;
        }
    }
}
