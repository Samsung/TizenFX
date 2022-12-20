using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.NUI.Text.Spans;
using Tizen.NUI.Text;


namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Text")]
    public class PublicSpannedTest
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
        [Description("Spanned GetAllSpans.")]
        [Property("SPEC", "Tizen.NUI.Text.Spanned.GetAllSpans M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannedGetAllSpans()
        {
            tlog.Debug(tag, $"SpannedGetAllSpans START");

            var testingTarget = SpannableString.Create("Hello World!");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Spanned>(testingTarget, "Should return Spanned instance.");

            var flagIsAttached = testingTarget.AttachSpan(
                ForegroundColorSpan.Create(Color.Green),
                Range.Create(2,5)
            );

            Assert.AreEqual(true, flagIsAttached, "Should be true!");

            var spans = testingTarget.GetAllSpans();
            Assert.IsInstanceOf<List<BaseSpan>>(spans, "Should return List<BaseSpan> instance.");

            Assert.AreEqual(1u, spans.Count, "Should be true!");

            Assert.IsInstanceOf<BaseSpan>( spans[0], "Should return BaseSpan instance.");
            Assert.AreEqual(TextSpanType.ForegroundColor, spans[0].SpanType, "Should be true!");
            Assert.IsInstanceOf<ForegroundColorSpan>( spans[0], "Should return ForegroundColorSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"SpannedGetAllSpans END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("Spanned RetrieveAllSpansAndRanges.")]
        [Property("SPEC", "Tizen.NUI.Text.Spanned.RetrieveAllSpansAndRanges M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void SpannedRetrieveAllSpansAndRanges()
        {
            tlog.Debug(tag, $"SpannedRetrieveAllSpansAndRanges START");

            var testingTarget = SpannableString.Create("Hello World!");
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Spanned>(testingTarget, "Should return Spanned instance.");

            var flagIsAttached = testingTarget.AttachSpan(
                ForegroundColorSpan.Create(Color.Green),
                Range.Create(2,5)
            );

            Assert.AreEqual(true, flagIsAttached, "Should be true!");

            List<BaseSpan> spans = new List<BaseSpan>();
            List<Tizen.NUI.Range> ranges = new List<Tizen.NUI.Range>();

            testingTarget.RetrieveAllSpansAndRanges(spans, ranges);

            Assert.AreEqual(1u, spans.Count, "Should be true!");
            Assert.AreEqual(1u, ranges.Count, "Should be true!");

            Assert.IsInstanceOf<BaseSpan>( spans[0], "Should return BaseSpan instance.");
            Assert.AreEqual(TextSpanType.ForegroundColor, spans[0].SpanType, "Should be true!");
            Assert.IsInstanceOf<ForegroundColorSpan>( spans[0], "Should return ForegroundColorSpan instance.");

            Assert.IsInstanceOf<Tizen.NUI.Range>( ranges[0], "Should return Tizen.NUI.Range instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"SpannedRetrieveAllSpansAndRanges END (OK)");
        }
    }
}