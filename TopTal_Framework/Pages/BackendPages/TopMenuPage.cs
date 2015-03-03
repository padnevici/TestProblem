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
    public class TopMenuPage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.XPath, Using = "//header//a[contains(@href, '/platform/company/jobs/new')]")]
        protected IWebElement addNewJobBtn;

        [FindsBy(How = How.XPath, Using = "//header//div[contains(@class,'top_nav__user_name g-text_overflow')]")]
        protected IWebElement userNameNav; 
        #endregion

        #region Click on
        public void ClickOnAddNewJob()
        {
            log.Debug(string.Format("Clicking on [Add New Job] button"));
            addNewJobBtn.Click();
            Browser.ImplicitWait();
        } 
        #endregion

        #region Checks
        public bool IsLoggedIn()
        {
            log.Info(string.Format("Checking if logged in successfully"));
            return userNameNav.ExistsAndDisplayed();
        }  
        #endregion
    }
}
