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
    class TSTransitionSet
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
        [Description("TransitionSet GetTransitionAt.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.GetTransitionAt M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetGetTransitionAt()
        {
            tlog.Debug(tag, $"TransitionSetGetTransitionAt START");

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

            var result = testingTarget.GetTransitionAt(1);
            Assert.IsNotNull(result, "Should be not null!");
            Assert.IsInstanceOf<TransitionItemBase>(result, "Should be an Instance of TransitionItemBase!");

            view.Dispose();
            transitionItemBase.Dispose();
            testingTarget.Dispose();
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

            var result = testingTarget.GetTransitionCount();
            Assert.IsTrue(1 == result);

            view.Dispose();
            transitionItemBase.Dispose();
            testingTarget.Dispose();
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

            view.Dispose();
            transitionItemBase.Dispose();
            testingTarget.Dispose();
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

            var transitionSet = new TransitionSet();
            Assert.IsNotNull(transitionSet, "Should be not null!");
            Assert.IsInstanceOf<TransitionSet>(transitionSet, "Should be an Instance of TransitionSet!");

            transitionSet.AddTransition(transitionItemBase);

            var testingTarget = new TransitionSet();
            var result = transitionSet.Assign(testingTarget);
            Assert.IsNotNull(result, "Should be not null!");
            Assert.IsInstanceOf<TransitionSet>(result, "Should be an Instance of TransitionSet!");

            view.Dispose();
            transitionItemBase.Dispose();
            testingTarget.Dispose();
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

            var transitionSet = new TransitionSet();
            Assert.IsNotNull(transitionSet, "Should be not null!");
            Assert.IsInstanceOf<TransitionSet>(transitionSet, "Should be an Instance of TransitionSet!");

            transitionSet.AddTransition(transitionItemBase);

            var testingTarget = transitionSet.FinishedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TransitionSetFinishedSignal>(testingTarget, "Should be an Instance of TransitionSet!");

            view.Dispose();
            transitionItemBase.Dispose();
            tlog.Debug(tag, $"TransitionSetFinishedSignal END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("TransitionSet Dispose.")]
        [Property("SPEC", "Tizen.NUI.TransitionSet.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetDispose()
        {
            tlog.Debug(tag, $"TransitionSetDispose START");

            var testingTarget = new TransitionSet();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TransitionSet>(testingTarget, "Should be an Instance of TransitionSet!");

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

            tlog.Debug(tag, $"TransitionSetDispose END (OK)");
        }
    }
}
