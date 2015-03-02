using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Logger;
using TopTal_Framework.Generators;
using System.Reflection;

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

        public static string GetValue(this Job.EstimatedLength estimatedLength)
        {
            var type = estimatedLength.GetType();
            var memInfo = type.GetMember(estimatedLength.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(ValueAttribute), false);
            return (attributes.Length > 0) ? ((ValueAttribute)attributes[0])._Value : null;
        }


        //public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        //{
        //    var type = enumVal.GetType();
        //    var memInfo = type.GetMember(enumVal.ToString());
        //    var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
        //    return (attributes.Length > 0) ? (T)attributes[0] : null;
        //}
    }
}
