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
    [Description("public/Transition/ScaleTransition")]
    public class PublicScaleTransitionTest
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
        [Description("ScaleTransition constructor.")]
        [Property("SPEC", "Tizen.NUI.ScaleTransition.ScaleTransition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScaleTransitionConstructor()
        {
            tlog.Debug(tag, $"ScaleTransitionConstructor START");

            var testingTarget = new ScaleTransition();
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<ScaleTransition>(testingTarget, "Should be an instance of ScaleTransition type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScaleTransitionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScaleTransition ScaleFactor.")]
        [Property("SPEC", "Tizen.NUI.ScaleTransition.ScaleFactor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScaleTransitionScaleFactor()
        {
            tlog.Debug(tag, $"ScaleTransitionScaleFactor START");

            var testingTarget = new ScaleTransition();
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<ScaleTransition>(testingTarget, "Should be an instance of ScaleTransition type.");

            using (Vector2 sf = new Vector2(100.0f, 200.0f))
            {
                testingTarget.ScaleFactor = sf;
                tlog.Debug(tag, "Opacity : " + testingTarget.ScaleFactor);
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScaleTransitionScaleFactor END (OK)");
        }
    }
}
