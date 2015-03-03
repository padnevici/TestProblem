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
    public class JobsPage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.XPath, Using = "//section[@class='content']//div[@class='title']//h2")]
        protected IWebElement title;
        #endregion

        public void Goto()
        {
            log.Info(string.Format("Navigating to [{0}] page", PagesXML.BackEndPages.Jobs.Name));
            Pages.BackendPages.LeftMenuNavigation.ClickOnJobs();
            Browser.ImplicitWait();
        }

        public bool IsAt()
        {
            log.Info(string.Format("Checking title for [{0}] page", PagesXML.BackEndPages.Jobs.Name));

            if (title.ExistsAndDisplayed())
            {
                bool result = title.Text.Contains(string.Format(PagesXML.BackEndPages.Jobs.Title));
                if (result)
                {
                    log.Info(string.Format("Title for [{0}] page is correct", PagesXML.BackEndPages.Jobs.Name));
                    return result;
                }
            }
            log.Info(string.Format("Title for [{0}] page is not correct", PagesXML.BackEndPages.Jobs.Name));
            return false;
        }
    }
}
