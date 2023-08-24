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
    [Description("public/Transition/FadeTransition")]
    public class PublicFadeTransitionTest
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
        [Description("FadeTransition constructor.")]
        [Property("SPEC", "Tizen.NUI.FadeTransition.FadeTransition C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FadeTransitionConstructor()
        {
            tlog.Debug(tag, $"FadeTransitionConstructor START");

            var testingTarget = new FadeTransition();
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<FadeTransition>(testingTarget, "Should be an instance of FadeTransition type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FadeTransitionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FadeTransition Opacity.")]
        [Property("SPEC", "Tizen.NUI.FadeTransition.Opacity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FadeTransitionOpacity()
        {
            tlog.Debug(tag, $"FadeTransitionOpacity START");

            var testingTarget = new FadeTransition();
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<FadeTransition>(testingTarget, "Should be an instance of FadeTransition type.");

            testingTarget.Opacity = 0.3f;
            tlog.Debug(tag, "Opacity : " + testingTarget.Opacity);

            testingTarget.Dispose();
            tlog.Debug(tag, $"FadeTransitionOpacity END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("FadeTransition CreateTransition.")]
        [Property("SPEC", "Tizen.NUI.FadeTransition.CreateTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FadeTransitionCreateTransition()
        {
            tlog.Debug(tag, $"FadeTransitionCreateTransition START");

            var testingTarget = new FadeTransition();
            Assert.IsNotNull(testingTarget, "Can't create success object FadeTransition");
            Assert.IsInstanceOf<FadeTransition>(testingTarget, "Should be an instance of FadeTransition type.");

            using (View view = new View())
            {
                TimePeriod timePeriod = new TimePeriod(0);
                AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default);
				
                var result = testingTarget.CreateTransition(view, true,timePeriod,alphaFunction);
                Assert.IsNotNull(result, "Can't create success object TransitionItemBase");
                Assert.IsInstanceOf<TransitionItemBase>(result, "Should be an instance of TransitionItemBase type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FadeTransitionCreateTransition END (OK)");
        }
    }
}
