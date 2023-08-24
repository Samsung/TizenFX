using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ColorCutQuantizer")]
    public class InternalColorCutQuantizerTest
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
        [Description("ColorCutQuantizer FromBitmap .")]
        [Property("SPEC", "Tizen.NUI.ColorCutQuantizer.FromBitmap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorCutQuantizerFromBitmap()
        {
            tlog.Debug(tag, $"ColorCutQuantizerFromBitmap START");

            using (PixelBuffer pixelBuffer = new PixelBuffer(100, 200, PixelFormat.RGBA8888))
            {
                using (Rectangle region = new Rectangle())
                {
                    var testingTarget = ColorCutQuantizer.FromBitmap(pixelBuffer, region, 255);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<ColorCutQuantizer>(testingTarget, "Should be an Instance of ColorCutQuantizer!");
                }
            }
            
            tlog.Debug(tag, $"ColorCutQuantizerFromBitmap END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ColorCutQuantizer FromBitmap. MaxColor < 1.")]
        [Property("SPEC", "Tizen.NUI.ColorCutQuantizer.FromBitmap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorCutQuantizerFromBitmapWithMaxColorLessThan1()
        {
            tlog.Debug(tag, $"ColorCutQuantizerFromBitmapWithMaxColorLessThan1 START");

            using (PixelBuffer pixelBuffer = new PixelBuffer(100, 200, PixelFormat.RGBA8888))
            {
                using (Rectangle region = new Rectangle())
                {
                    try
                    {
                        ColorCutQuantizer.FromBitmap(pixelBuffer, region, 0);
                    }
                    catch (ArgumentNullException e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        tlog.Debug(tag, $"ColorCutQuantizerFromBitmapWithMaxColorLessThan1 END (OK)");
                        Assert.Pass("Caught ArgumentNullException : Passed!");
                    }
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("ColorCutQuantizer FromBitmap. Region is null.")]
        [Property("SPEC", "Tizen.NUI.ColorCutQuantizer.FromBitmap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorCutQuantizerFromBitmapWithNullRegion()
        {
            tlog.Debug(tag, $"ColorCutQuantizerFromBitmapWithNullRegion START");

            using (PixelBuffer pixelBuffer = new PixelBuffer(1, 2, PixelFormat.A8))
            {
                using (Rectangle region = null)
                {
                    var testingTarget = ColorCutQuantizer.FromBitmap(pixelBuffer, region, 255);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<ColorCutQuantizer>(testingTarget, "Should be an Instance of ColorCutQuantizer!");
                }
            }

            tlog.Debug(tag, $"ColorCutQuantizerFromBitmapWithNullRegion END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ColorCutQuantizer GetQuantizedColors .")]
        [Property("SPEC", "Tizen.NUI.ColorCutQuantizer.GetQuantizedColors M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorCutQuantizerGetQuantizedColors()
        {
            tlog.Debug(tag, $"ColorCutQuantizerGetQuantizedColors START");

            using (PixelBuffer pixelBuffer = new PixelBuffer(100, 200, PixelFormat.A8))
            {
                using (Rectangle region = new Rectangle())
                {
                    var testingTarget = ColorCutQuantizer.FromBitmap(pixelBuffer, region, 255);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<ColorCutQuantizer>(testingTarget, "Should be an Instance of ColorCutQuantizer!");

                    try
                    {
                        testingTarget.GetQuantizedColors();
                        tlog.Debug(tag, "quantizedColors : " + testingTarget.GetQuantizedColors());
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception: Failed!");
                    }
                }
            }

            tlog.Debug(tag, $"ColorCutQuantizerGetQuantizedColors END (OK)");
        }
    }
}
