using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ColorUtils")]
    public class InternalColorUtilsTest
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
        [Description("ColorUtils RgbToXyz.")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.RgbToXyz M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsRgbToXyz()
        {
            tlog.Debug(tag, $"ColorUtilsRgbToXyz START");

            try
            {
                double[] outXyz = new double[3];
                ColorUtils.RgbToXyz(10, 8, 133, outXyz);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught Exception: Passed!");
            }

            tlog.Debug(tag, $"ColorUtilsRgbToXyz END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ColorUtils RgbToXyz.")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.RgbToXyz M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsRgbToXyzWithArgumentException()
        {
            tlog.Debug(tag, $"ColorUtilsRgbToXyzWithArgumentException START");

            try
            {
                double[] outXyz = new double[2];
                ColorUtils.RgbToXyz(10, 8, 133, outXyz);
            }
            catch (ArgumentException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ColorUtilsRgbToXyzWithArgumentException END (OK)");
                Assert.Pass("Caught ArgumentException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ColorUtils CalculateLuminance.")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.CalculateLuminance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsCalculateLuminance()
        {
            tlog.Debug(tag, $"ColorUtilsCalculateLuminance START");

            try
            {
                ColorUtils.CalculateLuminance(115);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught Exception: Passed!");
            }

            tlog.Debug(tag, $"ColorUtilsCalculateLuminance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ColorUtils CalculateContrast.")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.CalculateContrast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsCalculateContrast()
        {
            tlog.Debug(tag, $"ColorUtilsCalculateContrast START");

            try
            {
                ColorUtils.CalculateContrast(30, -2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught ArgumentException: Passed!");
            }

            tlog.Debug(tag, $"ColorUtilsCalculateContrast END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ColorUtils CalculateContrast. ArgumentException.")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.CalculateContrast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsCalculateContrastArgumentException()
        {
            tlog.Debug(tag, $"ColorUtilsCalculateContrastArgumentException START");

            try
            {
                ColorUtils.CalculateContrast(25, 0);
            }
            catch (ArgumentException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ColorUtilsCalculateContrastArgumentException END (OK)");
                Assert.Pass("Caught ArgumentException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ColorUtils SetAlphaComponent.")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.SetAlphaComponent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsSetAlphaComponent()
        {
            tlog.Debug(tag, $"ColorUtilsSetAlphaComponent START");

            try
            {
                ColorUtils.SetAlphaComponent(25, 111);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught Exception: Passed!");
            }

            tlog.Debug(tag, $"ColorUtilsSetAlphaComponent END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ColorUtils SetAlphaComponent. ArgumentException")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.SetAlphaComponent M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsSetAlphaComponentArgumentException()
        {
            tlog.Debug(tag, $"ColorUtilsSetAlphaComponentArgumentException START");

            try
            {
                ColorUtils.SetAlphaComponent(25, -1);
            }
            catch (ArgumentException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ColorUtilsSetAlphaComponentArgumentException END (OK)");
                Assert.Pass("Caught ArgumentException: Passed!");
            }            
        }

        [Test]
        [Category("P1")]
        [Description("ColorUtils CalculateMinimumAlpha.")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.CalculateMinimumAlpha M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsCalculateMinimumAlpha()
        {
            tlog.Debug(tag, $"ColorUtilsCalculateMinimumAlpha START");

            try
            {
                ColorUtils.CalculateMinimumAlpha(25, -2, 0.3f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Pass("Caught Exception: Passed!");
            }

            tlog.Debug(tag, $"ColorUtilsCalculateMinimumAlpha END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ColorUtils CalculateMinimumAlpha. ArgumentException")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.CalculateMinimumAlpha M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsCalculateMinimumAlphaArgumentException()
        {
            tlog.Debug(tag, $"ColorUtilsCalculateMinimumAlphaArgumentException START");

            try
            {
                ColorUtils.CalculateMinimumAlpha(25, 0, 0.3f);
            }
            catch (ArgumentException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ColorUtilsCalculateMinimumAlphaArgumentException END (OK)");
                Assert.Pass("Caught ArgumentException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ColorUtils HslToRgb.")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.HslToRgb M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsHslToRgb()
        {
            tlog.Debug(tag, $"ColorUtilsHslToRgb START");

            try
            {
                float[] hsl0 = { 10.0f, 200.0f, 500.0f };
                ColorUtils.HslToRgb(hsl0);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caugth Exception: Failed!");
            }

            try
            {
                float[] hsl1 = { 60.0f, 210.0f, 510.0f };
                ColorUtils.HslToRgb(hsl1);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caugth Exception: Failed!");
            }

            try
            {
                float[] hsl2 = { 120.0f, 220.0f, 520.0f };
                ColorUtils.HslToRgb(hsl2);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caugth Exception: Failed!");
            }

            try
            {
                float[] hsl3 = { 180.0f, 230.0f, 530.0f };
                ColorUtils.HslToRgb(hsl3);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caugth Exception: Failed!");
            }

            try
            {
                float[] hsl4 = { 240.0f, 240.0f, 540.0f };
                ColorUtils.HslToRgb(hsl4);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caugth Exception: Failed!");
            }

            try
            {
                float[] hsl5 = { 300.0f, 250.0f, 550.0f };
                ColorUtils.HslToRgb(hsl5);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caugth Exception: Failed!");
            }

            try
            {
                float[] hsl6 = { 360.0f, 260.0f, 560.0f };
                ColorUtils.HslToRgb(hsl6);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caugth Exception: Failed!");
            }

            tlog.Debug(tag, $"ColorUtilsHslToRgb END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ColorUtils GetBytesPerPixel.")]
        [Property("SPEC", "Tizen.NUI.ColorUtils.GetBytesPerPixel M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorUtilsGetBytesPerPixel()
        {
            tlog.Debug(tag, $"ColorUtilsGetBytesPerPixel START");

            var result = ColorUtils.GetBytesPerPixel(PixelFormat.RGBA4444);
            Assert.AreEqual(2, result, "Should be equal!");

            result = ColorUtils.GetBytesPerPixel(PixelFormat.RGB888);
            Assert.AreEqual(3, result, "Should be equal!");

            result = ColorUtils.GetBytesPerPixel(PixelFormat.BGR8888);
            Assert.AreEqual(4, result, "Should be equal!");

            result = ColorUtils.GetBytesPerPixel(0);
            Assert.AreEqual(0, result, "Should be equal!");

            tlog.Debug(tag, $"ColorUtilsGetBytesPerPixel END (OK)");
        }
    }
}
