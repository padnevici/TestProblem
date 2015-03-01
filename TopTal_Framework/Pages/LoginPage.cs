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
    public class LoginPage
    {
        private static Log log = Log.Instance;

        #region Elements
        [FindsBy(How = How.Id, Using = "user_email")]
        protected IWebElement userNameFld;

        [FindsBy(How = How.Id, Using = "user_password")]
        protected IWebElement userPasswordFld;

        [FindsBy(How = How.XPath, Using = "//*[@id='new_user']//a[@data-role='checkbox_wrapper']")]
        protected IWebElement rememberMeCheckBox;

        [FindsBy(How = How.Name, Using = "commit")]
        protected IWebElement loginBtn;
        #endregion

        #region Click on/Select
        public void ClickLogin()
        {
            log.Debug(string.Format("Clicking on [Login] button"));
            loginBtn.Click();
            Browser.ImplicitWait();
        }

        private void CheckRememberMe(bool rememberMe)
        {
            if (rememberMe == false)
            {
                if (rememberMeCheckBox.Selected == true)
                {
                    log.Debug("Remeber Me cehck Box is checked. Unchecking it");
                    rememberMeCheckBox.Click();
                }
                else
                    log.Debug("Remeber Me cehck Box is already unchecked.");
            }

            if (rememberMe == true)
            {
                if (rememberMeCheckBox.Selected == false)
                {
                    log.Debug("Remeber Me Cehck Box is unchecked. Checking it");
                    rememberMeCheckBox.Click();
                }
                else
                    log.Debug("Remeber Me Cehck Box is already checked.");
            }
        }
        #endregion

        #region Enter data
        private void EnterUserName(User user)
        {
            log.Debug(string.Format("Entering user name [{0}]", user.Username));
            userNameFld.Clear();
            userNameFld.SendKeys(user.Username);
        }

        private void EnterPassword(User user)
        {
            log.Debug(string.Format("Entering user password [{0}]", user.Password));
            userPasswordFld.Clear();
            userPasswordFld.SendKeys(user.Password);
        }
        #endregion

        #region Login
        public void Login(User user)
        {
            Login(user, true);
        }

        public void Login(User user, bool userRememberMe)
        {
            log.Info(string.Format("Login as [{0} / {1} - Remember Me: {1}]", user.Username, user.Password, userRememberMe));
            CheckIfCorrectPageAndNavigate();
            EnterUserName(user);
            EnterPassword(user);
            CheckRememberMe(userRememberMe);
            ClickLogin();
            Browser.ImplicitWait();
        }
        #endregion

        #region Check if and do
        private void CheckIfCorrectPageAndNavigate()
        {
            if (IsAt())
                return;
            else
                Goto();
        }
        #endregion

        public void Goto()
        {
            log.Info(string.Format("Navigating to [{0}] page", PagesXML.SitePages.Login.Name));
            Pages.SitePages.TopMenuNavigation.ClickOnLogin();
            Browser.ImplicitWait();
        }

        public bool IsAt()
        {
            log.Info(string.Format("Checking title for [{0}] page", PagesXML.SitePages.Login.Name));

            bool result = Browser.Title.Contains(string.Format(PagesXML.SitePages.Login.Title));
            if (result)
            {
                log.Info(string.Format("Title for [{0}] page is correct", PagesXML.SitePages.Login.Name));
                return result;
            }

            log.Info(string.Format("Title for [{0}] page is not correct", PagesXML.SitePages.Login.Name));
            return false;
        }
    }
}
