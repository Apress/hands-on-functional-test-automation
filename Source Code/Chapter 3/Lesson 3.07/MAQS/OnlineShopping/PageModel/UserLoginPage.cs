using Magenic.Maqs.BaseSeleniumTest;
using Magenic.Maqs.BaseSeleniumTest.Extensions;
using Magenic.Maqs.Utilities.Helper;
using OpenQA.Selenium;

namespace PageModel
{
    /// <summary>
    /// Page object for LoginToSite
    /// </summary>
    public class UserLoginPage
    {
        /// <summary>
        /// The page url
        /// </summary>
        private static readonly string PageUrl = SeleniumConfig.GetWebSiteBase() + "Account/SignIn";

        /// <summary>
        /// Selenium test object
        /// </summary>
        private SeleniumTestObject testObject;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginPage" /> class.
        /// </summary>
        /// <param name="testObject">The selenium test object</param>
        public UserLoginPage(SeleniumTestObject testObject)
        {
            this.testObject = testObject;
        }

        /// <summary>
        /// Gets the email field element
        /// </summary>
        private LazyElement EmailField
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#Email"), "User email fileld"); }
        }

        /// <summary>
        /// Gets the password field element
        /// </summary>
        private LazyElement PassowrdField
        {
            get { return new LazyElement(this.testObject, By.CssSelector("#Password"), "User password fileld"); }
        }

        /// <summary>
        /// Gets the Login field element
        /// </summary>
        private LazyElement LoginButton
        {
            get { return new LazyElement(this.testObject, By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big"), "Lonin button"); }
        }

        /// <summary>
        /// Check if the page has been loaded
        /// </summary>
        /// <returns>True if the page was loaded</returns>
        public bool IsPageLoaded()
        {
            return this.EmailField.Displayed;
        }

        ///<summary>
        ///SignIn
        /// </summary>
        public void LogInToUserAccount()
        {
            EmailField.SendKeys("demouser@microsoft.com");
            PassowrdField.SendKeys("Pass@word1");
            LoginButton.Click();         
        }
    }

}
