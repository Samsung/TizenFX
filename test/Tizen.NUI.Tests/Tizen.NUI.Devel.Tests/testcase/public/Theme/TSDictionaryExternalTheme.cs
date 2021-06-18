using NUnit.Framework;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Theme/DictionaryExternalTheme")]
    internal class PublicDictionaryExternalThemeTest
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
        [Description("Create a DictionaryExternalTheme object.")]
        [Property("SPEC", "Tizen.NUI.DictionaryExternalTheme.DictionaryExternalTheme C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void DictionaryExternalThemeConstructor()
        {
            tlog.Debug(tag, $"DictionaryExternalThemeConstructor START");
            string id = "id1"; string version = "version1";
            Dictionary<string, string> theme = new Dictionary<string, string>
            {
                { "aaa", "111" },
                { "bbb", "222" }
            };

            DictionaryExternalTheme a1 = new DictionaryExternalTheme(id, version, theme);

            tlog.Debug(tag, $"DictionaryExternalThemeConstructor END (OK)");
            Assert.Pass("DictionaryExternalThemeConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("test DictionaryExternalTheme Id.")]
        [Property("SPEC", "Tizen.NUI.DictionaryExternalTheme.Id A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void DictionaryExternalThemeId()
        {
            tlog.Debug(tag, $"DictionaryExternalThemeId START");

            string id = "id1"; string version = "version1";
            Dictionary<string, string> theme = new Dictionary<string, string>
            {
                { "aaa", "111" },
                { "bbb", "222" }
            };

            DictionaryExternalTheme a1 = new DictionaryExternalTheme(id, version, theme);
            string b1 = a1.Id;

            tlog.Debug(tag, $"DictionaryExternalThemeId END (OK)");
            Assert.Pass("DictionaryExternalThemeId");
        }

        [Test]
        [Category("P1")]
        [Description("test DictionaryExternalTheme Version.")]
        [Property("SPEC", "Tizen.NUI.DictionaryExternalTheme.Version A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void DictionaryExternalThemeVersion()
        {
            tlog.Debug(tag, $"DictionaryExternalThemeVersion START");

            string id = "id1"; string version = "version1";
            Dictionary<string, string> theme = new Dictionary<string, string>
            {
                { "aaa", "111" },
                { "bbb", "222" }
            };

            DictionaryExternalTheme a1 = new DictionaryExternalTheme(id, version, theme);
            string b1 = a1.Version;

            tlog.Debug(tag, $"DictionaryExternalThemeVersion END (OK)");
            Assert.Pass("DictionaryExternalThemeVersion");
        }

        [Test]
        [Category("P1")]
        [Description("test DictionaryExternalTheme GetValue.")]
        [Property("SPEC", "Tizen.NUI.DictionaryExternalTheme.GetValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void DictionaryExternalThemeGetValue()
        {
            tlog.Debug(tag, $"DictionaryExternalThemeGetValue START");

            string id = "id1"; string version = "version1";
            Dictionary<string, string> theme = new Dictionary<string, string>
            {
                { "aaa", "111" },
                { "bbb", "222" }
            };

            DictionaryExternalTheme a1 = new DictionaryExternalTheme(id, version, theme);
            string b1 = a1.GetValue("aaa");

            tlog.Debug(tag, $"DictionaryExternalThemeGetValue END (OK)");
            Assert.Pass("DictionaryExternalThemeGetValue");
        }
    }
}
