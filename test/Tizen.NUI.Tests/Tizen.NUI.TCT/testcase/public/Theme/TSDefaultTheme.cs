using NUnit.Framework;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Theme/DefaultTheme")]
    internal class PublicDefaultThemeTest
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
        [Description("DefaultThemeCreator GetExternalThemeKeyListSet")]
        [Property("SPEC", "Tizen.NUI.DefaultThemeCreator.GetExternalThemeKeyListSet M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        public void DefaultThemeCreatorGetExternalThemeKeyListSet()
        {
            tlog.Debug(tag, $"DefaultThemeCreatorGetExternalThemeKeyListSet START");

            DefaultThemeCreator.Instance.GetExternalThemeKeyListSet();

            tlog.Debug(tag, $"DefaultThemeCreatorGetExternalThemeKeyListSet END (OK)");
            Assert.Pass("DefaultThemeCreatorGetExternalThemeKeyListSet");
        }
    }

}

