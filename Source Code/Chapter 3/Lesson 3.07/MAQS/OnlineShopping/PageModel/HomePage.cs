using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using Magenic.Maqs.Utilities.Helper;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for HomePage
    /// </summary>
    public class HomePage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase();

        /// <summary>
        /// Selenium test object
        /// </summary>
        private SeleniumTestObject testObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public HomePage(SeleniumTestObject testObject)
        {
            this.testObject = testObject;
        }

        /// <summary>
        /// Gets the Login Link element
        /// </summary>
        private LazyElement LoginLink
        {
            get { return new LazyElement(this.testObject, By.LinkText("Login"), "Login Link in home page"); }
        }

        /// <summary>
        /// Gets the myorders Link element
        /// </summary>
        private LazyElement MyOrdersLink
        {
            get { return new LazyElement(this.testObject, By.LinkText("My orders"), "MyOrders Link disply in home page after login to user account"); }
        }
        /// <summary>
        /// Check if the page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public bool IsPageLoaded()
        {
            return this.LoginLink.Displayed;
        }


        ///<summary>
        ///Navigate to home page
        /// </summary>
        public void NavigateToHomePage()
        {
            this.testObject.WebDriver.Navigate().GoToUrl(PageUrl);
        }


        ///<summary>
        ///Click on LoginLink to move to login page
        /// </summary>
        public void ClickonLoginLink()
        {
            LoginLink.Click();          
        }

        ///<summary>
        ///Navigate to myorders
        /// </summary>
        public void SelectMyOrdersLink()
        {
            this.testObject.WebDriver.Wait().ForClickableElement(By.LinkText("My orders"));
            MyOrdersLink.Click();
        }
    }

}
