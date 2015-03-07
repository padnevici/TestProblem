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
using TopTal_Framework.Generators;
using NUnit.Framework;

namespace TopTal_Framework.BackendPages
{
    public class NewJobWizardWhatIsNextPage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.XPath, Using = "//section[@class='content']//div[@class='title']//h2")]
        protected IWebElement title;

        [FindsBy(How = How.XPath, Using = "//div[@class='panel for-wizard']//div[contains(@class,'has-status_current')]//div[@class='step__text']")]
        private IWebElement stepTitle;

        [FindsBy(How = How.XPath, Using = "//*[@class='wizard_complete for-new_job']//div[@class='wizard_complete__title']")]
        protected IWebElement completeTitle;

        [FindsBy(How = How.XPath, Using = "//*[@class='form__controls_submit']//a[text()='Jump to Job']")]
        protected IWebElement jumbToJobBtn;
        #endregion

        #region Click on
        public void ClickOnJumpToJob()
        {
            log.Debug(string.Format("Clicking on [Back] button"));
            jumbToJobBtn.Click();
            Browser.ImplicitWait();
        }
        #endregion

        #region Checks
        public bool IsAtStep()
        {
            log.Info(string.Format("Checking title for [{0}] page", PagesXML.BackEndPages.NewJobWizard.Step5_TechCall.Name));

            if (stepTitle.ExistsAndDisplayed())
            {
                bool resultStepTitle = stepTitle.Text.Contains(string.Format(PagesXML.BackEndPages.NewJobWizard.Step5_TechCall.Title));
                bool resultMessageTitle = completeTitle.Text.Contains(string.Format(PagesXML.BackEndPages.NewJobWizard.Step5_TechCall.successTitle));
                if (resultStepTitle && resultMessageTitle)
                {
                    log.Info(string.Format("Title for [{0}] page is correct", PagesXML.BackEndPages.NewJobWizard.Step5_TechCall.Name));
                    return resultStepTitle;
                }
            }
            log.Info(string.Format("Title for [{0}] page is not correct", PagesXML.BackEndPages.NewJobWizard.Step5_TechCall.Name));
            return false;
        }
        #endregion
    }
}
