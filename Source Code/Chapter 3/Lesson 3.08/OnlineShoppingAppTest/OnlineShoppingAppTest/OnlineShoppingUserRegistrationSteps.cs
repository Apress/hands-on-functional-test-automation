using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace OnlineShoppingAppTest
{
    [Binding]
    public class OnlineShoppingUserRegistrationSteps
    {
        IWebDriver driver;
        WebDriverWait wait;
        [Given(@"user is at home page")]
        public void GivenUserIsAtHomePage()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        
        [Given(@"navigate to registration page")]
        public void GivenNavigateToRegistrationPage()
        {
           IWebElement loginLink= wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Login")));
            loginLink.Click();
            IWebElement registerNewUser = wait.Until(ExpectedConditions.ElementExists(By.LinkText("Register as a new user?")));
            registerNewUser.Click();
        }
        
        [When(@"user enter valid email password and confirm password")]
        public void WhenUserEnterValidEmailPasswordAndConfirmPassword()
        {
            IWebElement emailField= wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Email")));
            emailField.SendKeys("BNLL@kk.com");
            IWebElement passWord = wait.Until(ExpectedConditions.ElementExists(By.Id("Password")));
            passWord.SendKeys("Pass@123");
            IWebElement confirmPassWord = wait.Until(ExpectedConditions.ElementExists(By.Id("ConfirmPassword")));
            confirmPassWord.SendKeys("Pass@123");           
        }
        
        [When(@"click on the Signin button")]
        public void WhenClickOnTheSigninButton()
        {
            IWebElement registerButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big")));
            registerButton.Click();
        }
        [Then(@"user navigate to user account")]
        public void ThenUserNavigateToUserAccount()
        { 
            Assert.AreEqual(true, driver.FindElement(By.LinkText("My account")).Displayed);
        }

        [When(@"user logout from the user account")]
        public void WhenUserLogoutFromTheUserAccount()
        {      
            IWebElement logoutLink = driver.FindElement(By.LinkText("Log Out"));
            logoutLink.Click();
        }      
      
        [Then(@"myaccount link should not be displayed")]
        public void ThenMyaccountLinkShouldNotBeDisplayed()
        {
            Assert.AreEqual(false, driver.FindElements(By.LinkText("My account")).Count>0);
        }
    }
}


