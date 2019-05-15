using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Locators
{
    [TestClass]
    public class UnitTest1
    {
        #region Locators
        [TestMethod]
        public void TestLocatorID()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
            IWebElement email = driver.FindElement(By.Id("Email"));
            email.SendKeys("demouser@microsoft.com");

        }

        [TestMethod]
        public void TestLocatorName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
            IWebElement password = driver.FindElement(By.Name("Password"));
            password.SendKeys("Pass@word1");
        }
            
        [TestMethod]
        public void TestLocatorClassName()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/");
            IWebElement basketImage = driver.FindElement(By.ClassName("esh-basketstatus-badge"));
            basketImage.Click();
        }

        [TestMethod]
        public void TestCSSSelector()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
            IWebElement submitButton = driver.FindElement(By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big"));
            submitButton.Submit();
        }

        [TestMethod]
        public void TestLinkText()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            IWebElement loginLink = driver.FindElement(By.LinkText("Login"));
            loginLink.Click();
        }

        [TestMethod]
        public void TestTagName()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            IWebElement tagElement = driver.FindElement(By.TagName("select"));
            tagElement.Click();
        }

        [TestMethod]
        public void TestXPath()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            IWebElement loginLink = driver.FindElement(By.LinkText("Login"));
            loginLink.Click();
            IWebElement email = driver.FindElement(By.Id("Email"));
            email.SendKeys("demouser@microsoft.com");
            IWebElement password = driver.FindElement(By.Name("Password"));
            password.SendKeys("Pass@word1");
            IWebElement submitButton = driver.FindElement(By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big"));
            submitButton.Submit();
            IWebElement myAccount = driver.FindElement(By.XPath("//*[@id='logoutForm']/section[2]/a[2]/div"));
            myAccount.Click();
        }

        [TestMethod]
        public void TestPartialLinkText()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
            IWebElement registerNewUser = driver.FindElement(By.PartialLinkText("Register as a"));
            registerNewUser.Click();
        }

        [TestMethod]

        public void TestSelectors()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            IWebElement loginLink = driver.FindElement(By.LinkText("Login"));
            loginLink.Click();
            IWebElement email = driver.FindElement(By.Id("Email"));
            email.SendKeys("demouser@microsoft.com");
            IWebElement password = driver.FindElement(By.Name("Password"));
            password.SendKeys("Pass@word1");
            IWebElement submitButton = driver.FindElement(By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big"));
            submitButton.Submit();
            IWebElement myAccount = driver.FindElement(By.CssSelector("#logoutForm > section:nth-of-type(2) > a:nth-of-type(2) > div"));
            myAccount.Click();
        }

        [TestMethod]
        public void CssSelectorSubChild()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            IWebElement loginLink = driver.FindElement(By.CssSelector(".esh-identity-section a"));
            loginLink.Click();
        }

        [TestMethod]
        public void CssSelectorUsingID()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            IWebElement loginLink = driver.FindElement(By.LinkText("Login"));
            loginLink.Click();
            IWebElement email = driver.FindElement(By.CssSelector("#Email"));
            email.SendKeys("demouser@microsoft.com");
        }

        [TestMethod]
        public void CssSelectorNextSibling()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net");
            IWebElement basketIcon = driver.FindElement(By.CssSelector(".row > section:nth-of-type(3) > a"));
            basketIcon.Click();
        }

        [TestMethod]
        public void CssSelectorAttributeValue()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");          
            IWebElement submitButton = driver.FindElement(By.CssSelector("button[type='submit']"));
            submitButton.Submit();
        }
        #endregion

    }
}
