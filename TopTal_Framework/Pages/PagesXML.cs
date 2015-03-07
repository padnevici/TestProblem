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
            public class HomeDashboard
            {
                public static string Name { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/homeDashboardPage", "name"); } }
                public static string Title { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/homeDashboardPage", "title"); } }
            }

            public class Jobs
            {
                public static string Name { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/jobsPage", "name"); } }
                public static string Title { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/jobsPage", "title"); } }
            }

            public class NewJobWizard
            {
                public static string Name { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage", "name"); } }
                public static string Title { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage", "title"); } }

                public class Step1_BasicInfo
                {
                    public static string Name { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage/basicInfoPage", "name"); } }
                    public static string Title { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage/basicInfoPage", "title"); } }
                    public static string EmptyTitleErr { get { return PagesXML.Instance.GetValueByXPath("//newJobWizardPage/basicInfoPage/errorMsgs/emptyField"); } }
                    public static string EmptyDescriptionErr { get { return PagesXML.Instance.GetValueByXPath("//newJobWizardPage/basicInfoPage/errorMsgs/emptyField"); } }
                }

                public class Step2_Details
                {
                    public static string Name { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage/detailsPage", "name"); } }
                    public static string Title { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage/detailsPage", "title"); } }
                    public static string EmptyDesiredStartDateErr { get { return PagesXML.BackEndPages.NewJobWizard.Step1_BasicInfo.EmptyTitleErr; } }
                    public static string EmptyEstimatedLengthErr { get { return PagesXML.BackEndPages.NewJobWizard.Step1_BasicInfo.EmptyTitleErr; } }
                    public static string EmptySpokenLanguageErr { get { return PagesXML.Instance.GetValueByXPath("//newJobWizardPage/detailsPage/errorMsgs/emptyLanguagesField"); } }
                    public static string InvalidDesiredStartDateErr { get { return PagesXML.Instance.GetValueByXPath("//newJobWizardPage/detailsPage/errorMsgs/invalidDateField"); } }
                }

                public class Step3_RequiredSkills
                {
                    public static string Name { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage/requiredSkillsPage", "name"); } }
                    public static string Title { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage/requiredSkillsPage", "title"); } }
                    public static string EmptySkillErr { get { return PagesXML.Instance.GetValueByXPath("//backendPages/newJobWizardPage/requiredSkillsPage/errorMsgs/emptySkillField"); } }
                }

                public class Step4_Confirm
                {
                    public static string Name { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage/confirmPage", "name"); } }
                    public static string Title { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage/confirmPage", "title"); } }
                    public static string errorMsg { get { return PagesXML.Instance.GetValueByXPath("//backendPages/newJobWizardPage/confirmPage/errorMsgs/errorMsg"); } }
                }

                public class Step5_TechCall
                {
                    public static string Name { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage/techCallPage", "name"); } }
                    public static string Title { get { return PagesXML.Instance.GetAttributeByXPath("//backendPages/newJobWizardPage/techCallPage", "title"); } }
                    public static string successTitle { get { return PagesXML.Instance.GetValueByXPath("//backendPages/newJobWizardPage/techCallPage/successMsgs/titleMsg"); } }
                }
            }
        }
        #endregion
    }
}




