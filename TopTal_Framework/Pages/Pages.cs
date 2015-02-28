using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace TopTal_Framework.Pages
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            T page = new T();
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }
    }
}
