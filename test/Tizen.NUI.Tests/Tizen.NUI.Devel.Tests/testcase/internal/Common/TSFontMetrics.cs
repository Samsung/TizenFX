using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/FontMetrics")]
    public class InternalFontMetricsTest
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
        [Description("FontMetrics constructor.")]
        [Property("SPEC", "Tizen.NUI.FontMetrics.FontMetrics C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontMetricsConstructor()
        {
            tlog.Debug(tag, $"FontMetricsConstructor START");

            var testingTarget = new FontMetrics();
            Assert.IsNotNull(testingTarget, "Can't create success object FontMetrics.");
            Assert.IsInstanceOf<FontMetrics>(testingTarget, "Should return FontMetrics instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontMetricsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontMetrics constructor.")]
        [Property("SPEC", "Tizen.NUI.FontMetrics.FontMetrics C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontMetricsConstructorWithFloats()
        {
            tlog.Debug(tag, $"FontMetricsConstructorWithFloats START");

            var testingTarget = new FontMetrics(0.3f, 0.1f, 0.5f, 0.9f, 0.0f);
            Assert.IsNotNull(testingTarget, "Can't create success object FontMetrics.");
            Assert.IsInstanceOf<FontMetrics>(testingTarget, "Should return FontMetrics instance.");

            testingTarget.UnderlineThickness = 0.3f;
            tlog.Debug(tag, "UnderlineThickness :" + testingTarget.UnderlineThickness);

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontMetricsConstructorWithFloats END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontMetrics Ascender.")]
        [Property("SPEC", "Tizen.NUI.FontMetrics.Ascender A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontMetricsAscender()
        {
            tlog.Debug(tag, $"FontMetricsAscender START");

            var testingTarget = new FontMetrics();
            Assert.IsNotNull(testingTarget, "Can't create success object FontMetrics.");
            Assert.IsInstanceOf<FontMetrics>(testingTarget, "Should return FontMetrics instance.");

            testingTarget.Ascender = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.Ascender, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontMetricsAscender END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontMetrics Descender.")]
        [Property("SPEC", "Tizen.NUI.FontMetrics.Descender A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontMetricsDescender()
        {
            tlog.Debug(tag, $"FontMetricsDescender START");

            var testingTarget = new FontMetrics();
            Assert.IsNotNull(testingTarget, "Can't create success object FontMetrics.");
            Assert.IsInstanceOf<FontMetrics>(testingTarget, "Should return FontMetrics instance.");

            testingTarget.Descender = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.Descender, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontMetricsDescender END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontMetrics Height.")]
        [Property("SPEC", "Tizen.NUI.FontMetrics.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontMetricsHeight()
        {
            tlog.Debug(tag, $"FontMetricsHeight START");

            var testingTarget = new FontMetrics();
            Assert.IsNotNull(testingTarget, "Can't create success object FontMetrics.");
            Assert.IsInstanceOf<FontMetrics>(testingTarget, "Should return FontMetrics instance.");

            testingTarget.Height = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.Height, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontMetricsHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontMetrics UnderlinePosition.")]
        [Property("SPEC", "Tizen.NUI.FontMetrics.UnderlinePosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontMetricsUnderlinePosition()
        {
            tlog.Debug(tag, $"FontMetricsUnderlinePosition START");

            var testingTarget = new FontMetrics();
            Assert.IsNotNull(testingTarget, "Can't create success object FontMetrics.");
            Assert.IsInstanceOf<FontMetrics>(testingTarget, "Should return FontMetrics instance.");

            testingTarget.UnderlinePosition = 0.3f;
            Assert.AreEqual(0.3f, testingTarget.UnderlinePosition, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontMetricsUnderlinePosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontMetrics UnderlineThickness.")]
        [Property("SPEC", "Tizen.NUI.FontMetrics.UnderlineThickness A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontMetricsUnderlineThickness()
        {
            tlog.Debug(tag, $"FontMetricsUnderlineThickness START");

            var testingTarget = new FontMetrics();
            Assert.IsNotNull(testingTarget, "Can't create success object FontMetrics.");
            Assert.IsInstanceOf<FontMetrics>(testingTarget, "Should return FontMetrics instance.");

            testingTarget.UnderlinePosition = 0.1f;
            Assert.AreEqual(0.1f, testingTarget.UnderlinePosition, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontMetricsUnderlineThickness END (OK)");
        }
    }
}
