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
    public class InternalAnimatedImageViewTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Image.png";
        private string animated_image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "dali-logo-anim.gif";

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
        [Description("internal API test in Ubuntu, AnimatedImageView.ResourceUrl")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.ResourceUrl")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void ResourceUrl_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();
            // Note : Current version of ANIMATED_IMAGE Visual works well only ResourceUrl's suffix is *.gif or *.webp
            string testUrl1 = "test1.gif";
            testView.ResourceUrl = testUrl1;

            Assert.AreEqual(testView.ResourceUrl, testUrl1, "ResourceUrl is not equal");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, AnimatedImageView.NaturalSize2D")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.NaturalSize2D")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void NaturalSize2D_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();
            testView.ResourceUrl = animated_image_path;
            Size2D result = new Size2D(326, 171); // The size of animated_image_path image.
            Size2D size = testView.NaturalSize2D;

            Assert.AreEqual(result.Width, size.Width, "NaturalSize Width is not equal");
            Assert.AreEqual(result.Height, size.Height, "NaturalSize Height is not equal");

            testView.Dispose();
        }


        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, AnimatedImageView.NaturalSize")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.NaturalSize")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void NaturalSize_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();
            testView.ResourceUrl = animated_image_path;
            Vector3 result = new Vector3(326, 171, 0); // The size of animated_image_path image.
            Vector3 size = testView.NaturalSize;

            Assert.AreEqual(result.X, size.X, "NaturalSize Width is not equal");
            Assert.AreEqual(result.Y, size.Y, "NaturalSize Height is not equal");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, AnimatedImageView.NaturalSize")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.NaturalSize")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void NaturalSize_GET_VALUE_as_View_class()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();
            testView.ResourceUrl = animated_image_path;
            Vector3 result = new Vector3(326, 171, 0); // The size of animated_image_path image.
            View testView2 = testView; // Convert class as View.
            Vector3 size = testView2.NaturalSize; // Check whether virtual ImageView.GetNaturalSize() called well.

            Assert.AreEqual(result.X, size.X, "NaturalSize Width is not equal");
            Assert.AreEqual(result.Y, size.Y, "NaturalSize Height is not equal");

            testView.Dispose();
            testView2.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, AnimatedImageView.Image with ResourceUrl")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.Image")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void Image_GET_VALUE_After_Set_ResourceUrl()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();
            string resultUrl1 = "";

            PropertyMap map1 = testView.Image;

            bool ret1 = (map1.Find(ImageVisualProperty.URL)?.Get(out resultUrl1) ?? false) && string.IsNullOrEmpty(resultUrl1);

            Assert.AreEqual(false, ret1, "map don't have ResourceUrl");

            // Note : Current version of ANIMATED_IMAGE Visual works well only ResourceUrl's suffix is *.gif or *.webp
            string testUrl1 = "test1.gif";
            testView.ResourceUrl = testUrl1;

            PropertyMap map2 = testView.Image;

            bool ret2 = (map2.Find(ImageVisualProperty.URL)?.Get(out resultUrl1) ?? false) && !string.IsNullOrEmpty(resultUrl1);

            Assert.AreEqual(true, ret2, "map must have ResourceUrl");
            Assert.AreEqual(testUrl1, resultUrl1, "...and That value must be equal what we added");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, AnimatedImageView.TotalFrame")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.TotalFrame")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void TotalFrame_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();
            int expectedTotalFrame = 15; // The total frame of animated_image_path image

            Assert.AreEqual(-1, testView.TotalFrame, "Total frame should be -1 when ResourceUrl is not setup");

            testView.ResourceUrl = animated_image_path;

            Assert.AreEqual(expectedTotalFrame, testView.TotalFrame, "Total frame doesn't matched!");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, AnimatedImageView.CurrentFrame")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.CurrentFrame")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void CurrentFrame_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();

            Assert.AreEqual(-1, testView.CurrentFrame, "Current frame should be -1 when ResourceUrl is not setup");

            testView.ResourceUrl = animated_image_path;

            Assert.AreEqual(0, testView.CurrentFrame, "Current frame doesn't matched!");

            // Set CurrentFrame will works well only if view is scene on.
            NUIApplication.GetDefaultWindow().Add(testView);

            int expectFrame = 3;
            testView.CurrentFrame = expectFrame;

            Assert.AreEqual(expectFrame, testView.CurrentFrame, "Current frame doesn't matched!");

            testView.Unparent();
            testView.Dispose();
        }


        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, AnimatedImageView.LoopCount")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.LoopCount")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void LoopCount_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();

            Assert.AreEqual(-1, testView.LoopCount, "LoopCount should be -1 when ResourceUrl is not setup");

            testView.ResourceUrl = animated_image_path;

            Assert.AreEqual(-1, testView.LoopCount, "LoopCount should be -1 (mean infinite loop) even ResourceUrl is setup");

            int expectLoopCount = 3;
            testView.LoopCount = expectLoopCount;
            Assert.AreEqual(expectLoopCount, testView.LoopCount, "LoopCount doesn't matched!");

            testView.LoopCount++;
            Assert.AreEqual(expectLoopCount + 1, testView.LoopCount, "LoopCount doesn't matched!");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, AnimatedImageView.StopBehavior")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.StopBehavior")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void StopBehavior_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();

            testView.ResourceUrl = animated_image_path;

            testView.StopBehavior = AnimatedImageView.StopBehaviorType.CurrentFrame;
            Assert.AreEqual(AnimatedImageView.StopBehaviorType.CurrentFrame, testView.StopBehavior, "StopBehavior is not equal");
            testView.StopBehavior = AnimatedImageView.StopBehaviorType.MinimumFrame;
            Assert.AreEqual(AnimatedImageView.StopBehaviorType.MinimumFrame, testView.StopBehavior, "StopBehavior is not equal");
            testView.StopBehavior = AnimatedImageView.StopBehaviorType.MaximumFrame;
            Assert.AreEqual(AnimatedImageView.StopBehaviorType.MaximumFrame, testView.StopBehavior, "StopBehavior is not equal");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, AnimatedImageView.URLs")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.URLs")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void URLs_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();
            List<string> urls = testView.URLs;

            urls.Add(image_path);
            urls.Add(image_path);
            urls.Add(image_path);

            // URLs don't have any change notifier. So we have to update property forcely by SetValues API.
            testView.SetValues();

            int expectedTotalFrame = urls.Count;
            int defaultFrameDelay = 100; ///< It can be changed in dali engine side
            int expectFrameDelay = 300;

            Assert.AreEqual(expectedTotalFrame, testView.TotalFrame, "Total frame doesn't matched!");
            Assert.AreEqual(defaultFrameDelay, testView.FrameDelay, "Default frame delay doesn't matched!");
            testView.FrameDelay = expectFrameDelay;
            Assert.AreEqual(expectFrameDelay, testView.FrameDelay, "frame delay doesn't matched!");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("internal API test in Ubuntu, AnimatedImageView.FrameSpeedFactor")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.AnimatedImageView.FrameSpeedFactor")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void FrameSpeedFactor_SET_GET_VALUE()
        {
            /* TEST CODE */
            AnimatedImageView testView = new AnimatedImageView();

            Assert.AreEqual(1.0f, testView.FrameSpeedFactor, "FrameSpeedFactor should be 1.0f when ResourceUrl is not setup");

            testView.ResourceUrl = animated_image_path;

            Assert.AreEqual(1.0f, testView.FrameSpeedFactor, "FrameSpeedFactor should be 1.0f even ResourceUrl is setup");

            float expectSpeedFactor = 3.0f;
            testView.FrameSpeedFactor = expectSpeedFactor;
            Assert.AreEqual(expectSpeedFactor, testView.FrameSpeedFactor, "FrameSpeedFactor doesn't matched!");

            expectSpeedFactor = 0.5f;
            testView.FrameSpeedFactor = expectSpeedFactor;
            Assert.AreEqual(expectSpeedFactor, testView.FrameSpeedFactor, "FrameSpeedFactor doesn't matched!");

            testView.Dispose();
        }
    }
}
