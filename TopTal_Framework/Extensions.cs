using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Logger;

namespace TopTal_Framework
{
    public static class Extensions
    {
        private static Log log = Log.Instance;

        public static bool Exists(this IWebElement element)
        {
            try
            {
                var text = element.Text;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public static bool ExistsAndDisplayed(this IWebElement element)
        {
            try
            {
                if (element.Enabled && element.Displayed)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
