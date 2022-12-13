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
    public class PublicBackgroundColorSpanTest
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
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundColorSpan.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void BackgroundColorSpanCreate()
        {
            tlog.Debug(tag, $"BackgroundColorSpanCreate START");

            var testingTarget = BackgroundColorSpan.Create(Color.Green);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundColorSpan>(testingTarget, "Should return BackgroundColorSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"BackgroundColorSpanCreate END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("BackgroundColorSpan Color.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundColorSpan.Color A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void BackgroundColorSpanColor()
        {
            tlog.Debug(tag, $"BackgroundColorSpanColor START");

            Color expected = Color.Green;

            var testingTarget = BackgroundColorSpan.Create(expected);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundColorSpan>(testingTarget, "Should return BackgroundColorSpan instance.");

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
            tlog.Debug(tag, $"BackgroundColorSpanColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BackgroundColorSpan HasColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundColorSpan.HasColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void BackgroundColorSpanHasColor()
        {
            tlog.Debug(tag, $"BackgroundColorSpanHasColor START");

            var expected = true;

            var testingTarget = BackgroundColorSpan.Create(Color.Green);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundColorSpan>(testingTarget, "Should return BackgroundColorSpan instance.");

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
            tlog.Debug(tag, $"BackgroundColorSpanHasColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BackgroundColorSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundColorSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "s.al-jammal@partner.samsung.com")]
        public void BackgroundColorSpanDispose()
        {
            tlog.Debug(tag, $"BackgroundColorSpanDispose START");

            var testingTarget = BackgroundColorSpan.Create(Color.Green);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundColorSpan>(testingTarget, "Should return BackgroundColorSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BackgroundColorSpanDispose END (OK)");
        }
    }
}