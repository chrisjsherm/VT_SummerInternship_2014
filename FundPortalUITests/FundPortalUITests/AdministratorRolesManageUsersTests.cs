using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundPortalUITests
{
    public class AdministratorRolesManageUsersTests
    {
        private UITestSetup uiTestSetup = new UITestSetup();
        private string usersUrl = "https://test-foundation.vpfin.vt.edu/#/users/browse";

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
        public void ManageUsers_Granted_Then_Users_Visible_Accessible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            try
            {
                Assert.AreEqual(usersUrl, uiTestSetup.Driver.Url);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("ManageFunds_ManageUsers_ManageAreas_AllGranted_Then_Users_Visible_Accessible");
                Assert.Fail(e.StackTrace);
            }
        }
    }
}
