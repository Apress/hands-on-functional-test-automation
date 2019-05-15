
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Winium;

namespace Winium_Demo
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DesktopOptions opt = new DesktopOptions();
            opt.ApplicationPath = @"C:\Windows\explorer.exe";
            WiniumDriver driver = new WiniumDriver(@"F:\Selenium-C#\Winium-Demo\Winium-Demo\bin\Debug", opt);
            driver.FindElementByName("Desktop").Click();
            driver.FindElementByName("Search Box").Click();
            driver.FindElementByName("Search Box").SendKeys("BookWork");
        }
    }
}


