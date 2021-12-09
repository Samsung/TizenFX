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
    [Description("public/Transition/SlideTransition")]
    public class PublicSlideTransitionTest
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
        [Description("SlideTransition constructor.")]
        [Property("SPEC", "Tizen.NUI.SlideTransition.SlideTransition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SlideTransitionConstructor()
        {
            tlog.Debug(tag, $"SlideTransitionConstructor START");

            var testingTarget = new SlideTransition();
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<SlideTransition>(testingTarget, "Should be an instance of SlideTransition type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SlideTransitionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SlideTransition Direction.")]
        [Property("SPEC", "Tizen.NUI.SlideTransition.Direction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SlideTransitionDirection()
        {
            tlog.Debug(tag, $"SlideTransitionDirection START");

            var testingTarget = new SlideTransition();
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<SlideTransition>(testingTarget, "Should be an instance of SlideTransition type.");

            using (Vector2 dir = new Vector2(100.0f, 200.0f))
            {
                testingTarget.Direction = dir;
                tlog.Debug(tag, "Opacity : " + testingTarget.Direction);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"SlideTransitionDirection END (OK)");
        }
    }
}
