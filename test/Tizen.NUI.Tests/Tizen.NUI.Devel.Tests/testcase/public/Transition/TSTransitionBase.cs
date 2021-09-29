using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Transition/TransitionBase.cs")]
    public class PublicTransitionBaseTest
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
        [Description("TransitionBase constructor.")]
        [Property("SPEC", "Tizen.NUI.TransitionBase.TransitionBase C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionBaseConstructor()
        {
            tlog.Debug(tag, $"TransitionBaseConstructor START");

            var testingTarget = new TransitionBase();
            Assert.IsNotNull(testingTarget, "Can't create success object TransitionBase");
            Assert.IsInstanceOf<TransitionBase>(testingTarget, "Should be an instance of TransitionBase type.");

            tlog.Debug(tag, $"TransitionBaseConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionBase AlphaFunction.")]
        [Property("SPEC", "Tizen.NUI.TransitionBase.AlphaFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionBaseAlphaFunction()
        {
            tlog.Debug(tag, $"TransitionBaseAlphaFunction START");

            var testingTarget = new TransitionBase()
            {
                TimePeriod = new TimePeriod(300),
                AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce),
            };
            Assert.IsNotNull(testingTarget, "Can't create success object TransitionBase");
            Assert.IsInstanceOf<TransitionBase>(testingTarget, "Should be an instance of TransitionBase type.");

            testingTarget.AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseIn);
            Assert.IsInstanceOf<AlphaFunction>(testingTarget.AlphaFunction, "Should be an instance of TimePeriod type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionBaseAlphaFunction END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionBase TimePeriod.")]
        [Property("SPEC", "Tizen.NUI.TransitionBase.TimePeriod A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionBaseTimePeriod()
        {
            tlog.Debug(tag, $"TransitionBaseTimePeriod START");

            var testingTarget = new TransitionBase()
            {
                TimePeriod = new TimePeriod(300),
                AlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Bounce),
            };
            Assert.IsNotNull(testingTarget, "Can't create success object TransitionBase");
            Assert.IsInstanceOf<TransitionBase>(testingTarget, "Should be an instance of TransitionBase type.");

            testingTarget.TimePeriod = new TimePeriod(500);
            Assert.IsInstanceOf<TimePeriod>(testingTarget.TimePeriod, "Should be an instance of TimePeriod type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionBaseTimePeriod END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionBase CreateTransition.")]
        [Property("SPEC", "Tizen.NUI.TransitionBase.CreateTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionBaseCreateTransition()
        {
            tlog.Debug(tag, $"TransitionBaseCreateTransition START");

            var testingTarget = new TransitionBase();
            Assert.IsNotNull(testingTarget, "Can't create success object TransitionBase");
            Assert.IsInstanceOf<TransitionBase>(testingTarget, "Should be an instance of TransitionBase type.");

            using (View view = new View())
            {
                var result = testingTarget.CreateTransition(view, true);
                Assert.IsNotNull(result, "Can't create success object TransitionItemBase");
                Assert.IsInstanceOf<TransitionItemBase>(result, "Should be an instance of TransitionItemBase type.");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionBaseCreateTransition END (OK)");
        }
    }
}
