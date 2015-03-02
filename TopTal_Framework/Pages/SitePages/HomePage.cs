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

namespace TopTal_Framework.SitePages
{
    public class HomePage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.XPath, Using = "//*[@id='top']//div[contains(@class, 'bounce_modal-close_icon js-close_modal')]")]
        protected IWebElement closePopupBtn; 
        #endregion

        #region Check and do
        public void CheckAndCloseAddPopup()
        {
            log.Debug(string.Format("Checking if Advertising popup exist and closing it"));
            if (closePopupBtn.ExistsAndDisplayed())
                closePopupBtn.Click();
            Browser.ImplicitWait();
        } 
        #endregion

        public void Goto()
        {
            Browser.Goto(Config.DefaultURL);
            Browser.ImplicitWait();
        }

        public bool IsAt()
        {
            log.Info(string.Format("Checking title for [{0}] page", PagesXML.SitePages.Home.Name));

            bool result = Browser.Title.Contains(string.Format(PagesXML.SitePages.Home.Title));
            if (result)
            {
                log.Info(string.Format("Title for [{0}] page is correct", PagesXML.SitePages.Home.Name));
                return result;
            }

            log.Info(string.Format("Title for [{0}] page is not correct", PagesXML.SitePages.Home.Name));
            return false;
        }
    }
}
