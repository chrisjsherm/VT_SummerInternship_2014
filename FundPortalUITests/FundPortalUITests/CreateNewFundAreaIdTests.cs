using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace FundPortalUITests
{
    [TestFixture]
    public class CreateNewFundAreaIdTests
    {
        private UITestSetup uiTestSetup = new UITestSetup();
        private Regex r = new Regex(@"(?<equalSign>[=])(?<areaId>\S+)");
        private Match m;

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
        public void PresidentCreateANewFund()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            SelectElement area = new SelectElement(uiTestSetup.Driver.FindElement(By.TagName("select")));
            area.SelectByText("President");

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var createANewFundLink = uiTestSetup.Driver.FindElement(By.LinkText("Create a new fund"));
            createANewFundLink.Click();
            var currentUrl = uiTestSetup.Driver.Url;

            m = r.Match(currentUrl);

            try
            {
                Assert.AreEqual("5272c67063623b20187f9a01", r.Match(currentUrl).Result("${areaId}"));
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("PresidentCreateANewFund");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void SeniorVicePresidentAndProvostCreateANewFund()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            SelectElement area = new SelectElement(uiTestSetup.Driver.FindElement(By.TagName("select")));
            area.SelectByText("Senior Vice President & Provost");

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var createANewFundLink = uiTestSetup.Driver.FindElement(By.LinkText("Create a new fund"));
            createANewFundLink.Click();
            var currentUrl = uiTestSetup.Driver.Url;

            m = r.Match(currentUrl);
            try
            {
                Assert.AreEqual("5272c6fe63623b1b54b6c142", r.Match(currentUrl).Result("${areaId}"));
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("SeniorVicePresidentAndProvostCreateANewFund");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void VicePresidentForDevelopmentAndUniversityRelationsCreateANewFund()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            SelectElement area = new SelectElement(uiTestSetup.Driver.FindElement(By.TagName("select")));
            area.SelectByText("Vice President for Development & University Relations");

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var createANewFundLink = uiTestSetup.Driver.FindElement(By.LinkText("Create a new fund"));
            createANewFundLink.Click();
            var currentUrl = uiTestSetup.Driver.Url;

            m = r.Match(currentUrl);
            try
            {
                Assert.AreEqual("5272c73d63623b1558f4a8a4", r.Match(currentUrl).Result("${areaId}"));
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("VicePresidentForDevelopmentAndUniversityRelationsCreateANewFund");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void VicePresidentForFinanceAndCfoCreateANewFund()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            SelectElement area = new SelectElement(uiTestSetup.Driver.FindElement(By.TagName("select")));
            area.SelectByText("Vice President for Finance & CFO");

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var createANewFundLink = uiTestSetup.Driver.FindElement(By.LinkText("Create a new fund"));
            createANewFundLink.Click();
            var currentUrl = uiTestSetup.Driver.Url;

            m = r.Match(currentUrl);
            try
            {
                Assert.AreEqual("5272c78863623b20bcdcc238", r.Match(currentUrl).Result("${areaId}"));
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("VicePresidentForFinanceAndCfoCreateANewFund");
                Assert.Fail(e.StackTrace);
            }
        }

        [TestCase]
        public void OtherUsesOfFundsCreateANewFund()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            SelectElement area = new SelectElement(uiTestSetup.Driver.FindElement(By.TagName("select")));
            area.SelectByText("Other uses of funds");

            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            var createANewFundLink = uiTestSetup.Driver.FindElement(By.LinkText("Create a new fund"));
            createANewFundLink.Click();
            var currentUrl = uiTestSetup.Driver.Url;

            m = r.Match(currentUrl);
            try
            {
                Assert.AreEqual("52a880c7b6c8f90cacf2ded0", r.Match(currentUrl).Result("${areaId}"));
            }
            catch (Exception e)
            {
                uiTestSetup.takeScreenShot("OtherUsesOfFundsCreateANewFund");
                Assert.Fail(e.StackTrace);
            }
        }
    }
}
