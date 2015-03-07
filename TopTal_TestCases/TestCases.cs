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
        #region TTC_01
        [Test]
        public void TTC_01()
        {
            try
            {
                log.Info("//#ttc_1");
                //1 - 2
                log.Info("//1 - 2");
                Pages.SitePages.Login.Login(Config.DefaultUser);
                Assert.IsTrue(Pages.BackendPages.HomeDashboard.IsAt());
                Assert.IsTrue(Pages.BackendPages.TopMenu.IsLoggedInAs(Config.DefaultUser));

                //3
                log.Info("//3");
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.IsAtStep();
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_02
        [Test]
        public void TTC_02()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_2");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);

                //1 - 2
                log.Info("//1 - 2");
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.ClickOnCancel();
                Assert.IsTrue(Pages.BackendPages.Jobs.IsAt());

                //3
                log.Info("//3");
                Job job = JobGenerator.Generate();

                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.ClickOnCancel();
                Assert.IsTrue(Pages.BackendPages.Jobs.IsAt());

                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.ClickOnCancel();
                Assert.IsTrue(Pages.BackendPages.Jobs.IsAt());

                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Confirm.ClickOnCancel();
                Assert.IsTrue(Pages.BackendPages.Jobs.IsAt());
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion
    }
}
