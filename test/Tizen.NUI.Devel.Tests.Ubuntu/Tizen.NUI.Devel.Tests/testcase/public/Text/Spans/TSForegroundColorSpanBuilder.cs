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
    public class PublicForegroundColorSpanBuilderTest
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
        [Description("ForegroundColorSpanBuilder Initialize.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ForegroundColorSpanBuilder.Initialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void ForegroundColorSpanBuilderInitialize()
        {
            tlog.Debug(tag, $"ForegroundColorSpanBuilderInitialize START");

            var testingTarget = ForegroundColorSpanBuilder.Initialize();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ForegroundColorSpanBuilder>(testingTarget, "Should return ForegroundColorSpanBuilder instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"ForegroundColorSpanBuilderInitialize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ForegroundColorSpanBuilder Build.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ForegroundColorSpanBuilder.Build M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void ForegroundColorSpanBuilderBuild()
        {
            tlog.Debug(tag, $"ForegroundColorSpanBuilderBuild START");

            var testingTarget = ForegroundColorSpanBuilder.Initialize().Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ForegroundColorSpan>(testingTarget, "Should return ForegroundColorSpan instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ForegroundColorSpanBuilderBuild END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ForegroundColorSpanBuilder WithForegroundColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ForegroundColorSpanBuilder.WithForegroundColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void ForegroundColorSpanBuilderWithForegroundColor()
        {
            tlog.Debug(tag, $"ForegroundColorSpanBuilderWithForegroundColor START");

            var testingTarget = ForegroundColorSpanBuilder.Initialize().WithForegroundColor(Color.Green);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ForegroundColorSpanBuilder>(testingTarget, "Should return ForegroundColorSpanBuilder instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ForegroundColorSpanBuilderWithForegroundColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ForegroundColorSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.ForegroundColorSpanBuilder.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void ForegroundColorSpanBuilderDispose()
        {
            tlog.Debug(tag, $"ForegroundColorSpanBuilderDispose START");

            var testingTarget = ForegroundColorSpanBuilder.Initialize();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ForegroundColorSpanBuilder>(testingTarget, "Should return ForegroundColorSpanBuilder instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"ForegroundColorSpanBuilderDispose END (OK)");
        }
    }
}
