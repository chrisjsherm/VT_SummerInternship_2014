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

            var usersLinkVisible = IsUsersLinkVisible();

            try
            {
                Assert.IsTrue(usersLinkVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("ManageUsers_Granted_Then_Users_Visible_Accessible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void ManageUsers_NotGranted_Then_Users_NotVisible_NotAccessible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var manageUsersCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='MANAGE-USERS']"));
            if (manageUsersCheckBox.Selected)
            {
                manageUsersCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLinkVisible = IsUsersLinkVisible();

            try
            {
                Assert.IsFalse(usersLinkVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("ManageUsers_NotGranted_Then_Users_NotVisible_NotAccessible");
                Assert.Fail(e.StackTrace);
            }
        }

        public bool IsUsersLinkVisible()
        {
            try
            {
                var manageUsersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
                manageUsersLink.Click();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
