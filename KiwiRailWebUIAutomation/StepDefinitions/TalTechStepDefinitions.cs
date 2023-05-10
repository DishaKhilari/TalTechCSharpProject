using TalTechWebUIAutomation.PageObjects;
using TalTechWebUIAutomation.Support;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TalTechWebUIAutomation.StepDefinitions
{
    [Binding]
    public sealed class TalTechStepDefinitions
    {
        private readonly MainPage _mainPage;
        private readonly GetaQuote _getQuotePage;
        public TalTechStepDefinitions(IWebDriver driver)
        {
            _mainPage = new MainPage(driver);
            _getQuotePage = new GetaQuote(driver);
        }
        [Given(@"I navigate to the TAL Website")]
        public void GivenINavigateToTheTALlWebsite()
        {
            // Gets the website URL from appsettings.json
            _mainPage.Navigate(TestConfiguration.GetSectionAndValue("Settings", "url"));
        }

        [When(@"I hover over the Primary Navigation menu : (.*)")]
        public void WhenIHoverOverThePrimaryNavigationMenu(string navMenu)
        {
            _mainPage.HoverOverTheNavigationMenu(navMenu);
        }

        [When(@"I click the menu item : (.*)")]
        public void WhenIClickTheMenuItem(string item)
        {
            _mainPage.ClickNavigationMenuItem(item);
        }

        [Then(@"I verify that I am on the page : (.*)")]
        public void ThenIVerifyThatIAmOnThePage(string pageHeader)
        {
            Assert.AreEqual(pageHeader, _mainPage.GetPageHeader());
        }

        [Then(@"I verify that I am on TAL Website Main Page")]
        public void ThenIVerifyThatIAmOnTALWebsiteMainPage()
        {
            var pageLocator = _mainPage.PageLocator;
            _mainPage.IsPageLoaded(pageLocator);
        }
        

        [Then(@"I click on (.*) at the top")]
        public void ThenIClickonNavigationLink(string NavigationMenu)
        {
            _mainPage.ClickNavigationMenuItem(NavigationMenu);
        }

        [Then(@"User add birthdate ""([^""]*)""")]
        public void ThenUserAddBirthdate(string dateString)
        {
            _getQuotePage.AddBirthdate(dateString);
        }
        [Then(@"User add income ""([^""]*)""")]
        public void ThenUserAddIncome(string income)
        {
            _getQuotePage.AddIncome(income);
        }
        [Then(@"User click on ""([^""]*)"" button")]
        public void ThenUserClickOnButton(string buttonName)
        {
            _mainPage.ClickButtonDiv(buttonName);
        }
        [Then(@"User click on ""([^""]*)"" big button")]
        public void ThenUserClickOnBigButton(string buttonName)
        {
            _mainPage.ClickButton(buttonName);
        }


        [Then(@"User add details '([^']*)' page")]
        public void ThenUserAddDetailsPage(string pageName, Table table)
        {
            IEnumerable<dynamic> details = table.CreateDynamicSet();
            foreach (var detail in details)
            {
                
                    _getQuotePage.EnterDetails(pageName, (string)detail.Question, (string)Convert.ToString(detail.Answer), (string)detail.Field_Type);
      
            }
        }

        [Then(@"User click on ""([^""]*)"" submit button")]
        public void ThenUserClickOnSubmitButton(string buttonName)
        {
            _mainPage.SubmitButton(buttonName);
        }

        [Then(@"I verify the main header navigation links are:")]
        public void ThenIVerifyTheMainHeaderNavigationLinksAre(Table links)
        {
            foreach (var link in links.Rows)
            {
                Assert.IsTrue(_mainPage.IsLinkPresentOnTheHeader(link[0]));
            }
        }

        [Then(@"Scroll down to the bottom of the page and click the ""([^""]*)""")]
        public void ThenScrollDownToTheBottomOfThePageAndClickThe(string navigationLink)
        {
            _getQuotePage.ScrollDownClickLink(navigationLink);

        }






    }
}
