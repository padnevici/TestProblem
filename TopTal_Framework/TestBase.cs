using NUnit.Framework;
using System.Reflection;
using System;
using Logger;
using TopTal_Framework.Generators;

namespace TopTal_Framework
{
    [TestFixture]
    public class TestBase
    {
        protected static Log log = Log.Instance;

        [TestFixtureSetUp]
        public static void Initialize()
        {
            Browser.Initialize();
            JobGenerator.Initialize();
        }

        [TestFixtureTearDown]
        public static void TestFixtureTearDown()
        {
            Browser.Quit();
        }

        [TearDown]
        public static void TearDown()
        {
        }

        public static void DoInCaseOfError(Exception e)
        {
            Browser.TakeAScreenshot();
            log.Error(e.Message); 
            log.Error(e.StackTrace);
            throw e;
        }
    }
}
