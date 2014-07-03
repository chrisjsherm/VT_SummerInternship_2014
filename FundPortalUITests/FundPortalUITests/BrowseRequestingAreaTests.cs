using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundPortalUITests
{
    public class BrowseRequestingAreaTests
    {
        private UITestSetup uiTestSetup = new UITestSetup();
        private bool sameData = false;

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
        public void BrowseRequestingAreaChange_Then_TableUpdates()
        {
            uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

            SelectElement area = new SelectElement(uiTestSetup.Driver.FindElement(By.TagName("select")));

            var areaOptionsCount = area.Options.Count();
            if (areaOptionsCount > 1)
            {
                Random rand = new Random();
                int index = rand.Next(0, area.Options.Count() - 1);

                area.SelectByIndex(index);

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                IWebElement browseFundsTable = uiTestSetup.Driver.FindElement(By.TagName("table")).
                    FindElement(By.TagName("tbody"));

                ReadOnlyCollection<IWebElement> table1Rows =
                    browseFundsTable.FindElements(By.TagName("tr"));

                int nextIndex;

                do
                {
                    nextIndex = rand.Next(0, area.Options.Count() - 1);
                } while (index == nextIndex);

                area.SelectByIndex(nextIndex);

                uiTestSetup.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                browseFundsTable = uiTestSetup.Driver.FindElement(By.TagName("table")).
                    FindElement(By.TagName("tbody"));

                ReadOnlyCollection<IWebElement> table2Rows =
                    browseFundsTable.FindElements(By.TagName("tr"));

                sameData = (table1Rows.Count == table2Rows.Count) && !table1Rows.Except(table2Rows).Any();

                try
                {
                    Assert.IsFalse(sameData);
                }
                catch (Exception e)
                {
                    uiTestSetup.takeScreenShot(
                        "BrowseRequestingAreaChange_Then_TableUpdates");
                    Assert.Fail(e.StackTrace);
                }
            }
            else
            {
                Assert.Inconclusive(
                    "Must be more than one area option available in dropdown menu. Grant more fund role privileges.");
            }
        }
    }
}
