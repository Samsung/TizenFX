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
    public class PublicFontSpanTest
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
        [Description("FontSpan Create.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.Create M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanCreate()
        {
            tlog.Debug(tag, $"FontSpanCreate START");

            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"FontSpanCreate END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("FontSpan FamilyName.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.FamilyName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanFamilyName()
        {
            tlog.Debug(tag, $"FontSpanFamilyName START");


            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                Assert.AreEqual("DejaVu Sans",  testingTarget.FamilyName, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontSpanFamilyName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontSpan WeightType.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.WeightType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanWeightType()
        {
            tlog.Debug(tag, $"FontSpanWeightType START");


            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                Assert.AreEqual( FontWeightType.Light, testingTarget.WeightType, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontSpanWeightType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontSpan WidthType.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.WidthType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanWidthType()
        {
            tlog.Debug(tag, $"FontSpanWidthType START");


            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                Assert.AreEqual(FontWidthType.Condensed, testingTarget.WidthType, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontSpanWidthType END (OK)");
        }

                [Test]
        [Category("P1")]
        [Description("FontSpan SlantType.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.SlantType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanSlantType()
        {
            tlog.Debug(tag, $"FontSpanSlantType START");


            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                Assert.AreEqual(FontSlantType.Italic, testingTarget.SlantType, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontSpanSlantType END (OK)");
        }

                [Test]
        [Category("P1")]
        [Description("FontSpan Size.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.Size A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanSize()
        {
            tlog.Debug(tag, $"FontSpanSize START");


            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                Assert.AreEqual( 40.0f, testingTarget.Size, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontSpanSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontSpan HasFamilyName.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.HasFamilyName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanHasFamilyName()
        {
            tlog.Debug(tag, $"FontSpanHasFamilyName START");

            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                Assert.AreEqual(true, testingTarget.HasFamilyName, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontSpanHasFamilyName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontSpan HasWeight.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.HasWeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanHasWeight()
        {
            tlog.Debug(tag, $"FontSpanHasWeight START");

            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                Assert.AreEqual(true, testingTarget.HasWeight, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontSpanHasWeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontSpan HasWidth.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.HasWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanHasWidth()
        {
            tlog.Debug(tag, $"FontSpanHasWidth START");

            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                Assert.AreEqual(true, testingTarget.HasFamilyName, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontSpanHasWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontSpan HasSlant.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.HasSlant A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanHasSlant()
        {
            tlog.Debug(tag, $"FontSpanHasSlant START");

            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                Assert.AreEqual(true, testingTarget.HasSlant, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontSpanHasSlant END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontSpan HasSize.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.HasSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanHasSize()
        {
            tlog.Debug(tag, $"FontSpanHasSize START");

            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );

            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                Assert.AreEqual(true, testingTarget.HasSize, "Should be true!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontSpanHasSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontSpan Dispose.")]
        [Property("SPEC", "Tizen.NUI.Text.Spans.FontSpan.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR MCST")]
        [Property("AUTHOR", "Shrouq Sabah, s.sabah@samsung.com")]
        public void FontSpanDispose()
        {
            tlog.Debug(tag, $"FontSpanDispose START");

            var testingTarget = FontSpan.Create("DejaVu Sans",
                                                 40.0f,
                                                 FontWeightType.Light,
                                                 FontWidthType.Condensed,
                                                 FontSlantType.Italic );


            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<FontSpan>(testingTarget, "Should return FontSpan instance.");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"FontSpanDispose END (OK)");
        }
    }
}