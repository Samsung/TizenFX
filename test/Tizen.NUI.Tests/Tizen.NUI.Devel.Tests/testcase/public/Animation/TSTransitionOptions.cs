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
            Assert.AreEqual("default", result, "should be equal!");

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
            Assert.AreEqual("default", result, "should be equal!");

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

            var testingTarget = new TransitionOptions();
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

            var testingTarget = new TransitionOptions();
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
        [Description("TransitionOptions Dispose")]
        [Property("SPEC", "Tizen.NUI.TransitionOptions.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionOptionsDispose()
        {
            tlog.Debug(tag, $"TransitionOptionsDispose START");

            var testingTarget = new TransitionOptions();
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
