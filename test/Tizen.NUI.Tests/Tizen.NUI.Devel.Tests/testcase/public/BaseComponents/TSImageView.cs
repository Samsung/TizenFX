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
    [Description("public/BaseComponents/ImageView")]
    public class PublicImageViewTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        public void OnResourceReady(object sender, ImageView.ResourceReadyEventArgs e)
        {
            // not implemented
        }

        internal class MyImageView : ImageView
        {
            public MyImageView() : base()
            { }

            public void OnResourceLoaded(object sender, ImageView.ResourceLoadedEventArgs e)
            {
                // not implemented
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
        [Description("ImageView constructor.")]
        [Property("SPEC", "Tizen.NUI.ImageView.ImageView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewConstructor()
        {
            tlog.Debug(tag, $"ImageViewConstructor START");

            var testingTarget = new ImageView(url, true);
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView constructor.")]
        [Property("SPEC", "Tizen.NUI.ImageView.ImageView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewConstructorWithStyle()
        {
            tlog.Debug(tag, $"ImageViewConstructorWithStyle START");

            ViewStyle style = new ViewStyle()
            {
                Color = Color.Cyan,
            };

            var testingTarget = new ImageView(style);
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageViewConstructorWithStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView constructor.")]
        [Property("SPEC", "Tizen.NUI.ImageView.ImageView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewConstructorWhetherShown()
        {
            tlog.Debug(tag, $"ImageViewConstructorWhetherShown START");

            var testingTarget = new ImageView(false);
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageViewConstructorWhetherShown END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView constructor. With size.")]
        [Property("SPEC", "Tizen.NUI.ImageView.ImageView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewConstructorWithSize()
        {
            tlog.Debug(tag, $"ImageViewConstructorWithSize START");

            using (Uint16Pair size = new Uint16Pair(40, 60))
            {
                var testingTarget = new ImageView(url, size, false);
                Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
                Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageViewConstructorWithSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView ResourceReady.")]
        [Property("SPEC", "Tizen.NUI.ImageView.ResourceReady A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewResourceReady()
        {
            tlog.Debug(tag, $"ImageViewResourceReady START");

            using (Uint16Pair size = new Uint16Pair(40, 60))
            {
                var testingTarget = new ImageView(url, size, false);
                Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
                Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

                testingTarget.ResourceReady += OnResourceReady;
                testingTarget.ResourceReady -= OnResourceReady;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageViewResourceReady END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView ResourceLoaded.")]
        [Property("SPEC", "Tizen.NUI.ImageView.ResourceLoaded A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewResourceLoaded()
        {
            tlog.Debug(tag, $"ImageViewResourceLoaded START");

            var testingTarget = new MyImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            testingTarget.ResourceLoaded += testingTarget.OnResourceLoaded;
            testingTarget.ResourceLoaded -= testingTarget.OnResourceLoaded;

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageViewResourceLoaded END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView DownCast.")]
        [Property("SPEC", "Tizen.NUI.ImageView.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ImageViewDownCast()
        {
            tlog.Debug(tag, $"ImageViewDownCast START");

            using (BaseHandle handle = new ImageView(url))
            {
                var testingTarget = ImageView.DownCast(handle);
                Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
                Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageViewDownCast END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ImageView DownCast. Handle is null.")]
        [Property("SPEC", "Tizen.NUI.ImageView.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ImageViewDownCastWithNullHandle()
        {
            tlog.Debug(tag, $"ImageViewDownCast START");

            try
            {
                ImageView.DownCast(null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ImageViewDownCast END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ImageView SetImage. Url is null.")]
        [Property("SPEC", "Tizen.NUI.ImageView.SetImage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ImageViewSetImage()
        {
            tlog.Debug(tag, $"ImageViewSetImage START");

            ViewStyle style = new ViewStyle()
            {
                Color = Color.Cyan,
            };

            var testingTarget = new ImageView(style);
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            try
            {
                testingTarget.SetImage(null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ImageViewSetImage END (OK)");
                Assert.Pass("Caught ArgumentNullException: Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageView IsResourceReady.")]
        [Property("SPEC", "Tizen.NUI.ImageView.IsResourceReady M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewIsResourceReady()
        {
            tlog.Debug(tag, $"ImageViewIsResourceReady START");

            var testingTarget = new ImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            testingTarget.ResourceUrl = url;

            try
            {
                testingTarget.IsResourceReady();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ImageViewIsResourceReady END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView AlphaMaskURL.")]
        [Property("SPEC", "Tizen.NUI.ImageView.AlphaMaskURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewAlphaMaskURL()
        {
            tlog.Debug(tag, $"ImageViewAlphaMaskURL START");

            var testingTarget = new ImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            PropertyMap map = new PropertyMap();
            map.Insert(ImageView.Property.IMAGE, new PropertyValue(new PropertyMap()));
            map.Insert(ImageVisualProperty.AlphaMaskURL, new PropertyValue(url));

            testingTarget.Image = map;

            try
            {
                var result = testingTarget.AlphaMaskURL;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ImageViewAlphaMaskURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView FittingMode.")]
        [Property("SPEC", "Tizen.NUI.ImageView.FittingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewFittingMode()
        {
            tlog.Debug(tag, $"ImageViewFittingMode START");

            var testingTarget = new ImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            tlog.Debug(tag, "FittingMode : " + testingTarget.FittingMode);

            testingTarget.FittingMode = FittingModeType.ScaleToFill;
            tlog.Debug(tag, "FittingMode : " + testingTarget.FittingMode);

            testingTarget.FittingMode = FittingModeType.ShrinkToFit;
            tlog.Debug(tag, "FittingMode : " + testingTarget.FittingMode);

            testingTarget.FittingMode = FittingModeType.Center;
            tlog.Debug(tag, "FittingMode : " + testingTarget.FittingMode);

            testingTarget.FittingMode = FittingModeType.Fill;
            tlog.Debug(tag, "FittingMode : " + testingTarget.FittingMode);

            testingTarget.FittingMode = FittingModeType.FitHeight;
            tlog.Debug(tag, "FittingMode : " + testingTarget.FittingMode);

            testingTarget.FittingMode = FittingModeType.FitWidth;
            tlog.Debug(tag, "FittingMode : " + testingTarget.FittingMode);

            tlog.Debug(tag, $"ImageViewFittingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView DesiredWidth.")]
        [Property("SPEC", "Tizen.NUI.ImageView.DesiredWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewDesiredWidth()
        {
            tlog.Debug(tag, $"ImageViewDesiredWidth START");

            var testingTarget = new ImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            testingTarget.DesiredWidth = 20;
            tlog.Debug(tag, "DesiredWidth : " + testingTarget.DesiredWidth);

            testingTarget.DesiredHeight = 30;
            tlog.Debug(tag, "DesiredHeight : " + testingTarget.DesiredHeight);

            tlog.Debug(tag, $"ImageViewDesiredWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView ReleasePolicy.")]
        [Property("SPEC", "Tizen.NUI.ImageView.ReleasePolicy A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewReleasePolicy()
        {
            tlog.Debug(tag, $"ImageViewReleasePolicy START");

            var testingTarget = new ImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            testingTarget.ReleasePolicy = ReleasePolicyType.Never;
            tlog.Debug(tag, "ReleasePolicy : " + testingTarget.ReleasePolicy);

            testingTarget.ReleasePolicy = ReleasePolicyType.Detached;
            tlog.Debug(tag, "ReleasePolicy : " + testingTarget.ReleasePolicy);

            testingTarget.ReleasePolicy = ReleasePolicyType.Destroyed;
            tlog.Debug(tag, "ReleasePolicy : " + testingTarget.ReleasePolicy);

            tlog.Debug(tag, $"ImageViewReleasePolicy END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView WrapModeU.")]
        [Property("SPEC", "Tizen.NUI.ImageView.WrapModeU A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewWrapModeU()
        {
            tlog.Debug(tag, $"ImageViewWrapModeU START");

            var testingTarget = new ImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            testingTarget.WrapModeU = WrapModeType.MirroredRepeat;
            tlog.Debug(tag, "WrapModeU : " + testingTarget.WrapModeU);

            testingTarget.WrapModeU = WrapModeType.Repeat;
            tlog.Debug(tag, "WrapModeU : " + testingTarget.WrapModeU);

            testingTarget.WrapModeU = WrapModeType.ClampToEdge;
            tlog.Debug(tag, "WrapModeU : " + testingTarget.WrapModeU);

            testingTarget.WrapModeU = WrapModeType.Default;
            tlog.Debug(tag, "WrapModeU : " + testingTarget.WrapModeU);

            tlog.Debug(tag, $"ImageViewWrapModeU END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView WrapModeV.")]
        [Property("SPEC", "Tizen.NUI.ImageView.WrapModeV A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewWrapModeV()
        {
            tlog.Debug(tag, $"ImageViewWrapModeV START");

            var testingTarget = new ImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            testingTarget.WrapModeV = WrapModeType.MirroredRepeat;
            tlog.Debug(tag, "WrapModeV : " + testingTarget.WrapModeV);

            testingTarget.WrapModeV = WrapModeType.Repeat;
            tlog.Debug(tag, "WrapModeV : " + testingTarget.WrapModeV);

            testingTarget.WrapModeV = WrapModeType.ClampToEdge;
            tlog.Debug(tag, "WrapModeV : " + testingTarget.WrapModeV);

            testingTarget.WrapModeV = WrapModeType.Default;
            tlog.Debug(tag, "WrapModeV : " + testingTarget.WrapModeV);

            tlog.Debug(tag, $"ImageViewWrapModeV END (OK)");
        }
    }
}
