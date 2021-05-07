using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Animation/TransitionData")]
    class PublicTransitionDataTest
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
        [Description("TransitionData constructor. With PropertyMap")]
        [Property("SPEC", "Tizen.NUI.TransitionData.TransitionData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionDataConstructorWithPropertyMap()
        {
            tlog.Debug(tag, $"TransitionDataConstructorWithPropertyMap START");

            var strAlpha = AlphaFunction.BuiltinFunctions.Default.GetDescription();
            var animator = new PropertyMap();
            using (PropertyValue myAlpha = new PropertyValue(strAlpha))
            {
                animator.Add("alphaFunction", myAlpha);
            }
            var transition = new PropertyMap();
            using (PropertyValue myAnimator = new PropertyValue(animator))
            {
                transition.Add("animator", myAnimator);
            }

            var testingTarget = new TransitionData(transition);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionData>(testingTarget, "should be an instance of TransitionData class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionDataConstructorWithPropertyMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionData constructor. With PropertyArray")]
        [Property("SPEC", "Tizen.NUI.TransitionData.TransitionData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionDataConstructorWithPropertyArray()
        {
            tlog.Debug(tag, $"TransitionDataConstructorWithPropertyArray START");

            var strAlpha = AlphaFunction.BuiltinFunctions.Default.GetDescription();
            var animator = new PropertyMap();
            using (PropertyValue myAlpha = new PropertyValue(strAlpha))
            {
                animator.Add("alphaFunction", myAlpha);
            }
            var transition = new PropertyMap();
            using (PropertyValue myAnimator = new PropertyValue(animator))
            {
                transition.Add("animator", myAnimator);
            }
            var animateArray = new PropertyArray();
            using (PropertyValue pvTransition = new PropertyValue(transition))
            {
                animateArray.Add(pvTransition);            
            }
            
            var testingTarget = new TransitionData(animateArray);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionData>(testingTarget, "should be an instance of TransitionData class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionDataConstructorWithPropertyArray END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionData constructor. By copy constructor")]
        [Property("SPEC", "Tizen.NUI.TransitionData.TransitionData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionDataConstructorByCopyConstructor()
        {
            tlog.Debug(tag, $"TransitionDataConstructorByCopyConstructor START");

            var strAlpha = AlphaFunction.BuiltinFunctions.Default.GetDescription();
            var animator = new PropertyMap();
            using (PropertyValue myAlpha = new PropertyValue(strAlpha))
            {
                animator.Add("alphaFunction", myAlpha);
            }
            var transition = new PropertyMap();
            using (PropertyValue myAnimator = new PropertyValue(animator))
            {
                transition.Add("animator", myAnimator);
            }
            var animateArray = new PropertyArray();
            using (PropertyValue pvTransition = new PropertyValue(transition))
            {
                animateArray.Add(pvTransition);
            }

            var dummy = new TransitionData(animateArray);
            Assert.IsNotNull(dummy, "should be not null");
            Assert.IsInstanceOf<TransitionData>(dummy, "should be an instance of TransitionData class!");

            var testingTarget = new TransitionData(dummy);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionData>(testingTarget, "should be an instance of TransitionData class!");

            dummy.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionDataConstructorByCopyConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionData Count")]
        [Property("SPEC", "Tizen.NUI.TransitionData.Count M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionDataCount()
        {
            tlog.Debug(tag, $"TransitionDataCount START");

            var strAlpha = AlphaFunction.BuiltinFunctions.Default.GetDescription();
            var animator = new PropertyMap();
            using (PropertyValue myAlpha = new PropertyValue(strAlpha))
            {
                animator.Add("alphaFunction", myAlpha);
            }
            var transition = new PropertyMap();
            using (PropertyValue myAnimator = new PropertyValue(animator))
            {
                transition.Add("animator", myAnimator);
            }
            var animateArray = new PropertyArray();
            using (PropertyValue pvTransition = new PropertyValue(transition))
            {
                animateArray.Add(pvTransition);
            }

            var testingTarget = new TransitionData(animateArray);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionData>(testingTarget, "should be an instance of TransitionData class!");

            var result = testingTarget.Count();
            Assert.AreEqual(1, result, "should be eaqual!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionDataCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionData GetAnimatorAt")]
        [Property("SPEC", "Tizen.NUI.TransitionData.GetAnimatorAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionDataGetAnimatorAt()
        {
            tlog.Debug(tag, $"TransitionDataGetAnimatorAt START");

            var strAlpha = AlphaFunction.BuiltinFunctions.Default.GetDescription();
            var animator = new PropertyMap();
            using (PropertyValue myAlpha = new PropertyValue(strAlpha))
            {
                animator.Add("alphaFunction", myAlpha);
            }
            var transition = new PropertyMap();
            using (PropertyValue myAnimator = new PropertyValue(animator))
            {
                transition.Add("animator", myAnimator);
            }
            var animateArray = new PropertyArray();
            using (PropertyValue pvTransition = new PropertyValue(transition))
            {
                animateArray.Add(pvTransition);
            }

            var testingTarget = new TransitionData(animateArray);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TransitionData>(testingTarget, "should be an instance of TransitionData class!");

            var result = testingTarget.GetAnimatorAt(0);
            Assert.AreEqual(3, result.Count(), "should be eaqual!");
            
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionDataGetAnimatorAt END (OK)");
        }
    }
}
