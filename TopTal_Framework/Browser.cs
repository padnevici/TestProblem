using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Threading;
using System;
using Logger;
using AutoItX3Lib;
using System.Runtime.InteropServices;

namespace TopTal_Framework
{
    public static class Browser
    {
        private static IWebDriver webDriver = null;
        private static Log log = Log.Instance;
        public static int sleepTime = 500;

        public static void Initialize()
        {
            log.Info(string.Format("Initializing the {0} browser", Config.MainBrowser));
            switch (Config.MainBrowser)
            {
                case "Chrome":
                    InitChrome();
                    break;
                case "Firefox":
                    InitFirefox();
                    break;
                default:
                    InitChrome();
                    break;
            }
        }

        private static void InitChrome()
        {
            webDriver = new ChromeDriver();
            SetWindowSize();
            GotoEnv();
            PassChromeAuthentificationPopup();
            PassChromeAuthentificationPopup();
            Pages.SitePages.Home.CheckAndCloseAddPopup();
        }

        private static void InitFirefox()
        {
            webDriver = new FirefoxDriver();
            SetWindowSize();
            GotoEnv();
            PassFirefoxAuthentificationPopup();
            PassFirefoxAuthentificationPopup();
            Pages.SitePages.Home.CheckAndCloseAddPopup();
        }

        private static void SetWindowSize()
        {
            WebDriver.Manage().Window.Position = new System.Drawing.Point(0, 0);
            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(sleepTime));
        }

        private static void PassChromeAuthentificationPopup()
        {
            var AutoIT = new AutoItX3();
            if (AutoIT.WinWait("staging.toptal.net - Google Chrome", "", 10) != 0)
            {
                AutoIT.Send(Config.WebProtectionUser.Username);
                AutoIT.Send("{TAB}");
                AutoIT.Send(Config.WebProtectionUser.Password);
                AutoIT.Send("{ENTER}");
                Browser.ImplicitWait(5000);
            }
        }

        private static void PassFirefoxAuthentificationPopup()
        {
            var AutoIT = new AutoItX3();
            if (AutoIT.WinWait("Authentication Required", "", 10) != 0)
            {
                AutoIT.WinActivate("Authentication Required");
                AutoIT.Send(Config.WebProtectionUser.Username);
                AutoIT.Send("{TAB}");
                AutoIT.Send(Config.WebProtectionUser.Password);
                AutoIT.Send("{ENTER}");
                Browser.ImplicitWait(5000);
            }
        }

        private static void GotoEnv()
        {
            WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            try
            {
                log.Info(string.Format("Navigating to: {0}", Config.DefaultURL));
                webDriver.Navigate().GoToUrl(Config.DefaultURL);
                ImplicitWait();
            }
            catch (Exception e)
            { }
            WebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(-1));
        }

        public static string Title
        {
            get { return webDriver.Title; }
        }

        public static ISearchContext Driver
        {
            get { return webDriver; }
        }

        public static IWebDriver WebDriver
        {
            get { return webDriver; }
        }

        public static IJavaScriptExecutor ExecuteJS(string script)
        {
            IJavaScriptExecutor js = Driver as IJavaScriptExecutor;

            return (IJavaScriptExecutor)js.ExecuteScript(script);
        }

        public static string GetElementText(IWebElement element)
        {
            return element.Text.Trim();
        }

        public static void Goto(string url)
        {
            log.Info(string.Format("Navigating to: {0}", url));
            webDriver.Navigate().GoToUrl(url);
            ImplicitWait();
        }

        public static void AcceptingAnAlert()
        {
            log.Debug(string.Format("Accepting confirmation popup"));

            IAlert alert = WebDriver.SwitchTo().Alert();
            string AlertText = alert.Text;
            alert.Accept();
            Thread.Sleep(sleepTime);
        }

        public static void CancelingAnAlert()
        {
            log.Debug(string.Format("Canceling confirmation popup"));

            IAlert alert = WebDriver.SwitchTo().Alert();
            string AlertText = alert.Text;
            alert.Dismiss();
        }

        public static void Close()
        {
            log.Info(string.Format("Closing the browser."));
            webDriver.Close();
        }

        public static void Quit()
        {
            log.Info(string.Format("Quiting the browser."));
            webDriver.Quit();
        }

        public static void ImplicitWait()
        {
            Thread.Sleep(sleepTime);
        }

        public static void ImplicitWait(int miliseconds)
        {
            Thread.Sleep(miliseconds);
        }

        public static string GetCurrentURL()
        {
            return WebDriver.Url;
        }

        public static void TakeAScreenshot()
        {
            string name = string.Format("Images/img{0}.png", Generators.GetEpochTime());
            log.Info(string.Format("Collecting a screnshot: [{0}]", name));
            try
            {
                if (!System.IO.Directory.Exists("Images"))
                    System.IO.Directory.CreateDirectory("Images");
                Screenshot ss = ((ITakesScreenshot)WebDriver).GetScreenshot();
                ss.SaveAsFile(name, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception e)
            {
                log.Fatal("Cannot collect a screenshot of current page due to:");
                log.Fatal(e.Message);
                log.Fatal(e.StackTrace);
            }
        }
    }
}