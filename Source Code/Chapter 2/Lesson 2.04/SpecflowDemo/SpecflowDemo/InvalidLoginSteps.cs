using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace SpecflowDemo
{
    [Binding]
    public class InvalidLoginSteps
    {
        IWebDriver driver;
        WebDriverWait wait;
        [Given(@"User is at the home page")]
        public void GivenUserIsAtTheHomePage()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            driver = new ChromeDriver(option);
            driver.Navigate().GoToUrl("https://github.com");
        }
        
        [Given(@"Navigate to login page")]
        public void GivenNavigateToLoginPage()
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.FindElement(By.LinkText("Sign in")).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlContains("https://github.com/login"));
        }
        
        [When(@"User enter incorrect user name and password")]
        public void WhenUserEnterIncorrectUserNameAndPassword()
        {
            driver.FindElement(By.Id("login_field")).SendKeys("ABC");
            driver.FindElement(By.Id("password")).SendKeys("123");

        }
        
        [When(@"Click on the signin button")]
        public void WhenClickOnTheSigninButton()
        {
            driver.FindElement(By.Name("commit")).Click();
        }
        
        [Then(@"Validation message should display and browser should close")]
        public void ThenValidationMessageShouldDisplayAndBrowserShouldClose()
        {
            IWebElement validationMsg = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("js-flash-container")));
            StringAssert.Contains("Incorrect username or password", validationMsg.Text);
            driver.Dispose();
        }
    }
}
