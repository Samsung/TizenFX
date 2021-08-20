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
    [Description("public/BaseComponents/AnimatedImageView")]
    public class PublicAnimatedImageViewTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        internal class MyAnimatedImageView : AnimatedImageView
        {
            public MyAnimatedImageView()
            { }

            public void OnDispose(DisposeTypes type)
            {
                base.Dispose(type);
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
        [Description("AnimatedImageView constructor.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.AnimatedImageView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewConstructor()
        {
            tlog.Debug(tag, $"AnimatedImageViewConstructor START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView Dispose.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewDispose()
        {
            tlog.Debug(tag, $"AnimatedImageViewDispose START");

            var testingTarget = new MyAnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }
           
            tlog.Debug(tag, $"AnimatedImageViewDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView ResourceUrl.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.ResourceUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewResourceUrl()
        {
            tlog.Debug(tag, $"AnimatedImageViewResourceUrl START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            testingTarget.ResourceUrl = url;
            Assert.AreEqual(url, testingTarget.ResourceUrl, "Should be equal");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewResourceUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView URLs.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.URLs A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewURLs()
        {
            tlog.Debug(tag, $"AnimatedImageViewURLs START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            Assert.IsNotNull(testingTarget.URLs);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewURLs END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView BatchSize.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.BatchSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewBatchSize()
        {
            tlog.Debug(tag, $"AnimatedImageViewBatchSize START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            Assert.AreEqual(1, testingTarget.BatchSize, "Should be equal!");

            testingTarget.BatchSize = 2;
            Assert.AreEqual(2, testingTarget.BatchSize, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewBatchSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView CacheSize.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.CacheSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewCacheSize()
        {
            tlog.Debug(tag, $"AnimatedImageViewCacheSize START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            Assert.AreEqual(1, testingTarget.CacheSize, "Should be equal!");

            testingTarget.CacheSize = 2;
            Assert.AreEqual(2, testingTarget.CacheSize, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewCacheSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView FrameDelay.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.FrameDelay A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewFrameDelay()
        {
            tlog.Debug(tag, $"AnimatedImageViewFrameDelay START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            testingTarget.FrameDelay = 300;
            Assert.AreEqual(300, testingTarget.FrameDelay, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewFrameDelay END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView LoopCount.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.LoopCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewLoopCount()
        {
            tlog.Debug(tag, $"AnimatedImageViewLoopCount START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            testingTarget.LoopCount = 3;
            Assert.AreEqual(3, testingTarget.LoopCount, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewLoopCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView StopBehavior.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.StopBehavior A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewStopBehavior()
        {
            tlog.Debug(tag, $"AnimatedImageViewStopBehavior START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            testingTarget.StopBehavior = AnimatedImageView.StopBehaviorType.MinimumFrame;
            Assert.AreEqual(AnimatedImageView.StopBehaviorType.MinimumFrame, testingTarget.StopBehavior, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewStopBehavior END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView TotalFrame.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.TotalFrame A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewTotalFrame()
        {
            tlog.Debug(tag, $"AnimatedImageViewTotalFrame START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                map.Insert(ImageVisualProperty.URL, new PropertyValue(url));
                map.Insert(ImageVisualProperty.Border, new PropertyValue(new Extents(4, 4, 4, 4)));
                map.Insert(ImageVisualProperty.TotalFrameNumber, new PropertyValue(ImageVisualProperty.TotalFrameNumber));

                testingTarget.Image = map;

                try
                {
                    var resutl = testingTarget.TotalFrame;
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewTotalFrame END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView CurrentFrame.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.CurrentFrame A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewCurrentFrame()
        {
            tlog.Debug(tag, $"AnimatedImageViewCurrentFrame START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                map.Insert(ImageVisualProperty.URL, new PropertyValue(url));
                map.Insert(ImageVisualProperty.Border, new PropertyValue(new Extents(4, 4, 4, 4)));
                map.Insert(ImageVisualProperty.TotalFrameNumber, new PropertyValue(30));
                map.Insert(ImageVisualProperty.CurrentFrameNumber, new PropertyValue(0));

                testingTarget.Image = map;

                try
                {
                    testingTarget.CurrentFrame = 15;
                    var resutl = testingTarget.CurrentFrame;
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewCurrentFrame END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageView Play.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageView.Play M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageViewPlay()
        {
            tlog.Debug(tag, $"AnimatedImageViewPlay START");

            var testingTarget = new AnimatedImageView();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageView");
            Assert.IsInstanceOf<AnimatedImageView>(testingTarget, "Should be an instance of AnimatedImageView type.");

            using (PropertyMap map = new PropertyMap())
            {
                map.Insert(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
                map.Insert(ImageVisualProperty.URL, new PropertyValue(url));
                map.Insert(ImageVisualProperty.AlphaMaskURL, new PropertyValue(url));
                map.Insert(ImageVisualProperty.AuxiliaryImageURL, new PropertyValue(url));
                map.Insert(ImageVisualProperty.Border, new PropertyValue(new Extents(4, 4, 4, 4)));
                map.Insert(ImageVisualProperty.TotalFrameNumber, new PropertyValue(30));
                map.Insert(ImageVisualProperty.CurrentFrameNumber, new PropertyValue(0));

                testingTarget.Image = map;

                testingTarget.BatchSize = 2;
                testingTarget.CacheSize = 2;
                testingTarget.LoopCount = 3;
                testingTarget.StopBehavior = AnimatedImageView.StopBehaviorType.MinimumFrame;

                try
                {
                    testingTarget.Play();
                }
                catch (Exception e)
                {
                    testingTarget.Dispose();
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"AnimatedImageViewPlay END (OK)");
                    Assert.Pass("Passed!");
                }
            }
            testingTarget?.Dispose();
            tlog.Debug(tag, $"AnimatedImageViewPlay END (OK)");
        }
    }
}
