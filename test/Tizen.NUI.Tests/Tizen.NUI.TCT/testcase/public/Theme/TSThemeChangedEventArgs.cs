using NUnit.Framework;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Theme/ThemeChangedEventArgs")]
    internal class PublicThemeChangedEventArgsTest
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
        [Description("Create a ThemeChangedEventArgs ThemeChangedEventArgs object.")]
        [Property("SPEC", "Tizen.NUI.ThemeChangedEventArgs.ThemeChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        public void ThemeChangedEventArgsConstructor()
        {
            tlog.Debug(tag, $"ThemeChangedEventArgsConstructor START");

            ThemeChangedEventArgs a1 = new ThemeChangedEventArgs("themeid");

            tlog.Debug(tag, $"ThemeChangedEventArgsConstructor END (OK)");
            Assert.Pass("ThemeChangedEventArgsConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Test ThemeChangedEventArgs ThemeId.")]
        [Property("SPEC", "Tizen.NUI.ThemeChangedEventArgs.ThemeId  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        public void ThemeChangedEventArgsThemeId()
        {
            tlog.Debug(tag, $"ThemeChangedEventArgsThemeId START");

            ThemeChangedEventArgs a1 = new ThemeChangedEventArgs("themeid");
            string b1 = a1.ThemeId;

            tlog.Debug(tag, $"ThemeChangedEventArgsThemeId END (OK)");
            Assert.Pass("ThemeChangedEventArgsThemeId");
        }
    }
}

