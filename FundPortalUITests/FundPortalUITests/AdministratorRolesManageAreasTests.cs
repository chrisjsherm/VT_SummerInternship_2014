using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundPortalUITests
{
    public class AdministratorRolesManageAreasTests
    {
        private UITestSetup uiTestSetup = new UITestSetup();
        private string areasUrl = "https://test-foundation.vpfin.vt.edu/#/areas/browse";

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
        public void ManageAreas_Granted_Then_Areas_Visible_Accessible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Areas"));
            usersLink.Click();

            try
            {
                Assert.AreEqual(areasUrl, uiTestSetup.Driver.Url);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("ManageFunds_ManageUsers_ManageAreas_AllGranted_Then_Areas_Visible_Accessible");
                Assert.Fail(e.StackTrace);
            }
        }
    }
}
