using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Images/ImageUrl")]
    public class PublicImageUrlTest
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
        [Description("ImageUrl Dispose.")]
        [Property("SPEC", "Tizen.NUI.ImageUrl.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageUrlDispose()
        {
            tlog.Debug(tag, $"ImageUrlDispose START");

            byte[] buffer = new byte[10];
            PixelData data = new PixelData(buffer, 10, 1, 2, PixelFormat.L8, PixelData.ReleaseFunction.Free);

            var testingTarget = data.GenerateUrl();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageUrl");
            Assert.IsInstanceOf<ImageUrl>(testingTarget, "Should be an instance of ImageUrl type.");

            buffer = null;
            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageUrlDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ImageUrl ToString.")]
        [Property("SPEC", "Tizen.NUI.ImageUrl.ToString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ImageUrlToString()
        {
            tlog.Debug(tag, $"ImageUrlToString START");

            byte[] buffer = new byte[10];
            PixelData data = new PixelData(buffer, 10, 1, 2, PixelFormat.L8, PixelData.ReleaseFunction.Free);

            var testingTarget = data.GenerateUrl();
            Assert.IsNotNull(testingTarget, "Can't create success object ImageUrl");
            Assert.IsInstanceOf<ImageUrl>(testingTarget, "Should be an instance of ImageUrl type.");

            tlog.Debug(tag, testingTarget.ToString());

            buffer = null;
            testingTarget.Dispose();
            tlog.Debug(tag, $"ImageUrlToString END (OK)");
        }
    }
}
