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

namespace FoundPortalSeleniumTests
{
    [TestFixture]
    public class CreateNewFundTests
    {
        private IWebDriver driver;
        private string url = "https://test-foundation.vpfin.vt.edu/";
        private Regex r = new Regex(@"(?<equalSign>[=])(?<areaId>\S+)");
        private Match m;

        private void FirefoxSetup()
        {
            driver = new FirefoxDriver();
            driver.Url = url;
            driver.Manage().Window.Maximize();
        }

        private void ChromeSetup()
        {
            driver = new ChromeDriver(@"C:\WebDriverLibrary\");
            driver.Url = url;
            driver.Manage().Window.Maximize();
        }

        private void IeSetup()
        {
            driver = new InternetExplorerDriver(@"C:\WebDriverLibrary\");
            driver.Url = url;
            driver.Manage().Window.Maximize();
        }

        private void LoginCAS()
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            Credentials credentials = new Credentials();
            IWebElement usernameInput = driver.FindElement(By.Id("username"));
            IWebElement passwordInput = driver.FindElement(By.Id("password"));
            IWebElement submitButton = driver.FindElement(By.Name("submit"));

            usernameInput.SendKeys(credentials.Pid());
            passwordInput.SendKeys(credentials.WordPass());
            submitButton.Click();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        private void takeScreenShot(String _testName)
        {
            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            String currentDate = String.Concat(DateTime.Now.Month, ".", DateTime.Now.Day, ".", DateTime.Now.Year,
                "_", DateTime.Now.Hour, ".", DateTime.Now.Minute, ".", DateTime.Now.Second);
            String fileName = String.Concat(_testName, "_", currentDate);
            screenShot.SaveAsFile(@"C:\FundPortalScreenShots\" + fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }

        [TestCase]
        public void PresidentCreateANewFund()
        {
            try
            { 
                FirefoxSetup();
                LoginCAS();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                SelectElement area = new SelectElement(driver.FindElement(By.TagName("select")));
                area.SelectByText("President");

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var createANewFundLink = driver.FindElement(By.LinkText("Create a new fund"));
                createANewFundLink.Click();
                var currentUrl = driver.Url;

                m = r.Match(currentUrl);
                Assert.AreEqual("5272c67063623b20187f9a01", r.Match(currentUrl).Result("${areaId}"));
            }
            catch (Exception e)
            {
                takeScreenShot("PresidentCreateANewFund");
                Assert.Fail("Incorrect area id for Presdient");
                Console.WriteLine(e.StackTrace);
            }
            finally
            { 
                driver.Close();
            }
        }

        [TestCase]
        public void SeniorVicePresidentAndProvostCreateANewFund()
        {
            try
            {
                FirefoxSetup();
                LoginCAS();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                SelectElement area = new SelectElement(driver.FindElement(By.TagName("select")));
                area.SelectByText("Senior Vice President & Provost");

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var createANewFundLink = driver.FindElement(By.LinkText("Create a new fund"));
                createANewFundLink.Click();
                var currentUrl = driver.Url;

                m = r.Match(currentUrl);
                Assert.AreEqual("5272c6fe63623b1b54b6c142", r.Match(currentUrl).Result("${areaId}"));
            }
            catch (Exception e)
            {
                takeScreenShot("SeniorVicePresidentAndProvostCreateANewFund");
                Assert.Fail("Incorrect area id for Senior VP and Provost");
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                driver.Close();
            }
        }

        [TestCase]
        public void VicePresidentForDevelopmentAndUniversityRelationsCreateANewFund()
        {
            try
            {
                FirefoxSetup();
                LoginCAS();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                SelectElement area = new SelectElement(driver.FindElement(By.TagName("select")));
                area.SelectByText("Vice President for Development & University Relations");

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var createANewFundLink = driver.FindElement(By.LinkText("Create a new fund"));
                createANewFundLink.Click();
                var currentUrl = driver.Url;

                m = r.Match(currentUrl);
                Assert.AreEqual("5272c73d63623b1558f4a8a4", r.Match(currentUrl).Result("${areaId}"));
            }
            catch (Exception e)
            {
                takeScreenShot("VicePresidentForDevelopmentAndUniversityRelationsCreateANewFund");
                Assert.Fail("Incorrect area id for VP for Development and University Relations");
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                driver.Close();
            }
        }

        [TestCase]
        public void VicePresidentForFinanceAndCfoCreateANewFund()
        {
            try
            {
                FirefoxSetup();
                LoginCAS();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                SelectElement area = new SelectElement(driver.FindElement(By.TagName("select")));
                area.SelectByText("Vice President for Finance & CFO");

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var createANewFundLink = driver.FindElement(By.LinkText("Create a new fund"));
                createANewFundLink.Click();
                var currentUrl = driver.Url;

                m = r.Match(currentUrl);
                Assert.AreEqual("5272c78863623b20bcdcc238", r.Match(currentUrl).Result("${areaId}"));
            }
            catch (Exception e)
            {
                takeScreenShot("VicePresidentForFinanceAndCfoCreateANewFund");
                Assert.Fail("Incorrect area id for VP for Finance and Cfo");
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                driver.Close();
            }
        }

        [TestCase]
        public void OtherUsesOfFundsCreateANewFund()
        {
            try
            {
                FirefoxSetup();
                LoginCAS();

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                SelectElement area = new SelectElement(driver.FindElement(By.TagName("select")));
                area.SelectByText("Other uses of funds");

                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));

                var createANewFundLink = driver.FindElement(By.LinkText("Create a new fund"));
                createANewFundLink.Click();
                var currentUrl = driver.Url;

                m = r.Match(currentUrl);
                Assert.AreEqual("52a880c7b6c8f90cacf2ded0", r.Match(currentUrl).Result("${areaId}"));
            }
            catch (Exception e)
            {
                takeScreenShot("OtherUsesOfFundsCreateANewFund");
                Assert.Fail("Incorrect area id for Other Uses Of Funds");
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                driver.Close();
            }
        }
    }
}
