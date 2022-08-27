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
    public class PublicUnderlineSpanBuilderTest
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
        [Description("UnderlineSpanBuilder Initialize.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpanBuilder.Initialize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanBuilderInitialize()
        {
            tlog.Debug(tag, $"UnderlineSpanBuilderInitialize START");

            var testingTarget = UnderlineSpanBuilder.Initialize();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpanBuilder>(testingTarget, "Should return UnderlineSpanBuilder instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"UnderlineSpanBuilderInitialize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpanBuilder Build.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpanBuilder.Build M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanBuilderBuild()
        {
            tlog.Debug(tag, $"UnderlineSpanBuilderBuild START");

            var testingTarget = UnderlineSpanBuilder.Initialize().Build();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpan>(testingTarget, "Should return UnderlineSpan instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanBuilderBuild END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpanBuilder WithUnderlineType.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpanBuilder.WithUnderlineType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanBuilderWithUnderlineType()
        {
            tlog.Debug(tag, $"UnderlineSpanBuilderWithUnderlineType START");

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineType(UnderlineType.Dashed);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpanBuilder>(testingTarget, "Should return UnderlineSpanBuilder instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanBuilderWithUnderlineType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpanBuilder WithUnderlineColor.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpanBuilder.WithUnderlineColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanBuilderWithUnderlineColor()
        {
            tlog.Debug(tag, $"UnderlineSpanBuilderWithUnderlineColor START");

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineColor(Color.Green);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpanBuilder>(testingTarget, "Should return UnderlineSpanBuilder instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanBuilderWithUnderlineColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpanBuilder WithUnderlineHeight.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpanBuilder.WithUnderlineHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanBuilderWithUnderlineHeight()
        {
            tlog.Debug(tag, $"UnderlineSpanBuilderWithUnderlineHeight START");

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineHeight(4.0f);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpanBuilder>(testingTarget, "Should return UnderlineSpanBuilder instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanBuilderWithUnderlineHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpanBuilder WithUnderlineDashGap.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpanBuilder.WithUnderlineDashGap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanBuilderWithUnderlineDashGap()
        {
            tlog.Debug(tag, $"UnderlineSpanBuilderWithUnderlineDashGap START");

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineDashGap(2.0f);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpanBuilder>(testingTarget, "Should return UnderlineSpanBuilder instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanBuilderWithUnderlineDashGap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpanBuilder WithUnderlineDashWidth.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpanBuilder.WithUnderlineDashWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanBuilderWithUnderlineDashWidth()
        {
            tlog.Debug(tag, $"UnderlineSpanBuilderWithUnderlineDashWidth START");

            var testingTarget = UnderlineSpanBuilder.Initialize().WithUnderlineDashWidth(3.0f);

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpanBuilder>(testingTarget, "Should return UnderlineSpanBuilder instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"UnderlineSpanBuilderWithUnderlineDashWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("UnderlineSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.UnderlineSpanBuilder.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void UnderlineSpanBuilderDispose()
        {
            tlog.Debug(tag, $"UnderlineSpanBuilderDispose START");

            var testingTarget = UnderlineSpanBuilder.Initialize();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<UnderlineSpanBuilder>(testingTarget, "Should return UnderlineSpanBuilder instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"UnderlineSpanBuilderDispose END (OK)");
        }
    }
}
