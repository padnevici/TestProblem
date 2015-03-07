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

namespace TopTal_Framework.SitePages
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
            log.Debug(string.Format("Entering user name [{0}]", user.Email));
            userNameFld.Clear();
            userNameFld.SendKeys(user.Email);
            Browser.ImplicitWait();
        }

        private void EnterPassword(User user)
        {
            log.Debug(string.Format("Entering user password [{0}]", user.Password));
            userPasswordFld.Clear();
            userPasswordFld.SendKeys(user.Password);
            Browser.ImplicitWait();
        }
        #endregion

        #region Login
        public void Login(User user)
        {
            Login(user, true);
        }

        public void Login(User user, bool userRememberMe)
        {
            log.Info(string.Format("Login as [{0} / {1} - Remember Me: {1}]", user.Email, user.Password, userRememberMe));
            CheckIfCorrectPageAndNavigate();
            Browser.ImplicitWait(5000);// sometime scrits cannot find email field. Better solutions is to wait a little bit before login
            EnterUserName(user);
            EnterPassword(user);
            CheckRememberMe(userRememberMe);
            ClickLogin();
        }
        #endregion

        #region Check if and do
        public void CheckIfLogedIfNoThenLogin(User user)
        {
            log.Info(string.Format("Checking if [{0}] is alreade logged in", user.Email));
            if (!Pages.BackendPages.TopMenu.IsLoggedInAs(user))
                Pages.SitePages.Login.Login(user);
        }

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
