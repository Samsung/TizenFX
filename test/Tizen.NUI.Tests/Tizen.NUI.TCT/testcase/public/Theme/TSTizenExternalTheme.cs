using NUnit.Framework;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Theme/TizenExternalTheme")]
    internal class PublicTizenExternalThemeTest
    {
        private const string tag = "NUITEST";
        private readonly object themeLoader;

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
        [Description("Test TizenExternalTheme GetValue.")]
        [Property("SPEC", "Tizen.NUI.TizenExternalTheme.GetValue  M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        public void TizenExternalThemeGetValue()
        {
            tlog.Debug(tag, $"TizenExternalThemeGetValue START");

            Tizen.Applications.ThemeManager.ThemeLoader themeLoader = new Tizen.Applications.ThemeManager.ThemeLoader();

            Tizen.Applications.ThemeManager.Theme a1 = null;
            string id = "myId";

            a1 = themeLoader.LoadTheme(id);

            TizenExternalTheme b1 = new TizenExternalTheme(a1);



            tlog.Debug(tag, $"TizenExternalThemeGetValue END (OK)");
            Assert.Pass("TizenExternalThemeGetValue");
        }
    }
}

