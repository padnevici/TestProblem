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
    public class NewJobWizardConfirmPage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.XPath, Using = "//section[@class='content']//div[@class='title']//h2")]
        protected IWebElement title;

        [FindsBy(How = How.XPath, Using = "//div[@class='panel for-wizard']//div[contains(@class,'has-status_current')]//div[@class='step__text']")]
        private IWebElement stepTitle;

        [FindsBy(How = How.Id, Using = "new_job_accept_review")]
        private IWebElement reviewCheckBox;

        [FindsBy(How = How.Id, Using = "new_job_accept_deposit")]
        private IWebElement depositCheckBox;

        [FindsBy(How = How.Id, Using = "new_job_accept_interview")]
        private IWebElement interviewCheckBox;

        string errorMsgsXpath = "//div[@class='error is-big is-new_job is-confirmation']";

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_confirmation']//div[@data-step='required_skills']")]
        protected IWebElement backBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_confirmation']//button[contains(@type,'submit')]")]
        protected IWebElement nextBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_confirmation']//a[contains(@class,'is-cancel')]")]
        protected IWebElement cancelBtn;
        #endregion

        #region Click on
        private string _js = "document.getElementById('{0}').click()";

        public void ClickTopTalReview()
        {
            if (!reviewCheckBox.Selected)
                log.Debug(string.Format("Checking on [TopTal will review] checkbox"));
            else
                log.Debug(string.Format("Unchecking on [TopTal will review] checkbox"));

            string js = string.Format(_js, reviewCheckBox.GetAttribute("id"));
            Browser.ExecuteJS(js);
            Browser.ImplicitWait();
        }

        public void ClickDeposit()
        {
            if (!depositCheckBox.Selected)
                log.Debug(string.Format("Checking on [Deposit] checkbox"));
            else
                log.Debug(string.Format("Unchecking on [Deposit] checkbox"));

            string js = string.Format(_js, depositCheckBox.GetAttribute("id"));
            Browser.ExecuteJS(js);
            Browser.ImplicitWait();
        }

        public void ClickInterview()
        {
            if (!interviewCheckBox.Selected)
                log.Debug(string.Format("Checking on [3 days for interview] checkbox"));
            else
                log.Debug(string.Format("Unchecking on [3 days for interview] checkbox"));

            string js = string.Format(_js, interviewCheckBox.GetAttribute("id"));
            Browser.ExecuteJS(js);
            Browser.ImplicitWait();
        }

        public void ClickOnBack()
        {
            log.Debug(string.Format("Clicking on [Back] button"));
            backBtn.Click();
            Browser.ImplicitWait(1000);
        }

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

        public void PassThisStep()
        {
            log.Info(string.Format("Confirmating job and passing this [{0}] step", PagesXML.BackEndPages.NewJobWizard.Step4_Confirm.Name));
            ClickTopTalReview();
            ClickDeposit();
            ClickInterview();
            ClickOnNext();
        }

        #region Checks
        public void CheckForErrors()
        {
            log.Info(string.Format("Checking for errors"));

            // empty
            log.Info(string.Format("Checking for empty data"));
            ClickOnNext();
            List<IWebElement> elements = Browser.WebDriver.FindElements(By.XPath(errorMsgsXpath)).ToList();
            foreach (var element in elements)
                Assert.AreEqual(PagesXML.BackEndPages.NewJobWizard.Step4_Confirm.errorMsg, element.Text.Trim());


            // dissapears
            log.Info(string.Format("Checking if errors disappears"));
            ClickTopTalReview();
            ClickDeposit();
            ClickInterview();

            elements = Browser.WebDriver.FindElements(By.XPath(errorMsgsXpath)).ToList();

            if (elements.Count > 0)
                Assert.Fail("Error messages are still present");

            log.Info(string.Format("Validation errors are appear/disappear correctly"));
        }

        public bool IsAtStep()
        {
            log.Info(string.Format("Checking title for [{0}] page", PagesXML.BackEndPages.NewJobWizard.Step4_Confirm.Name));

            if (stepTitle.ExistsAndDisplayed())
            {
                bool result = stepTitle.Text.Contains(string.Format(PagesXML.BackEndPages.NewJobWizard.Step4_Confirm.Title));
                if (result)
                {
                    log.Info(string.Format("Title for [{0}] page is correct", PagesXML.BackEndPages.NewJobWizard.Step4_Confirm.Name));
                    return result;
                }
            }
            log.Info(string.Format("Title for [{0}] page is not correct", PagesXML.BackEndPages.NewJobWizard.Step4_Confirm.Name));
            return false;
        }
        #endregion
    }
}
