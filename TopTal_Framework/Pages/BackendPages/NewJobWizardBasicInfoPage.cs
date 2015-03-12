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
    public class NewJobWizardBasicInfoPage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.XPath, Using = "//section[@class='content']//div[@class='title']//h2")]
        protected IWebElement title;

        [FindsBy(How = How.XPath, Using = "//div[@class='panel for-wizard']//div[contains(@class,'has-status_current')]//div[@class='step__text']")]
        private IWebElement stepTitle;

        [FindsBy(How = How.Id, Using = "new_job_title")]
        private IWebElement titleTxtBox;

        [FindsBy(How = How.Id, Using = "new_job_description")]
        private IWebElement descriptionTxtBox;

        [FindsBy(How = How.XPath, Using = "//div[@class='error is-big is-new_job for-textbox']")]
        private IWebElement titleErrMsg;

        [FindsBy(How = How.XPath, Using = "//div[@class='error is-big is-new_job for-textarea']")]
        private IWebElement descriptionErrMsg;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_name_and_description']//button[contains(@type,'submit')]")]
        protected IWebElement nextBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_name_and_description']//a[contains(@class,'is-cancel')]")]
        protected IWebElement cancelBtn;
        #endregion

        #region Click on
        public void ClickOnNext()
        {
            log.Debug(string.Format("Clicking on [Next] button"));
            nextBtn.Click();
            Browser.ImplicitWait(1000);
        }

        public void ClickOnCancel()
        {
            log.Debug(string.Format("Clicking on [Cancel] button"));
            cancelBtn.Click();
            Browser.ImplicitWait(1000);
        }
        #endregion

        #region Enter data
        public void EnterTitle(Job job)
        {
            log.Debug(string.Format("Entering job title [{0}]", job._Title));
            titleTxtBox.Clear();
            titleTxtBox.SendKeys(job._Title);
            Browser.ImplicitWait();
        }

        public void EnterDescription(Job job)
        {
            log.Debug(string.Format("Entering job description [{0}]", job._Description));
            descriptionTxtBox.Clear();
            descriptionTxtBox.SendKeys(job._Description);
            Browser.ImplicitWait();
        }
        #endregion

        public void PassThisStep(Job job)
        {
            log.Info(string.Format("Enter job details and passing this [{0}] step", PagesXML.BackEndPages.NewJobWizard.Step1_BasicInfo.Name));
            CheckIfCorrectPageAndNavigate();
            EnterTitle(job);
            EnterDescription(job);
            ClickOnNext();
        }

        #region Check and do
        private void CheckIfCorrectPageAndNavigate()
        {
            if (IsAtStep())
                return;
            else
                Goto();
        } 
        #endregion

        #region Checks
        public void CheckForErrors()
        {
            log.Info(string.Format("Checking for errors"));
            CheckIfCorrectPageAndNavigate();

            // empty
            log.Info(string.Format("Checking for empty data"));
            Job job = new Job() { _Title = "", _Description = "" };
            PassThisStep(job);
            Assert.AreEqual(PagesXML.BackEndPages.NewJobWizard.Step1_BasicInfo.EmptyTitleErr, titleErrMsg.Text.Trim());
            Assert.AreEqual(PagesXML.BackEndPages.NewJobWizard.Step1_BasicInfo.EmptyTitleErr, descriptionErrMsg.Text.Trim());

            // dissapears
            log.Info(string.Format("Checking if errors disappears"));
            job = JobGenerator.Generate();
            EnterTitle(job);
            EnterDescription(job);
            Assert.False(titleErrMsg.ExistsAndDisplayed());
            Assert.False(titleErrMsg.ExistsAndDisplayed());

            log.Info(string.Format("Validation errors are appear/disappear correctly"));
        }

        public bool IsAtStep()
        {
            log.Info(string.Format("Checking title for [{0}] page", PagesXML.BackEndPages.NewJobWizard.Step1_BasicInfo.Name));

            if (stepTitle.ExistsAndDisplayed())
            {
                bool result = stepTitle.Text.Contains(string.Format(PagesXML.BackEndPages.NewJobWizard.Step1_BasicInfo.Title));
                if (result)
                {
                    log.Info(string.Format("Title for [{0}] page is correct", PagesXML.BackEndPages.NewJobWizard.Step1_BasicInfo.Name));
                    return result;
                }
            }
            log.Info(string.Format("Title for [{0}] page is not correct", PagesXML.BackEndPages.NewJobWizard.Step1_BasicInfo.Name));
            return false;
        } 
        #endregion

        public void Goto()
        {
            log.Info(string.Format("Navigating to [{0}] page", PagesXML.BackEndPages.NewJobWizard.Name));
            Pages.BackendPages.TopMenu.ClickOnAddNewJob();
            Browser.ImplicitWait();
        }
    }
}
