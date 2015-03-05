using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using TopTal_Framework.SitePages;
using TopTal_Framework.BackendPages;

namespace TopTal_Framework
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }

        #region SitePages
        public static class SitePages
        {
            public static HomePage Home
            {
                get { return GetPage<HomePage>(); }
            }

            public static LoginPage Login
            {
                get { return GetPage<LoginPage>(); }
            }

            public static TopMenuNavigationPage TopMenuNavigation
            {
                get { return GetPage<TopMenuNavigationPage>(); }
            }
        } 
        #endregion

        #region BackendPages
        public static class BackendPages
        {
            public static TopMenuPage TopMenu
            {
                get { return GetPage<TopMenuPage>(); }
            }

            public static LeftMenuNavigationPage LeftMenuNavigation
            {
                get { return GetPage<LeftMenuNavigationPage>(); }
            }

            public static HomeDashboardPage HomeDashboard
            {
                get { return GetPage<HomeDashboardPage>(); }
            }

            public static JobsPage Jobs
            {
                get { return GetPage<JobsPage>(); }
            }

            public static class NewJobWizardPages
            {
                public static NewJobWizardBasicInfoPage BasicInfo
                {
                    get { return GetPage<NewJobWizardBasicInfoPage>(); }
                }

                public static NewJobWizardDetailsPage Details
                {
                    get { return GetPage<NewJobWizardDetailsPage>(); }
                }

                public static NewJobWizardRequiredSkillsPage RequiredSkills
                {
                    get { return GetPage<NewJobWizardRequiredSkillsPage>(); }
                }

                public static NewJobWizardConfirmPage Confirm
                {
                    get { return GetPage<NewJobWizardConfirmPage>(); }
                }
            }
        } 
        #endregion
    }
}
