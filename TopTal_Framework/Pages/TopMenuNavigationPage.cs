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

namespace TopTal_Framework
{
    public class TopMenuNavigationPage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.XPath, Using = "//*[@id='top']//a[contains(@href, 'users/login')]")]
        protected IWebElement closePopupBtn; 
        #endregion

        #region Click on
        public void ClickOnLogin()
        {
            log.Debug(string.Format("Clicking on [Login] button"));
            Pages.SitePages.Home.CheckAndCloseAddPopup();
            closePopupBtn.Click();
            Browser.ImplicitWait();
        } 
        #endregion
    }
}
