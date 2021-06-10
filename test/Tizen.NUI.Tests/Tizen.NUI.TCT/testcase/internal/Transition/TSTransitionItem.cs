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
    class TSTransitionItem
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

            View currentView = new View()
            {
                Name = "currentPage",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            currentView.TransitionOptions.TransitionTag = "Transition";
            currentView.TransitionOptions.EnableTransition = true;

            View newView = new View()
            {
                Name = "newPage",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            newView.TransitionOptions.TransitionTag = "Transition";
            newView.TransitionOptions.EnableTransition = true;

            AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default);
            TimePeriod timePeriod = new TimePeriod(500);

            var testingTarget = new TransitionItem(currentView, newView, timePeriod, alphaFunction);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TransitionItem>(testingTarget, "Should be an Instance of TransitionItem!");

            newView.Dispose();
            currentView.Dispose();
            timePeriod.Dispose();
            alphaFunction.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionItemConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItem ShowSourceAfterFinished.")]
        [Property("SPEC", "Tizen.NUI.TransitionItem.ShowSourceAfterFinished A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PROW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemShowSourceAfterFinished()
        {
            tlog.Debug(tag, $"TransitionItemShowSourceAfterFinished START");

            View currentView = new View()
            {
                Name = "currentPage",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            currentView.TransitionOptions.TransitionTag = "Transition";
            currentView.TransitionOptions.EnableTransition = true;

            View newView = new View()
            {
                Name = "newPage",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            newView.TransitionOptions.TransitionTag = "Transition";
            newView.TransitionOptions.EnableTransition = true;

            AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default);
            TimePeriod timePeriod = new TimePeriod(500);

            var testingTarget = new TransitionItem(currentView, newView, timePeriod, alphaFunction);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TransitionItem>(testingTarget, "Should be an Instance of TransitionItem!");

            try
            {
                testingTarget.ShowSourceAfterFinished = true;
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                LogUtils.Write(LogUtils.DEBUG, LogUtils.TAG, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            newView.Dispose();
            currentView.Dispose();
            timePeriod.Dispose();
            alphaFunction.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionItemShowSourceAfterFinished END (OK)");
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

            View currentView = new View()
            {
                Name = "currentPage",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            currentView.TransitionOptions.TransitionTag = "Transition";
            currentView.TransitionOptions.EnableTransition = true;

            View newView = new View()
            {
                Name = "newPage",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            newView.TransitionOptions.TransitionTag = "Transition";
            newView.TransitionOptions.EnableTransition = true;

            AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default);
            TimePeriod timePeriod = new TimePeriod(500);

            var testingTarget = new TransitionItem(currentView, newView, timePeriod, alphaFunction);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TransitionItem>(testingTarget, "Should be an Instance of TransitionItem!");

            using (TransitionItem rhs = new TransitionItem(testingTarget))
            {
                var result = testingTarget.Assign(rhs);
                Assert.IsNotNull(result, "Should be not null!");
                Assert.IsInstanceOf<TransitionItem>(result, "Should be an Instance of TransitionItem!");
            }

            currentView?.Dispose();
            newView?.Dispose();
            timePeriod?.Dispose();
            alphaFunction?.Dispose();
            testingTarget?.Dispose();
            tlog.Debug(tag, $"TransitionItemAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionItem Dispose.")]
        [Property("SPEC", "Tizen.NUI.TransitionItem.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionItemDispose()
        {
            tlog.Debug(tag, $"TransitionItemDispose START");

            View currentView = new View()
            {
                Name = "currentPage",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            currentView.TransitionOptions.TransitionTag = "Transition";
            currentView.TransitionOptions.EnableTransition = true;

            View newView = new View()
            {
                Name = "newPage",
                TransitionOptions = new TransitionOptions(Window.Instance)
            };
            newView.TransitionOptions.TransitionTag = "Transition";
            newView.TransitionOptions.EnableTransition = true;

            AlphaFunction alphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.Default);
            TimePeriod timePeriod = new TimePeriod(500);

            var testingTarget = new TransitionItem(currentView, newView, timePeriod, alphaFunction);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TransitionItem>(testingTarget, "Should be an Instance of TransitionItem!");

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

            currentView?.Dispose();
            newView?.Dispose();
            timePeriod?.Dispose();
            alphaFunction?.Dispose();
            tlog.Debug(tag, $"TransitionItemDispose END (OK)");
        }
    }
}
