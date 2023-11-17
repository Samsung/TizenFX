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
        [Description("internal API test in Ubuntu, ImageView.PreMultipliedAlpha")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.PreMultipliedAlpha")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void PreMultipliedAlpha_SET_GET_VALUE()
        {
            /* TEST CODE */
            ImageView testView = new ImageView(image_path);

            testView.PreMultipliedAlpha = true;

            Assert.AreEqual(testView.PreMultipliedAlpha, true, "PreMultipliedAlpha is not updated");

            testView.PreMultipliedAlpha = false;

            Assert.AreEqual(testView.PreMultipliedAlpha, false, "PreMultipliedAlpha is not updated");

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

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, ImageView.Image with ResourceUrl")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.Image")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Image_GET_VALUE_After_Set_ResourceUrl()
        {
            /* TEST CODE */
            ImageView testView = new ImageView();
            string resultUrl1 = "";

            PropertyMap map1 = testView.Image;

            bool ret1 = (map1.Find(ImageVisualProperty.URL)?.Get(out resultUrl1) ?? false) && string.IsNullOrEmpty(resultUrl1);

            Assert.AreEqual(false, ret1, "map don't have ResourceUrl");

            string testUrl1 = "test1";
            testView.ResourceUrl = testUrl1;

            PropertyMap map2 = testView.Image;

            bool ret2 = (map2.Find(ImageVisualProperty.URL)?.Get(out resultUrl1) ?? false) && !string.IsNullOrEmpty(resultUrl1);

            Assert.AreEqual(true, ret2, "map must have ResourceUrl");
            Assert.AreEqual(testUrl1, resultUrl1, "...and That value must be equal what we added");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, ImageView.Image with something")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.Image")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Image_GET_VALUE_After_Set_something()
        {
            /* TEST CODE */
            ImageView testView = new ImageView();
            string resultString = "";
            bool resultBool = false;

            using(PropertyMap map = testView.Image)
            {
                bool ret = (map.Find(ImageVisualProperty.URL)?.Get(out resultString) ?? false) && string.IsNullOrEmpty(resultString);
                Assert.AreEqual(false, ret, "map don't have ResourceUrl");
                ret = map.Find(ImageVisualProperty.AlphaMaskURL)?.Get(out resultString) ?? false;
                Assert.AreEqual(false, ret, "map don't have AlphaMaskURL");
                ret = map.Find(ImageVisualProperty.CropToMask)?.Get(out resultBool) ?? false;
                Assert.AreEqual(false, ret, "map don't have CropToMask");
                ret = map.Find(ImageVisualProperty.SynchronousLoading)?.Get(out resultBool) ?? false;
                Assert.AreEqual(false, ret, "map don't have SynchronousLoading");
            }

            string testUrl1 = "test1";
            testView.AlphaMaskURL = testUrl1;
            testView.CropToMask = true;
            testView.SynchronousLoading = true;

            using(PropertyMap map = testView.Image)
            {
                bool ret = (map.Find(ImageVisualProperty.URL)?.Get(out resultString) ?? false) && string.IsNullOrEmpty(resultString);
                Assert.AreEqual(false, ret, "map don't have ResourceUrl");
                ret = (map.Find(ImageVisualProperty.AlphaMaskURL)?.Get(out resultString) ?? false) && string.IsNullOrEmpty(resultString);
                Assert.AreEqual(false, ret, "map don't have AlphaMaskURL cause ResoureUrl is empty");
                ret = map.Find(ImageVisualProperty.CropToMask)?.Get(out resultBool) ?? false;
                Assert.AreEqual(false, ret, "map don't have CropToMask cause ResoureUrl is empty");
                ret = map.Find(ImageVisualProperty.SynchronousLoading)?.Get(out resultBool) ?? false;
                Assert.AreEqual(false, ret, "map don't have SynchronousLoading cause ResoureUrl is empty");
            }

            testView.ResourceUrl = image_path;

            using(PropertyMap map = testView.Image)
            {
                bool ret = (map.Find(ImageVisualProperty.URL)?.Get(out resultString) ?? false) && !string.IsNullOrEmpty(resultString);
                Assert.AreEqual(true, ret, "map must have ResourceUrl");
                Assert.AreEqual(image_path, resultString, "...and That value must be equal what we added");
                ret = (map.Find(ImageVisualProperty.AlphaMaskURL)?.Get(out resultString) ?? false) && !string.IsNullOrEmpty(resultString);
                Assert.AreEqual(true, ret, "map must have AlphaMaskURL");
                Assert.AreEqual(testUrl1, resultString, "...and That value must be equal what we added");
                ret = map.Find(ImageVisualProperty.CropToMask)?.Get(out resultBool) ?? false;
                Assert.AreEqual(true, ret, "map must have CropToMask");
                Assert.AreEqual(true, resultBool, "...and That value must be equal what we added");
                ret = map.Find(ImageVisualProperty.SynchronousLoading)?.Get(out resultBool) ?? false;
                Assert.AreEqual(true, ret, "map must have SynchronousLoading");
                Assert.AreEqual(true, resultBool, "...and That value must be equal what we added");
            }

            // Insert empty resource Url
            testView.ResourceUrl = "";

            using(PropertyMap map = testView.Image)
            {
                bool ret = (map.Find(ImageVisualProperty.URL)?.Get(out resultString) ?? false) && string.IsNullOrEmpty(resultString);
                Assert.AreEqual(false, ret, "map don't have ResourceUrl");
                ret = (map.Find(ImageVisualProperty.AlphaMaskURL)?.Get(out resultString) ?? false) && string.IsNullOrEmpty(resultString);
                Assert.AreEqual(false, ret, "map don't have AlphaMaskURL cause ResoureUrl is empty");
                ret = map.Find(ImageVisualProperty.CropToMask)?.Get(out resultBool) ?? false;
                Assert.AreEqual(false, ret, "map don't have CropToMask cause ResoureUrl is empty");
                ret = map.Find(ImageVisualProperty.SynchronousLoading)?.Get(out resultBool) ?? false;
                Assert.AreEqual(false, ret, "map don't have SynchronousLoading cause ResoureUrl is empty");
            }

            // Insert valid resource Url
            testView.ResourceUrl = mask_path;

            using(PropertyMap map = testView.Image)
            {
                bool ret = (map.Find(ImageVisualProperty.URL)?.Get(out resultString) ?? false) && !string.IsNullOrEmpty(resultString);
                Assert.AreEqual(true, ret, "map must have ResourceUrl");
                Assert.AreEqual(mask_path, resultString, "...and That value must be equal what we added");
                ret = (map.Find(ImageVisualProperty.AlphaMaskURL)?.Get(out resultString) ?? false) && !string.IsNullOrEmpty(resultString);
                Assert.AreEqual(true, ret, "map must have AlphaMaskURL");
                Assert.AreEqual(testUrl1, resultString, "...and That value must be equal what we added");
                ret = map.Find(ImageVisualProperty.CropToMask)?.Get(out resultBool) ?? false;
                Assert.AreEqual(true, ret, "map must have CropToMask");
                Assert.AreEqual(true, resultBool, "...and That value must be equal what we added");
                ret = map.Find(ImageVisualProperty.SynchronousLoading)?.Get(out resultBool) ?? false;
                Assert.AreEqual(true, ret, "map must have SynchronousLoading");
                Assert.AreEqual(true, resultBool, "...and That value must be equal what we added");
            }

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, set ImageView.Image and check cached properties changed")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.ImageView.Image")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Image_SET_VALUE_After_Set_something()
        {
            /* TEST CODE */
            ImageView testView = new ImageView();
            string resultString = "";
            bool resultBool = false;

            using(PropertyMap map = testView.Image)
            {
                bool ret = (map.Find(ImageVisualProperty.URL)?.Get(out resultString) ?? false) && string.IsNullOrEmpty(resultString);
                Assert.AreEqual(false, ret, "map don't have ResourceUrl");
                ret = map.Find(ImageVisualProperty.AlphaMaskURL)?.Get(out resultString) ?? false;
                Assert.AreEqual(false, ret, "map don't have AlphaMaskURL");
                ret = map.Find(ImageVisualProperty.CropToMask)?.Get(out resultBool) ?? false;
                Assert.AreEqual(false, ret, "map don't have CropToMask");
                ret = map.Find(ImageVisualProperty.SynchronousLoading)?.Get(out resultBool) ?? false;
                Assert.AreEqual(false, ret, "map don't have SynchronousLoading");
            }

            string testUrl1 = "test1";
            string testUrl2 = "test2";
            testView.ResourceUrl = testUrl1;
            testView.AlphaMaskURL = testUrl2;
            testView.CropToMask = true;
            testView.SynchronousLoading = true;

            using(PropertyMap map = testView.Image)
            {
                bool ret = (map.Find(ImageVisualProperty.URL)?.Get(out resultString) ?? false) && !string.IsNullOrEmpty(resultString);
                Assert.AreEqual(true, ret, "map must have ResourceUrl");
                Assert.AreEqual(testUrl1, resultString, "...and That value must be equal what we added");
                ret = (map.Find(ImageVisualProperty.AlphaMaskURL)?.Get(out resultString) ?? false) && !string.IsNullOrEmpty(resultString);
                Assert.AreEqual(true, ret, "map must have AlphaMaskURL");
                Assert.AreEqual(testUrl2, resultString, "...and That value must be equal what we added");
                ret = map.Find(ImageVisualProperty.CropToMask)?.Get(out resultBool) ?? false;
                Assert.AreEqual(true, ret, "map must have CropToMask");
                Assert.AreEqual(true, resultBool, "...and That value must be equal what we added");
                ret = map.Find(ImageVisualProperty.SynchronousLoading)?.Get(out resultBool) ?? false;
                Assert.AreEqual(true, ret, "map must have SynchronousLoading");
                Assert.AreEqual(true, resultBool, "...and That value must be equal what we added");
            }

            // Update Image map by PropertyMap.
            // Cached property map will be overwrited.
            using(PropertyMap setImageMap = new PropertyMap())
            {
                setImageMap[ImageVisualProperty.URL] = new PropertyValue(image_path);
                setImageMap[ImageVisualProperty.AlphaMaskURL] = new PropertyValue(mask_path);
                setImageMap[ImageVisualProperty.CropToMask] = new PropertyValue(false);
                setImageMap[ImageVisualProperty.SynchronousLoading] = new PropertyValue(false);
                testView.Image = setImageMap;
            }

            using(PropertyMap map = testView.Image)
            {
                bool ret = (map.Find(ImageVisualProperty.URL)?.Get(out resultString) ?? false) && !string.IsNullOrEmpty(resultString);
                Assert.AreEqual(true, ret, "map must have ResourceUrl");
                Assert.AreEqual(image_path, resultString, "...and That value must be equal what we added");
                ret = (map.Find(ImageVisualProperty.AlphaMaskURL)?.Get(out resultString) ?? false) && !string.IsNullOrEmpty(resultString);
                Assert.AreEqual(true, ret, "map must have AlphaMaskURL");
                Assert.AreEqual(mask_path, resultString, "...and That value must be equal what we added");
                ret = map.Find(ImageVisualProperty.CropToMask)?.Get(out resultBool) ?? false;
                Assert.AreEqual(true, ret, "map must have CropToMask");
                Assert.AreEqual(false, resultBool, "...and That value must be equal what we added");
                ret = map.Find(ImageVisualProperty.SynchronousLoading)?.Get(out resultBool) ?? false;
                Assert.AreEqual(true, ret, "map must have SynchronousLoading");
                Assert.AreEqual(false, resultBool, "...and That value must be equal what we added");
            }
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, Container.DisposeRecursively")]
        [Property("SPEC", "Tizen.NUI.Common.Container.DisposeRecursively M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void DisposeRecursively_VALUE()
        {
            /* TEST CODE */
            View testParent = new View();
            View testChildL0 = new View();
            View testChildL1 = new View();

            testParent.Add(testChildL0);
            testChildL0.Add(testChildL1);

            Assert.AreEqual(false, testParent.Disposed, "View should not disposed yet.");
            Assert.AreEqual(false, testChildL0.Disposed, "View should not disposed yet.");
            Assert.AreEqual(false, testChildL1.Disposed, "View should not disposed yet.");

            testParent.DisposeRecursively();

            Assert.AreEqual(true, testParent.Disposed, "View should be disposed now.");
            Assert.AreEqual(true, testChildL0.Disposed, "View should be disposed now.");
            Assert.AreEqual(true, testChildL1.Disposed, "View should be disposed now.");
        }
    }
}
