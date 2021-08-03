using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Transition/TransitionItem")]
    public class InternalTransitionItemTest
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
        [Description("TransitionItem constructor.")]
        [Property("SPEC", "Tizen.NUI.TransitionItem.TransitionItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemConstructor()
        {
            tlog.Debug(tag, $"TransitionItemConstructor START");

            using (View view = new View())
            {
                var testingTarget = new TransitionItem(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionItem>(testingTarget, "Should be an Instance of TransitionItem!");

                testingTarget.Dispose();
            }
                
            tlog.Debug(tag, $"TransitionItemConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItem Assign.")]
        [Property("SPEC", "Tizen.NUI.TransitionItem.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemAssign()
        {
            tlog.Debug(tag, $"TransitionItemAssign START");

            using (View view = new View())
            {
                var testingTarget = new TransitionItem(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionItem>(testingTarget, "Should be an Instance of TransitionItem!");

                try
                {
                    testingTarget.Assign(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TransitionItemAssign END (OK)");
        }
    }
}
