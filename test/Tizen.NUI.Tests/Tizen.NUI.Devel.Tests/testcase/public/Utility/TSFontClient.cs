using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Utility/FontClient")]
    class TSFontClient
    {
        private const string tag = "NUITEST";
        private string ttf_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "TizenSansRegular.ttf";

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

        internal class MySWIGTYPE_p_unsigned_int : SWIGTYPE_p_unsigned_int
        {
            public MySWIGTYPE_p_unsigned_int() : base()
            { }
        }

        [Test]
        [Category("P1")]
        [Description("FontClient constructor.")]
        [Property("SPEC", "Tizen.NUI.FontClient.FontClient C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientConstructor()
        {
            tlog.Debug(tag, $"FontClientConstructor START");

            var testingTarget = new FontClient();
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<FontClient>(testingTarget, "Should be an instance of FontClient type.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"FontClientConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontClient constructor. With FontClient")]
        [Property("SPEC", "Tizen.NUI.FontClient.FontClient C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientConstructorWithFontClient()
        {
            tlog.Debug(tag, $"FontClientConstructorWithFontClient START");

            var testingTarget = new FontClient(FontClient.Instance);
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<FontClient>(testingTarget, "Should be an instance of FontClient type.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"FontClientConstructorWithFontClient END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontClient DefaultPointSize.")]
        [Property("SPEC", "Tizen.NUI.FontClient.DefaultPointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientDefaultPointSize()
        {
            tlog.Debug(tag, $"FontClientDefaultPointSize START");

            var testingTarget = FontClient.DefaultPointSize;
            Assert.AreEqual(768, testingTarget, "Should be equal!");

            tlog.Debug(tag, $"FontClientDefaultPointSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontClient Assign.")]
        [Property("SPEC", "Tizen.NUI.FontClient.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientAssign()
        {
            tlog.Debug(tag, $"FontClientAssign START");

            using (FontClient client = new FontClient())
            {
                try
                {
                    var testingTarget = client.Assign(FontClient.Instance);
                    Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
                    Assert.IsInstanceOf<FontClient>(testingTarget, "Should be an instance of FontClient type.");

                    testingTarget.Dispose();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"FontClientAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontClient GetDpi.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GetDpi M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientGetDpi()
        {
            tlog.Debug(tag, $"FontClientGetDpi START");

            Size size = new Size(1920, 1080);   
            FontClient.Instance.SetDpi((uint)size.Width, (uint)size.Height);

            try
            {
                var horizontalDpi = new SWIGTYPE_p_unsigned_int(size.SwigCPtr.Handle);
                var verticalDpi = new SWIGTYPE_p_unsigned_int(size.SwigCPtr.Handle);
                FontClient.Instance.GetDpi(horizontalDpi, verticalDpi);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed");
            }

            tlog.Debug(tag, $"FontClientGetDpi END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontClient GetDefaultFontSize.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GetDefaultFontSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientGetDefaultFontSize()
        {
            tlog.Debug(tag, $"FontClientGetDefaultFontSize START");

            var testingTarget = new FontClient(FontClient.Instance);
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<FontClient>(testingTarget, "Should be an instance of FontClient type.");

            Assert.IsNotNull(testingTarget.GetDefaultFontSize());

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontClientGetDefaultFontSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontClient GetDefaultPlatformFontDescription.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GetDefaultPlatformFontDescription M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientGetDefaultPlatformFontDescription()
        {
            tlog.Debug(tag, $"FontClientGetDefaultPlatformFontDescription START");

            using (FontDescription description = new FontDescription())
            {
                description.Path = ttf_path;

                var testingTarget = new FontClient(FontClient.Instance);
                Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
                Assert.IsInstanceOf<FontClient>(testingTarget, "Should be an instance of FontClient type.");

                try
                {
                    testingTarget.GetDefaultPlatformFontDescription(description);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"FontClientGetDefaultPlatformFontDescription END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontClient IsScalable.")]
        [Property("SPEC", "Tizen.NUI.FontClient.IsScalable M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientIsScalable()
        {
            tlog.Debug(tag, $"FontClientIsScalable START");

            using (FontDescription description = new FontDescription())
            {
                description.Path = ttf_path;

                var testingTarget = new FontClient(FontClient.Instance);
                Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
                Assert.IsInstanceOf<FontClient>(testingTarget, "Should be an instance of FontClient type.");

                var result = testingTarget.IsScalable(description);
                Assert.IsNotNull(result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"FontClientIsScalable END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontClient CreateVectorBlob.")]
        [Property("SPEC", "Tizen.NUI.FontClient.CreateVectorBlob M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientCreateVectorBlob()
        {
            tlog.Debug(tag, $"FontClientCreateVectorBlob START");

            var testingTarget = new FontClient(FontClient.Instance);

            using (Color color = new Color(0.4f, 1.0f, 0.3f, 0.0f))
            {
                var blob = new SWIGTYPE_p_p_Dali__TextAbstraction__VectorBlob(color.SwigCPtr.Handle);
                var blobLegnth = new SWIGTYPE_p_unsigned_int(color.SwigCPtr.Handle);

                var nominalWidth = new SWIGTYPE_p_unsigned_int(FontClient.Instance.SwigCPtr.Handle);
                var nominalHeight = new SWIGTYPE_p_unsigned_int(testingTarget.SwigCPtr.Handle);

                try
                {
                    testingTarget.CreateVectorBlob(0, 0, blob, blobLegnth, nominalWidth, nominalHeight);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"FontClientCreateVectorBlob END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontClient GetEllipsisGlyph.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GetEllipsisGlyph M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientGetEllipsisGlyph()
        {
            tlog.Debug(tag, $"FontClientGetEllipsisGlyph START");

            var testingTarget = new FontClient(FontClient.Instance);
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<FontClient>(testingTarget, "Should be an instance of FontClient type.");

            var result = testingTarget.GetEllipsisGlyph(10);
            Assert.IsInstanceOf<GlyphInfo>(result, "Should be an instance of GlyphInfo type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontClientGetEllipsisGlyph END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontClient IsColorGlyph.")]
        [Property("SPEC", "Tizen.NUI.FontClient.IsColorGlyph M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientIsColorGlyph()
        {
            tlog.Debug(tag, $"FontClientIsColorGlyph START");

            var testingTarget = new FontClient(FontClient.Instance);
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<FontClient>(testingTarget, "Should be an instance of FontClient type.");

            try
            {
                testingTarget.IsColorGlyph(testingTarget.GetFontId(ttf_path), testingTarget.GetGlyphIndex(0, 0x0041));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caugth Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontClientIsColorGlyph END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphBufferData constructor.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GlyphBufferData.GlyphBufferData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientGlyphBufferDataConstructor()
        {
            tlog.Debug(tag, $"FontClientGlyphBufferDataConstructor START");

            using (FontClient.GlyphBufferData data = new FontClient.GlyphBufferData())
            {
                var testingTarget = new FontClient.GlyphBufferData(data.SwigCPtr.Handle, true);
                Assert.IsNotNull(testingTarget, "Return a null object of GlyphBufferData");
                Assert.IsInstanceOf<FontClient.GlyphBufferData>(testingTarget, "Should be an instance of GlyphBufferData type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"FontClientGlyphBufferDataConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphBufferData Width.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GlyphBufferData.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientGlyphBufferDataWidth()
        {
            tlog.Debug(tag, $"FontClientGlyphBufferDataWidth START");

            var testingTarget = new FontClient.GlyphBufferData();
            Assert.IsNotNull(testingTarget, "Return a null object of GlyphBufferData");
            Assert.IsInstanceOf<FontClient.GlyphBufferData>(testingTarget, "Should be an instance of GlyphBufferData type.");

            testingTarget.Width = 10;
            Assert.AreEqual(10, testingTarget.Width, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontClientGlyphBufferDataWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphBufferData Height.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GlyphBufferData.Height A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientGlyphBufferDataHeight()
        {
            tlog.Debug(tag, $"FontClientGlyphBufferDataHeight START");

            var testingTarget = new FontClient.GlyphBufferData(); ;
            Assert.IsNotNull(testingTarget, "Return a null object of GlyphBufferData");
            Assert.IsInstanceOf<FontClient.GlyphBufferData>(testingTarget, "Should be an instance of GlyphBufferData type.");

            testingTarget.Height = 50;
            Assert.AreEqual(50, testingTarget.Height, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontClientGlyphBufferDataHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GlyphBufferData Format.")]
        [Property("SPEC", "Tizen.NUI.FontClient.GlyphBufferData.Format A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontClientGlyphBufferDataFormat()
        {
            tlog.Debug(tag, $"FontClientGlyphBufferDataFormat START");

            var testingTarget = new FontClient.GlyphBufferData();
            Assert.IsNotNull(testingTarget, "Return a null object of GlyphBufferData");
            Assert.IsInstanceOf<FontClient.GlyphBufferData>(testingTarget, "Should be an instance of GlyphBufferData type.");

            testingTarget.Format = PixelFormat.BGR8888;
            Assert.AreEqual(PixelFormat.BGR8888, testingTarget.Format, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontClientGlyphBufferDataFormat END (OK)");
        }
    }
}
