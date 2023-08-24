using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Theme/ExternalThemeManager")]
    internal class PublicExternalThemeManagerTest
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Test_Theme.xaml";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("test ExternalThemeManager SharedResourcePath.")]
        [Property("SPEC", "Tizen.NUI.ExternalThemeManager.SharedResourcePath A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ExternalThemeManagerSharedResourcePath()
        {
            tlog.Debug(tag, $"ExternalThemeManagerSharedResourcePath START");

            ExternalThemeManager.SharedResourcePath = path;
            Assert.AreEqual(path, ExternalThemeManager.SharedResourcePath, "Should be equal!");

            tlog.Debug(tag, $"ExternalThemeManagerSharedResourcePath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("test ExternalThemeManager Initialize")]
        [Property("SPEC", "Tizen.NUI.ExternalThemeManager.Initialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ExternalThemeManagerInitialize()
        {
            tlog.Debug(tag, $"ExternalThemeManagerInitialize START");

            ExternalThemeManager.Initialize();

            tlog.Debug(tag, $"ExternalThemeManagerInitialize END (OK)");
            Assert.Pass("ExternalThemeManagerInitialize");
        }

        [Test]
        [Category("P1")]
        [Description("test ExternalThemeManager SetTheme")]
        [Property("SPEC", "Tizen.NUI.ExternalThemeManager.SetTheme M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ExternalThemeManagerSetTheme()
        {
            tlog.Debug(tag, $"ExternalThemeManagerSetTheme START");

            try
            {
                ExternalThemeManager.SetTheme("Tizen.NUI.Theme.Common");
                ExternalThemeManager.SetTheme(ThemeManager.CurrentTheme.Id);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, "SetTheme : " + e.Message.ToString());
                Assert.Fail("Caught Exception :  Failed!");
            }

            tlog.Debug(tag, $"ExternalThemeManagerSetTheme END (OK)");
        }
    }
}