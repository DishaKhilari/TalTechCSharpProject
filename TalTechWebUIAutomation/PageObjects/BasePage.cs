using System;
using OpenQA.Selenium;

namespace TalTechWebUIAutomation.PageObjects
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public string GetPageUrl()
        {
            return Driver.Url;
        }

        public bool IsPageLoaded(By pageLocator)
        {
            try
            {
                return Driver.FindElement(pageLocator).Displayed;
            }
            catch (Exception)
            {
                Console.WriteLine($@"No page found with locator: {pageLocator}");
                throw;
            }
        }
    }
}
