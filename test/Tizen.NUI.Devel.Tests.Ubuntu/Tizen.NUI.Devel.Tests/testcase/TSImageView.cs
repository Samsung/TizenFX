using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/ImageView")]
    public class InternalImageViewTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Image.png";
        private string mask_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "star-mod.png";

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
        [Description("internal API test in Ubuntu, ImageView.ResourceUrl")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.ResourceUrl")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void ResourceUrl_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView testView = new ImageView();
            string testUrl1 = "test1";
            testView.ResourceUrl = testUrl1;

            Assert.AreEqual(testView.ResourceUrl, testUrl1, "ResourceUrl is not equal");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, ImageView.AlphaMaskURL")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.AlphaMaskURL")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void AlphaMaskURL_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView testView = new ImageView(image_path);
            string testUrl1 = "test1";
            testView.AlphaMaskURL = testUrl1;

            Assert.AreEqual(testView.AlphaMaskURL, testUrl1, "AlphaMaskURL is not equal");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, ImageView.CropToMask")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.CropToMask")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void CropToMask_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView testView = new ImageView(image_path);

            Assert.AreEqual(testView.CropToMask, false, "CropToMask default is false when we don't set mask image url");

            testView.CropToMask = true;

            Assert.AreEqual(testView.CropToMask, true, "CropToMask is not updated");

            testView.CropToMask = false;

            Assert.AreEqual(testView.CropToMask, false, "CropToMask is not updated");

            testView.AlphaMaskURL = mask_path;

            Assert.AreEqual(testView.CropToMask, false, "CropToMask should not changed even we set mask image url");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, ImageView.CropToMask with AlphaMaskURL")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.CropToMask")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void CropToMask_DEFAULT_GET_VALUE()
        {
            /* TEST CODE */
            ImageView testView = new ImageView(image_path);

            Assert.AreEqual(testView.CropToMask, false, "CropToMask default is false when we don't set mask image url");

            testView.AlphaMaskURL = image_path;

            Assert.AreEqual(testView.CropToMask, true, "CropToMask default is true when we set mask image url");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, ImageView.NaturalSize2D")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.NaturalSize2D")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void NaturalSize2D_GET_VALUE()
        {
            /* TEST CODE */
            ImageView testView = new ImageView();
            testView.ResourceUrl = image_path;
            Size2D result = new Size2D(212, 150); // The size of image_path image.
            Size2D size = testView.NaturalSize2D;

            Assert.AreEqual(result.Width, size.Width, "NaturalSize Width is not equal");
            Assert.AreEqual(result.Height, size.Height, "NaturalSize Height is not equal");

            testView.Dispose();
        }


        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, ImageView.NaturalSize")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.NaturalSize")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void NaturalSize_GET_VALUE()
        {
            /* TEST CODE */
            ImageView testView = new ImageView();
            testView.ResourceUrl = image_path;
            Vector3 result = new Vector3(212, 150, 0); // The size of image_path image.
            Vector3 size = testView.NaturalSize;

            Assert.AreEqual(result.X, size.X, "NaturalSize Width is not equal");
            Assert.AreEqual(result.Y, size.Y, "NaturalSize Height is not equal");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, ImageView.NaturalSize")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.NaturalSize")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void NaturalSize_GET_VALUE_as_View_class()
        {
            /* TEST CODE */
            ImageView testView = new ImageView();
            testView.ResourceUrl = image_path;
            Vector3 result = new Vector3(212, 150, 0); // The size of image_path image.
            View testView2 = testView; // Convert class as View.
            Vector3 size = testView2.NaturalSize; // Check whether virtual ImageView.GetNaturalSize() called well.

            Assert.AreEqual(result.X, size.X, "NaturalSize Width is not equal");
            Assert.AreEqual(result.Y, size.Y, "NaturalSize Height is not equal");

            testView.Dispose();
            testView2.Dispose();
        }
    }
}
