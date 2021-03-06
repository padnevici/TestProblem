﻿using System;
using System.Xml.XPath;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
using TopTal_Framework.Generators;

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
                log.Warn(string.Format("Cannot get value using xpath [{0}]", xPath));
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

        public static string DefaultEmail
        {
            get { return Instance.GetValueByXPath("configs/defaultAccount/email"); }
        }

        public static string DefaultUserPassword
        {
            get { return Instance.GetValueByXPath("configs/defaultAccount/password"); }
        }

        public static string DefaultCompany
        {
            get { return Instance.GetValueByXPath("configs/defaultAccount/company"); }
        }

        public static User DefaultUser
        {
            get { return new User() { Email = DefaultEmail, Password = DefaultUserPassword, Company = DefaultCompany }; }
        }

        public static string WebProtectionUsrName
        {
            get { return Instance.GetValueByXPath("configs/webProtection/username"); }
        }

        public static string WebProtectionUsrPwd
        {
            get { return Instance.GetValueByXPath("configs/webProtection/password"); }
        }

        public static User WebProtectionUser
        {
            get { return new User() { Email = WebProtectionUsrName, Password = WebProtectionUsrPwd }; }
        }
        #endregion
    }
}




