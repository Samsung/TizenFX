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
    public class PublicBoldSpanTest
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
        [Property("SPEC", "Tizen.NUI.Text.Spans.BoldSpan.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Sara Al-Jammal, s.al-jammal@partner.samsung.com")]
        public void BoldSpanCreate()
        {
            tlog.Debug(tag, $"BoldSpanCreate START");

            var testingTarget = BoldSpan.Create();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BoldSpan>(testingTarget, "Should return BoldSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"BoldSpanCreate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BoldSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BoldSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Sara Al-Jammal, s.al-jammal@partner.samsung.com")]
        public void BoldSpanDispose()
        {
            tlog.Debug(tag, $"BoldSpanDispose START");

            var testingTarget = BoldSpan.Create();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BoldSpan>(testingTarget, "Should return BoldSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BoldSpanDispose END (OK)");
        }
    }
}