using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TalTechWebUIAutomation.PageObjects
{
    internal class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
                // Assuming you have initialized the WebDriver instance elsewhere in your test code
            IWebDriver driver = new ChromeDriver();

            // Create an instance of the MainPage class and pass the WebDriver instance
            MainPage mainPage = new MainPage(driver);

            // Now you can use the methods of the MainPage class to interact with the web pages

        }

        #region Locators

        public By PageLocator => By.CssSelector("#header > div.cf > div > div.c-logo > a > img");

        private IEnumerable<IWebElement> NavigationLinks =>
            Driver.FindElements(By.ClassName("nav-cf"));

        public IWebElement ActiveNavigationMenuItems(string link) =>
            Driver.FindElement(By.XPath("//a[contains(text(), "+link+")]"));

        private IWebElement PageHeader =>
            Driver.FindElement(By.CssSelector("head > title"));

        private IWebElement buttonClickDiv(string buttonName) =>
            Driver.FindElement(By.XPath("//button//span[text()='"+buttonName+"']"));

        private IWebElement buttonClick(string buttonName) =>
            Driver.FindElement(By.XPath("//button[text()='"+buttonName+"']"));

        private IWebElement submitbuttonClick(string buttonName) =>
            Driver.FindElement(By.XPath("//input[@value='"+buttonName+"']"));

        #endregion

        /// <summary>
        /// Verifies if Navigation Option is present on Main Page Header
        /// </summary>
        /// <param name="linkText"></param>
        /// <returns></returns>
        public bool? IsLinkPresentOnTheHeader(string linkText)
        {
            return NavigationLinks.First(navLink => navLink.Text.Trim() == linkText).Displayed;
        }

        public void SubmitButton(string buttonName)
        {
            submitbuttonClick(buttonName).Click();
        }
        public void ClickButtonDiv(string buttonName)
        {
            buttonClickDiv(buttonName).Click();
        }

        public void ClickButton(string buttonName)
        {
            buttonClick(buttonName).Click();
        }

        public void HoverOverTheNavigationMenu(string navLink)
        {
            Actions action = new Actions(Driver);

            var navigationItem = NavigationLinks.First(nav => nav.Text.Trim() == navLink);

            action.MoveToElement(navigationItem).Perform();
        }

        public void ClickNavigationMenuItem(string link)
        {
            ActiveNavigationMenuItems(link).Click();
        }

        /// <summary>
        /// This is common method to extract the Header Text of different pages
        /// to verify on clicking a navigation link user lands on it's page.
        /// Example: After clicking Freight user lands on Freight Page
        /// </summary>
        /// <returns></returns>
        public string GetPageHeader()
        {
            return PageHeader.Text;
        }
    }
}