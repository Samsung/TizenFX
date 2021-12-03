using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.IO;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/images/ImageLoading")]
    public class InternalImageLoadingTest
    {
        private const string tag = "NUITEST";
        private string imageurl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private string bmp_path = "https://image.baidu.com/search/detail?ct=503316480&z=0&ipn=d&word=bmp%E4%B8%8B%E8%BD%BD%20%E4%BD%8D%E5%9B%BE&step_word=&hs=2&pn=0&spn=0&di=30360&pi=0&rn=1&tn=baiduimagedetail&is=0%2C0&istype=2&ie=utf-8&oe=utf-8&in=&cl=2&lm=-1&st=-1&cs=506847219%2C2820013657&os=4205693751%2C1065126395&simid=0%2C0&adpicid=0&lpn=0&ln=389&fr=&fmq=1389861203899_R&fm=&ic=0&s=undefined&hd=undefined&latest=undefined&copyright=undefined&se=&sme=&tab=0&width=&height=&face=undefined&ist=&jit=&cg=&bdtype=0&oriquery=bmp%E4%B8%8B%E8%BD%BD&objurl=https%3A%2F%2Fgimg2.baidu.com%2Fimage_search%2Fsrc%3Dhttp%3A%2F%2Fbpic.ooopic.com%2F17%2F52%2F38%2F17523837-6a28a5a38920964a54ed89d8e93c3a3c-0.jpg%26refer%3Dhttp%3A%2F%2Fbpic.ooopic.com%26app%3D2002%26size%3Df9999%2C10000%26q%3Da80%26n%3D0%26g%3D0n%26fmt%3Djpeg%3Fsec%3D1624445232%26t%3Db9e3c91e4753f12d81e73c7142181326&fromurl=ippr_z2C%24qAzdH3FAzdH3Fooo_z%26e3B555rtv_z%26e3Bv54AzdH3Ffij3ty7wgf7AzdH3F80cdnbn0_z%26e3Bip4s&gsm=1&rpstart=0&rpnum=0&islist=&querylist=&force=undefined";

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

        private Stream FileToStream(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            Stream stream = new MemoryStream(bytes);

            return stream;
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading LoadImageFromFile.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ImageLoadingLoadImageFromFile()
        {
            tlog.Debug(tag, $"ImageLoadingLoadImageFromFile START");

            var testingTarget = ImageLoading.LoadImageFromFile(imageurl);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoadingLoadImageFromFile END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ImageLoadingLoadImageFromBufferWithOrientationCorrection()
        {
            tlog.Debug(tag, $"ImageLoadingLoadImageFromBufferWithOrientationCorrection START");

            var stream = FileToStream(imageurl);

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoading.LoadImageFromBuffer(stream, size2d, FittingModeType.ScaleToFill, SamplingModeType.Linear, true);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoadingLoadImageFromBufferWithOrientationCorrection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading GetClosestImageSize.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ImageLoadingGetClosestImageSize()
        {
            tlog.Debug(tag, $"ImageLoadingGetClosestImageSize START");

            var testingTarget = ImageLoading.GetClosestImageSize("picture");
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoadingGetClosestImageSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoading GetOriginalImageSize.")]
        [Property("SPEC", "Tizen.NUI.ImageLoading.GetOriginalImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ImageLoadingGetOriginalImageSize()
        {
            tlog.Debug(tag, $"ImageLoadingGetOriginalImageSize START");

            var testingTarget = ImageLoading.GetOriginalImageSize("picture");
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
        [Obsolete]
        public void ImageLoadingDownloadImageSynchronously()
        {
            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronously START");


            var testingTarget = ImageLoading.DownloadImageSynchronously(bmp_path);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoadingDownloadImageSynchronously END (OK)");
        }
    }
}
