using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Animation/TransitionAnimations")]
    public class PublicTransitionAnimationsTest
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
        [Description("TransitionAnimations constructor")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.TransitionAnimations C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationConstructor()
        {
            tlog.Debug(tag, $"TransitionAnimationConstructor START");

            var testingTarget = new TransitionAnimation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionAnimation>(testingTarget, "should be an instance of TransitionAnimation class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations DurationMilliSeconds. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.DurationMilliSeconds A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDurationMilliSecondsGet()
        {
            tlog.Debug(tag, $"TransitionAnimationDurationMilliSecondsGet START");

            var testingTarget = new TransitionAnimation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionAnimation>(testingTarget, "should be an instance of TransitionAnimation class!");

            var result = testingTarget.DurationMilliSeconds;
            Assert.IsTrue(3000 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationDurationMilliSecondsGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations DurationMilliSeconds. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.DurationMilliSeconds A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDurationMilliSecondsSet()
        {
            tlog.Debug(tag, $"TransitionAnimationDurationMilliSecondsSet START");

            var testingTarget = new TransitionAnimation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionAnimation>(testingTarget, "should be an instance of TransitionAnimation class!");

            testingTarget.DurationMilliSeconds = 600;
            var result = testingTarget.DurationMilliSeconds;
            Assert.IsTrue(600 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationDurationMilliSecondsSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations AnimationDataList")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.AnimationDataList A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationAnimationDataList()
        {
            tlog.Debug(tag, $"TransitionAnimationAnimationDataList START");

            var testingTarget = new TransitionAnimation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionAnimation>(testingTarget, "should be an instance of TransitionAnimation class!");

            var result = testingTarget.AnimationDataList;
            Assert.IsTrue(0 == result.Count);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationAnimationDataList END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations AddAnimationData")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.AddAnimationData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationAddAnimationData()
        {
            tlog.Debug(tag, $"TransitionAnimationAddAnimationData START");

            var testingTarget = new TransitionAnimation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionAnimation>(testingTarget, "should be an instance of TransitionAnimation class!");

            var dummy = new TransitionAnimationData()
            {
                Property = "Size",
                DestinationValue = "100, 100",
                StartTime = 300,
                EndTime = 600
            };
            testingTarget.AddAnimationData(dummy);

            var result = testingTarget.AnimationDataList;
            Assert.IsTrue(1 == result.Count);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationAddAnimationData END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations RemoveAnimationData")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.RemoveAnimationData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationRemoveAnimationData()
        {
            tlog.Debug(tag, $"TransitionAnimationRemoveAnimationData START");

            var testingTarget = new TransitionAnimation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionAnimation>(testingTarget, "should be an instance of TransitionAnimation class!");

            var dummy = new TransitionAnimationData()
            {
                Property = "Size",
                DestinationValue = "100, 100",
                StartTime = 300,
                EndTime = 600
            };
            testingTarget.AddAnimationData(dummy);

            var result = testingTarget.AnimationDataList.Count;
            Assert.IsTrue(1 == result);

            testingTarget.RemoveAnimationData(dummy);
            result = testingTarget.AnimationDataList.Count;
            Assert.IsTrue(0 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationRemoveAnimationData END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations ClearAnimationData")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.ClearAnimationData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationClearAnimationData()
        {
            tlog.Debug(tag, $"TransitionAnimationClearAnimationData START");

            var testingTarget = new TransitionAnimation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionAnimation>(testingTarget, "should be an instance of TransitionAnimation class!");

            var dummy = new TransitionAnimationData()
            {
                Property = "Size",
                DestinationValue = "100, 100",
                StartTime = 300,
                EndTime = 600
            };
            testingTarget.AddAnimationData(dummy);

            var result = testingTarget.AnimationDataList.Count;
            Assert.IsTrue(1 == result);

            testingTarget.ClearAnimationData();
            result = testingTarget.AnimationDataList.Count;
            Assert.IsTrue(0 == result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationClearAnimationData END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations DefaultImageStyle. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.DefaultImageStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDefaultImageStyleGet()
        {
            tlog.Debug(tag, $"TransitionAnimationDefaultImageStyleGet START");

            var testingTarget = new TransitionAnimation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionAnimation>(testingTarget, "should be an instance of TransitionAnimation class!");

            var result = testingTarget.DefaultImageStyle;
            Assert.IsNotNull(result, "should be not null");
            Assert.IsInstanceOf<ImageViewStyle>(result, "should be an instance of ImageViewStyle class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationDefaultImageStyleGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations DefaultImageStyle. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.DefaultImageStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDefaultImageStyleSet()
        {
            tlog.Debug(tag, $"TransitionAnimationDefaultImageStyleSet START");

            var testingTarget = new TransitionAnimation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionAnimation>(testingTarget, "should be an instance of TransitionAnimation class!");

            var style = new ImageViewStyle()
            {
                Size = new Size(100, 100),
                Position = new Position(150, 200),
            };
            testingTarget.DefaultImageStyle = style;
            var result = testingTarget.DefaultImageStyle;
            Assert.IsTrue(100 == result.Size.Width);
            Assert.IsTrue(100 == result.Size.Height);
            Assert.IsTrue(150 == result.Position.X);
            Assert.IsTrue(200 == result.Position.Y);

            style.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationDefaultImageStyleSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations Dispose. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.Dispose A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDispose()
        {
            tlog.Debug(tag, $"TransitionAnimationDispose START");

            var testingTarget = new TransitionAnimation(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionAnimation>(testingTarget, "should be an instance of TransitionAnimation class!");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            
            tlog.Debug(tag, $"TransitionAnimationDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations SlideIn constructor")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.SlideIn C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationSlideIn()
        {
            tlog.Debug(tag, $"TransitionAnimationSlideIn START");

            var testingTarget = new SlideIn(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<SlideIn>(testingTarget, "should be an instance of SlideIn class!");

            var style = testingTarget.DefaultImageStyle;
            var dummy = -Window.Instance.GetWindowSize().Width;
           
            Assert.IsTrue(Window.Instance.GetWindowSize().Width == style.Size.Width);
            Assert.IsTrue(Window.Instance.GetWindowSize().Height == style.Size.Height);
            Assert.IsTrue(dummy == style.Position.X);
            Assert.IsTrue(0 == style.Position.Y);

            Assert.IsTrue(0 == testingTarget.AnimationDataList[0].StartTime);
            Assert.IsTrue(3000 == testingTarget.AnimationDataList[0].EndTime);
            Assert.IsTrue("PositionX" == testingTarget.AnimationDataList[0].Property);
            Assert.IsTrue("0" == testingTarget.AnimationDataList[0].DestinationValue);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationSlideIn END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimations SlideOut constructor")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.SlideOut C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationSlideOut()
        {
            tlog.Debug(tag, $"TransitionAnimationSlideOut START");

            var testingTarget = new SlideOut(3000);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<SlideOut>(testingTarget, "should be an instance of SlideOut class!");

            var style = testingTarget.DefaultImageStyle;

            Assert.IsTrue(Window.Instance.GetWindowSize().Width == style.Size.Width);
            Assert.IsTrue(Window.Instance.GetWindowSize().Height == style.Size.Height);

            Assert.IsTrue(0 == testingTarget.AnimationDataList[0].StartTime);
            Assert.IsTrue(3000 == testingTarget.AnimationDataList[0].EndTime);
            Assert.IsTrue("PositionX" == testingTarget.AnimationDataList[0].Property);
            Assert.IsTrue(Window.Instance.GetWindowSize().Width.ToString() == testingTarget.AnimationDataList[0].DestinationValue);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionAnimationSlideOut END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimationData StartTime. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.TransitionAnimationData.StartTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDataStartTimeGet()
        {
            tlog.Debug(tag, $"TransitionAnimationDataStartTimeGet START");

            var testingTarget = new TransitionAnimationData()
            {
                StartTime = 300,
                EndTime = 600,
                Property = "Size",
                DestinationValue = "100, 100",
            };
            var result = testingTarget.StartTime;
            Assert.AreEqual(300, result, "should be eaqual!");

            tlog.Debug(tag, $"TransitionAnimationDataStartTimeGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimationData StartTime. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.TransitionAnimationData.StartTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDataStartTimeSet()
        {
            tlog.Debug(tag, $"TransitionAnimationDataStartTimeSet START");

            var testingTarget = new TransitionAnimationData()
            {
                StartTime = 300,
                EndTime = 600,
                Property = "Size",
                DestinationValue = "100, 100",
            };

            var result = testingTarget.StartTime;
            Assert.AreEqual(300, result, "should be eaqual!");

            testingTarget.StartTime = 600;
            result = testingTarget.StartTime;
            Assert.AreEqual(600, result, "should be eaqual!");

            tlog.Debug(tag, $"TransitionAnimationDataStartTimeSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimationData EndTime. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.TransitionAnimationData.EndTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDataEndTimeGet()
        {
            tlog.Debug(tag, $"TransitionAnimationDataEndTimeGet START");

            var testingTarget = new TransitionAnimationData()
            {
                StartTime = 300,
                EndTime = 600,
                Property = "Size",
                DestinationValue = "100, 100",
            };

            var result = testingTarget.EndTime;
            Assert.AreEqual(600, result, "should be eaqual!");

            tlog.Debug(tag, $"TransitionAnimationDataEndTimeGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimationData EndTime. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.TransitionAnimationData.EndTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDataEndTimeSet()
        {
            tlog.Debug(tag, $"TransitionAnimationDataEndTimeSet START");

            var testingTarget = new TransitionAnimationData()
            {
                StartTime = 300,
                EndTime = 600,
                Property = "Size",
                DestinationValue = "100, 100",
            };

            var result = testingTarget.EndTime;
            Assert.AreEqual(600, result, "should be eaqual!");

            testingTarget.EndTime = 900;
            result = testingTarget.EndTime;
            Assert.AreEqual(900, result, "should be eaqual!");

            tlog.Debug(tag, $"TransitionAnimationDataEndTimeSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimationData Property. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.TransitionAnimationData.Property A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDataPropertyGet()
        {
            tlog.Debug(tag, $"TransitionAnimationDataPropertyGet START");

            var testingTarget = new TransitionAnimationData()
            {
                StartTime = 300,
                EndTime = 600,
                Property = "Size",
                DestinationValue = "100, 100",
            };

            var result = testingTarget.Property;
            Assert.AreEqual("Size", result, "should be eaqual!");

            tlog.Debug(tag, $"TransitionAnimationDataPropertyGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimationData Property. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.TransitionAnimationData.Property A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDataPropertySet()
        {
            tlog.Debug(tag, $"TransitionAnimationDataPropertySet START");

            var testingTarget = new TransitionAnimationData()
            {
                StartTime = 300,
                EndTime = 600,
                Property = "Size",
                DestinationValue = "100, 100",
            };

            var result = testingTarget.Property;
            Assert.AreEqual("Size", result, "should be eaqual!");

            testingTarget.Property = "Position";
            result = testingTarget.Property;
            Assert.AreEqual("Position", result, "should be eaqual!");

            tlog.Debug(tag, $"TransitionAnimationDataPropertySet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimationData DestinationValue. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.TransitionAnimationData.DestinationValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDataDestinationValueGet()
        {
            tlog.Debug(tag, $"TransitionAnimationDataDestinationValueGet START");

            var testingTarget = new TransitionAnimationData()
            {
                StartTime = 300,
                EndTime = 600,
                Property = "Size",
                DestinationValue = "100, 100",
            };

            var result = testingTarget.DestinationValue;
            Assert.AreEqual("100, 100", result, "should be eaqual!");

            tlog.Debug(tag, $"TransitionAnimationDataDestinationValueGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionAnimationData DestinationValue. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionAnimations.TransitionAnimationData.DestinationValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionAnimationDataDestinationValueSet()
        {
            tlog.Debug(tag, $"TransitionAnimationDataDestinationValueSet START");

            var testingTarget = new TransitionAnimationData()
            {
                StartTime = 300,
                EndTime = 600,
                Property = "Size",
                DestinationValue = "100, 100",
            };

            var result = testingTarget.DestinationValue;
            Assert.AreEqual("100, 100", result, "should be eaqual!");

            testingTarget.Property = "Position";
            testingTarget.DestinationValue = "0.3f, 0.9f, 0.0f";
            result = testingTarget.DestinationValue;
            Assert.AreEqual("0.3f, 0.9f, 0.0f", result, "should be eaqual!");

            tlog.Debug(tag, $"TransitionAnimationDataDestinationValueSet END (OK)");
        }
    }
}
