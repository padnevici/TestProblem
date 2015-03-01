using System;
using System.Xml.XPath;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace TopTal_Framework
{
    public class PagesXML
    {
        private static PagesXML _instance;
        private XPathDocument _doc;
        private XPathNavigator _nav;
        private Log log = Log.Instance;

        #region internal stuffs
        private PagesXML()
        {
            _doc = new XPathDocument("Pages/Pages.xml");
            _nav = _doc.CreateNavigator();
        }

        public static PagesXML Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PagesXML();
                }
                return _instance;
            }
        }

        protected string GetValueByXPath(string xPath)
        {
            string value = "";
            try
            {
                value = _nav.SelectSingleNode(xPath).Value;
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Cannot get value using xpath [{0}]", xPath));
                log.Warn(ex.Message);
                log.Warn(ex.StackTrace);
            }

            return value;
        }

        protected string GetAttributeByXPath(string xPath, string attribute)
        {
            string attr = "";
            try
            {
                attr = _nav.SelectSingleNode(xPath).GetAttribute(attribute, "");
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Cannot get attribute [{0}] using xpath [{1}]", attribute, xPath));
                log.Warn(ex.Message);
                log.Warn(ex.StackTrace);
            }

            return attr;
        }
        #endregion

        #region Site Pages
        public class SitePages
        {
            public class Login
            {
                public static string Name { get { return PagesXML.Instance.GetAttributeByXPath("//sitePages/loginPage", "name"); } }
                public static string Title { get { return PagesXML.Instance.GetAttributeByXPath("//sitePages/loginPage", "title"); } }
            }

            public class Home
            {
                public static string Name { get { return PagesXML.Instance.GetAttributeByXPath("//sitePages/homePage", "name"); } }
                public static string Title { get { return PagesXML.Instance.GetAttributeByXPath("//sitePages/homePage", "title"); } }
            }
        }
        #endregion

        #region Backend Pages
        public class BackEndPages
        {
            
        }
        #endregion
    }
}




