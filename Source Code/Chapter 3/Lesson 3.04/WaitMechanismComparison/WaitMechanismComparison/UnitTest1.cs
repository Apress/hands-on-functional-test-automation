using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WaitMechanismComparison
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GoogleSearchWithoutWait()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("Selenium");
            IWebElement listValue = driver.FindElement(By.XPath("//div[@class='sbsb_a']//ul/li[2]"));
            listValue.Click();
        }

        [TestMethod]
        public void GoogleSearchImplicitWait()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("Selenium");
            IWebElement listValue = driver.FindElement(By.XPath("//div[@class='sbsb_a']//ul/li[2]"));
            listValue.Click();
        }

        [TestMethod]
        public void GoogleSearchWithThreadWait()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("Selenium");
            Thread.Sleep(5000);
            IWebElement listValue = driver.FindElement(By.XPath("//div[@class='sbsb_a']//ul/li[2]"));
            listValue.Click();
        }

        [TestMethod]
        public void GoogleSearchWithWait()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Navigate().GoToUrl("https://www.google.com");
            IWebElement searchField = driver.FindElement(By.Id("lst-ib"));
            searchField.SendKeys("Selenium");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='sbsb_a']//ul/li[2]")));
            IWebElement listValue = driver.FindElement(By.XPath("//div[@class='sbsb_a']//ul/li[2]"));
            listValue.Click();
        }
    }
}

