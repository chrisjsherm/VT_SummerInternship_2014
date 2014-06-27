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
        public void ManageFunds_Granted_Then_Funds_Browse_Manage_Visible_Accessible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var manageFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='MANAGE-FUNDS']"));
            if (!manageFundsCheckBox.Selected)
            {
                manageFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();
                
                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var fundsDropdownMenuVisible = IsFundsDropdownVisible();

            try
            {
                Assert.IsTrue(fundsDropdownMenuVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "ManageFunds_ManageUsers_ManageAreas_AllGranted_Then_Funds_Browse_Visible_Accessible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void ManageFunds_NotGranted_Then_Funds_Browse_Manage_NotVisible_NotAccessible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var manageFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='MANAGE-FUNDS']"));
            if (manageFundsCheckBox.Selected)
            {
                manageFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();
                
                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var fundsDropdownMenuVisible = IsFundsDropdownVisible();

            try
            {
                Assert.IsFalse(fundsDropdownMenuVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "ManageUsers_ManageAreas_Granted_Then_Funds_Browse_NotVisible_NotAccessible");
                Assert.Fail(e.StackTrace);
            }
        }

        public bool IsFundsDropdownVisible()
        {
            try
            {
                var fundsLink = uiTestSetup.Driver.FindElement(By.LinkText("Funds"));
                fundsLink.Click();
                var browseFundsLink = uiTestSetup.Driver.FindElement(By.LinkText("Browse"));
                browseFundsLink.Click();
                fundsLink.Click();
                var manageFundsLink = uiTestSetup.Driver.FindElement(By.LinkText("Manage"));
                manageFundsLink.Click();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
