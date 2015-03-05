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
    public class NewJobWizardDetailsPage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.XPath, Using = "//section[@class='content']//div[@class='title']//h2")]
        protected IWebElement title;

        [FindsBy(How = How.XPath, Using = "//div[@class='panel for-wizard']//div[contains(@class,'has-status_current')]//div[@class='step__text']")]
        private IWebElement stepTitle;

        [FindsBy(How = How.Id, Using = "new_job_commitment")]
        private IWebElement desiredCommitmentDropDown;

        [FindsBy(How = How.Id, Using = "job_prefer_timezone_no")]
        private IWebElement timeZonePreferenceNoRadioBtn;

        [FindsBy(How = How.Id, Using = "job_prefer_timezone_yes")]
        private IWebElement timeZonePreferenceYesRadioBtn;

        [FindsBy(How = How.Id, Using = "new_job_time_zone_name")]
        private IWebElement timeZoneDropDown;

        [FindsBy(How = How.Id, Using = "new_job_hours_overlap")]
        private IWebElement hoursOfOverlapDropDown;

        [FindsBy(How = How.Id, Using = "new_job_start_date")]
        private IWebElement desiredStartDateTxtBox;

        [FindsBy(How = How.Id, Using = "new_job_estimated_length")]
        private IWebElement estimatedLengthDropDown;

        [FindsBy(How = How.Id, Using = "new_job_languages")]
        private IWebElement spokenLanguagesTxtBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_details']//div[@class='ui-tags js-suggests-multiple__items_container']")]
        private IWebElement addedSpokenLanguages;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_details']//div[@class='base_error is-big is-new_job is-wide js-form__main_error']/span")]
        private IWebElement languagesErrMsg;

        [FindsBy(How = How.XPath, Using = "//div[@class='error is-big is-new_job is-wide for-textbox']")]
        private IWebElement desiredStartDateErrMsg;

        [FindsBy(How = How.XPath, Using = "//div[@class='error is-big is-new_job is-wide']")]
        private IWebElement estimatedLengthErrMsg;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_details']//div[@data-step='name_and_description']")]
        protected IWebElement backBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_details']//button[contains(@type,'submit')]")]
        protected IWebElement nextBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_details']//a[contains(@class,'is-cancel')]")]
        protected IWebElement cancelBtn;
        #endregion

        #region Click on
        public void ClickOnNext()
        {
            log.Debug(string.Format("Clicking on [Next] button"));
            nextBtn.Click();
            Browser.ImplicitWait();
        }

        public void ClickOnCancel()
        {
            log.Debug(string.Format("Clicking on [Cancel] button"));
            cancelBtn.Click();
            Browser.ImplicitWait();
        }

        public void ClickOnBack()
        {
            log.Debug(string.Format("Clicking on [Back] button"));
            backBtn.Click();
            Browser.ImplicitWait();
        }
        #endregion

        #region Enter/Select data
        public void SelectDesiredCommitment(Job job)
        {
            log.Debug(string.Format("Selecting desired commitment [{0}]", job._DesiredCommitment));
            SelectElement select = new SelectElement(desiredCommitmentDropDown);
            select.SelectByValue(job._DesiredCommitment.ToString());
            Browser.ImplicitWait();
        }

        public void SelectDesiredTimeZonePreference(Job job)
        {
            log.Debug(string.Format("Selecting time zone preference [{0}]", job._TimeZonePreference));
            if (job._TimeZonePreference)
                timeZonePreferenceYesRadioBtn.Click();
            else
                timeZonePreferenceNoRadioBtn.Click();
            Browser.ImplicitWait();
        }

        public void SelectTimeZone(Job job)
        {
            if (job._TimeZonePreference)
            {
                log.Debug(string.Format("Selecting time zone [{0}]", job._TimeZone.GetValue()));
                SelectElement select = new SelectElement(timeZoneDropDown);
                select.SelectByValue(job._TimeZone.GetValue());
                Browser.ImplicitWait();
            }
        }

        public void SelectHouseOverlap(Job job)
        {
            if (job._TimeZonePreference)
            {
                if (job._HoursOverlap != Job.HoursOverlap.NoPreference)
                {
                    log.Debug(string.Format("Selecting hours overlap [{0}]", job._HoursOverlap));
                    SelectElement select = new SelectElement(hoursOfOverlapDropDown);
                    select.SelectByValue(job._HoursOverlap.GetValue());
                    Browser.ImplicitWait();
                }
            }
        }

        public void EnterDesiredStartDate(Job job)
        {
            EnterDesiredStartDate(job._DesiredStartDate.ToString("yyyy-MM-dd"));
        }

        public void EnterDesiredStartDate(string date)
        {
            log.Debug(string.Format("Entering desired date [{0}]", date));
            desiredStartDateTxtBox.Clear();
            desiredStartDateTxtBox.SendKeys(date);
            Browser.ImplicitWait();
        }

        public void SelectEstimatedLength(Job job)
        {
            log.Debug(string.Format("Selecting estimate length [{0}]", job._EstimatedLength));
            SelectElement select = new SelectElement(estimatedLengthDropDown);
            select.SelectByValue(job._EstimatedLength.GetValue());
            Browser.ImplicitWait();
        }

        public void EnterLanguages(Job job)
        {
            log.Debug(string.Format("Entering spoken languages"));
            foreach (Job.SpokenLanguages lang in job._SpokenLanguages)
            {
                spokenLanguagesTxtBox.Clear();
                spokenLanguagesTxtBox.SendKeys(lang.ToString());
                Browser.ImplicitWait();
                spokenLanguagesTxtBox.SendKeys(Keys.Enter);
            }
        }
        #endregion

        public void PassThisStep(Job job)
        {
            log.Info(string.Format("Enter job details and passing this [{0}] step", PagesXML.BackEndPages.NewJobWizard.Step2_Details.Name));
            SelectDesiredCommitment(job);
            SelectDesiredTimeZonePreference(job);
            SelectTimeZone(job);
            SelectHouseOverlap(job);
            EnterDesiredStartDate(job);
            SelectEstimatedLength(job);
            EnterLanguages(job);
            ClickOnNext();
        }

        public void RemoveAllSpokenLanguages()
        {
            log.Info(string.Format("Removing all spoken languages"));
            List<IWebElement> elements = addedSpokenLanguages.FindElements(By.XPath("//div[@class='ui-tag has-select is-deletable js-language']/div[@class='ui-tag__delete_icon js-delete']")).ToList();
            foreach (IWebElement element in elements)
            {
                element.Click();
                Browser.ImplicitWait();
            }
        }


        public void CheckForErrors()
        {
            log.Info(string.Format("Checking for errors"));

            // empty
            log.Info(string.Format("Checking for empty data"));
            RemoveAllSpokenLanguages();
            ClickOnNext();
            Assert.AreEqual(PagesXML.BackEndPages.NewJobWizard.Step2_Details.EmptySpokenLanguageErr, languagesErrMsg.Text.Trim());
            Assert.AreEqual(PagesXML.BackEndPages.NewJobWizard.Step2_Details.EmptyDesiredStartDateErr, desiredStartDateErrMsg.Text.Trim());
            Assert.AreEqual(PagesXML.BackEndPages.NewJobWizard.Step2_Details.EmptyEstimatedLengthErr, estimatedLengthErrMsg.Text.Trim());

            // dissapears
            log.Info(string.Format("Checking if errors disappears"));
            Job job = JobGenerator.Generate();
            EnterDesiredStartDate("INVALID");
            SelectEstimatedLength(job);
            EnterLanguages(job);
            Assert.True(languagesErrMsg.ExistsAndDisplayed());
            Assert.False(desiredStartDateErrMsg.ExistsAndDisplayed());
            Assert.False(estimatedLengthErrMsg.ExistsAndDisplayed());

            // invalid date
            ClickOnNext();
            Assert.AreEqual(PagesXML.BackEndPages.NewJobWizard.Step2_Details.InvalidDesiredStartDateErr, desiredStartDateErrMsg.Text.Trim());

            log.Info(string.Format("Validation errors are appear/disappear correctly"));
        }

        public bool IsAtStep()
        {
            log.Info(string.Format("Checking title for [{0}] page", PagesXML.BackEndPages.NewJobWizard.Step2_Details.Name));

            if (stepTitle.ExistsAndDisplayed())
            {
                bool result = stepTitle.Text.Contains(string.Format(PagesXML.BackEndPages.NewJobWizard.Step2_Details.Title));
                if (result)
                {
                    log.Info(string.Format("Title for [{0}] enterpage is correct", PagesXML.BackEndPages.NewJobWizard.Step2_Details.Name));
                    return result;
                }
            }
            log.Info(string.Format("Title for [{0}] page is not correct", PagesXML.BackEndPages.NewJobWizard.Step2_Details.Name));
            return false;
        }
    }
}
