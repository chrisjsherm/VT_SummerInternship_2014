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

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.targetUser));
            targetUserLink.Click();

            var manageAreasCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='MANAGE-AREAS']"));
            if (!manageAreasCheckBox.Selected)
            {
                manageAreasCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var areasLinkVisible = IsAreasLinkVisible();

            try
            {
                Assert.IsTrue(areasLinkVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("ManageAreas_Granted_Then_Areas_Visible_Accessible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void ManageAreas_NotGranted_Then_Areas_NotVisible_NotAccessible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.targetUser));
            targetUserLink.Click();

            var manageAreasCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='MANAGE-AREAS']"));
            if (manageAreasCheckBox.Selected)
            {
                manageAreasCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var areasLinkVisible = IsAreasLinkVisible();

            try
            {
                Assert.IsFalse(areasLinkVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("ManageAreas_NotGranted_Then_Areas_NotVisible_NotAccessible");
                Assert.Fail(e.StackTrace);
            }
        }

        public bool IsAreasLinkVisible()
        {
            try
            {
                var manageAreasLink = uiTestSetup.Driver.FindElement(By.LinkText("Areas"));
                manageAreasLink.Click();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
