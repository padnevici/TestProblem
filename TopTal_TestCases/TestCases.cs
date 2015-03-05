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
            Job job = JobGenerator.Generate();
            Pages.SitePages.Login.Login(Config.DefaultUser);
            //Assert.True(Pages.BackendPages.TopMenu.IsLoggedIn());
            //Pages.BackendPages.Jobs.Goto();
            //Assert.True(Pages.BackendPages.Jobs.IsAt());
            //Pages.BackendPages.HomeDashboard.Goto();
            //Assert.True(Pages.BackendPages.HomeDashboard.IsAt());

            //Pages.BackendPages.NewJobWizardPages.BasicInfo.CheckForErrors();
            //Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
            //Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);

            //job = JobGenerator.Generate();
            //Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
            //Pages.BackendPages.NewJobWizardPages.Details.ClickOnBack();
            //Pages.BackendPages.NewJobWizardPages.BasicInfo.ClickOnNext();
            //Pages.BackendPages.NewJobWizardPages.Details.ClickOnCancel();
            //Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
            //Pages.BackendPages.NewJobWizardPages.Details.CheckForErrors();
            //Pages.BackendPages.NewJobWizardPages.Details.ClickOnCancel();

            //Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
            //Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
            //Pages.BackendPages.NewJobWizardPages.RequiredSkills.CheckForErrors();
            //Pages.BackendPages.NewJobWizardPages.RequiredSkills.ClickOnBack();
            //Pages.BackendPages.NewJobWizardPages.Details.ClickOnNext();
            //Pages.BackendPages.NewJobWizardPages.RequiredSkills.ClickOnCancel();

            //Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
            //Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
            //Pages.BackendPages.NewJobWizardPages.RequiredSkills.EnterSkillName(job._Skills[0]);
            //Pages.BackendPages.NewJobWizardPages.RequiredSkills.RemoveAddedSkill(job._Skills[0]);

            Pages.BackendPages.NewJobWizardPages.BasicInfo.Goto();
            Pages.BackendPages.NewJobWizardPages.BasicInfo.IsAtStep();
            Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
            Pages.BackendPages.NewJobWizardPages.Details.IsAtStep();
            Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
            Pages.BackendPages.NewJobWizardPages.RequiredSkills.IsAtStep();
            Pages.BackendPages.NewJobWizardPages.RequiredSkills.PassThisStep(job);
            Pages.BackendPages.NewJobWizardPages.Confirm.IsAtStep();
            Pages.BackendPages.NewJobWizardPages.Confirm.CheckForErrors();
            Pages.BackendPages.NewJobWizardPages.Confirm.PassThisStep();
            Pages.BackendPages.NewJobWizardPages.Confirm.PassThisStep();
        }
    }
}
