using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Logger;
using TopTal_Framework;

namespace TopTal_TestCases
{
    [TestFixture]
    public class TestCases : TestBase
    {
        [Test]
        public void Test_01()
        {
            Pages.SitePages.Login.Login(Config.DefaultUser);
        }
    }
}
