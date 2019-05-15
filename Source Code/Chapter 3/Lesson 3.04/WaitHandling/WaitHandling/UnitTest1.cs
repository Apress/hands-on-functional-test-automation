using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace WaitHandling
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/");
            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(30));
            Assert.AreEqual(true,wait.Until(ExpectedConditions.TitleIs("Catalog - Microsoft.eShopOnWeb")));          
            IWebElement loginLink= wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Login")));
            loginLink.Click();
            Assert.AreEqual(true, wait.Until(ExpectedConditions.TitleContains("Log in")));
            Assert.AreEqual(true,wait.Until(ExpectedConditions.UrlToBe("http://eshop-testweb.azurewebsites.net/Account/SignIn")));
            IWebElement emailField= wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Email")));
            emailField.SendKeys("demouser@microsoft.com");
            Assert.AreEqual(true, wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Id("Email"), "demouser@microsoft.com")));
            IWebElement passwordField = wait.Until(ExpectedConditions.ElementExists(By.Id("Password")));
            passwordField.SendKeys("Pass@word1");          
            IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big")));
            Assert.AreEqual(true, wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big"), "LOG IN")));
            loginButton.Submit();
            Assert.AreEqual(true, wait.Until(ExpectedConditions.UrlContains("http://eshop-testweb")));
            Assert.AreEqual(true, wait.Until(ExpectedConditions.UrlToBe("http://eshop-testweb.azurewebsites.net/")));
        }
      
    }
}
