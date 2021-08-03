using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/VisualAnimator")]
    public class PublicVisualAnimatorTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static bool flagComposingPropertyMap;
        internal class MyVisualAnimator : VisualAnimator
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
        [Description("VisualAnimator constructor.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.VisualAnimator C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualAnimatorConstructor()
        {
            tlog.Debug(tag, $"VisualAnimatorConstructor START");

            var testingTarget = new VisualAnimator();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualAnimator");
            Assert.IsInstanceOf<VisualAnimator>(testingTarget, "Should be an instance of VisualAnimator type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualAnimatorConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualAnimator AlphaFunction.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.AlphaFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualAnimatorAlphaFunction()
        {
            tlog.Debug(tag, $"VisualAnimatorAlphaFunction START");

            var testingTarget = new VisualAnimator();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualAnimator");
            Assert.IsInstanceOf<VisualAnimator>(testingTarget, "Should be an instance of VisualAnimator type.");

            testingTarget.AlphaFunction = AlphaFunction.BuiltinFunctions.EaseIn;
            Assert.AreEqual(AlphaFunction.BuiltinFunctions.EaseIn, testingTarget.AlphaFunction, "Retrieved AlphaFunction should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualAnimatorAlphaFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualAnimator StartTime.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.StartTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualAnimatorStartTime()
        {
            tlog.Debug(tag, $"VisualAnimatorStartTime START");

            var testingTarget = new VisualAnimator();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualAnimator");
            Assert.IsInstanceOf<VisualAnimator>(testingTarget, "Should be an instance of VisualAnimator type.");

            testingTarget.StartTime = 10;
            Assert.AreEqual(10, testingTarget.StartTime, "Retrieved StartTime should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualAnimatorStartTime END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualAnimator EndTime.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.EndTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualAnimatorEndTime()
        {
            tlog.Debug(tag, $"VisualAnimatorEndTime START");

            var testingTarget = new VisualAnimator();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualAnimator");
            Assert.IsInstanceOf<VisualAnimator>(testingTarget, "Should be an instance of VisualAnimator type.");

            testingTarget.EndTime = 1000;
            Assert.AreEqual(1000, testingTarget.EndTime, "Retrieved EndTime should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualAnimatorEndTime END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualAnimator Target.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.Target A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualAnimatorTarget()
        {
            tlog.Debug(tag, $"VisualAnimatorTarget START");

            var testingTarget = new VisualAnimator();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualAnimator");
            Assert.IsInstanceOf<VisualAnimator>(testingTarget, "Should be an instance of VisualAnimator type.");

            testingTarget.Target = "IconVisual";
            Assert.AreEqual("IconVisual", testingTarget.Target, "Retrieved Target should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualAnimatorTarget END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualAnimator PropertyIndex.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.PropertyIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualAnimatorPropertyIndex()
        {
            tlog.Debug(tag, $"VisualAnimatorPropertyIndex START");

            var testingTarget = new VisualAnimator();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualAnimator");
            Assert.IsInstanceOf<VisualAnimator>(testingTarget, "Should be an instance of VisualAnimator type.");

            testingTarget.PropertyIndex = "MixColor";
            Assert.AreEqual("MixColor", testingTarget.PropertyIndex, "Retrieved PropertyIndex should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualAnimatorPropertyIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualAnimator DestinationValue.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.DestinationValue A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualAnimatorDestinationValue()
        {
            tlog.Debug(tag, $"VisualAnimatorDestinationValue START");

            var testingTarget = new VisualAnimator();
            Assert.IsNotNull(testingTarget, "Can't create success object VisualAnimator");
            Assert.IsInstanceOf<VisualAnimator>(testingTarget, "Should be an instance of VisualAnimator type.");

            using (Color color = new Color(1.0f, 0.0f, 1.0f, 1.0f))
            {
                testingTarget.DestinationValue = color;
                Assert.IsTrue(color.Equals(testingTarget.DestinationValue), "Retrieved DestinationValue should be equal to set value");
            }
                
            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualAnimatorDestinationValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VisualAnimator ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.VisualAnimator.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VisualAnimatorComposingPropertyMap()
        {
            tlog.Debug(tag, $"VisualAnimatorComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyVisualAnimator()
            {
                AlphaFunction = AlphaFunction.BuiltinFunctions.EaseIn,
                StartTime = 10,
                EndTime = 200,
                Target = "IconVisual",
                PropertyIndex = "MixColor",
                DestinationValue = 0.3f
            };
            Assert.IsInstanceOf<VisualAnimator>(testingTarget, "Should be an instance of VisualAnimator type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VisualAnimatorComposingPropertyMap END (OK)");
        }
    }
}
