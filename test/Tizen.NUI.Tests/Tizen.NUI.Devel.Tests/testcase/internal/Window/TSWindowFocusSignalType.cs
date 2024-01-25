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
    [Description("internal/Window/WindowFocusSignalType")]
    public class InternalWindowFocusSignalTypeTest
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
        [Description("WindowFocusSignalType constructor")]
        [Property("SPEC", "Tizen.NUI.WindowFocusSignalType.WindowFocusSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowFocusSignalTypeConstructor()
        {
            tlog.Debug(tag, $"WindowFocusSignalTypeConstructor START");

            var testingTarget = new WindowFocusSignalType();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<WindowFocusSignalType>(testingTarget, "should be an instance of WindowFocusSignalType class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"WindowFocusSignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowFocusSignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.WindowFocusSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowFocusSignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"WindowFocusSignalTypeGetConnectionCount START");

            var testingTarget = new WindowFocusSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WindowFocusSignalType>(testingTarget, "Should be an Instance of WindowFocusSignalType!");

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

            tlog.Debug(tag, $"WindowFocusSignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowFocusSignalType Emit.")]
        [Property("SPEC", "Tizen.NUI.WindowFocusSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowFocusSignalTypeEmit()
        {
            tlog.Debug(tag, $"WindowFocusSignalTypeEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (Window window = new Window(new Rectangle(0, 0, 2, 2), false))
            {
                var testingTarget = new WindowFocusSignalType();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<WindowFocusSignalType>(testingTarget, "Should be an Instance of WindowFocusSignalType!");

                try
                {
                    testingTarget.Emit(window, false);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WindowFocusSignalTypeEmit END (OK)");
        }
    }
}
