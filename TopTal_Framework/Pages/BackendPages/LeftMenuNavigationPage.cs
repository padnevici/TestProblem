using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace TopTal_Framework.BackendPages
{
    public class LeftMenuNavigationPage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.XPath, Using = "//div[@class='sidebar__inner']//a[contains(@href,'/platform/company/dashboard')]")]
        protected IWebElement overviewLnk;

        [FindsBy(How = How.XPath, Using = "//div[@class='sidebar__inner']//a[contains(@href,'/platform/company/jobs')]")]
        protected IWebElement jobsLnk; 
        #endregion

        #region Click on
        public void ClickOnOverview()
        {
            log.Debug(string.Format("Clicking on [Overview] link"));
            overviewLnk.Click();
            Browser.ImplicitWait();
        }

        public void ClickOnJobs()
        {
            log.Debug(string.Format("Clicking on [Jobs] link"));
            jobsLnk.Click();
            Browser.ImplicitWait();
        } 
        #endregion
    }
}
