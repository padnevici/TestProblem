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
    public class NewJobWizardRequiredSkillsPage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.XPath, Using = "//section[@class='content']//div[@class='title']//h2")]
        protected IWebElement title;

        [FindsBy(How = How.XPath, Using = "//div[@class='panel for-wizard']//div[contains(@class,'has-status_current')]//div[@class='step__text']")]
        private IWebElement stepTitle;

        [FindsBy(How = How.Id, Using = "job_skill_sets")]
        private IWebElement skillNameTxtBox;

        private string itemInExpandedListXpath = "//ul[@class='js-autocomplete_wrap']/li[contains(@data-value,'\"label\":\"{0}\"')]/a";

        [FindsBy(How = How.XPath, Using = "//div[@class='error is-big is-new_job for-textbox']")]
        private IWebElement emptySkillErrMsg;

        private string skillLvlDropDownXpath = "//*[@id='new_job--step_required_skills']//div[@data-name='{0}']//select";
        private string skillLvlCloseBtnXpath = "//*[@id='new_job--step_required_skills']//div[@data-name='{0}']//div[@class='ui-tag__delete_icon_inner']";
        private string skillLableTypeXpath = "//*[@id='new_job--step_required_skills']//div[@data-name='{0}']/../../label";

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_required_skills']//div[@data-step='details']")]
        protected IWebElement backBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_required_skills']//button[contains(@type,'submit')]")]
        protected IWebElement nextBtn;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_job--step_required_skills']//a[contains(@class,'is-cancel')]")]
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

        public void ClickOnBack()
        {
            log.Debug(string.Format("Clicking on [Back] button"));
            backBtn.Click();
            Browser.ImplicitWait(1000);
        }
        #endregion

        #region Enter/Select data/ Remove
        public void SelectSkillLvl(Skill skill)
        {
            log.Debug(string.Format("Selecting skill level for [{0} - {1}]", skill.Name, skill.SkillLevel));
            string xpat = string.Format(skillLvlDropDownXpath, skill.Name);
            IWebElement element = Browser.WebDriver.FindElement(By.XPath(xpat));
            SelectElement select = new SelectElement(element);
            select.SelectByText(skill.SkillLevel.ToString());
            Browser.ImplicitWait();
        }

        public void EnterSkillName(Skill skill)
        {
            log.Debug(string.Format("Entering skill name: [{0}]", skill.Name));
            skillNameTxtBox.Clear();
            Actions bulder = new Actions(Browser.WebDriver);
            bulder.MoveToElement(skillNameTxtBox).SendKeys(skill.Name).SendKeys(Keys.Space).SendKeys(Keys.Backspace).Perform();
            Browser.ImplicitWait(1000);
        }

        public void EnterSkillNameAndSelect(Skill skill)
        {
            EnterSkillName(skill);

            string xpath = string.Format(itemInExpandedListXpath, skill.Name);
            IWebElement element;
            try
            {
                element = Browser.WebDriver.FindElement(By.XPath(xpath));
                element.Click();
            }
            catch (Exception)
            {
                skillNameTxtBox.SendKeys(Keys.Enter);
            }

            Browser.ImplicitWait();
        }

        public void EnterSkills(Job job)
        {
            foreach (var skill in job._Skills)
            {
                EnterSkillNameAndSelect(skill);
                SelectSkillLvl(skill);
            }
        }

        public void RemoveAddedSkill(Skill skill)
        {
            log.Debug(string.Format("Removing aded skill: [{0}]", skill.Name));
            string xpat = string.Format(skillLvlCloseBtnXpath, skill.Name);
            IWebElement element = Browser.WebDriver.FindElement(By.XPath(xpat));
            element.Click();
            Browser.ImplicitWait();
        }
        #endregion

        public void PassThisStep(Job job)
        {
            log.Info(string.Format("Enter job details and passing this [{0}] step", PagesXML.BackEndPages.NewJobWizard.Step3_RequiredSkills.Name));
            EnterSkills(job);
            ClickOnNext();
        }

        #region Checks
        public void CheckForErrors()
        {
            log.Info(string.Format("Checking for errors"));

            // empty
            log.Info(string.Format("Checking for empty data"));
            ClickOnNext();
            Assert.AreEqual(PagesXML.BackEndPages.NewJobWizard.Step3_RequiredSkills.EmptySkillErr, emptySkillErrMsg.Text.Trim());

            // dissapears
            log.Info(string.Format("Checking if errors disappears"));
            Job job = JobGenerator.Generate();
            EnterSkillNameAndSelect(job._Skills[0]);
            Assert.False(emptySkillErrMsg.ExistsAndDisplayed());

            log.Info(string.Format("Validation errors are appear/disappear correctly"));
        }

        public bool CheckSkillType(Skill skill)
        {
            log.Debug(string.Format("Checking if aded skill [{0}] is placed under correct skill type [{1}]", skill.Name, skill.SkillType));
            string xpat = string.Format(skillLableTypeXpath, skill.Name);
            IWebElement element = Browser.WebDriver.FindElement(By.XPath(xpat));
            string label = element.Text.Trim();
            Skill.Type skillType = (Skill.Type)Enum.Parse(typeof(Skill.Type), label.Replace("/", "_"));
            return (skillType == skill.SkillType);
        }

        public bool CheckSkillLvl(Skill skill)
        {
            log.Debug(string.Format("Checking if aded skill [{0}] has correct level [{0}]", skill.Name, skill.SkillLevel));
            string xpat = string.Format(skillLvlDropDownXpath, skill.Name);
            IWebElement element = Browser.WebDriver.FindElement(By.XPath(xpat));
            SelectElement select = new SelectElement(element);
            Skill.Level selectedLvl = (Skill.Level)Enum.Parse(typeof(Skill.Level), select.SelectedOption.Text.Trim());
            return (selectedLvl == skill.SkillLevel);
        }

        public bool CheckIfSkillIsPresent(Skill skill)
        {
            log.Info(string.Format("Check if following [{0}] skill is present", skill.Name));
            string xpath = string.Format(skillLvlCloseBtnXpath, skill.Name);
            try
            {
                IWebElement element = Browser.WebDriver.FindElement(By.XPath(xpath));
                return element.ExistsAndDisplayed();
            }
            catch (Exception)
            { }
            return false;
        }

        public bool IsAtStep()
        {
            log.Info(string.Format("Checking title for [{0}] page", PagesXML.BackEndPages.NewJobWizard.Step3_RequiredSkills.Name));

            if (stepTitle.ExistsAndDisplayed())
            {
                bool result = stepTitle.Text.Contains(string.Format(PagesXML.BackEndPages.NewJobWizard.Step3_RequiredSkills.Title));
                if (result)
                {
                    log.Info(string.Format("Title for [{0}] page is correct", PagesXML.BackEndPages.NewJobWizard.Step3_RequiredSkills.Name));
                    return result;
                }
            }
            log.Info(string.Format("Title for [{0}] page is not correct", PagesXML.BackEndPages.NewJobWizard.Step3_RequiredSkills.Name));
            return false;
        }
        #endregion
    }
}
