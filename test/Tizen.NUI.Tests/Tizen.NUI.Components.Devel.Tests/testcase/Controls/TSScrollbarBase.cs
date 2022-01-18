using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/ScrollbarBase")]
    public class ScrollbarBaseTest
    {
        private const string tag = "NUITEST";

        internal class ScrollbarBaseImpl : ScrollbarBase
        {
            public ScrollbarBaseImpl() : base()
            { }

            public override float ScrollPosition => 0.0f;

            public override float ScrollCurrentPosition => 30.0f;

            public override void Initialize(float contentLength, float viewportLength, float currentPosition, bool isHorizontal = false) { }

            public override void ScrollTo(float position, uint durationMs = 0, AlphaFunction alphaFunction = null) { }

            public override void Update(float contentLength, float viewportLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null) { }

            public override void Update(float contentLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null) { }
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
        [Description("ScrollbarBase Unparent.")]
        [Property("SPEC", "Tizen.NUI.Components.ScrollbarBase.Unparent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollbarBaseUnparent()
        {
            tlog.Debug(tag, $"ScrollbarBaseUnparent START");

            var testingTarget = new ScrollbarBaseImpl();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ScrollbarBase>(testingTarget, "Should return ScrollbarBase instance.");

            try
            {
                testingTarget.Unparent();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Assert Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollbarBaseUnparent END (OK)");
        }
    }
}
