using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Images/ImageLoader")]
    public class ImageLoaderTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Image.png";

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
        [Description("ImageLoader LoadImageFromFile.")]
        [Property("SPEC", "Tizen.NUI.ImageLoader.LoadImageFromFile M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageLoaderLoadImageFromFile()
        {
            tlog.Debug(tag, $"ImageLoaderLoadImageFromFile START");

            {
                var testingTarget = ImageLoader.LoadImageFromFile(image_path);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer.");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should return PixelBuffer instance.");

                Assert.AreEqual(false, PixelBuffer.ReferenceEquals(testingTarget, null), "Valid image's load result should not be null!");
                Assert.AreEqual(false, testingTarget == null, "Valid image's load result compare with null should be false!");
                Assert.AreEqual(true, (bool)testingTarget, "Valid image's load result bool operator should be true!");
                Assert.AreEqual(false, !testingTarget, "Valid image's load result not operator should be false!");

                testingTarget.Dispose();
            }

            {
                var testingTarget = ImageLoader.LoadImageFromFile("invalid.jpg");
                Assert.AreEqual(false, PixelBuffer.ReferenceEquals(testingTarget, null), "Invalid image's load result should not be null!");
                Assert.AreEqual(true, testingTarget == null, "Invalid image's load result compare with null should be true!");
                Assert.AreEqual(false, (bool)testingTarget, "Invalid image's load result bool operator should be false!");
                Assert.AreEqual(true, !testingTarget, "Invalid image's load result not operator should be true!");

                testingTarget.Dispose();
            }
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
                Assert.Fail("Didn't through exception. Failed!");
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"ImageLoaderLoadImageFromFileWithSize END (OK)");
                Assert.Pass("Catch ArgumentNullException, Pass!");
            }
        }
    }
}
