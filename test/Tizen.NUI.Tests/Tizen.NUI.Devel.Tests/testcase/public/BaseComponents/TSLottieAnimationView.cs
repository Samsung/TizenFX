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
    [Description("public/BaseComponents/LottieAnimationView")]
    public class PublicLottieAnimationViewTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/picture.png";
        private string lottieFilePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/lottie.json";

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
        [Description("LottieAnimationView URL.")]
        [Property("SPEC", "Tizen.NUI.LottieAnimationView.URL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieAnimationViewURL()
        {
            tlog.Debug(tag, $"LottieAnimationViewURL START");

            using (Uint16Pair size = new Uint16Pair(40, 60))
            {
                var testingTarget = new LottieAnimationView(1.0f, true);
                Assert.IsNotNull(testingTarget, "Can't create success object LottieAnimationView");
                Assert.IsInstanceOf<LottieAnimationView>(testingTarget, "Should be an instance of LottieAnimationView type.");

                testingTarget.URL = lottieFilePath;

                try
                {
                    var result = testingTarget.URL;
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LottieAnimationViewURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieAnimationView RedrawInScalingDown.")]
        [Property("SPEC", "Tizen.NUI.LottieAnimationView.RedrawInScalingDown A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieAnimationViewRedrawInScalingDown()
        {
            tlog.Debug(tag, $"LottieAnimationViewRedrawInScalingDown START");

            using (Uint16Pair size = new Uint16Pair(40, 60))
            {
                var testingTarget = new LottieAnimationView(1.0f, true);
                Assert.IsNotNull(testingTarget, "Can't create success object LottieAnimationView");
                Assert.IsInstanceOf<LottieAnimationView>(testingTarget, "Should be an instance of LottieAnimationView type.");

                testingTarget.URL = lottieFilePath;

                PropertyMap map = new PropertyMap();
                map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image))
                    .Add(ImageVisualProperty.URL, new PropertyValue(url))
                    .Add(ImageVisualProperty.LoopCount, new PropertyValue(2));
                testingTarget.Image = map;

                testingTarget.RedrawInScalingDown = true;
                Assert.IsTrue(testingTarget.RedrawInScalingDown);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LottieAnimationViewRedrawInScalingDown END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieAnimationView SetMinMaxFrameByMarker.")]
        [Property("SPEC", "Tizen.NUI.LottieAnimationView.SetMinMaxFrameByMarker M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieAnimationViewSetMinMaxFrameByMarker()
        {
            tlog.Debug(tag, $"LottieAnimationViewSetMinMaxFrameByMarker START");

            var testingTarget = new LottieAnimationView();
            Assert.IsNotNull(testingTarget, "Can't create success object LottieAnimationView");
            Assert.IsInstanceOf<LottieAnimationView>(testingTarget, "Should be an instance of LottieAnimationView type.");

            testingTarget.URL = lottieFilePath;

            string maker = "startframe: 1; endframe: 10";

            try
            {
                testingTarget.SetMinMaxFrameByMarker(maker, null);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LottieAnimationViewSetMinMaxFrameByMarker END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieAnimationView GetMinMaxFrame.")]
        [Property("SPEC", "Tizen.NUI.LottieAnimationView.GetMinMaxFrame M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieAnimationViewGetMinMaxFrame()
        {
            tlog.Debug(tag, $"LottieAnimationViewGetMinMaxFrame START");

            var testingTarget = new LottieAnimationView();
            Assert.IsNotNull(testingTarget, "Can't create success object LottieAnimationView");
            Assert.IsInstanceOf<LottieAnimationView>(testingTarget, "Should be an instance of LottieAnimationView type.");

            testingTarget.URL = lottieFilePath;

            PropertyMap map = new PropertyMap();
            map.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image))
                .Add(ImageVisualProperty.URL, new PropertyValue(url))
                .Add(ImageVisualProperty.LoopCount, new PropertyValue(2))
                .Add(ImageVisualProperty.PlayRange, new PropertyValue(50));
            testingTarget.Image = map;

            string maker = "startframe: 1; endframe: 10";
            testingTarget.SetMinMaxFrameByMarker(maker, null);

            try
            {
                testingTarget.GetMinMaxFrame();    
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LottieAnimationViewGetMinMaxFrame END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieAnimationView Finished.")]
        [Property("SPEC", "Tizen.NUI.LottieAnimationView.Finished M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieAnimationViewFinished()
        {
            tlog.Debug(tag, $"LottieAnimationViewFinished START");

            var testingTarget = new LottieAnimationView();
            Assert.IsNotNull(testingTarget, "Can't create success object LottieAnimationView");
            Assert.IsInstanceOf<LottieAnimationView>(testingTarget, "Should be an instance of LottieAnimationView type.");

            testingTarget.URL = lottieFilePath;
            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(testingTarget);

            testingTarget.Finished += OnFinishedEvent;
            testingTarget.Finished -= OnFinishedEvent;

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"LottieAnimationViewFinished END (OK)");
        }

        public void OnFinishedEvent(object sender, EventArgs e)
        { 
            // not implemented
        }
    }
}
