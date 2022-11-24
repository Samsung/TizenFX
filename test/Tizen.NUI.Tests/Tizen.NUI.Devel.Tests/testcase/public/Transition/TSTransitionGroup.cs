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
    [Description("public/Transition/TransitionGroup")]
    public class PublicTransitionGroupTest
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
        [Description("TransitionGroup constructor.")]
        [Property("SPEC", "Tizen.NUI.TransitionGroup.TransitionGroup C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionGroupConstructor()
        {
            tlog.Debug(tag, $"TransitionGroupConstructor START");

            var testingTarget = new TransitionGroup();
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<TransitionGroup>(testingTarget, "Should be an instance of TransitionGroup type.");

            testingTarget.UseGroupTimePeriod = true;
            tlog.Debug(tag, "UseGroupTimePeriod : " + testingTarget.UseGroupTimePeriod);

            testingTarget.StepTransition = true;
            tlog.Debug(tag, "StepTransition : " + testingTarget.StepTransition);

            testingTarget.UseGroupAlphaFunction = true;
            tlog.Debug(tag, "UseGroupAlphaFunction : " + testingTarget.UseGroupAlphaFunction);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionGroupConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionGroup AddTransition.")]
        [Property("SPEC", "Tizen.NUI.TransitionGroup.AddTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionGroupAddTransition()
        {
            tlog.Debug(tag, $"TransitionGroupAddTransition START");

            var testingTarget = new TransitionGroup();
            Assert.IsNotNull(testingTarget, "Return a null object of FontClient");
            Assert.IsInstanceOf<TransitionGroup>(testingTarget, "Should be an instance of TransitionGroup type.");

            try
            {
                using (TransitionBase tb = new TransitionBase())
                {
                    tb.TimePeriod = new TimePeriod(300);
                    tb.AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce);
                    
                    testingTarget.AddTransition(tb);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionGroupAddTransition END (OK)");
        }
        [Test]
        [Category("P1")]
        [Description("TransitionGroup CreateTransition.")]
        [Property("SPEC", "Tizen.NUI.TransitionGroup.CreateTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionGroupCreateTransition()
        {
            tlog.Debug(tag, $"TransitionGroupCreateTransition START");

            var testingTarget = new TransitionGroup();
            Assert.IsNotNull(testingTarget, "Can't create success object TransitionGroup");
            Assert.IsInstanceOf<TransitionGroup>(testingTarget, "Should be an instance of TransitionGroup type.");

            using (TransitionBase tb = new TransitionBase())
            {
                tb.TimePeriod = new TimePeriod(300);
                tb.AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce);
                testingTarget.AddTransition(tb);

                using (View view = new View())
                {
                    TimePeriod timePeriod = new TimePeriod(0);
                    AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default);

                    var result = testingTarget.CreateTransition(view, true, timePeriod, alphaFunction);
                    Assert.IsNotNull(result, "Can't create success object TransitionItemBase");
                    Assert.IsInstanceOf<TransitionItemBase>(result, "Should be an instance of TransitionItemBase type.");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionGroupCreateTransition END (OK)");
        }
    }
}
