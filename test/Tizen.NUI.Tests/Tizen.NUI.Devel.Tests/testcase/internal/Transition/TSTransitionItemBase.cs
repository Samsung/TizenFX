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
    class TSTransitionItemBase
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

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase testingTarget = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    testingTarget = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionItemBaseConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItemBase Duration.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.Duration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseDuration()
        {
            tlog.Debug(tag, $"TransitionItemBaseDuration START");

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase testingTarget = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    testingTarget = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

            testingTarget.Duration = 300;
            Assert.IsTrue(300 == testingTarget.Duration);

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionItemBaseDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItemBase Delay.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.Delay A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseDelay()
        {
            tlog.Debug(tag, $"TransitionItemBaseDelay START");

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase testingTarget = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    testingTarget = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

            testingTarget.Delay = 300;
            Assert.IsTrue(300 == testingTarget.Delay);

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionItemBaseDelay END (OK)");
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

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase testingTarget = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    testingTarget = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

            try
            {
                using (TimePeriod setValue = new TimePeriod(300))
                {
                    testingTarget.TimePeriod = setValue;
                }
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionItemBaseTimePeriod END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItemBase AlphaFunction.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.AlphaFunction A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseAlphaFunction()
        {
            tlog.Debug(tag, $"TransitionItemBaseAlphaFunction START");

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase testingTarget = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    testingTarget = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

            using (AlphaFunction setValue = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut)) 
            {
                testingTarget.AlphaFunction = setValue;
                var result = testingTarget.AlphaFunction;
                Assert.IsTrue(result.GetBuiltinFunction() == AlphaFunction.BuiltinFunctions.EaseOut);
            }

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionItemBaseAlphaFunction END (OK)");
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

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase testingTarget = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    testingTarget = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

            try
            {
                testingTarget.TransitionWithChild = true;
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            view.Dispose();
            testingTarget.Dispose();
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

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase testingTarget = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    testingTarget = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

            var result = TransitionItemBase.DownCast(testingTarget);
            Assert.IsNotNull(result, "Should be not null!");
            Assert.IsInstanceOf<TransitionItemBase>(result, "Should be an Instance of TransitionItemBase!");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionItemBaseDownCast END (OK)");
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

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase testingTarget = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    testingTarget = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

            using (TransitionItemBase rhs = new TransitionItemBase(testingTarget))
            {
                var result = testingTarget.Assign(rhs);
                Assert.IsNotNull(result, "Should be not null!");
                Assert.IsInstanceOf<TransitionItemBase>(result, "Should be an Instance of TransitionItemBase!");
            }

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionItemBaseAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItemBase Dispose.")]
        [Property("SPEC", "Tizen.NUI.TransitionItemBase.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemBaseDispose()
        {
            tlog.Debug(tag, $"TransitionItemBaseDispose START");

            View view = new View()
            {
                Name = "view",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            view.TransitionOptions.TransitionTag = "Transition";
            view.TransitionOptions.EnableTransition = true;

            TransitionItemBase testingTarget = null;
            using (TimePeriod timePeriod = new TimePeriod(500))
            {
                using (AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default))
                {
                    testingTarget = new TransitionItemBase(view, true, timePeriod, alphaFunction);
                }
            }

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

            view?.Dispose();
            tlog.Debug(tag, $"TransitionItemBaseDispose END (OK)");
        }
    }
}
