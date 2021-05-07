using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Animation/TransitionOptions")]
    public class PublicTransitionOptionsTest
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
        [Description("TransitionOptions constructor")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.TransitionOptions C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsConstructor()
        {
            tlog.Debug(tag, $"TransitionOptionsConstructor START");

            var testingTarget = new TransitionOptions();
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions constructor. With window instance")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.TransitionOptions C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsConstructorWithWindowInstance()
        {
            tlog.Debug(tag, $"TransitionOptionsConstructorWithWindowInstance START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsConstructorWithWindowInstance END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions AnimatedTarget. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.TransitionOptions A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsAnimatedTargetGet()
        {
            tlog.Debug(tag, $"TransitionOptionsAnimatedTargetGet START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            View view = new View()
            {
                Size = new Size(30, 50)
            };
            testingTarget.AnimatedTarget = view;

            var result = testingTarget.AnimatedTarget;
            Assert.AreEqual(30, result.SizeWidth, "should be eaqual!");
            Assert.AreEqual(50, result.SizeHeight, "should be eaqual!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsAnimatedTargetGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions AnimatedTarget. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.TransitionOptions A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsAnimatedTargetSet()
        {
            tlog.Debug(tag, $"TransitionOptionsAnimatedTargetSet START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            View view = new View()
            {
                Size = new Size(30, 50)
            };
            testingTarget.AnimatedTarget = view;

            var result = testingTarget.AnimatedTarget;
            Assert.AreEqual(30, result.SizeWidth, "should be eaqual!");
            Assert.AreEqual(50, result.SizeHeight, "should be eaqual!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsAnimatedTargetSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions EnableTransition. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.EnableTransition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsEnableTransitionGet()
        {
            tlog.Debug(tag, $"TransitionOptionsEnableTransitionGet START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            var result = testingTarget.EnableTransition;
            Assert.IsFalse(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsEnableTransitionGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions EnableTransition. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.EnableTransition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsEnableTransitionSet()
        {
            tlog.Debug(tag, $"TransitionOptionsEnableTransitionSet START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            testingTarget.EnableTransition = true;
            Assert.IsTrue(testingTarget.EnableTransition);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsEnableTransitionSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions TransitionTag. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.TransitionTag A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsTransitionTagGet()
        {
            tlog.Debug(tag, $"TransitionOptionsTransitionTagGet START");

            View view = new View()
            {
                Size = new Size(50, 80),
                TransitionOptions = new TransitionOptions()
            };
            view.TransitionOptions.TransitionTag = "default";
            var result = view.TransitionOptions.TransitionTag;
            Assert.AreEqual("default", result, "should be eaqual!");

            view.Dispose();
            tlog.Debug(tag, $"TransitionOptionsTransitionTagGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions TransitionTag. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.TransitionTag A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsTransitionTagSet()
        {
            tlog.Debug(tag, $"TransitionOptionsTransitionTagSet START");

            View view = new View()
            {
                Size = new Size(50, 80),
                TransitionOptions = new TransitionOptions()
            };
            view.TransitionOptions.TransitionTag = "default";
            var result = view.TransitionOptions.TransitionTag;
            Assert.AreEqual("default", result, "should be eaqual!");

            view.Dispose();
            tlog.Debug(tag, $"TransitionOptionsTransitionTagSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions TransitionWithChild. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.TransitionWithChild A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsTransitionWithChildGet()
        {
            tlog.Debug(tag, $"TransitionOptionsTransitionWithChildGet START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            var result = testingTarget.TransitionWithChild;
            Assert.IsFalse(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsTransitionWithChildGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions TransitionWithChild. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.TransitionWithChild A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsTransitionWithChildSet()
        {
            tlog.Debug(tag, $"TransitionOptionsTransitionWithChildSet START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            var result = testingTarget.TransitionWithChild;
            Assert.IsFalse(result);

            testingTarget.TransitionWithChild = true;
            result = testingTarget.TransitionWithChild;
            Assert.IsTrue(result);

            tlog.Debug(tag, $"TransitionOptionsTransitionWithChildSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions ForwardAnimation. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.ForwardAnimation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsForwardAnimationGet()
        {
            tlog.Debug(tag, $"TransitionOptionsForwardAnimationGet START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            View view = new View()
            { 
                Size = new Size(150, 300),
                Color = Color.Green
            };
            testingTarget.AnimatedTarget = view;
            testingTarget.EnableTransition = true;

            TransitionAnimation forwordAnimation = new TransitionAnimation(300);
            testingTarget.ForwardAnimation = forwordAnimation;

            var result = testingTarget.ForwardAnimation;    
            Assert.AreEqual(300 == result.DurationMilliSeconds, "should be eaqual!");

            view.Dispose();
            forwordAnimation.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsForwardAnimationGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions ForwardAnimation. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.ForwardAnimation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsForwardAnimationSet()
        {
            tlog.Debug(tag, $"TransitionOptionsForwardAnimationSet START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            View view = new View()
            {
                Size = new Size(150, 300),
                Color = Color.Green
            };
            testingTarget.AnimatedTarget = view;
            testingTarget.EnableTransition = true;

            TransitionAnimation forwordAnimation = new TransitionAnimation(300);
            testingTarget.ForwardAnimation = forwordAnimation;

            var result = testingTarget.ForwardAnimation;
            Assert.AreEqual(300 == result.DurationMilliSeconds, "should be eaqual!");

            view.Dispose();
            forwordAnimation.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsForwardAnimationSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions BackwardAnimation. Get")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.BackwardAnimation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsBackwardAnimationGet()
        {
            tlog.Debug(tag, $"TransitionOptionsBackwardAnimationGet START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            View view = new View()
            {
                Size = new Size(150, 300),
                Color = Color.Green
            };
            testingTarget.AnimatedTarget = view;
            testingTarget.EnableTransition = true;

            TransitionAnimation backwordAnimation = new TransitionAnimation(300);
            testingTarget.BackwardAnimation = backwordAnimation;

            var result = testingTarget.BackwardAnimation;
            Assert.AreEqual(300 == result.DurationMilliSeconds, "should be eaqual!");

            view.Dispose();
            backwordAnimation.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsBackwardAnimationGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions BackwardAnimation. Set")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.BackwardAnimation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsBackwardAnimationSet()
        {
            tlog.Debug(tag, $"TransitionOptionsBackwardAnimationSet START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

            View view = new View()
            {
                Size = new Size(150, 300),
                Color = Color.Green
            };
            testingTarget.AnimatedTarget = view;
            testingTarget.EnableTransition = true;

            TransitionAnimation backwordAnimation = new TransitionAnimation(300);
            testingTarget.BackwardAnimation = backwordAnimation;

            var result = testingTarget.BackwardAnimation;
            Assert.AreEqual(300 == result.DurationMilliSeconds, "should be eaqual!");

            view.Dispose();
            backwordAnimation.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionOptionsBackwardAnimationSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionOptions Dispose")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsDispose()
        {
            tlog.Debug(tag, $"TransitionOptionsDispose START");

            var testingTarget = new TransitionOptions(Window.Instance);
            Assert.IsNotNull(testingTarget, "should not be null.");
            Assert.IsInstanceOf<TransitionOptions>(testingTarget, "should be an instance of TransitionOptions class!");

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

            tlog.Debug(tag, $"TransitionOptionsDispose END (OK)");
        }
    }
}
