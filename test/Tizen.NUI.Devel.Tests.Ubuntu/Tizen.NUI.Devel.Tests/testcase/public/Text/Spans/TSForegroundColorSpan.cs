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
        [Description("Range Create.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ForegroundColorSpan.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void ForegroundColorSpanCreate()
        {
            tlog.Debug(tag, $"ForegroundColorSpanCreate START");

            var testingTarget = ForegroundColorSpan.Create(Color.Green);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ForegroundColorSpan>(testingTarget, "Should return ForegroundColorSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"ForegroundColorSpanCreate END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("ForegroundColorSpan Color.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ForegroundColorSpan.Color A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void ForegroundColorSpanColor()
        {
            tlog.Debug(tag, $"ForegroundColorSpanColor START");

            Color expected = Color.Green;

            var testingTarget = ForegroundColorSpan.Create(expected);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ForegroundColorSpan>(testingTarget, "Should return ForegroundColorSpan instance.");

            try
            {
                var result = testingTarget.Color;
                Assert.AreEqual(true, TestUtils.CheckColor(expected, result), "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ForegroundColorSpanColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ForegroundColorSpan HasColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ForegroundColorSpan.HasColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void ForegroundColorSpanHasColor()
        {
            tlog.Debug(tag, $"ForegroundColorSpanHasColor START");

            var expected = true;

            var testingTarget = ForegroundColorSpan.Create(Color.Green);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ForegroundColorSpan>(testingTarget, "Should return ForegroundColorSpan instance.");

            try
            {
                var result = testingTarget.HasColor;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ForegroundColorSpanHasColor END (OK)");
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

            var testingTarget = ForegroundColorSpan.Create(Color.Green);
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