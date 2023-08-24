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
    [Description("Style/SliderStyle")]
    public class SliderStyleTest
    {
        private const string tag = "NUITEST";

        internal class MySliderStyle : SliderStyle
        {
            public MySliderStyle() : base()
            { }

            public void OnDispose(bool disposing)
            {
                base.Dispose(disposing);
            }
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
        [Description("SliderStyle Dispose.")]
        [Property("SPEC", "Tizen.NUI.Components.SliderStyle.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SliderStyleDispose()
        {
            tlog.Debug(tag, $"SliderStyleDispose START");

            var testingTarget = new MySliderStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<SliderStyle>(testingTarget, "Should return SliderStyle instance.");

            try
            {
                testingTarget.OnDispose(true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"SliderStyleDispose END (OK)");
        }
    }
}
