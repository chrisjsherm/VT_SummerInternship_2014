﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundPortalUITests
{
    public class FundRolesTests
    {
        private UITestSetup uiTestSetup = new UITestSetup();
        private string targetUser = "brands6";

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
        public void EditOtherUsesOfFunds_Granted_Then_Browse_RequestingArea_EditOtherUsesOfFunds_Visible_Accessible()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var usersLink = uiTestSetup.Driver.FindElement(By.LinkText("Users"));
            usersLink.Click();

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var targetUserLink = uiTestSetup.Driver.FindElement(By.PartialLinkText(targetUser));
            targetUserLink.Click();

            

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)uiTestSetup.Driver;
            var keys = Keys.Control + Keys.Shift + "r";
            uiTestSetup.Driver.FindElement(By.TagName("body")).SendKeys(keys);

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            try
            {
                
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot(
                    "EditOtherUsesOfFunds_Granted_Then_Browse_RequestingArea_EditOtherUsesOfFunds_Visible_Accessible");
                Assert.Fail(e.StackTrace);
            }
        }

        
    }
}
