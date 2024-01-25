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

            using (View source = new View() { Position = new Position(0, 0), Size = new Size(100, 50) })
            {
                using (View dest = new View() { Position = new Position(120, 50), Size = new Size(100, 50) })
                {
                    using (TimePeriod timePeriod = new TimePeriod(300))
                    {
                        using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                        {
                            var testingTarget = new TransitionItem(source, dest, true, timePeriod, alphaFunction);
                            Assert.IsNotNull(testingTarget, "Should be not null!");
                            Assert.IsInstanceOf<TransitionItem>(testingTarget, "Should be an Instance of TransitionItem!");

                            testingTarget.Dispose();
                        }
                    }
                }
            }
                
            tlog.Debug(tag, $"TransitionItemConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItem constructor.")]
        [Property("SPEC", "Tizen.NUI.TransitionItem.TransitionItem C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemConstructorWithTransitionItem()
        {
            tlog.Debug(tag, $"TransitionItemConstructorWithTransitionItem START");

            using (View view = new View())
            {
                using (TransitionItem item = new TransitionItem(view.SwigCPtr.Handle, false))
                {
                    var testingTarget = new TransitionItem(item);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<TransitionItem>(testingTarget, "Should be an Instance of TransitionItem!");

                    testingTarget.Dispose();
                    // disposed
                    testingTarget.Dispose();
                }

            }

            tlog.Debug(tag, $"TransitionItemConstructorWithTransitionItem END (OK)");
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
