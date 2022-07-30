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
    public class PublicBaseSpanTest
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
        [Description("BaseSpan GetMarkupTagName.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BaseSpan.GetMarkupTagName M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void BaseSpanGetMarkupTagName()
        {
            tlog.Debug(tag, $"BaseSpanGetMarkupTagName START");

            var testingTarget = ForegroundColorSpanBuilder.Initialize().Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseSpan>(testingTarget, "Should return ForegroundColorSpan instance.");

            try
            {
                var result = testingTarget.GetMarkupTagName();
                Assert.IsNotNull(result, "null handle");
                Assert.IsInstanceOf<string>(result, "Should return string instance.");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseSpanGetMarkupTagName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BaseSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BaseSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void BaseSpanDispose()
        {
            tlog.Debug(tag, $"BaseSpanDispose START");

            var testingTarget = ForegroundColorSpanBuilder.Initialize().Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BaseSpan>(testingTarget, "Should return BaseSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BaseSpanDispose END (OK)");
        }
    }
}
