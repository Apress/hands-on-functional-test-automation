using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext context;

        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }

        [TestMethod]
        [DataSource("MyDataSource")]
        public void AddNewUser()
        {
            string userEmail = context.DataRow["UserName"].ToString();
            string userpassword = context.DataRow["Password"].ToString();
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("--start-maximized");
            IWebDriver driver = new ChromeDriver(option);
            driver.Navigate().GoToUrl("http://eshop-testweb.azurewebsites.net/");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IWebElement loginLink = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Login")));
            loginLink.Click();
            IWebElement registerNewUser = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Register as a new user?")));
            registerNewUser.Click();
            IWebElement emailField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Email")));
            emailField.SendKeys(userEmail);
            IWebElement passWordField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("Password")));
            passWordField.SendKeys(userpassword);
            IWebElement confirmPassWordField = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("ConfirmPassword")));
            confirmPassWordField.SendKeys(userpassword);
            IWebElement registerButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(".btn.btn-default.btn-brand.btn-brand-big")));
            registerButton.Submit();
            IWebElement myAccountLink = wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("My account")));
            myAccountLink.Click();
            Assert.AreEqual(true, wait.Until(ExpectedConditions.TextToBePresentInElementValue(By.Id("Email"), userEmail)));

            driver.Quit();
        }

        [TestCleanup()]
        public void Cleanup_RemoveNewUser()
        {
            string userToDelete = context.DataRow["UserName"].ToString();

            string deleteUserScript = File.ReadAllText(@".\CleanupScripts\RemovenewUser.sql");
            deleteUserScript = string.Format(deleteUserScript, userToDelete);             

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SystemIdentityCon"].ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = deleteUserScript;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}






