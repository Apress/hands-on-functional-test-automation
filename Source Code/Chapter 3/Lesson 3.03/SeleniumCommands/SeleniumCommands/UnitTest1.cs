using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace SeleniumCommands
{
    [TestClass]
    public class UnitTest1
    {
        #region commands

        [TestMethod]
        public void TestGetAttribute()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
            IWebElement email = driver.FindElement(By.Id("Email"));
            var value = email.GetAttribute("type");
            Console.WriteLine(value);
        }

        [TestMethod]
        public void TestGetCssValue()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(options);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/Account/SignIn");
            IWebElement email = driver.FindElement(By.Id("Email"));
            var value = email.GetCssValue("background-color");
            Console.WriteLine(value);
        }

        [TestMethod]
        public void TestClickAndHold()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            driver.SwitchTo().Frame(0);
            IWebElement drag = driver.FindElement(By.Id("draggable"));
            IWebElement drop = driver.FindElement(By.Id("droppable"));
            Actions action = new Actions(driver);
            action.ClickAndHold(drag).Build().Perform();
            action.MoveToElement(drop).Build().Perform();
        }

        [TestMethod]
        public void TestDragAndDrop()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            driver.SwitchTo().Frame(0);
            IWebElement drag = driver.FindElement(By.Id("draggable"));
            IWebElement drop = driver.FindElement(By.Id("droppable"));
            Actions action = new Actions(driver);
            action.DragAndDrop(drag, drop).Build().Perform();
        }

        [TestMethod]
        public void TestDragAndDropOffset()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            driver.SwitchTo().Frame(0);
            IWebElement drag = driver.FindElement(By.Id("draggable"));
            Actions action = new Actions(driver);
            action.DragAndDropToOffset(drag, 100, 100).Build().Perform();
        }

        #endregion
    }
}
