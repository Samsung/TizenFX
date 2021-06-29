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
        public void ImageViewConstructorResourceReady()
        {
            tlog.Debug(tag, $"ImageViewConstructorResourceReady START");

            using (Uint16Pair size = new Uint16Pair(40, 60))
            {
                var testingTarget = new ImageView(url, size, false);
                Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
                Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

                testingTarget.ResourceReady += OnResourceReady;
                testingTarget.ResourceReady -= OnResourceReady;

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageViewConstructorResourceReady END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView ResourceLoaded.")]
        [Property("SPEC", "Tizen.NUI.ImageView.ResourceLoaded A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewConstructorResourceLoaded()
        {
            tlog.Debug(tag, $"ImageViewConstructorResourceLoaded START");

            var testingTarget = new MyImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
            Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

            testingTarget.ResourceLoaded += testingTarget.OnResourceLoaded;
            testingTarget.ResourceLoaded -= testingTarget.OnResourceLoaded;

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageViewConstructorResourceLoaded END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView DownCast.")]
        [Property("SPEC", "Tizen.NUI.ImageView.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ImageViewConstructorDownCast()
        {
            tlog.Debug(tag, $"ImageViewConstructorDownCast START");

            using (BaseHandle handle = new ImageView(url))
            {
                var testingTarget = ImageView.DownCast(handle);
                Assert.IsNotNull(testingTarget, "Can't create success object ImageView");
                Assert.IsInstanceOf<ImageView>(testingTarget, "Should be an instance of ImageView type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageViewConstructorDownCast END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ImageView DownCast. Handle is null.")]
        [Property("SPEC", "Tizen.NUI.ImageView.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ImageViewConstructorDownCastWithNullHandle()
        {
            tlog.Debug(tag, $"ImageViewConstructorDownCast START");

            try
            {
                ImageView.DownCast(null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ImageViewConstructorDownCast END (OK)");
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
        public void ImageViewConstructorIsResourceReady()
        {
            tlog.Debug(tag, $"ImageViewConstructorIsResourceReady START");

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

            tlog.Debug(tag, $"ImageViewConstructorIsResourceReady END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageView AlphaMaskURL.")]
        [Property("SPEC", "Tizen.NUI.ImageView.AlphaMaskURL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageViewConstructorAlphaMaskURL()
        {
            tlog.Debug(tag, $"ImageViewConstructorAlphaMaskURL START");

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

            tlog.Debug(tag, $"ImageViewConstructorAlphaMaskURL END (OK)");
        }
    }
}
