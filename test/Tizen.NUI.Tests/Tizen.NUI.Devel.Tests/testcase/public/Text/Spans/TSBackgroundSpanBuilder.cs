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
    public class PublicBackgroundSpanBuilderTest
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
        [Description("BackgroundSpanBuilder Initialize.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundSpanBuilder.Initialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void BackgroundSpanBuilderInitialize()
        {
            tlog.Debug(tag, $"BackgroundSpanBuilderInitialize START");

            var testingTarget = BackgroundSpanBuilder.Initialize();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundSpanBuilder>(testingTarget, "Should return BackgroundSpanBuilder instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"BackgroundSpanBuilderInitialize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BackgroundSpanBuilder Build.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundSpanBuilder.Build M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void BackgroundSpanBuilderBuild()
        {
            tlog.Debug(tag, $"BackgroundSpanBuilderBuild START");

            var testingTarget = BackgroundSpanBuilder.Initialize().Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundSpan>(testingTarget, "Should return BackgroundSpan instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"BackgroundSpanBuilderBuild END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BackgroundSpanBuilder WithBackgroundColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundSpanBuilder.WithBackgroundColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void BackgroundSpanBuilderWithBackgroundColor()
        {
            tlog.Debug(tag, $"BackgroundSpanBuilderWithBackgroundColor START");

            var testingTarget = BackgroundSpanBuilder.Initialize().WithBackgroundColor(Color.Green);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundSpanBuilder>(testingTarget, "Should return BackgroundSpanBuilder instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"BackgroundSpanBuilderWithBackgroundColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BackgroundSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.BackgroundSpanBuilder.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void BackgroundSpanBuilderDispose()
        {
            tlog.Debug(tag, $"BackgroundSpanBuilderDispose START");

            var testingTarget = BackgroundSpanBuilder.Initialize();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<BackgroundSpanBuilder>(testingTarget, "Should return BackgroundSpanBuilder instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"BackgroundSpanBuilderDispose END (OK)");
        }
    }
}
