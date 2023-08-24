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
    [Description("internal/Window/WindowEffectSignal")]
    public class InternalWindowEffectSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr signal);
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
        [Description("WindowTransitionEffectSignal constructor")]
        [Property("SPEC", "Tizen.NUI.WindowEffectSignal.WindowTransitionEffectSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowTransitionEffectSignalConstructor()
        {
            tlog.Debug(tag, $"WindowTransitionEffectSignalConstructor START");

            var testingTarget = new WindowTransitionEffectSignal(Window.Instance);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<WindowTransitionEffectSignal>(testingTarget, "should be an instance of WindowTransitionEffectSignal class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"WindowTransitionEffectSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowTransitionEffectSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.WindowTransitionEffectSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowTransitionEffectSignalEmpty()
        {
            tlog.Debug(tag, $"WindowTransitionEffectSignalEmpty START");

            var testingTarget = new WindowTransitionEffectSignal(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WindowTransitionEffectSignal>(testingTarget, "Should be an Instance of WindowTransitionEffectSignal!");

            try
            {
                testingTarget.Empty();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"WindowTransitionEffectSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowTransitionEffectSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.WindowTransitionEffectSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowTransitionEffectSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"WindowTransitionEffectSignalGetConnectionCount START");

            var testingTarget = new WindowTransitionEffectSignal(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WindowTransitionEffectSignal>(testingTarget, "Should be an Instance of WindowTransitionEffectSignal!");

            try
            {
                testingTarget.GetConnectionCount();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"WindowTransitionEffectSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowTransitionEffectSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.WindowTransitionEffectSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowTransitionEffectSignalConnect()
        {
            tlog.Debug(tag, $"WindowTransitionEffectSignalConnect START");

            var testingTarget = new WindowTransitionEffectSignal(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WindowTransitionEffectSignal>(testingTarget, "Should be an Instance of WindowTransitionEffectSignal!");

            try
            {
                dummyCallback callback = OnDummyCallback;
                testingTarget.Connect(callback);
                testingTarget.Disconnect(callback);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"WindowTransitionEffectSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowTransitionEffectSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.WindowTransitionEffectSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowTransitionEffectSignalEmit()
        {
            tlog.Debug(tag, $"WindowTransitionEffectSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (Window window = new Window(new Rectangle(0, 0, 2, 2), false))
            {
                var testingTarget = new WindowTransitionEffectSignal(Window.Instance);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<WindowTransitionEffectSignal>(testingTarget, "Should be an Instance of WindowTransitionEffectSignal!");

                try
                {
                    testingTarget.Emit(window, 1, 1);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowTransitionEffectSignalEmit END (OK)");
        }
    }
}
