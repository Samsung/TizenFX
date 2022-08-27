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
    public class PublicStrikethroughSpanBuilderTest
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
        [Description("StrikethroughSpanBuilder Initialize.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpanBuilder.Initialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanBuilderInitialize()
        {
            tlog.Debug(tag, $"StrikethroughSpanBuilderInitialize START");

            var testingTarget = StrikethroughSpanBuilder.Initialize();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpanBuilder>(testingTarget, "Should return StrikethroughSpanBuilder instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"StrikethroughSpanBuilderInitialize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpanBuilder Build.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpanBuilder.Build M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanBuilderBuild()
        {
            tlog.Debug(tag, $"StrikethroughSpanBuilderBuild START");

            var testingTarget = StrikethroughSpanBuilder.Initialize().Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpan>(testingTarget, "Should return StrikethroughSpan instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"StrikethroughSpanBuilderBuild END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("StrikethroughSpanBuilder WithStrikethroughColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpanBuilder.WithStrikethroughColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanBuilderWithStrikethroughColor()
        {
            tlog.Debug(tag, $"StrikethroughSpanBuilderWithStrikethroughColor START");

            var testingTarget = StrikethroughSpanBuilder.Initialize().WithStrikethroughColor(Color.Green);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpanBuilder>(testingTarget, "Should return StrikethroughSpanBuilder instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"StrikethroughSpanBuilderWithStrikethroughColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpanBuilder WithStrikethroughHeight.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpanBuilder.WithStrikethroughHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanBuilderWithStrikethroughHeight()
        {
            tlog.Debug(tag, $"StrikethroughSpanBuilderWithStrikethroughHeight START");

            var testingTarget = StrikethroughSpanBuilder.Initialize().WithStrikethroughHeight(4.0f);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpanBuilder>(testingTarget, "Should return StrikethroughSpanBuilder instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"StrikethroughSpanBuilderWithStrikethroughHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StrikethroughSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.StrikethroughSpanBuilder.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void StrikethroughSpanBuilderDispose()
        {
            tlog.Debug(tag, $"StrikethroughSpanBuilderDispose START");

            var testingTarget = StrikethroughSpanBuilder.Initialize();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<StrikethroughSpanBuilder>(testingTarget, "Should return StrikethroughSpanBuilder instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"StrikethroughSpanBuilderDispose END (OK)");
        }
    }
}
