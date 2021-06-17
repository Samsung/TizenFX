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
    [Description("public/Common/ImageLoading")]
    public class PublicImageLoadingTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private string bmp_path = "https://image.baidu.com/search/detail?ct=503316480&z=0&ipn=d&word=bmp%E4%B8%8B%E8%BD%BD%20%E4%BD%8D%E5%9B%BE&step_word=&hs=2&pn=0&spn=0&di=30360&pi=0&rn=1&tn=baiduimagedetail&is=0%2C0&istype=2&ie=utf-8&oe=utf-8&in=&cl=2&lm=-1&st=-1&cs=506847219%2C2820013657&os=4205693751%2C1065126395&simid=0%2C0&adpicid=0&lpn=0&ln=389&fr=&fmq=1389861203899_R&fm=&ic=0&s=undefined&hd=undefined&latest=undefined&copyright=undefined&se=&sme=&tab=0&width=&height=&face=undefined&ist=&jit=&cg=&bdtype=0&oriquery=bmp%E4%B8%8B%E8%BD%BD&objurl=https%3A%2F%2Fgimg2.baidu.com%2Fimage_search%2Fsrc%3Dhttp%3A%2F%2Fbpic.ooopic.com%2F17%2F52%2F38%2F17523837-6a28a5a38920964a54ed89d8e93c3a3c-0.jpg%26refer%3Dhttp%3A%2F%2Fbpic.ooopic.com%26app%3D2002%26size%3Df9999%2C10000%26q%3Da80%26n%3D0%26g%3D0n%26fmt%3Djpeg%3Fsec%3D1624445232%26t%3Db9e3c91e4753f12d81e73c7142181326&fromurl=ippr_z2C%24qAzdH3FAzdH3Fooo_z%26e3B555rtv_z%26e3Bv54AzdH3Ffij3ty7wgf7AzdH3F80cdnbn0_z%26e3Bip4s&gsm=1&rpstart=0&rpnum=0&islist=&querylist=&force=undefined";
        private string file_name = "picture";

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
        [Description("ImageLoading LoadImageFromFile.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingLoadImageFromFile()
        {
            tlog.Debug(tag, $"ImageLoadingLoadImageFromFile START");

            var testingTarget = ImageLoading.LoadImageFromFile(image_path);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoadingLoadImageFromFile END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading LoadImageFromFile. With Size.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingLoadImageFromFileWithSize()
        {
            tlog.Debug(tag, $"ImageLoadingLoadImageFromFileWithSize START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.LoadImageFromFile(image_path, size2d);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            // size is null
            try
            {
                var testingTarget = ImageLoading.LoadImageFromFile(image_path, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.Pass("Catch ArgumentNullException, Pass!");
            }

            tlog.Debug(tag, $"ImageLoadingLoadImageFromFileWithSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading LoadImageFromFile. With FittingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingLoadImageFromFileWithFittingMode()
        {
            tlog.Debug(tag, $"ImageLoadingLoadImageFromFileWithFittingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.LoadImageFromFile(image_path, size2d, FittingModeType.ScaleToFill);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            // size is null
            try
            {
                var testingTarget = ImageLoading.LoadImageFromFile(image_path, null, FittingModeType.ScaleToFill);
            }
            catch (ArgumentNullException e)
            {
                Assert.Pass("Catch ArgumentNullException, Pass!");
            }

            tlog.Debug(tag, $"ImageLoadingLoadImageFromFileWithFittingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading LoadImageFromFile. With SamplingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingLoadImageFromFileWithSamplingMode()
        {
            tlog.Debug(tag, $"ImageLoadingLoadImageFromFileWithSamplingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.LoadImageFromFile(image_path, size2d, FittingModeType.ScaleToFill, SamplingModeType.Linear);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            // size is null
            try
            {
                var testingTarget = ImageLoading.LoadImageFromFile(image_path, null, FittingModeType.ScaleToFill, SamplingModeType.Linear);
            }
            catch (ArgumentNullException e)
            {
                Assert.Pass("Catch ArgumentNullException, Pass!");
            }

            tlog.Debug(tag, $"ImageLoadingLoadImageFromFileWithSamplingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading LoadImageFromFile. With orientationCorrection.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingLoadImageFromFileWithOrientationCorrection()
        {
            tlog.Debug(tag, $"ImageLoadingLoadImageFromFileWithOrientationCorrection START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.LoadImageFromFile(image_path, size2d, FittingModeType.ScaleToFill, SamplingModeType.Linear, true);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoadingLoadImageFromFileWithOrientationCorrection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading GetClosestImageSize.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingGetClosestImageSize()
        {
            tlog.Debug(tag, $"ImageLoadingGetClosestImageSize START");

            var testingTarget = ImageLoading.GetClosestImageSize(file_name);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoadingGetClosestImageSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading GetClosestImageSize. With Size.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingGetClosestImageSizeWithSize()
        {
            tlog.Debug(tag, $"ImageLoadingGetClosestImageSizeWithSize START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.GetClosestImageSize(file_name, size2d);
                Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
                Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoadingGetClosestImageSizeWithSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading GetClosestImageSize. With FittingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingGetClosestImageSizeWithFittingMode()
        {
            tlog.Debug(tag, $"ImageLoadingGetClosestImageSizeWithFittingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.GetClosestImageSize(file_name, size2d, FittingModeType.ShrinkToFit);
                Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
                Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoadingGetClosestImageSizeWithFittingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading GetClosestImageSize. With SamplingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingGetClosestImageSizeWithSamplingMode()
        {
            tlog.Debug(tag, $"ImageLoadingGetClosestImageSizeWithSamplingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.GetClosestImageSize(file_name, size2d, FittingModeType.ShrinkToFit, SamplingModeType.Box);
                Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
                Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoadingGetClosestImageSizeWithSamplingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading GetClosestImageSize. With orientationCorrection.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingGetClosestImageSizeWithOrientationCorrection()
        {
            tlog.Debug(tag, $"ImageLoadingGetClosestImageSizeWithOrientationCorrection START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.GetClosestImageSize(file_name, size2d, FittingModeType.ShrinkToFit, SamplingModeType.Box, true);
                Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
                Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoadingGetClosestImageSizeWithOrientationCorrection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading GetOriginalImageSize.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.GetOriginalImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingGetOriginalImageSize()
        {
            tlog.Debug(tag, $"ImageLoadingGetOriginalImageSize START");

            var testingTarget = ImageLoading.GetOriginalImageSize(file_name, true);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoadingGetOriginalImageSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading DownloadImageSynchronously.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingDownloadImageSynchronously()
        {
            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronously START");


            var testingTarget = ImageLoading.DownloadImageSynchronously(bmp_path);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronously END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading DownloadImageSynchronously. With Size.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingDownloadImageSynchronouslyWithSize()
        {
            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronouslyWithSize START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.DownloadImageSynchronously(bmp_path, size2d);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronouslyWithSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading DownloadImageSynchronously. With FittingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingDownloadImageSynchronouslyWithFittingMode()
        {
            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronouslyWithFittingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.DownloadImageSynchronously(bmp_path, size2d, FittingModeType.FitHeight);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronouslyWithFittingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading DownloadImageSynchronously. With SamplingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingDownloadImageSynchronouslyWithSamplingMode()
        {
            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronouslyWithSamplingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.DownloadImageSynchronously(bmp_path, size2d, FittingModeType.FitWidth, SamplingModeType.Nearest);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronouslyWithSamplingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading DownloadImageSynchronously. With orientationCorrection.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoadingDownloadImageSynchronouslyWithOrientationCorrection()
        {
            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronouslyWithOrientationCorrection START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.DownloadImageSynchronously(bmp_path, size2d, FittingModeType.Center, SamplingModeType.DontCare, true);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronouslyWithOrientationCorrection END (OK)");
        }
    }
}
