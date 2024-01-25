using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/GlyphInfo")]
    public class InternalGlyphInfoTest
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
        [Description("GlyphInfo constructor.")]
        [Property("SPEC", "Tizen.NUI.GlyphInfo.GlyphInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GlyphInfoConstructor()
        {
            tlog.Debug(tag, $"GlyphInfoConstructor START");

            var testingTarget = new GlyphInfo();
            Assert.IsNotNull(testingTarget, "Can't create success object GlyphInfo.");
            Assert.IsInstanceOf<GlyphInfo>(testingTarget, "Should return GlyphInfo instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GlyphInfoConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphInfo constructor. With parameters.")]
        [Property("SPEC", "Tizen.NUI.GlyphInfo.GlyphInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GlyphInfoConstructorWithParameters()
        {
            tlog.Debug(tag, $"GlyphInfoConstructorWithParameters START");

            var testingTarget = new GlyphInfo(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object GlyphInfo.");
            Assert.IsInstanceOf<GlyphInfo>(testingTarget, "Should return GlyphInfo instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GlyphInfoConstructorWithParameters END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphInfo FontId.")]
        [Property("SPEC", "Tizen.NUI.GlyphInfo.FontId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GlyphInfoFontId()
        {
            tlog.Debug(tag, $"GlyphInfoFontId START");

            var testingTarget = new GlyphInfo(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object GlyphInfo.");
            Assert.IsInstanceOf<GlyphInfo>(testingTarget, "Should return GlyphInfo instance.");

            testingTarget.FontId = 3;
            tlog.Debug(tag, "FontId :" + testingTarget.FontId);

            testingTarget.Dispose();
            tlog.Debug(tag, $"GlyphInfoFontId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphInfo Index.")]
        [Property("SPEC", "Tizen.NUI.GlyphInfo.Index A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GlyphInfoIndex()
        {
            tlog.Debug(tag, $"GlyphInfoIndex START");

            var testingTarget = new GlyphInfo(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object GlyphInfo.");
            Assert.IsInstanceOf<GlyphInfo>(testingTarget, "Should return GlyphInfo instance.");

            testingTarget.Index = 3;
            tlog.Debug(tag, "Index :" + testingTarget.FontId);

            testingTarget.Dispose();
            tlog.Debug(tag, $"GlyphInfoIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphInfo Width.")]
        [Property("SPEC", "Tizen.NUI.GlyphInfo.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GlyphInfoWidth()
        {
            tlog.Debug(tag, $"GlyphInfoWidth START");

            var testingTarget = new GlyphInfo(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object GlyphInfo.");
            Assert.IsInstanceOf<GlyphInfo>(testingTarget, "Should return GlyphInfo instance.");

            testingTarget.Width = 30.0f;
            tlog.Debug(tag, "Width :" + testingTarget.Width);

            testingTarget.Dispose();
            tlog.Debug(tag, $"GlyphInfoWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphInfo Height.")]
        [Property("SPEC", "Tizen.NUI.GlyphInfo.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GlyphInfoHeight()
        {
            tlog.Debug(tag, $"GlyphInfoHeight START");

            var testingTarget = new GlyphInfo(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object GlyphInfo.");
            Assert.IsInstanceOf<GlyphInfo>(testingTarget, "Should return GlyphInfo instance.");

            testingTarget.Height = 30.0f;
            tlog.Debug(tag, "Height :" + testingTarget.Height);

            testingTarget.Dispose();
            tlog.Debug(tag, $"GlyphInfoHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphInfo XBearing.")]
        [Property("SPEC", "Tizen.NUI.GlyphInfo.XBearing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GlyphInfoXBearing()
        {
            tlog.Debug(tag, $"GlyphInfoXBearing START");

            var testingTarget = new GlyphInfo(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object GlyphInfo.");
            Assert.IsInstanceOf<GlyphInfo>(testingTarget, "Should return GlyphInfo instance.");

            testingTarget.XBearing = 20.0f;
            tlog.Debug(tag, "XBearing :" + testingTarget.XBearing);

            testingTarget.Dispose();
            tlog.Debug(tag, $"GlyphInfoXBearing END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphInfo YBearing.")]
        [Property("SPEC", "Tizen.NUI.GlyphInfo.YBearing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GlyphInfoYBearing()
        {
            tlog.Debug(tag, $"GlyphInfoYBearing START");

            var testingTarget = new GlyphInfo(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object GlyphInfo.");
            Assert.IsInstanceOf<GlyphInfo>(testingTarget, "Should return GlyphInfo instance.");

            testingTarget.YBearing = 20.0f;
            tlog.Debug(tag, "YBearing :" + testingTarget.YBearing);

            testingTarget.Dispose();
            tlog.Debug(tag, $"GlyphInfoYBearing END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphInfo Advance.")]
        [Property("SPEC", "Tizen.NUI.GlyphInfo.Advance A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GlyphInfoAdvance()
        {
            tlog.Debug(tag, $"GlyphInfoAdvance START");

            var testingTarget = new GlyphInfo(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object GlyphInfo.");
            Assert.IsInstanceOf<GlyphInfo>(testingTarget, "Should return GlyphInfo instance.");

            testingTarget.Advance = 20.0f;
            tlog.Debug(tag, "Advance :" + testingTarget.Advance);

            testingTarget.Dispose();
            tlog.Debug(tag, $"GlyphInfoAdvance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphInfo ScaleFactor.")]
        [Property("SPEC", "Tizen.NUI.GlyphInfo.ScaleFactor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GlyphInfoScaleFactor()
        {
            tlog.Debug(tag, $"GlyphInfoScaleFactor START");

            var testingTarget = new GlyphInfo(1, 2);
            Assert.IsNotNull(testingTarget, "Can't create success object GlyphInfo.");
            Assert.IsInstanceOf<GlyphInfo>(testingTarget, "Should return GlyphInfo instance.");

            testingTarget.ScaleFactor = 0.3f;
            tlog.Debug(tag, "ScaleFactor :" + testingTarget.ScaleFactor);

            testingTarget.Dispose();
            tlog.Debug(tag, $"GlyphInfoScaleFactor END (OK)");
        }
    }
}
