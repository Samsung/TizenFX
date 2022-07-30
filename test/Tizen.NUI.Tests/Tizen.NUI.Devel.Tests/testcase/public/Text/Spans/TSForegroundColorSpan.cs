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
    public class PublicForegroundColorSpanTest
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
        [Description("ForegroundColorSpan ForegroundColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ForegroundColorSpan.ForegroundColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void ForegroundColorSpanForegroundColor()
        {
            tlog.Debug(tag, $"ForegroundColorSpanForegroundColor START");

            Color expected = Color.Green;

            var testingTarget = ForegroundColorSpanBuilder.Initialize().WithForegroundColor(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ForegroundColorSpan>(testingTarget, "Should return ForegroundColorSpan instance.");

            try
            {
                var resutl = testingTarget.ForegroundColor;
                Assert.AreEqual(true, TestUtils.CheckColor(expected, resutl), "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ForegroundColorSpanForegroundColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ForegroundColorSpan ForegroundColorDefined.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ForegroundColorSpan.ForegroundColorDefined A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void ForegroundColorSpanForegroundColorDefined()
        {
            tlog.Debug(tag, $"ForegroundColorSpanForegroundColorDefined START");

            Color expected = Color.Green;

            var testingTarget = ForegroundColorSpanBuilder.Initialize().WithForegroundColor(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ForegroundColorSpan>(testingTarget, "Should return ForegroundColorSpan instance.");

            try
            {
                var resutl = testingTarget.ForegroundColorDefined;
                Assert.AreEqual(true, resutl, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ForegroundColorSpanForegroundColorDefined END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ForegroundColorSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ForegroundColorSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void ForegroundColorSpanDispose()
        {
            tlog.Debug(tag, $"ForegroundColorSpanDispose START");

            var testingTarget = ForegroundColorSpanBuilder.Initialize().Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ForegroundColorSpan>(testingTarget, "Should return ForegroundColorSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ForegroundColorSpanDispose END (OK)");
        }
    }
}
