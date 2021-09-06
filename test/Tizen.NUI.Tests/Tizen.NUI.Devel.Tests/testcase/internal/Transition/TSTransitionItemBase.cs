using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Transition/TransitionItemBase")]
    public class InternalTransitionItemBaseTest
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
        [Description("TransitionItemBase constructor.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.TransitionItemBase C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseConstructor()
        {
            tlog.Debug(tag, $"TransitionItemBaseConstructor START");

            using (View view = new View())
            {
                var testingTarget = new TransitionItemBase(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionItemBase>(testingTarget, "Should be an Instance of TransitionItemBase!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TransitionItemBaseConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItemBase constructor.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.TransitionItemBase C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseConstructorWithTransitionItemBase()
        {
            tlog.Debug(tag, $"TransitionItemBaseConstructorWithTransitionItemBase START");

            using (View view = new View())
            {
                using (TransitionItemBase item = new TransitionItemBase(view.SwigCPtr.Handle, false))
                {
                    var testingTarget = new TransitionItemBase(item);
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<TransitionItemBase>(testingTarget, "Should be an Instance of TransitionItemBase!");

                    testingTarget.Dispose();
                    // disposed
                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"TransitionItemBaseConstructorWithTransitionItemBase END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItemBase TimePeriod.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.TimePeriod A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseTimePeriod()
        {
            tlog.Debug(tag, $"TransitionItemBaseTimePeriod START");

            using (View view = new View())
            {
                using (TimePeriod timePeriod = new TimePeriod(300))
                {
                    using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                    {
                        var testingTarget = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                        Assert.IsNotNull(testingTarget, "Should be not null!");
                        Assert.IsInstanceOf<TransitionItemBase>(testingTarget, "Should be an Instance of TransitionItemBase!");

                        tlog.Debug(tag, "TimePeriod : " + testingTarget.TimePeriod);
                        tlog.Debug(tag, "AlphaFunction : " + testingTarget.AlphaFunction);

                        testingTarget.Dispose();
                        // disposed
                        testingTarget.Dispose();
                    }
                }
            }

            tlog.Debug(tag, $"TransitionItemBaseTimePeriod END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItemBase TransitionWithChild.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.TransitionWithChild A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseTransitionWithChild()
        {
            tlog.Debug(tag, $"TransitionItemBaseTransitionWithChild START");

            using (View view = new View())
            {
                var testingTarget = new TransitionItemBase(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionItemBase>(testingTarget, "Should be an Instance of TransitionItemBase!");

                try
                {
                    testingTarget.TransitionWithChild = false;
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TransitionItemBaseTransitionWithChild END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItemBase DownCast.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseDownCast()
        {
            tlog.Debug(tag, $"TransitionItemBaseDownCast START");

            using (View view = new View())
            {
                var testingTarget = new TransitionItemBase(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionItemBase>(testingTarget, "Should be an Instance of TransitionItemBase!");

                try
                {
                    TransitionItemBase.DownCast(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Error(tag, "Caught Exception" + e.ToString());
                    LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                    Assert.Fail("Caught Exception" + e.ToString());
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TransitionItemBaseDownCast END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("TransitionItemBase DownCast.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseDownCastWithNullHandle()
        {
            tlog.Debug(tag, $"TransitionItemBaseDownCastWithNullHandle START");

            using (View view = new View())
            {
                var testingTarget = new TransitionItemBase(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionItemBase>(testingTarget, "Should be an Instance of TransitionItemBase!");

                try
                {
                    TransitionItemBase.DownCast(null);
                }
                catch (ArgumentNullException e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    tlog.Debug(tag, $"TransitionItemBaseDownCastWithNullHandle END (OK)");
                    Assert.Pass("Caught ArgumentNullException : Passed!");
                }

                testingTarget.Dispose();
            }
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItemBase Assign.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseAssign()
        {
            tlog.Debug(tag, $"TransitionItemBaseAssign START");

            using (View view = new View())
            {
                var testingTarget = new TransitionItemBase(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionItemBase>(testingTarget, "Should be an Instance of TransitionItemBase!");

                try
                {
                    testingTarget.Assign(testingTarget);
                }
                catch (Exception e)
                {
                    tlog.Error(tag, "Caught Exception" + e.ToString());
                    LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                    Assert.Fail("Caught Exception" + e.ToString());
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TransitionItemBaseAssign END (OK)");
        }
    }
}
