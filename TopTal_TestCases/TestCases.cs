using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Logger;
using TopTal_Framework;
using TopTal_Framework.Generators;

namespace TopTal_TestCases
{
    [TestFixture]
    public class TestCases : TestBase
    {
        [Test]
        public void Test_01()
        {
            Job job1 = JobGenerator.Generate();
            Job job2 = JobGenerator.Generate();
            Job job3 = JobGenerator.Generate();
            Job job4 = JobGenerator.Generate();
            //Pages.SitePages.Login.Login(Config.DefaultUser);
            //Assert.True(Pages.BackendPages.TopMenu.IsLoggedIn());
            //Pages.BackendPages.Jobs.Goto();
            //Assert.True(Pages.BackendPages.Jobs.IsAt());
            //Pages.BackendPages.HomeDashboard.Goto();
            //Assert.True(Pages.BackendPages.HomeDashboard.IsAt());
            
            //Pages.BackendPages.NewJobWizardPages.BasicInfo.CheckForErrors();
            //Job job = JobGenerator.Generate();
            //Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
            //Pages.BackendPages.NewJobWizardPages.BasicInfo.Goto();
            //Pages.BackendPages.NewJobWizardPages.BasicInfo.ClickOnCancel();
        }
    }
}
