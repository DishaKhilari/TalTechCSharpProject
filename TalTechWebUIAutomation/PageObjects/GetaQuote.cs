using TalTechWebUIAutomation.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalTechWebUIAutomation.PageObjects
{
    internal class GetaQuote : BasePage
    {
        public GetaQuote(IWebDriver driver) : base(driver)
        {

        }

        private IWebElement NavigationLink(string navlink) =>
            Driver.FindElement(By.XPath("//*[text()='"+navlink+"']"));

        public void AddBirthdate(string birthdate)
        {
            IWebElement question_birthdate() => Driver.FindElement(By.XPath("//*[text()='Date of birth']/following::input"));
            question_birthdate().Click();
            question_birthdate().SendKeys(birthdate);

        }

        public void AddIncome(string income)
        {
            IWebElement question_income() => Driver.FindElement(By.XPath("//*[text()='Annual Income (Excluding Superannuation)']/following::input"));
            question_income().SendKeys(income);

        }


        public void EnterDetails(string pageName, string question , string answer, string feildType) 
        {
         

            if (feildType == "TextInput")
            {
                IWebElement question_locator(string question) => Driver.FindElement(By.XPath("//*[text()='"+question+"']/following::input"));
                question_locator(question).SendKeys(answer);

            }
            else if (feildType == "TextArea")
            {
                IWebElement question_locator(string question) => Driver.FindElement(By.XPath("//*[text()='"+question+"']/following::textarea"));
                question_locator(question).SendKeys(answer);

            }
            else if (feildType == "PhoneNumber")
            {
                string l = answer;
                int number = Convert.ToInt32(l);
                IWebElement question_locator(string question) => Driver.FindElement(By.XPath("//*[text()='"+question+"']/following::input"));
                question_locator(question).SendKeys(Convert.ToString("0'"+number+"'"));
            }
            else if (feildType == "CheckBox")
            {
                
                IWebElement answer_locator(string question, string answer) => Driver.FindElement(By.XPath("//*[text()='"+question+"']/following::div[text()='"+answer+"']"));
                answer_locator(question, answer).Click();
            }
            else if (feildType == "Dropdownfill")
            {
                IWebElement question_locator(string question) => Driver.FindElement(By.XPath("//*[text()='"+question+"']/following::input"));
                IWebElement answer_locator(string question, string answer) => Driver.FindElement(By.XPath("//*[text()='"+question+"']/following::input[@value='"+answer+"']"));

                question_locator(question).Click();
                question_locator(question).SendKeys(answer);
                answer_locator(question, answer).Click();
            }
            else if (feildType == "DropDown")
            {
                IWebElement question_locator(string question) => Driver.FindElement(By.XPath("//*[text()='"+question+"']/following::select"));
                IWebElement answer_locator(string question, string answer) => Driver.FindElement(By.XPath("//*[text()='"+question+"']/following::option[@value='"+answer+"']"));

                question_locator(question).Click();
                answer_locator(question, answer).Click();
            }
        }

        public void ScrollDownClickLink(string navigation)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");

            NavigationLink(navigation).Click();
        }


    }
}


        