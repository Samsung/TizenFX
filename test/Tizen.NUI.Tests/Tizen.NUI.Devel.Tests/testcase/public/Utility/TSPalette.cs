using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Utility/Palette")]
    public class PublicPaletteTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("Palette Generate.")]
        [Property("SPEC", "Tizen.NUI.Palette.Generate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGenerate()
        {
            tlog.Debug(tag, $"PaletteGenerate START");

            try
            {
                using (PixelBuffer buffer = ImageLoader.LoadImageFromFile(image_path))
                {
                    var testingTarget = Palette.Generate(buffer);
                    Assert.IsNotNull(testingTarget, "Can't create success object Palette");
                    Assert.IsInstanceOf<Palette>(testingTarget, "Should be an instance of Palette type.");
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGenerate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette Generate. With Rectangle.")]
        [Property("SPEC", "Tizen.NUI.Palette.Generate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGenerateWithRectangle()
        {
            tlog.Debug(tag, $"PaletteGenerateWithRectangle START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(10, 8, PixelFormat.A8))
                {
                    using (Rectangle region = new Rectangle(2, 2, 2, 2))
                    {
                        var testingTarget = Palette.Generate(buffer, region);
                        Assert.IsNotNull(testingTarget, "Can't create success object Palette");
                        Assert.IsInstanceOf<Palette>(testingTarget, "Should be an instance of Palette type.");
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGenerateWithRectangle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette Generate. PixelBuffer is null.")]
        [Property("SPEC", "Tizen.NUI.Palette.Generate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGenerateWithNullPixelBuffer()
        {
            tlog.Debug(tag, $"PaletteGenerateWithNullPixelBuffer START");

            try
            {
                using (Rectangle region = new Rectangle(24, 24, 24, 24))
                {
                    var testingTarget = Palette.Generate(null, region);
                }
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"PaletteGenerateWithNullPixelBuffer END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("Palette GetSwatches.")]
        [Property("SPEC", "Tizen.NUI.Palette.GetSwatches M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGetSwatches()
        {
            tlog.Debug(tag, $"PaletteGetSwatches START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(10, 8, PixelFormat.A8))
                {
                    using (Rectangle region = new Rectangle(2, 2, 2, 2))
                    {
                        var testingTarget = Palette.Generate(buffer, region);
                        Assert.IsNotNull(testingTarget, "Can't create success object Palette");
                        Assert.IsInstanceOf<Palette>(testingTarget, "Should be an instance of Palette type.");

                        testingTarget.GetSwatches();
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGetSwatches END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette GetDominantSwatch.")]
        [Property("SPEC", "Tizen.NUI.Palette.GetDominantSwatch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGetDominantSwatch()
        {
            tlog.Debug(tag, $"PaletteGetDominantSwatch START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(10, 8, PixelFormat.A8))
                {
                    using (Rectangle region = new Rectangle(2, 2, 2, 2))
                    {
                        var testingTarget = Palette.Generate(buffer, region);
                        Assert.IsNotNull(testingTarget, "Can't create success object Palette");
                        Assert.IsInstanceOf<Palette>(testingTarget, "Should be an instance of Palette type.");

                        testingTarget.GetDominantSwatch();
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGetDominantSwatch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette GetVibrantSwatch.")]
        [Property("SPEC", "Tizen.NUI.Palette.GetVibrantSwatch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGetVibrantSwatch()
        {
            tlog.Debug(tag, $"PaletteGetVibrantSwatch START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(10, 8, PixelFormat.A8))
                {
                    using (Rectangle region = new Rectangle(2, 2, 2, 2))
                    {
                        var testingTarget = Palette.Generate(buffer, region);
                        Assert.IsNotNull(testingTarget, "Can't create success object Palette");
                        Assert.IsInstanceOf<Palette>(testingTarget, "Should be an instance of Palette type.");

                        testingTarget.GetVibrantSwatch();
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGetVibrantSwatch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette GetLightVibrantSwatch.")]
        [Property("SPEC", "Tizen.NUI.Palette.GetLightVibrantSwatch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGetLightVibrantSwatch()
        {
            tlog.Debug(tag, $"PaletteGetLightVibrantSwatch START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(10, 8, PixelFormat.A8))
                {
                    using (Rectangle region = new Rectangle(2, 2, 2, 2))
                    {
                        var testingTarget = Palette.Generate(buffer, region);
                        Assert.IsNotNull(testingTarget, "Can't create success object Palette");
                        Assert.IsInstanceOf<Palette>(testingTarget, "Should be an instance of Palette type.");

                        testingTarget.GetLightVibrantSwatch();
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGetLightVibrantSwatch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette GetDarkVibrantSwatch.")]
        [Property("SPEC", "Tizen.NUI.Palette.GetDarkVibrantSwatch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGetDarkVibrantSwatch()
        {
            tlog.Debug(tag, $"PaletteGetDarkVibrantSwatch START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(10, 8, PixelFormat.A8))
                {
                    using (Rectangle region = new Rectangle(2, 2, 2, 2))
                    {
                        var testingTarget = Palette.Generate(buffer, region);
                        Assert.IsNotNull(testingTarget, "Can't create success object Palette");
                        Assert.IsInstanceOf<Palette>(testingTarget, "Should be an instance of Palette type.");

                        testingTarget.GetDarkVibrantSwatch();
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGetDarkVibrantSwatch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette GetMutedSwatch.")]
        [Property("SPEC", "Tizen.NUI.Palette.GetMutedSwatch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGetMutedSwatch()
        {
            tlog.Debug(tag, $"PaletteGetMutedSwatch START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(10, 8, PixelFormat.A8))
                {
                    using (Rectangle region = new Rectangle(2, 2, 2, 2))
                    {
                        var testingTarget = Palette.Generate(buffer, region);
                        Assert.IsNotNull(testingTarget, "Can't create success object Palette");
                        Assert.IsInstanceOf<Palette>(testingTarget, "Should be an instance of Palette type.");

                        testingTarget.GetMutedSwatch();
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGetMutedSwatch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette GetLightMutedSwatch.")]
        [Property("SPEC", "Tizen.NUI.Palette.GetLightMutedSwatch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGetLightMutedSwatch()
        {
            tlog.Debug(tag, $"PaletteGetLightMutedSwatch START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(10, 8, PixelFormat.A8))
                {
                    using (Rectangle region = new Rectangle(2, 2, 2, 2))
                    {
                        var testingTarget = Palette.Generate(buffer, region);
                        Assert.IsNotNull(testingTarget, "Can't create success object Palette");
                        Assert.IsInstanceOf<Palette>(testingTarget, "Should be an instance of Palette type.");

                        testingTarget.GetLightMutedSwatch();
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGetLightMutedSwatch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette GetDarkMutedSwatch.")]
        [Property("SPEC", "Tizen.NUI.Palette.GetDarkMutedSwatch M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGetDarkMutedSwatch()
        {
            tlog.Debug(tag, $"PaletteGetDarkMutedSwatch START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(10, 8, PixelFormat.A8))
                {
                    using (Rectangle region = new Rectangle(2, 2, 2, 2))
                    {
                        var testingTarget = Palette.Generate(buffer, region);
                        Assert.IsNotNull(testingTarget, "Can't create success object Palette");
                        Assert.IsInstanceOf<Palette>(testingTarget, "Should be an instance of Palette type.");

                        testingTarget.GetDarkMutedSwatch();
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGetDarkMutedSwatch END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette.Swatch constructor.")]
        [Property("SPEC", "Tizen.NUI.Palette.Swatch.Swatch C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteSwatchConstructor()
        {
            tlog.Debug(tag, $"PaletteSwatchConstructor START");

            var testingTarget = new Palette.Swatch(221, 125);
            Assert.IsNotNull(testingTarget, "Can't create success object Swatch");
            Assert.IsInstanceOf<Palette.Swatch>(testingTarget, "Should be an instance of Swatch type.");

            tlog.Debug(tag, $"PaletteSwatchConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette.Swatch GetRgb.")]
        [Property("SPEC", "Tizen.NUI.Palette.Swatch.GetRgb M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteSwatchGetRgb()
        {
            tlog.Debug(tag, $"PaletteSwatchGetRgb START");

            var testingTarget = new Palette.Swatch(221, 125, 128, 55);
            Assert.IsNotNull(testingTarget, "Can't create success object Swatch");
            Assert.IsInstanceOf<Palette.Swatch>(testingTarget, "Should be an instance of Swatch type.");

            var result = testingTarget.GetRgb();
            Assert.IsNotNull(result, "Can't create success object Color");
            Assert.IsInstanceOf<Color>(result, "Should be an instance of Color type.");

            tlog.Debug(tag, $"PaletteSwatchGetRgb END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette.Swatch GetTitleTextColor.")]
        [Property("SPEC", "Tizen.NUI.Palette.Swatch.GetTitleTextColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteSwatchGetTitleTextColor()
        {
            tlog.Debug(tag, $"PaletteSwatchGetTitleTextColor START");

            var testingTarget = new Palette.Swatch(221, 125, 128, 55);
            Assert.IsNotNull(testingTarget, "Can't create success object Swatch");
            Assert.IsInstanceOf<Palette.Swatch>(testingTarget, "Should be an instance of Swatch type.");

            var result = testingTarget.GetTitleTextColor();
            Assert.IsNotNull(result, "Can't create success object Color");
            Assert.IsInstanceOf<Color>(result, "Should be an instance of Color type.");

            tlog.Debug(tag, $"PaletteSwatchGetTitleTextColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette.Swatch GetBodyTextColor.")]
        [Property("SPEC", "Tizen.NUI.Palette.Swatch.GetBodyTextColor M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteSwatchGetBodyTextColor()
        {
            tlog.Debug(tag, $"PaletteSwatchGetBodyTextColor START");

            var testingTarget = new Palette.Swatch(221, 125, 128, 55);
            Assert.IsNotNull(testingTarget, "Can't create success object Swatch");
            Assert.IsInstanceOf<Palette.Swatch>(testingTarget, "Should be an instance of Swatch type.");

            var result = testingTarget.GetBodyTextColor();
            Assert.IsNotNull(result, "Can't create success object Color");
            Assert.IsInstanceOf<Color>(result, "Should be an instance of Color type.");

            /** lightBodyAlpha != -1 && lightTitleAlpha != -1 */
            testingTarget = new Palette.Swatch(22, 45, 28, 55);

            try
            {
                testingTarget.GetBodyTextColor();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteSwatchGetBodyTextColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette GenerateAsync.")]
        [Property("SPEC", "Tizen.NUI.Palette.GenerateAsync M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGenerateAsync()
        {
            tlog.Debug(tag, $"PaletteGenerateAsync START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(2, 2, PixelFormat.A8))
                {
                    _ = Palette.GenerateAsync(buffer);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGenerateAsync END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Palette GenerateAsync. With Rectangle.")]
        [Property("SPEC", "Tizen.NUI.Palette.GenerateAsync M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PaletteGenerateAsyncWithRectangle()
        {
            tlog.Debug(tag, $"PaletteGenerateAsyncWithRectangle START");

            try
            {
                using (PixelBuffer buffer = new PixelBuffer(2, 2, PixelFormat.A8))
                {
                    using (Rectangle region = new Rectangle(1, 1, 1, 1))
                    {
                        _ = Palette.GenerateAsync(buffer, region);
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"PaletteGenerateAsyncWithRectangle END (OK)");
        }
    }
}
