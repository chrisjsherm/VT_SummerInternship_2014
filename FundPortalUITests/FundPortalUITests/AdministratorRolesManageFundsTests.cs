using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundPortalUITests
{
    [TestFixture]
    public class AdministratorRolesManageFundsTests
    {
        private UITestSetup uiTestSetup = new UITestSetup();
        private string browseFundsUrl = "https://test-foundation.vpfin.vt.edu/#/funds/browse";
        private string manageFundsUrl = "";

        [SetUp]
        public void Init()
        {
            uiTestSetup.FirefoxSetup();
            uiTestSetup.LoginCAS();
        }

        [TearDown]
        public void Dispose()
        {
            uiTestSetup.Driver.Close();
        }

        [TestCase]
        public void ManageFunds_ManageUsers_ManageAreas_AllGranted_Then_Funds_Browse_Visible_Accessible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var fundsLink = uiTestSetup.Driver.FindElement(By.LinkText("Funds"));
            fundsLink.Click();
            var browseFundsLink = uiTestSetup.Driver.FindElement(By.LinkText("Browse"));
            browseFundsLink.Click();
            
            try
            {
                Assert.AreEqual(browseFundsUrl, uiTestSetup.Driver.Url);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("ManageFunds_ManageUsers_ManageAreas_AllGranted_Then_Funds_Browse_Visible_Accessible");
                Assert.Fail(e.StackTrace);
            }
        }
    }
}
