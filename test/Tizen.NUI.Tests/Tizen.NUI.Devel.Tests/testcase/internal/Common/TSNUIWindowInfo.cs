using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/NUIWindowInfo")]
    public class InternalNUIWindowInfoTest
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
        [Description("NUIWindowInfo ResourceId.")]
        [Property("SPEC", "Tizen.NUI.NUIWindowInfo.ResourceId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWindowInfoResourceId()
        {
            tlog.Debug(tag, $"NUIWindowInfoResourceId START");

            var testingTarget = new NUIWindowInfo(Window.Instance);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<NUIWindowInfo>(testingTarget, "Should return NUIWindowInfo instance.");

            var result = testingTarget.ResourceId;
            tlog.Debug(tag, "ResourceId : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWindowInfoResourceId END (OK)");
        }
    }
}
