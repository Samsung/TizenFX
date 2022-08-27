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
    public class PublicUnderlineSpanTest
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
        [Description("UnderlineSpan UnderlineType.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.UnderlineType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanUnderlineType()
        {
            tlog.Debug(tag, $"UnderlineSpanUnderlineType START");

            UnderlineType expected = UnderlineType.Double;

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineType(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.UnderlineType;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanUnderlineType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan UnderlineTypeDefined.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.UnderlineTypeDefined A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanUnderlineTypeDefined()
        {
            tlog.Debug(tag, $"UnderlineSpanUnderlineTypeDefined START");

            UnderlineType expected = UnderlineType.Double;

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineType(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.UnderlineTypeDefined;
                Assert.AreEqual(true, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanUnderlineTypeDefined END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan UnderlineColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.UnderlineColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanUnderlineColor()
        {
            tlog.Debug(tag, $"UnderlineSpanForegroundColor START");

            Color expected = Color.Green;

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineColor(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.UnderlineColor;
                Assert.AreEqual(true, TestUtils.CheckColor(expected, result), "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanUnderlineColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan UnderlineColorDefined.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.UnderlineColorDefined A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanUnderlineColorDefined()
        {
            tlog.Debug(tag, $"UnderlineSpanUnderlineColorDefined START");

            Color expected = Color.Green;

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineColor(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.UnderlineColorDefined;
                Assert.AreEqual(true, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanUnderlineColorDefined END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan UnderlineHeight.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.UnderlineHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanUnderlineHeight()
        {
            tlog.Debug(tag, $"UnderlineSpanUnderlineHeight START");

            float expected = 5.0f;

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineHeight(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.UnderlineHeight;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanUnderlineHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan UnderlineHeightDefined.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.UnderlineHeightDefined A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanUnderlineHeightDefined()
        {
            tlog.Debug(tag, $"UnderlineSpanUnderlineHeightDefined START");

            float expected = 5.0f;

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineHeight(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.UnderlineHeightDefined;
                Assert.AreEqual(true, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanUnderlineHeightDefined END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan UnderlineDashGap.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.UnderlineDashGap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanUnderlineDashGap()
        {
            tlog.Debug(tag, $"UnderlineSpanUnderlineDashGap START");

            float expected = 2.0f;

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineDashGap(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.UnderlineDashGap;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanUnderlineDashGap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan UnderlineDashGapDefined.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.UnderlineDashGapDefined A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanUnderlineDashGapDefined()
        {
            tlog.Debug(tag, $"UnderlineSpanUnderlineDashGapDefined START");

            float expected = 2.0f;

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineDashGap(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.UnderlineDashGapDefined;
                Assert.AreEqual(true, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanUnderlineDashGapDefined END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan UnderlineDashWidth.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.UnderlineDashWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanUnderlineDashWidth()
        {
            tlog.Debug(tag, $"UnderlineSpanUnderlineDashWidth START");

            float expected = 3.0f;

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineDashWidth(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.UnderlineDashWidth;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanUnderlineDashWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan UnderlineDashWidthDefined.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.UnderlineDashWidthDefined A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanUnderlineDashWidthDefined()
        {
            tlog.Debug(tag, $"UnderlineSpanUnderlineDashWidthDefined START");

            float expected = 3.0f;

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineDashWidth(expected).Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                var result = testingTarget.UnderlineDashWidthDefined;
                Assert.AreEqual(true, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanUnderlineDashWidthDefined END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanDispose()
        {
            tlog.Debug(tag, $"UnderlineSpanDispose START");

            var testingTarget = UnderlineSpanBuilder.Initialize().Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"UnderlineSpanDispose END (OK)");
        }
    }
}
