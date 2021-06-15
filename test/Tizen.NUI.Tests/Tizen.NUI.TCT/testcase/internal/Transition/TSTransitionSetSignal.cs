using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Transition/TransitionSetSignal")]
    class TSTransitionSetSignal
    {
        private const string tag = "NUITEST";
        private global::System.IntPtr OnIntPtrCallback;
        private delegate bool dummyCallback(IntPtr transitionSet);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
        }

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
        [Description("TransitionSetSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.TransitionSetSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetSignalEmpty()
        {
            tlog.Debug(tag, $"TransitionSetSignalEmpty START");

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

            var transitionSetSignal = testingTarget.FinishedSignal();
            Assert.IsNotNull(transitionSetSignal, "Should be not null!");
            Assert.IsInstanceOf<TransitionSetFinishedSignal>(transitionSetSignal, "Should be an Instance of TransitionSet!");

            var result = transitionSetSignal.Empty();
            Assert.IsTrue(result);

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionSetSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSetSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.TransitionSetSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"TransitionSetSignalGetConnectionCount START");

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

            var transitionSetSignal = testingTarget.FinishedSignal();
            Assert.IsNotNull(transitionSetSignal, "Should be not null!");
            Assert.IsInstanceOf<TransitionSetFinishedSignal>(transitionSetSignal, "Should be an Instance of TransitionSet!");

            var result = transitionSetSignal.GetConnectionCount();
            Assert.IsTrue(0 == result);

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionSetSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSetSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.TransitionSetSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetSignalConnect()
        {
            tlog.Debug(tag, $"TransitionSetSignalConnect START");

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

            var transitionSetSignal = testingTarget.FinishedSignal();
            Assert.IsNotNull(transitionSetSignal, "Should be not null!");
            Assert.IsInstanceOf<TransitionSetFinishedSignal>(transitionSetSignal, "Should be an Instance of TransitionSet!");

            dummyCallback callback = OnDummyCallback;
            transitionSetSignal.Connect(callback);
            transitionSetSignal.Disconnect(callback);

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionSetSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSetSignal Connect. With IntPtr")]
        [Property("SPEC", "Tizen.NUI.TransitionSetSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetSignalConnectWithIntPtr()
        {
            tlog.Debug(tag, $"TransitionSetSignalConnectWithIntPtr START");

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

            var transitionSetSignal = testingTarget.FinishedSignal();
            Assert.IsNotNull(transitionSetSignal, "Should be not null!");
            Assert.IsInstanceOf<TransitionSetFinishedSignal>(transitionSetSignal, "Should be an Instance of TransitionSet!");

            transitionSetSignal.Connect(OnIntPtrCallback);
            transitionSetSignal.Disconnect(OnIntPtrCallback);

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionSetSignalConnectWithIntPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSetSignal Disconnect.")]
        [Property("SPEC", "Tizen.NUI.TransitionSetSignal.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetSignalDisconnect()
        {
            tlog.Debug(tag, $"TransitionSetSignalDisconnect START");

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

            var transitionSetSignal = testingTarget.FinishedSignal();
            Assert.IsNotNull(transitionSetSignal, "Should be not null!");
            Assert.IsInstanceOf<TransitionSetFinishedSignal>(transitionSetSignal, "Should be an Instance of TransitionSet!");

            dummyCallback callback = OnDummyCallback;
            transitionSetSignal.Connect(callback);
            transitionSetSignal.Disconnect(callback);

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionSetSignalDisconnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TransitionSetSignal Disconnect. With IntPtr")]
        [Property("SPEC", "Tizen.NUI.TransitionSetSignal.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TransitionSetSignalDisconnectWithIntPtr()
        {
            tlog.Debug(tag, $"TransitionSetSignalDisconnectWithIntPtr START");

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

            var transitionSetSignal = testingTarget.FinishedSignal();
            Assert.IsNotNull(transitionSetSignal, "Should be not null!");
            Assert.IsInstanceOf<TransitionSetFinishedSignal>(transitionSetSignal, "Should be an Instance of TransitionSet!");

            transitionSetSignal.Connect(OnIntPtrCallback);
            transitionSetSignal.Disconnect(OnIntPtrCallback);

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TransitionSetSignalDisconnectWithIntPtr END (OK)");
        }
    }
}
