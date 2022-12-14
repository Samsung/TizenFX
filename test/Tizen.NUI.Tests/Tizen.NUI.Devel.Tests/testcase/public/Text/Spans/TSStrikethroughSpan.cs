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
        [Description("StrikethroughSpan Create.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanCreate()
        {
            tlog.Debug(tag, $"StrikethroughSpanCreate START");

            var testingTarget = StrikethroughSpan.Create();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"StrikethroughSpanCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpan Create.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanCreateColorHeight()
        {
            tlog.Debug(tag, $"StrikethroughSpanCreateColorHeight START");

            var testingTarget = StrikethroughSpan.Create(Color.Green, 5.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"StrikethroughSpanCreateColorHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpan Color.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.Color A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanColor()
        {
            tlog.Debug(tag, $"StrikethroughSpanColor START");

            var testingTarget = StrikethroughSpan.Create(Color.Green, 5.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            try
            {
                var result = testingTarget.Color;
                Assert.AreEqual(true, TestUtils.CheckColor(Color.Green, result), "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"StrikethroughSpanColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpan Height.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanHeight()
        {
            tlog.Debug(tag, $"StrikethroughSpanHeight START");

            var testingTarget = StrikethroughSpan.Create(Color.Green, 5.0f);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            try
            {
                Assert.AreEqual( 5.0f, testingTarget.Height, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"StrikethroughSpanHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpan HasColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.HasColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanHasColor()
        {
            tlog.Debug(tag, $"StrikethroughSpanHasColor START");

            var expected = true;

            var testingTarget = StrikethroughSpan.Create(Color.Green, 5.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

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
            tlog.Debug(tag, $"StrikethroughSpanHasColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpan HasHeight.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpan.HasHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanHasHeight()
        {
            tlog.Debug(tag, $"StrikethroughSpanHasHeight START");

            var expected = true;

            var testingTarget = StrikethroughSpan.Create(Color.Green, 5.0f);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            try
            {
                var result = testingTarget.HasHeight;
                Assert.AreEqual(expected, result, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"StrikethroughSpanHasHeight END (OK)");
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

            var testingTarget = StrikethroughSpan.Create( );
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