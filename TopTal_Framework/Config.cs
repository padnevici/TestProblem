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
    public class Config
    {
        private static Config _instance;
        private XPathDocument _doc;
        private XPathNavigator _nav;
        private static Log log = Log.Instance;


        #region internal stuffs
        private Config()
        {
            _doc = new XPathDocument("config.xml");
            _nav = _doc.CreateNavigator();
        }

        public static Config Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Config();
                }
                return _instance;
            }
        }

        private string GetValueByXPath(string xPath)
        {
            string value = "";
            try
            {
                value = _nav.SelectSingleNode(xPath).Value;
            }
            catch (Exception ex)
            {
                log.Warn(string.Format("Cannot get value using xpath [{1}]", xPath));
                log.Warn(ex.Message);
                log.Warn(ex.StackTrace);
            }

            return value;
        }
        #endregion

        #region Props
        public static string DefaultURL
        {
            get { return Instance.GetValueByXPath("configs/defaultURL"); }
        }

        public static string MainBrowser
        {
            get { return Instance.GetValueByXPath("configs/mainBrowser"); }
        }

        public static string DefaultUserName
        {
            get { return Instance.GetValueByXPath("configs/materAdmin/username"); }
        }

        public static string DefaultUserPassword
        {
            get { return Instance.GetValueByXPath("configs/materAdmin/password"); }
        }

        public static User DefaultUser
        {
            get { return new User() { Username = DefaultUserName, Password = DefaultUserPassword }; }
        }
        #endregion
    }
}




