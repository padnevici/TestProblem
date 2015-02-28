using NUnit.Framework;
using System.Reflection;
using System;
using Logger;

namespace TopTal_Framework
{
    [TestFixture]
    public class TestBase
    {
        private static Log log = Log.Instance;

        [TestFixtureSetUp]
        public static void Initialize()
        {
            Browser.Initialize();
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
    }
}
