using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/RenderTaskSignal")]
    public class InternalRenderTaskSignalTest
    {
        private const string tag = "NUITEST";

		private delegate bool dummyCallback(IntPtr signal);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
        }

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
        [Description("RenderTaskSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.RenderTaskSignal.RenderTaskSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RenderTaskSignalConstructor()
        {
            tlog.Debug(tag, $"RenderTaskSignalConstructor START");

            var testingTarget = new RenderTaskSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<RenderTaskSignal>(testingTarget, "Should be an Instance of RenderTaskSignal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RenderTaskSignalConstructor END (OK)");
        }
    }
}
