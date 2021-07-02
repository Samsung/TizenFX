using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/ColorHistogram")]
    public class InternalColorHistogramTest
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
        [Description("ColorHistogram constructor.")]
        [Property("SPEC", "Tizen.NUI.ColorHistogram.ColorHistogram C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorHistogramConstructor()
        {
            tlog.Debug(tag, $"ColorHistogramConstructor START");

            int[] pixels = new int[3] { 16, 4, 20 };
            var testingTarget = new ColorHistogram(pixels);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ColorHistogram>(testingTarget, "Should be an Instance of ColorHistogram!");

            tlog.Debug(tag, $"ColorHistogramConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ColorHistogram GetNumberOfColors.")]
        [Property("SPEC", "Tizen.NUI.ColorHistogram.GetNumberOfColors M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorHistogramGetNumberOfColors()
        {
            tlog.Debug(tag, $"ColorHistogramGetNumberOfColors START");

            int[] pixels = new int[3] { 16, 4, 20 };
            var testingTarget = new ColorHistogram(pixels);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ColorHistogram>(testingTarget, "Should be an Instance of ColorHistogram!");

            try
            {
                testingTarget.GetNumberOfColors();
                tlog.Debug(tag, "numberColors :" + testingTarget.GetNumberOfColors());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ColorHistogramGetNumberOfColors END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ColorHistogram GetColors.")]
        [Property("SPEC", "Tizen.NUI.ColorHistogram.GetColors M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorHistogramGetColors()
        {
            tlog.Debug(tag, $"ColorHistogramGetColors START");

            int[] pixels = new int[3] { 16, 4, 20 };
            var testingTarget = new ColorHistogram(pixels);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ColorHistogram>(testingTarget, "Should be an Instance of ColorHistogram!");

            try
            {
                testingTarget.GetColors();
                tlog.Debug(tag, "colors :" + testingTarget.GetColors());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ColorHistogramGetColors END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ColorHistogram GetColorCounts.")]
        [Property("SPEC", "Tizen.NUI.ColorHistogram.GetColorCounts M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorHistogramGetColorCounts()
        {
            tlog.Debug(tag, $"ColorHistogramGetColorCounts START");

            int[] pixels = new int[3] { 16, 4, 20 };
            var testingTarget = new ColorHistogram(pixels);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ColorHistogram>(testingTarget, "Should be an Instance of ColorHistogram!");

            try
            {
                testingTarget.GetColorCounts();
                tlog.Debug(tag, "colorCounts :" + testingTarget.GetColorCounts());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ColorHistogramGetColorCounts END (OK)");
        }
    }
}
