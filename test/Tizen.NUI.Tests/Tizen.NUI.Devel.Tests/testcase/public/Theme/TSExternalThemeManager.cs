using NUnit.Framework;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Theme/ExternalThemeManager")]
    internal class PublicExternalThemeManagerTest
    {
        private const string tag = "NUITEST";

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

            string b1 = ExternalThemeManager.SharedResourcePath;

            ExternalThemeManager.Initialize();
            b1 = ExternalThemeManager.SharedResourcePath;

            tlog.Debug(tag, $"ExternalThemeManagerSharedResourcePath END (OK)");
            Assert.Pass("ExternalThemeManagerSharedResourcePath");
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
        [Description("test ExternalThemeManager GetCurrentTheme")]
        [Property("SPEC", "Tizen.NUI.ExternalThemeManager.GetCurrentTheme M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ExternalThemeManagerGetCurrentTheme()
        {
            tlog.Debug(tag, $"ExternalThemeManagerGetCurrentTheme START");

            ExternalThemeManager.GetCurrentTheme();

            tlog.Debug(tag, $"ExternalThemeManagerGetCurrentTheme END (OK)");
            Assert.Pass("ExternalThemeManagerGetCurrentTheme");
        }

        [Test]
        [Category("P1")]
        [Description("test ExternalThemeManager GetTheme")]
        [Property("SPEC", "Tizen.NUI.ExternalThemeManager.GetTheme M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ExternalThemeManagerGetTheme()
        {
            tlog.Debug(tag, $"ExternalThemeManagerGetTheme START");

            ExternalThemeManager.GetTheme("aaa");

            tlog.Debug(tag, $"ExternalThemeManagerGetTheme END (OK)");
            Assert.Pass("ExternalThemeManagerGetTheme");
        }

        [Test]
        [Category("P1")]
        [Description("test ExternalThemeManager SetTestTheme")]
        [Property("SPEC", "Tizen.NUI.ExternalThemeManager.SetTestTheme M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void ExternalThemeManagerSetTestTheme()
        {
            tlog.Debug(tag, $"ExternalThemeManagerSetTestTheme START");

            ExternalThemeManager.SetTestTheme(null);

            string id = "id1"; string version = "version1";
            Dictionary<string, string> theme = new Dictionary<string, string>
            {
                { "aaa", "111" },
                { "bbb", "222" }
            };

            DictionaryExternalTheme a1 = new DictionaryExternalTheme(id, version, theme);

            ExternalThemeManager.SetTestTheme(a1);
            ExternalThemeManager.SetTestTheme(id, version, theme);

            tlog.Debug(tag, $"ExternalThemeManagerSetTestTheme END (OK)");
            Assert.Pass("ExternalThemeManagerSetTestTheme");
        }
    }
}