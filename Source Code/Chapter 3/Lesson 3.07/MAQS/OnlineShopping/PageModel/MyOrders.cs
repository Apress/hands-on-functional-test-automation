using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using Magenic.Maqs.Utilities.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for MyOrders
    /// </summary>
    public class MyOrders
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "/Order/Index";

        /// <summary>
        /// Selenium test object
        /// </summary>
        private SeleniumTestObject testObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyOrders" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public MyOrders(SeleniumTestObject testObject)
        {
            this.testObject = testObject;
        }

        /// <summary>
        /// Gets the sample element
        /// </summary>
        private LazyElement Sample
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#CSS_ID"), "SAMPLE"); }
        }

        /// <summary>
        /// Check if the page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public bool IsPageLoaded()
        {
            return this.Sample.Displayed;
        }

        ///<summary>
        ///
        /// </summary>
        public void VerifyMyOrderPage()
        {
            this.testObject.WebDriver.Wait().UntilPageLoad();
            Assert.AreEqual(true, this.testObject.WebDriver.FindElement(By.CssSelector(".container > h1")).Text.Equals("My Order History"));
        }
    }

}
