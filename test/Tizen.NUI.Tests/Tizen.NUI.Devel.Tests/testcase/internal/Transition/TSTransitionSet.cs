using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Transition/TransitionSet")]
    public class InternalTransitionSetTest
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
        [Description("TransitionSet constructor.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.TransitionSet C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetConstructor()
        {
            tlog.Debug(tag, $"TransitionSetConstructor START");

            var testingTarget = new TransitionSet();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TransitionSet>(testingTarget, "Should be an Instance of TransitionSet!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionSetConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSet DownCast.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetDownCast()
        {
            tlog.Debug(tag, $"TransitionSetDownCast START");

            using (TransitionSet transitionSet = new TransitionSet())
            {
                var testingTarget = TransitionSet.DownCast(transitionSet);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionSet>(testingTarget, "Should be an Instance of TransitionSet!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TransitionSetDownCast END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSet AddTransition.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.AddTransition M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetAddTransition()
        {
            tlog.Debug(tag, $"TransitionSetAddTransition START");

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase transitionItemBase = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    transitionItemBase = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

            var testingTarget = new TransitionSet();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TransitionSet>(testingTarget, "Should be an Instance of TransitionSet!");

            try
            {
                testingTarget.AddTransition(transitionItemBase);
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            view.Dispose();
            transitionItemBase.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionSetAddTransition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSet Finished.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.Finished A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetFinished()
        {
            tlog.Debug(tag, $"TransitionSetFinished START");

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase transitionItemBase = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    transitionItemBase = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

            var testingTarget = new TransitionSet();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TransitionSet>(testingTarget, "Should be an Instance of TransitionSet!");

            testingTarget.AddTransition(transitionItemBase);

            testingTarget.Finished += MyOnFinished;
            testingTarget.Finished -= MyOnFinished;

            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionSetFinished END (OK)");
        }

        private void MyOnFinished(object sender, EventArgs e) { }

        [Test]
        [Category("P1")]
        [Description("TransitionSet GetTransitionAt.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.GetTransitionAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetGetTransitionAt()
        {
            tlog.Debug(tag, $"TransitionSetGetTransitionAt START");

            using (View view = new View())
            {
                var testingTarget = new TransitionSet(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionSet>(testingTarget, "Should be an Instance of TransitionSet!");

                try
                {
                    testingTarget.GetTransitionAt(0);
                }
                catch (Exception e)
                {
                    tlog.Error(tag, "Caught Exception" + e.ToString());
                    LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                    Assert.Fail("Caught Exception" + e.ToString());
                }
            }

            tlog.Debug(tag, $"TransitionSetGetTransitionAt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSet GetTransitionCount.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.GetTransitionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetGetTransitionCount()
        {
            tlog.Debug(tag, $"TransitionSetGetTransitionCount START");

            using (View view = new View())
            {
                var testingTarget = new TransitionSet(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionSet>(testingTarget, "Should be an Instance of TransitionSet!");

                try
                {
                    testingTarget.GetTransitionCount();
                }
                catch (Exception e)
                {
                    tlog.Error(tag, "Caught Exception" + e.ToString());
                    LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                    Assert.Fail("Caught Exception" + e.ToString());
                }
            }

            tlog.Debug(tag, $"TransitionSetGetTransitionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSet Play.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.Play M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetPlay()
        {
            tlog.Debug(tag, $"TransitionSetPlay START");

            using (View view = new View())
            {
                var testingTarget = new TransitionSet(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionSet>(testingTarget, "Should be an Instance of TransitionSet!");

                try
                {
                    testingTarget.Play();
                }
                catch (Exception e)
                {
                    tlog.Error(tag, "Caught Exception" + e.ToString());
                    LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                    Assert.Fail("Caught Exception" + e.ToString());
                }
            }

            tlog.Debug(tag, $"TransitionSetPlay END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSet Assign.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetAssign()
        {
            tlog.Debug(tag, $"TransitionSetAssign START");

            using (View view = new View())
            {
                var testingTarget = new TransitionSet(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionSet>(testingTarget, "Should be an Instance of TransitionSet!");

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
            }

            tlog.Debug(tag, $"TransitionSetAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSet FinishedSignal.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.FinishedSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetFinishedSignal()
        {
            tlog.Debug(tag, $"TransitionSetFinishedSignal START");

            using (View view = new View())
            {
                var testingTarget = new TransitionSet(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TransitionSet>(testingTarget, "Should be an Instance of TransitionSet!");

                try
                {
                    testingTarget.FinishedSignal();
                }
                catch (Exception e)
                {
                    tlog.Error(tag, "Caught Exception" + e.ToString());
                    LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                    Assert.Fail("Caught Exception" + e.ToString());
                }
            }

            tlog.Debug(tag, $"TransitionSetFinishedSignal END (OK)");
        }
    }
}
