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
    //The test cases for a specific Fund Roles area not being granted will currently
    //fail. This is because something doesn't seem to be working correctly with these
    //Fund Roles authorization/filter rules.
    public class FundRolesTests
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
        public void EditOtherUsesOfFunds_Granted_Then_Browse_RequestingArea_OtherUsesOfFunds_Visible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var editOtherUsesOfFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='EDIT-O']"));
            if (!editOtherUsesOfFundsCheckBox.Selected)
            {
                editOtherUsesOfFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            
            var requestingAreaVisible = IsRequestingAreaVisibleInDropdownMenu("Other uses of funds");
            
            try
            {
                Assert.IsTrue(requestingAreaVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditOtherUsesOfFunds_Granted_Then_Browse_RequestingArea_OtherUsesOfFunds_Visible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void EditOtherUsesOfFunds_NotGranted_Then_Browse_RequestingArea_OtherUsesOfFunds_NotVisible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var editOtherUsesOfFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='EDIT-O']"));
            if (editOtherUsesOfFundsCheckBox.Selected)
            {
                editOtherUsesOfFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var requestingAreaVisible = IsRequestingAreaVisibleInDropdownMenu("Other uses of funds");

            try
            {
                Assert.IsFalse(requestingAreaVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditOtherUsesOfFunds_NotGranted_Then_Browse_RequestingArea_OtherUsesOfFunds_NotVisible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void EditPresident_Granted_Then_Browse_RequestingArea_President_Visible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var editOtherUsesOfFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='EDIT-S27']"));
            if (!editOtherUsesOfFundsCheckBox.Selected)
            {
                editOtherUsesOfFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var requestingAreaVisible = IsRequestingAreaVisibleInDropdownMenu("President");

            try
            {
                Assert.IsTrue(requestingAreaVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditPresident_Granted_Then_Browse_RequestingArea_President_Visible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void EditPresident_NotGranted_Then_Browse_RequestingArea_President_NotVisible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var editOtherUsesOfFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='EDIT-S27']"));
            if (editOtherUsesOfFundsCheckBox.Selected)
            {
                editOtherUsesOfFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var requestingAreaVisible = IsRequestingAreaVisibleInDropdownMenu("President");

            try
            {
                Assert.IsFalse(requestingAreaVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditPresident_NotGranted_Then_Browse_RequestingArea_President_NotVisible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void EditSeniorVicePresidentAndProvost_Granted_Then_Browse_RequestingArea_SeniorVicePresidentAndProvost_Visible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var editOtherUsesOfFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='EDIT-S26']"));
            if (!editOtherUsesOfFundsCheckBox.Selected)
            {
                editOtherUsesOfFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var requestingAreaVisible = IsRequestingAreaVisibleInDropdownMenu("Senior Vice President & Provost");

            try
            {
                Assert.IsTrue(requestingAreaVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditSeniorVicePresidentAndProvost_Granted_Then_Browse_RequestingArea_SeniorVicePresidentAndProvost_Visible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void EditSeniorVicePresidentAndProvost_NotGranted_Then_Browse_RequestingArea_SeniorVicePresidentAndProvost_NotVisible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var editOtherUsesOfFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='EDIT-S26']"));
            if (editOtherUsesOfFundsCheckBox.Selected)
            {
                editOtherUsesOfFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var requestingAreaVisible = IsRequestingAreaVisibleInDropdownMenu("Senior Vice President & Provost");

            try
            {
                Assert.IsFalse(requestingAreaVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditSeniorVicePresidentAndProvost_NotGranted_Then_Browse_RequestingArea_SeniorVicePresidentAndProvost_NotVisible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void EditVicePresidentForDevelopmentAndUniversityRelations_Granted_Then_Browse_RequestingArea_VicePresidentForDevelopmentAndUniversityRelations_Visible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var editOtherUsesOfFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='EDIT-S41']"));
            if (!editOtherUsesOfFundsCheckBox.Selected)
            {
                editOtherUsesOfFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var requestingAreaVisible = IsRequestingAreaVisibleInDropdownMenu("Vice President for Development & University Relations");

            try
            {
                Assert.IsTrue(requestingAreaVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditVicePresidentForDevelopmentAndUniversityRelations_Granted_Then_Browse_RequestingArea_VicePresidentForDevelopmentAndUniversityRelations_Visible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void EditVicePresidentForDevelopmentAndUniversityRelations_NotGranted_Then_Browse_RequestingArea_VicePresidentForDevelopmentAndUniversityRelations_NotVisible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var editOtherUsesOfFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='EDIT-S41']"));
            if (editOtherUsesOfFundsCheckBox.Selected)
            {
                editOtherUsesOfFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var requestingAreaVisible = IsRequestingAreaVisibleInDropdownMenu("Vice President for Development & University Relations");

            try
            {
                Assert.IsFalse(requestingAreaVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditVicePresidentForDevelopmentAndUniversityRelations_NotGranted_Then_Browse_RequestingArea_VicePresidentForDevelopmentAndUniversityRelations_NotVisible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void EditVicePresidentForFinanceAndCFO_Granted_Then_Browse_RequestingArea_VicePresidentForFinanceAndCFO_Visible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var editOtherUsesOfFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='EDIT-S46']"));
            if (!editOtherUsesOfFundsCheckBox.Selected)
            {
                editOtherUsesOfFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var requestingAreaVisible = IsRequestingAreaVisibleInDropdownMenu("Vice President for Finance & CFO");

            try
            {
                Assert.IsTrue(requestingAreaVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditVicePresidentForFinanceAndCFO_Granted_Then_Browse_RequestingArea_VicePresidentForFinanceAndCFO_Visible");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void EditVicePresidentForFinanceAndCFO_NotGranted_Then_Browse_RequestingArea_VicePresidentForFinanceAndCFO_NotVisible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(uiTestSetup.TargetUser()));
            targetUserLink.Click();

            var editOtherUsesOfFundsCheckBox = uiTestSetup.Driver.FindElement(By.XPath("//input[@value='EDIT-S46']"));
            if (editOtherUsesOfFundsCheckBox.Selected)
            {
                editOtherUsesOfFundsCheckBox.Click();
                var saveButton = uiTestSetup.Driver.FindElement(By.ClassName("text-button"));
                saveButton.Click();

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var keys = Keys.Control + Keys.Shift + "r";
                uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);
            }

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var requestingAreaVisible = IsRequestingAreaVisibleInDropdownMenu("Vice President for Finance & CFO");

            try
            {
                Assert.IsFalse(requestingAreaVisible);
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditVicePresidentForFinanceAndCFO_NotGranted_Then_Browse_RequestingArea_VicePresidentForFinanceAndCFO_NotVisible");
                Assert.Fail(e.StackTrace);
            }
        }

        public bool IsRequestingAreaVisibleInDropdownMenu(string _requestingAreaText)
        {
            try
            {
                var fundsLink = uiTestSetup.Driver.FindElement(By.LinkText("Funds"));
                fundsLink.Click();
                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var browseFundsLink = uiTestSetup.Driver.FindElement(By.LinkText("Browse"));
                browseFundsLink.Click();
                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                SelectElement area = new SelectElement(uiTestSetup.Driver.FindElement(By.TagName("select")));
                area.SelectByText(_requestingAreaText);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
