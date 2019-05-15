using Magenic.Maqs.BaseSeleniumTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageModel;

// TODO: Add reference to object model
// using PageModel;

namespace Tests
{
    /// <summary>
    /// TestClass test class
    /// </summary>
    [TestClass]
    public class TestClass : BaseSeleniumTest
    {
        /// <summary>
        /// Registered user login
        /// </summary>
        [TestMethod]
        public void LoginToUserAccount()
        {
            HomePage homePage = new HomePage(this.TestObject);
            homePage.NavigateToHomePage();
            Assert.AreEqual(true,homePage.IsPageLoaded());
            homePage.ClickonLoginLink();
            UserLoginPage loginToSite = new UserLoginPage(this.TestObject);
            loginToSite.LogInToUserAccount();
            homePage.SelectMyOrdersLink();
            MyOrders myOrders = new MyOrders(this.TestObject);
            myOrders.VerifyMyOrderPage();
        }
    }
}
