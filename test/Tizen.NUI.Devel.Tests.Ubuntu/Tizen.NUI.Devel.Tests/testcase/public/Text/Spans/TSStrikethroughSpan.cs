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
    public class PublicStrikethroughSpanTest
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
        [Description("StrikethroughSpan StrikethroughColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.StrikethroughColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanStrikethroughColor()
        {
            tlog.Debug(tag, $"StrikethroughSpanForegroundColor START");

            Color expected = Color.Green;

            var testingTarget = StrikethroughSpanBuilder.Initialize().WithStrikethroughColor(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            try
            {
                var result = testingTarget.StrikethroughColor;
                Assert.AreEqual(true, TestUtils.CheckColor(expected, result), "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"StrikethroughSpanStrikethroughColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpan StrikethroughColorDefined.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.StrikethroughColorDefined A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanStrikethroughColorDefined()
        {
            tlog.Debug(tag, $"StrikethroughSpanStrikethroughColorDefined START");

            Color expected = Color.Green;

            var testingTarget = StrikethroughSpanBuilder.Initialize().WithStrikethroughColor(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            try
            {
                var result = testingTarget.StrikethroughColorDefined;
                Assert.AreEqual(true, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"StrikethroughSpanStrikethroughColorDefined END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpan StrikethroughHeight.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.StrikethroughHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanStrikethroughHeight()
        {
            tlog.Debug(tag, $"StrikethroughSpanStrikethroughHeight START");

            float expected = 5.0f;

            var testingTarget = StrikethroughSpanBuilder.Initialize().WithStrikethroughHeight(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            try
            {
                var result = testingTarget.StrikethroughHeight;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"StrikethroughSpanStrikethroughHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpan StrikethroughHeightDefined.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.StrikethroughHeightDefined A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanStrikethroughHeightDefined()
        {
            tlog.Debug(tag, $"StrikethroughSpanStrikethroughHeightDefined START");

            float expected = 5.0f;

            var testingTarget = StrikethroughSpanBuilder.Initialize().WithStrikethroughHeight(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            try
            {
                var result = testingTarget.StrikethroughHeightDefined;
                Assert.AreEqual(true, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"StrikethroughSpanStrikethroughHeightDefined END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanDispose()
        {
            tlog.Debug(tag, $"StrikethroughSpanDispose START");

            var testingTarget = StrikethroughSpanBuilder.Initialize().Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"StrikethroughSpanDispose END (OK)");
        }
    }
}
