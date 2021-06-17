using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/ImageVisual")]
    public class PublicImageVisualTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";
        private static bool flagComposingPropertyMap;
        internal class MyImageVisual : ImageVisual
        {
            protected override void ComposingPropertyMap()
            {
                flagComposingPropertyMap = true;
                base.ComposingPropertyMap();
            }
        }

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
        [Description("ImageVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.ImageVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualConstructor()
        {
            tlog.Debug(tag, $"ImageVisualConstructor START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ColorVisualMap type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual URL.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.URL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualURL()
        {
            tlog.Debug(tag, $"ImageVisualURL START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.URL = "URL";
            Assert.AreEqual("URL", testingTarget.URL, "Retrieved URL should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual FittingMode.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.FittingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualFittingMode()
        {
            tlog.Debug(tag, $"ImageVisualFittingMode START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.FittingMode = FittingModeType.FitHeight;
            Assert.AreEqual(FittingModeType.FitHeight, testingTarget.FittingMode, "Retrieved FittingMode should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualFittingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual SamplingMode.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.SamplingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualSamplingMode()
        {
            tlog.Debug(tag, $"ImageVisualSamplingMode START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.SamplingMode = SamplingModeType.Box;
            Assert.AreEqual(SamplingModeType.Box, testingTarget.SamplingMode, "Retrieved SamplingMode should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualSamplingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual DesiredWidth.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.DesiredWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualDesiredWidth()
        {
            tlog.Debug(tag, $"ImageVisualDesiredWidth START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.DesiredWidth = 3;
            Assert.AreEqual(3, testingTarget.DesiredWidth, "Retrieved DesiredWidth should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualDesiredWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual AlphaMaskURL.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.AlphaMaskURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualAlphaMaskURL()
        {
            tlog.Debug(tag, $"ImageVisualAlphaMaskURL START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.AlphaMaskURL = image_path;
            Assert.AreEqual(image_path, testingTarget.AlphaMaskURL, "Retrieved AlphaMaskURL should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualAlphaMaskURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual AuxiliaryImageURL.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.AuxiliaryImageURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualAuxiliaryImageURL()
        {
            tlog.Debug(tag, $"ImageVisualAuxiliaryImageURL START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.AuxiliaryImageURL = image_path;
            Assert.AreEqual(image_path, testingTarget.AuxiliaryImageURL, "Retrieved AuxiliaryImageURL should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualAuxiliaryImageURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual AuxiliaryImageAlpha.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.AuxiliaryImageAlpha A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualAuxiliaryImageAlpha()
        {
            tlog.Debug(tag, $"ImageVisualAuxiliaryImageAlpha START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.AuxiliaryImageAlpha = 0.9f;
            Assert.AreEqual(0.9f, testingTarget.AuxiliaryImageAlpha, "Retrieved AuxiliaryImageAlpha should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualAuxiliaryImageAlpha END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual DesiredHeight.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.DesiredHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualDesiredHeight()
        {
            tlog.Debug(tag, $"ImageVisualDesiredHeight START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.DesiredHeight = 3;
            Assert.AreEqual(3, testingTarget.DesiredHeight, "Retrieved DesiredHeight should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualDesiredHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual SynchronousLoading.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.SynchronousLoading A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualSynchronousLoading()
        {
            tlog.Debug(tag, $"ImageVisualSynchronousLoading START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.SynchronousLoading = true;
            Assert.AreEqual(true, testingTarget.SynchronousLoading, "Retrieved SynchronousLoading should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualSynchronousLoading END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual BorderOnly.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.BorderOnly A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualBorderOnly()
        {
            tlog.Debug(tag, $"ImageVisualBorderOnly START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.BorderOnly = true;
            Assert.AreEqual(true, testingTarget.BorderOnly, "Retrieved BorderOnly should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualBorderOnly END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual PixelArea.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.PixelArea A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualPixelArea()
        {
            tlog.Debug(tag, $"ImageVisualPixelArea START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            using (Vector4 vector = new Vector4(1.0f, 1.0f, 1.0f, 1.0f))
            {
                testingTarget.PixelArea = vector;
                Assert.AreEqual(vector.R, testingTarget.PixelArea.R, "Retrieved PixelArea.R should be equal to set value");
                Assert.AreEqual(vector.G, testingTarget.PixelArea.G, "Retrieved PixelArea.G should be equal to set value");
                Assert.AreEqual(vector.B, testingTarget.PixelArea.B, "Retrieved PixelArea.B should be equal to set value");
                Assert.AreEqual(vector.A, testingTarget.PixelArea.A, "Retrieved PixelArea.A should be equal to set value");
            }
           
            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualPixelArea END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual WrapModeU.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.WrapModeU A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualWrapModeU()
        {
            tlog.Debug(tag, $"ImageVisualWrapModeU START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.WrapModeU = WrapModeType.ClampToEdge;
            Assert.AreEqual(WrapModeType.ClampToEdge, testingTarget.WrapModeU, "Retrieved WrapModeU should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualWrapModeU END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual WrapModeV.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.WrapModeV A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualWrapModeV()
        {
            tlog.Debug(tag, $"ImageVisualWrapModeV START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.WrapModeV = WrapModeType.ClampToEdge;
            Assert.AreEqual(WrapModeType.ClampToEdge, testingTarget.WrapModeV, "Retrieved WrapModeV should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualWrapModeV END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual CropToMask.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.CropToMask A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualCropToMask()
        {
            tlog.Debug(tag, $"ImageVisualCropToMask START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.CropToMask = false;
            Assert.AreEqual(false, testingTarget.CropToMask, "Retrieved CropToMask should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualCropToMask END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual MaskContentScale.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.MaskContentScale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualMaskContentScale()
        {
            tlog.Debug(tag, $"ImageVisualMaskContentScale START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.MaskContentScale = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.MaskContentScale, "Retrieved MaskContentScale should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualMaskContentScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual ReleasePolicy.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.ReleasePolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualReleasePolicy()
        {
            tlog.Debug(tag, $"ImageVisualReleasePolicy START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.ReleasePolicy = ReleasePolicyType.Detached;
            Assert.AreEqual(ReleasePolicyType.Detached, testingTarget.ReleasePolicy, "Retrieved ReleasePolicy should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualReleasePolicy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual OrientationCorrection.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.OrientationCorrection A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualOrientationCorrection()
        {
            tlog.Debug(tag, $"ImageVisualOrientationCorrection START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.OrientationCorrection = true;
            Assert.IsTrue(testingTarget.OrientationCorrection, "Retrieved OrientationCorrection should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualOrientationCorrection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual LoadPolicy.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.LoadPolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualLoadPolicy()
        {
            tlog.Debug(tag, $"ImageVisualLoadPolicy START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.LoadPolicy = LoadPolicyType.Immediate;
            Assert.AreEqual(LoadPolicyType.Immediate, testingTarget.LoadPolicy, "Retrieved LoadPolicy should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualLoadPolicy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual Atlasing.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.Atlasing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageVisualAtlasing()
        {
            tlog.Debug(tag, $"ImageVisualAtlasing START");

            var testingTarget = new ImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");

            testingTarget.Atlasing = true;
            Assert.AreEqual(true, testingTarget.Atlasing, "Retrieved Atlasing should be equal to set value");

            testingTarget.Atlasing = false;
            Assert.AreEqual(false, testingTarget.Atlasing, "Retrieved Atlasing should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualAtlasing END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.ImageVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com@samsung.com")]
        public void ImageVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"ImageVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyImageVisual()
            {
                URL = image_path,
                AuxiliaryImageURL = image_path,
                DesiredWidth = 3,
                FittingMode = FittingModeType.FitHeight,
                SamplingMode = SamplingModeType.Box,
                PixelArea = new Vector4(1.0f, 1.0f, 1.0f, 1.0f),
                WrapModeU = WrapModeType.ClampToEdge,
                WrapModeV = WrapModeType.ClampToEdge,
                CropToMask = false,
                AuxiliaryImageAlpha = 0.9f,
                ReleasePolicy = ReleasePolicyType.Detached,
                LoadPolicy = LoadPolicyType.Immediate

            };
            Assert.IsInstanceOf<ImageVisual>(testingTarget, "Should be an instance of ImageVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageVisualComposingPropertyMap END (OK)");
        }
    }
}
