using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Images/ImageLoader")]
    public class PublicImageLoaderTest
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
        [Description("ImageLoader LoadImageFromFile.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromFile()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromFile START");

            var testingTarget = ImageLoader.LoadImageFromFile(image_path);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoaderLoadImageFromFile END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader LoadImageFromFile. With Size.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromFileWithSize()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithSize START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.LoadImageFromFile(image_path, size2d);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            // size is null
            try
            {
                var testingTarget = ImageLoader.LoadImageFromFile(image_path, null);
            }
            catch (ArgumentNullException e)
            {
                Assert.Pass("Catch ArgumentNullException, Pass!");
            }

            tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader LoadImageFromFile. With FittingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromFileWithFittingMode()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithFittingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.LoadImageFromFile(image_path, size2d, FittingModeType.ScaleToFill);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            // size is null
            try
            {
                var testingTarget = ImageLoader.LoadImageFromFile(image_path, null, FittingModeType.ScaleToFill);
            }
            catch (ArgumentNullException e)
            {
                Assert.Pass("Catch ArgumentNullException, Pass!");
            }

            tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithFittingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader LoadImageFromFile. With SamplingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromFileWithSamplingMode()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithSamplingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.LoadImageFromFile(image_path, size2d, FittingModeType.ScaleToFill, SamplingModeType.Linear);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            // size is null
            try
            {
                var testingTarget = ImageLoader.LoadImageFromFile(image_path, null, FittingModeType.ScaleToFill, SamplingModeType.Linear);
            }
            catch (ArgumentNullException e)
            {
                Assert.Pass("Catch ArgumentNullException, Pass!");
            }

            tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithSamplingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader LoadImageFromFile. With orientationCorrection.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromFileWithOrientationCorrection()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithOrientationCorrection START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.LoadImageFromFile(image_path, size2d, FittingModeType.ScaleToFill, SamplingModeType.Linear, true);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithOrientationCorrection END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader LoadImageFromFile. With orientationCorrection.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromFileWithOrientationCorrectionAndNullSize()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithOrientationCorrectionAndNullSize START");

            try
            {
                ImageLoader.LoadImageFromFile(image_path, null, FittingModeType.ScaleToFill, SamplingModeType.Linear, true);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithOrientationCorrectionAndNullSize END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithOrientationCorrection()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithOrientationCorrection START");

            var stream = FileToStream(image_path);

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.LoadImageFromBuffer(stream, size2d, FittingModeType.ScaleToFill, SamplingModeType.Linear, true);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithOrientationCorrection END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithOrientationCorrectionNullBuffer()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithOrientationCorrectionNullBuffer START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                try
                {
                    ImageLoader.LoadImageFromBuffer(null, size2d, FittingModeType.ScaleToFill, SamplingModeType.Linear, true);
                }
                catch (ArgumentNullException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithOrientationCorrectionNullBuffer END (OK)");
                    Assert.Pass("Caught ArgumentNullException :  Passed!");
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithOrientationCorrectionNullSize()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithOrientationCorrectionNullSize START");

            var stream = FileToStream(image_path);

            try
            {
                ImageLoader.LoadImageFromBuffer(stream, null, FittingModeType.ScaleToFill, SamplingModeType.Linear, true); ;
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithOrientationCorrectionNullSize END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithSamplingMode()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSamplingMode START");

            var stream = FileToStream(image_path);

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.LoadImageFromBuffer(stream, size2d, FittingModeType.ScaleToFill, SamplingModeType.Linear);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSamplingMode END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithSamplingModeNullBuffer()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSamplingModeNullBuffer START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                try
                {
                    ImageLoader.LoadImageFromBuffer(null, size2d, FittingModeType.ScaleToFill, SamplingModeType.Linear);
                }
                catch (ArgumentNullException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSamplingModeNullBuffer END (OK)");
                    Assert.Pass("Caught ArgumentNullException :  Passed!");
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithSamplingModeNullSize()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSamplingModeNullSize START");

            var stream = FileToStream(image_path);

            try
            {
                ImageLoader.LoadImageFromBuffer(stream, null, FittingModeType.ScaleToFill, SamplingModeType.Linear);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSamplingModeNullSize END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithFittingMode()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithFittingMode  START");

            var stream = FileToStream(image_path);

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.LoadImageFromBuffer(stream, size2d, FittingModeType.ScaleToFill);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithFittingMode  END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithFittingModeNullBuffer()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithFittingModeNullBuffer START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                try
                {
                    ImageLoader.LoadImageFromBuffer(null, size2d, FittingModeType.ScaleToFill);
                }
                catch (ArgumentNullException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithFittingModeNullBuffer END (OK)");
                    Assert.Pass("Caught ArgumentNullException :  Passed!");
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithFittingModeNullSize()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithFittingModeNullSize START");

            var stream = FileToStream(image_path);

            try
            {
                ImageLoader.LoadImageFromBuffer(stream, null, FittingModeType.ScaleToFill);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithFittingModeNullSize END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithSize()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSize  START");

            var stream = FileToStream(image_path);

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.LoadImageFromBuffer(stream, size2d);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSize  END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithSizeNullBuffer()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSizeNullBuffer START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                try
                {
                    ImageLoader.LoadImageFromBuffer(null, size2d);
                }
                catch (ArgumentNullException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSizeNullBuffer END (OK)");
                    Assert.Pass("Caught ArgumentNullException :  Passed!");
                }
            }
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithSizeNullSize()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSizeNullSize START");

            var stream = FileToStream(image_path);

            try
            {
                ImageLoader.LoadImageFromBuffer(stream, null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithSizeNullSize END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBuffer()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBuffer  START");

            var stream = FileToStream(image_path);

            var testingTarget = ImageLoader.LoadImageFromBuffer(stream);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBuffer  END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader LoadImageFromBuffer.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromBufferWithNullBuffer()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithNullBuffer START");

            try
            {
                ImageLoader.LoadImageFromBuffer(null);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"ImageLoaderLoadImageFromBufferWithNullBuffer END (OK)");
                Assert.Pass("Caught ArgumentNullException :  Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader GetClosestImageSize.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderGetClosestImageSize()
        {
            tlog.Debug(tag, $"ImageLoaderGetClosestImageSize START");

            var testingTarget = ImageLoader.GetClosestImageSize(file_name);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoaderGetClosestImageSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader GetClosestImageSize. With Size.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderGetClosestImageSizeWithSize()
        {
            tlog.Debug(tag, $"ImageLoaderGetClosestImageSizeWithSize START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.GetClosestImageSize(file_name, size2d);
                Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
                Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoaderGetClosestImageSizeWithSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader GetClosestImageSize. With FittingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderGetClosestImageSizeWithFittingMode()
        {
            tlog.Debug(tag, $"ImageLoaderGetClosestImageSizeWithFittingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.GetClosestImageSize(file_name, size2d, FittingModeType.ShrinkToFit);
                Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
                Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoaderGetClosestImageSizeWithFittingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader GetClosestImageSize. With SamplingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderGetClosestImageSizeWithSamplingMode()
        {
            tlog.Debug(tag, $"ImageLoaderGetClosestImageSizeWithSamplingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.GetClosestImageSize(file_name, size2d, FittingModeType.ShrinkToFit, SamplingModeType.Box);
                Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
                Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoaderGetClosestImageSizeWithSamplingMode END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader GetClosestImageSize. With orientationCorrection.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.GetClosestImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderGetClosestImageSizeWithOrientationCorrection()
        {
            tlog.Debug(tag, $"ImageLoaderGetClosestImageSizeWithOrientationCorrection START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.GetClosestImageSize(file_name, size2d, FittingModeType.ShrinkToFit, SamplingModeType.Box, true);
                Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
                Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoaderGetClosestImageSizeWithOrientationCorrection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader GetOriginalImageSize.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.GetOriginalImageSize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderGetOriginalImageSize()
        {
            tlog.Debug(tag, $"ImageLoaderGetOriginalImageSize START");

            var testingTarget = ImageLoader.GetOriginalImageSize(file_name);
            Assert.IsNotNull(testingTarget, "Can't create success object Size2D.");
            Assert.IsInstanceOf<Size2D>(testingTarget, "Should return Size2D instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoaderGetOriginalImageSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader DownloadImageSynchronously.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderDownloadImageSynchronously()
        {
            tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronously START");


            var testingTarget = ImageLoader.DownloadImageSynchronously(bmp_path);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronously END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader DownloadImageSynchronously. With Size.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderDownloadImageSynchronouslyWithSize()
        {
            tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyWithSize START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.DownloadImageSynchronously(bmp_path, size2d);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyWithSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader DownloadImageSynchronously. With FittingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderDownloadImageSynchronouslyWithFittingMode()
        {
            tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyWithFittingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.DownloadImageSynchronously(bmp_path, size2d, FittingModeType.FitHeight);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            try
            {
                ImageLoader.DownloadImageSynchronously(bmp_path, null, FittingModeType.FitHeight);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyWithFittingMode END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader DownloadImageSynchronously. With SamplingModeType.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderDownloadImageSynchronouslyWithSamplingMode()
        {
            tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyWithSamplingMode START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.DownloadImageSynchronously(bmp_path, size2d, FittingModeType.FitWidth, SamplingModeType.Nearest);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            try
            {
                ImageLoader.DownloadImageSynchronously(bmp_path, null, FittingModeType.FitHeight, SamplingModeType.Nearest);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyWithSamplingMode END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader DownloadImageSynchronously. With orientationCorrection.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderDownloadImageSynchronouslyWithOrientationCorrection()
        {
            tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyWithOrientationCorrection START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.DownloadImageSynchronously(bmp_path, size2d, FittingModeType.Center, SamplingModeType.DontCare, true);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            try
            {
                ImageLoader.DownloadImageSynchronously(bmp_path, null, FittingModeType.FitHeight, SamplingModeType.Nearest, true);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyWithOrientationCorrection END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("ImageLoader DownloadImageSynchronously. With Uri.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderDownloadImageSynchronouslyByUrl()
        {
            tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyByUrl START");

            using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
            {
                var testingTarget = ImageLoader.DownloadImageSynchronously(new Uri(bmp_path), size2d, FittingModeType.Center);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                testingTarget.Dispose();
            }

            try
            {
                ImageLoader.DownloadImageSynchronously(new Uri(bmp_path), null, FittingModeType.FitHeight);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyByUrl END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("ImageLoader DownloadImageSynchronously. With Uri.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.DownloadImageSynchronously M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderDownloadImageSynchronouslyByNullUrl()
        {
            tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyByNullUrl START");

            try
            {
                using (Size2D size2d = new Size2D(NUIApplication.GetDefaultWindow().WindowSize.Width, NUIApplication.GetDefaultWindow().WindowSize.Height))
                {
                    Uri uri = null;
                    ImageLoader.DownloadImageSynchronously(uri, size2d, FittingModeType.Center);
                }
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"ImageLoaderDownloadImageSynchronouslyByNullUrl END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }
    }
}
