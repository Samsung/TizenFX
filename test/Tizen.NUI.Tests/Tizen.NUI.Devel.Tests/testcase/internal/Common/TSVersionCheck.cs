using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/VersionCheck")]
    public class InternalVersionCheckTest
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
        [Description("VersionCheck DaliVersionMatchWithNUI.")]
        [Property("SPEC", "Tizen.NUI.VersionCheck.DaliVersionMatchWithNUI M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VersionCheckDaliVersionMatchWithNUI()
        {
            tlog.Debug(tag, $"VersionCheckDaliVersionMatchWithNUI START");

            try
            {
                var result = Tizen.NUI.Version.DaliVersionMatchWithNUI();
                tlog.Debug(tag, "DaliVersionMatchWithNUI : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"VersionCheckDaliVersionMatchWithNUI END (OK)");
                Assert.Pass();
            }

            tlog.Debug(tag, $"VersionCheckDaliVersionMatchWithNUI END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VersionCheck PrintDaliNativeVersion.")]
        [Property("SPEC", "Tizen.NUI.VersionCheck.PrintDaliNativeVersion M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VersionPrintDaliNativeVersion()
        {
            tlog.Debug(tag, $"VersionPrintDaliNativeVersion START");

            try
            {
                Tizen.NUI.Version.PrintDaliNativeVersion();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"VersionPrintDaliNativeVersion END (OK)");
        }
    }
}
