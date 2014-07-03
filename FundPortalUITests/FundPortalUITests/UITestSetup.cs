using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundPortalUITests
{
    sealed internal class UITestSetup
    {
        public IWebDriver Driver { get; set; }
        private string url;
        private string targetUser = "brands6";

        public string TargetUser()
        {
            return targetUser;
        }

        public UITestSetup()
        {
            this.url = "https://test-foundation.vpfin.vt.edu/";
        }

        public void FirefoxSetup()
        {
            Driver = new FirefoxDriver();
            Driver.Url = this.url;
            Driver.Manage().Window.Maximize();
        }

        public void ChromeSetup()
        {
            Driver = new ChromeDriver(@"C:\WebDriverLibrary\");
            Driver.Url = this.url;
            Driver.Manage().Window.Maximize();
        }

        public void IeSetup()
        {
            Driver = new InternetExplorerDriver(@"C:\WebDriverLibrary\");
            Driver.Url = this.url;
            Driver.Manage().Window.Maximize();
        }

        internal void LoginCAS()
        {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
            ICredentials credentials = new Credentials();
            IWebElement usernameInput = Driver.FindElement(By.Id("username"));
            IWebElement passwordInput = Driver.FindElement(By.Id("password"));
            IWebElement submitButton = Driver.FindElement(By.Name("submit"));

            usernameInput.SendKeys(credentials.GetPid());
            passwordInput.SendKeys(credentials.GetWordPass());
            submitButton.Click();
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        public void takeScreenShot(String _testName)
        {
            Screenshot screenShot = ((ITakesScreenshot)Driver).GetScreenshot();
            String currentDate = String.Concat(DateTime.Now.Month, ".", DateTime.Now.Day, ".", DateTime.Now.Year,
                "_", DateTime.Now.Hour, ".", DateTime.Now.Minute, ".", DateTime.Now.Second);
            String fileName = String.Concat(_testName, "_", currentDate);
            screenShot.SaveAsFile(@"C:\FundPortalScreenShots\" + fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
