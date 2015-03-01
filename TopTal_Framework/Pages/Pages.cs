using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

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
        } 
        #endregion
    }
}
