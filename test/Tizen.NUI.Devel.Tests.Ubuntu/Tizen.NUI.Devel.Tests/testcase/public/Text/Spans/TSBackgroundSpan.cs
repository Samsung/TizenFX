using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.Text.Spans;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Text/Spans")]
    public class PublicBackgroundSpanTest
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
        [Description("BackgroundSpan BackgroundColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundSpan.BackgroundColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void BackgroundSpanBackgroundColor()
        {
            tlog.Debug(tag, $"BackgroundSpanBackgroundColor START");

            Color expected = Color.Green;

            var testingTarget = BackgroundSpanBuilder.Initialize().WithBackgroundColor(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundSpan>(testingTarget, "Should return BackgroundSpan instance.");

            try
            {
                var resutl = testingTarget.BackgroundColor;
                Assert.AreEqual(true, TestUtils.CheckColor(expected, resutl), "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"BackgroundSpanBackgroundColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BackgroundSpan BackgroundColorDefined.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundSpan.BackgroundColorDefined A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void BackgroundSpanBackgroundColorDefined()
        {
            tlog.Debug(tag, $"BackgroundSpanBackgroundColorDefined START");

            Color expected = Color.Green;

            var testingTarget = BackgroundSpanBuilder.Initialize().WithBackgroundColor(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundSpan>(testingTarget, "Should return BackgroundSpan instance.");

            try
            {
                var resutl = testingTarget.BackgroundColorDefined;
                Assert.AreEqual(true, resutl, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"BackgroundSpanBackgroundColorDefined END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BackgroundSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void BackgroundSpanDispose()
        {
            tlog.Debug(tag, $"BackgroundSpanDispose START");

            var testingTarget = BackgroundSpanBuilder.Initialize().Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundSpan>(testingTarget, "Should return BackgroundSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BackgroundSpanDispose END (OK)");
        }
    }
}
