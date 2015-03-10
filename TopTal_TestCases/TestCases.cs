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
                Assert.True(Pages.BackendPages.HomeDashboard.IsAt());
                Assert.True(Pages.BackendPages.TopMenu.IsLoggedInAs(Config.DefaultUser));

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
                Assert.True(Pages.BackendPages.Jobs.IsAt());

                //3
                log.Info("//3");
                Job job = JobGenerator.Generate();

                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.ClickOnCancel();
                Assert.True(Pages.BackendPages.Jobs.IsAt());

                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.ClickOnCancel();
                Assert.True(Pages.BackendPages.Jobs.IsAt());

                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Confirm.ClickOnCancel();
                Assert.True(Pages.BackendPages.Jobs.IsAt());
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_03
        [Test]
        public void TTC_03()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_3");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);

                //1 - 3
                log.Info("//1 - 3");
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.CheckForErrors();

                //4
                log.Info("//4");
                Pages.BackendPages.NewJobWizardPages.BasicInfo.ClickOnNext();
                Assert.True(Pages.BackendPages.NewJobWizardPages.Details.IsAtStep());
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_04
        [Test]
        public void TTC_04()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_4");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.Details.IsAtStep());

                //1 - 4
                log.Info("//1 - 4");
                Pages.BackendPages.NewJobWizardPages.Details.CheckForErrors();
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.IsAtStep());
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_05
        [Test]
        public void TTC_05()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_5");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.Details.IsAtStep());

                //1 - 2
                log.Info("//1 - 2");
                Pages.BackendPages.NewJobWizardPages.Details.EnterLanguages(job._SpokenLanguages);
                foreach (Job.SpokenLanguages lang in job._SpokenLanguages)
                {
                    Pages.BackendPages.NewJobWizardPages.Details.RemoveAddedLanguage(lang);
                    Assert.False(Pages.BackendPages.NewJobWizardPages.Details.CheckIfLanguageIsPresent(lang));
                }
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_06
        [Test]
        public void TTC_06()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_6");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.Details.IsAtStep());

                //1 - 2
                log.Info("//1 - 2");
                Pages.BackendPages.NewJobWizardPages.Details.EnterLanguages(job._SpokenLanguages);
                foreach (Job.SpokenLanguages lang in job._SpokenLanguages)
                {
                    Pages.BackendPages.NewJobWizardPages.Details.RemoveAddedLanguage(lang);
                    Assert.False(Pages.BackendPages.NewJobWizardPages.Details.CheckIfLanguageIsPresent(lang));
                }

                Pages.BackendPages.NewJobWizardPages.Details.EnterLanguages(job._SpokenLanguages);
                foreach (Job.SpokenLanguages lang in job._SpokenLanguages)
                    Assert.True(Pages.BackendPages.NewJobWizardPages.Details.CheckIfLanguageIsPresent(lang));
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_07
        [Test]
        public void TTC_07()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_7");

                throw new NotImplementedException("Not implemented Yet");
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_08
        [Test]
        public void TTC_08()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_8");

                throw new NotImplementedException("Not implemented Yet");
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_09
        [Test]
        public void TTC_09()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_9");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.IsAtStep());

                //1 - 3
                log.Info("//1 - 3");
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.CheckForErrors();
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.ClickOnNext();
                Assert.True(Pages.BackendPages.NewJobWizardPages.Confirm.IsAtStep());
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_10
        [Test]
        public void TTC_10()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_10");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.IsAtStep());

                //1 - 3
                log.Info("//1 - 3");
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.EnterSkills(job);
                foreach (var skill in job._Skills)
                {
                    Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.CheckSkillType(skill));
                }
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_11
        [Test]
        public void TTC_11()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_11");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.IsAtStep());

                //1 - 3
                log.Info("//1 - 3");
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.EnterSkills(job);
                foreach (var skill in job._Skills)
                {
                    Pages.BackendPages.NewJobWizardPages.RequiredSkills.RemoveAddedSkill(skill);
                    Assert.False(Pages.BackendPages.NewJobWizardPages.RequiredSkills.CheckIfSkillIsPresent(skill));
                }
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_12
        [Test]
        public void TTC_12()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_12");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.IsAtStep());

                //1 - 3
                log.Info("//1 - 3");
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.EnterSkills(job);
                foreach (var skill in job._Skills)
                    Pages.BackendPages.NewJobWizardPages.RequiredSkills.RemoveAddedSkill(skill);

                Pages.BackendPages.NewJobWizardPages.RequiredSkills.EnterSkills(job);
                foreach (var skill in job._Skills)
                    Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.CheckIfSkillIsPresent(skill));
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_13
        [Test]
        public void TTC_13()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_13");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.IsAtStep());

                //1 - 2
                log.Info("//1 - 2");
                Skill skill = new Skill() { Name = "Uncategorized", SkillType = Skill.Type.Misc, SkillLevel = Skill.Level.Strong };
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.EnterSkillNameAndSelect(skill);
                Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.CheckSkillType(skill));
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_14
        [Test]
        public void TTC_14()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_14");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.IsAtStep());

                //1 - 3
                log.Info("//1 - 3");
                Skill skill = new Skill() { Name = "Uncategorized", SkillType = Skill.Type.Misc, SkillLevel = Skill.Level.Strong };
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.EnterSkillName(skill);
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.ClickOnNext();
                Pages.BackendPages.NewJobWizardPages.Confirm.ClickOnBack();
                Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.CheckSkillType(skill));
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_15
        [Test]
        public void TTC_15()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_15");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.IsAtStep());

                //1 - 5
                log.Info("//1 - 5");
                Skill skillCompetenet = new Skill() { Name = "UncategorizedCompetenet", SkillType = Skill.Type.Misc, SkillLevel = Skill.Level.Competent };
                Skill skillStrong = new Skill() { Name = "UncategorizedStrong", SkillType = Skill.Type.Misc, SkillLevel = Skill.Level.Strong };
                Skill skillExpert = new Skill() { Name = "UncategorizedExpert", SkillType = Skill.Type.Misc, SkillLevel = Skill.Level.Expert };
                job._Skills.Add(skillCompetenet);
                job._Skills.Add(skillStrong);
                job._Skills.Add(skillExpert);
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Confirm.ClickOnBack();
                foreach (var skill in job._Skills)
                    Assert.True(Pages.BackendPages.NewJobWizardPages.RequiredSkills.CheckSkillLvl(skill));

            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_16
        [Test]
        public void TTC_16()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_16");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.Confirm.IsAtStep());

                //1 - 3
                log.Info("//1 - 3");
                Pages.BackendPages.NewJobWizardPages.Confirm.CheckForErrors();
                Pages.BackendPages.NewJobWizardPages.Confirm.ClickOnNext();
                Assert.True(Pages.BackendPages.NewJobWizardPages.WhatIsNext.IsAtStep());

            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion

        #region TTC_17
        [Test]
        public void TTC_17()
        {
            try
            {
                // prerequisites
                log.Info("// prerequisites #ttc_17");
                Pages.SitePages.Login.CheckIfLogedIfNoThenLogin(Config.DefaultUser);


                //1 - 2
                log.Info("//1 - 2");
                Job job = JobGenerator.Generate();
                Pages.BackendPages.TopMenu.ClickOnAddNewJob();
                Pages.BackendPages.NewJobWizardPages.BasicInfo.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.Details.PassThisStep(job);
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.PassThisStep(job);
                Assert.True(Pages.BackendPages.NewJobWizardPages.Confirm.IsAtStep());

                //3
                log.Info("//3");
                Pages.BackendPages.NewJobWizardPages.Confirm.ClickOnBack();
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.ClickOnBack();
                Pages.BackendPages.NewJobWizardPages.Details.ClickOnBack();
                Assert.True(Pages.BackendPages.NewJobWizardPages.BasicInfo.IsAtStep());

                //4
                log.Info("//4");
                Pages.BackendPages.NewJobWizardPages.BasicInfo.ClickOnNext();
                Pages.BackendPages.NewJobWizardPages.Details.ClickOnNext();
                Pages.BackendPages.NewJobWizardPages.RequiredSkills.ClickOnNext();

                //5
                log.Info("//5");
                Pages.BackendPages.NewJobWizardPages.Confirm.PassThisStep();
                Browser.ImplicitWait(1000);
                Assert.True(Pages.BackendPages.NewJobWizardPages.WhatIsNext.IsAtStep());
            }
            catch (Exception e)
            {
                DoInCaseOfError(e);
            }
        }
        #endregion
    }
}
