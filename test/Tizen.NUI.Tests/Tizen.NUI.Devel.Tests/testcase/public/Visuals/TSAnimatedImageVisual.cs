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
    [Description("public/Visuals/AnimatedImageVisual")]
    public class PublicAnimatedImageVisualTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static bool flagComposingPropertyMap;
        internal class MyAnimatedImageVisual : AnimatedImageVisual
        {
            protected override void ComposingPropertyMap()
            {
                flagComposingPropertyMap = true;
                base.ComposingPropertyMap();
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
        [Description("AnimatedImageVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.AnimatedImageVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageVisualConstructor()
        {
            tlog.Debug(tag, $"AnimatedImageVisualConstructor START");
            
            var testingTarget = new AnimatedImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<AnimatedImageVisual>(testingTarget, "Should be an instance of AnimatedImageVisual type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageVisual URL.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.URL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageVisualURL()
        {
            tlog.Debug(tag, $"AnimatedImageVisualURL START");

            var testingTarget = new AnimatedImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<AnimatedImageVisual>(testingTarget, "Should be an instance of AnimatedImageVisual type.");

            testingTarget.URL = image_path;
            Assert.AreEqual(image_path, testingTarget.URL, "Retrieved URL should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageVisualURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageVisual BatchSize.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.BatchSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageVisualBatchSize()
        {
            tlog.Debug(tag, $"AnimatedImageVisualBatchSize START");

            var testingTarget = new AnimatedImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<AnimatedImageVisual>(testingTarget, "Should be an instance of AnimatedImageVisual type.");

            List<string> list = new List<string>();
            list.Add(image_path);

            testingTarget.URLS = list;
            testingTarget.BatchSize = 1;
            Assert.AreEqual(1, testingTarget.BatchSize, "Retrieved BatchSize should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageVisualBatchSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageVisual CacheSize.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.CacheSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageVisualCacheSize()
        {
            tlog.Debug(tag, $"AnimatedImageVisualCacheSize START");

            var testingTarget = new AnimatedImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<AnimatedImageVisual>(testingTarget, "should be an instance of AnimatedImageVisual type.");

            List<string> list = new List<string>();
            list.Add(image_path);

            testingTarget.URLS = list;
            testingTarget.CacheSize = 1;
            Assert.AreEqual(1, testingTarget.CacheSize, "Retrieved CacheSize should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageVisualCacheSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageVisual FrameDelay.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.FrameDelay A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageVisualFrameDelay()
        {
            tlog.Debug(tag, $"AnimatedImageVisualFrameDelay START");

            var testingTarget = new AnimatedImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<AnimatedImageVisual>(testingTarget, "should be an instance of AnimatedImageVisual type.");

            List<string> list = new List<string>();
            list.Add(image_path);

            testingTarget.URLS = list;
            testingTarget.FrameDelay = 0.1f;
            Assert.AreEqual(0.1f, testingTarget.FrameDelay, "Retrieved FrameDelay should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageVisualFrameDelay END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageVisual LoopCount.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.LoopCount A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageVisualLoopCount()
        {
            tlog.Debug(tag, $"AnimatedImageVisualLoopCount START");

            var testingTarget = new AnimatedImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<AnimatedImageVisual>(testingTarget, "should be an instance of AnimatedImageVisual type.");

            List<string> list = new List<string>();
            list.Add(image_path);

            testingTarget.URLS = list;
            testingTarget.LoopCount = 0.1f;
            Assert.AreEqual(0.1f, testingTarget.LoopCount, "Retrieved LoopCount should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageVisualLoopCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageVisual URLS.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.URLS A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageVisualURLS()
        {
            tlog.Debug(tag, $"AnimatedImageVisualURLS START");

            var testingTarget = new AnimatedImageVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<AnimatedImageVisual>(testingTarget, "should be an instance of AnimatedImageVisual type.");

            List<string> list = new List<string>();
            list.Add(image_path);

            testingTarget.URLS = list;
            string url = testingTarget.URLS[0] as string;
            Assert.AreEqual(image_path, url, "Retrieved URLS should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageVisualURLS END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AnimatedImageVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.AnimatedImageVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimatedImageVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"AnimatedImageVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyAnimatedImageVisual()
            {
                URL = image_path,
                BatchSize = 1,
                CacheSize = 1,
                FrameDelay = 0.1f,
                LoopCount = 0.1f
            };
            Assert.IsInstanceOf<AnimatedImageVisual>(testingTarget, "Should be an instance of AnimatedImageVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimatedImageVisualComposingPropertyMap END (OK)");
        }
    }
}
