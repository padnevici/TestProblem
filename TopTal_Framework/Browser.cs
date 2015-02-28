using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Threading;
using System;
using Logger;

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
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver();
                    break;
                default:
                    webDriver = new ChromeDriver();
                    break;
            }
            webDriver.Manage().Window.Position = new System.Drawing.Point(0, 0);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(sleepTime));
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
            webDriver.Url = url;
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
            string name = string.Format("Images/img{0}.png", Generators.Generators.GetEpochTime());
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