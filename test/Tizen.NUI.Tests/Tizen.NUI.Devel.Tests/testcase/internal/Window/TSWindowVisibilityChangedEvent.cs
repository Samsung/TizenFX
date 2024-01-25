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
    [Description("internal/Window/WindowVisibilityChangedEvent")]
    public class InternalWindowVisibilityChangedEventTest
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
        [Description("WindowVisibilityChangedEvent constructor")]
        [Property("SPEC", "Tizen.NUI.WindowVisibilityChangedEvent.WindowVisibilityChangedEvent C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowVisibilityChangedEventConstructor()
        {
            tlog.Debug(tag, $"WindowVisibilityChangedEventConstructor START");

            var testingTarget = new WindowVisibilityChangedEvent(Window.Instance);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<WindowVisibilityChangedEvent>(testingTarget, "should be an instance of WindowVisibilityChangedEvent class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"WindowVisibilityChangedEventConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowVisibilityChangedEvent Empty.")]
        [Property("SPEC", "Tizen.NUI.WindowVisibilityChangedEvent.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowVisibilityChangedEventEmpty()
        {
            tlog.Debug(tag, $"WindowVisibilityChangedEventEmpty START");

            var testingTarget = new WindowVisibilityChangedEvent(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WindowVisibilityChangedEvent>(testingTarget, "Should be an Instance of WindowVisibilityChangedEvent!");

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
            tlog.Debug(tag, $"WindowVisibilityChangedEventEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowVisibilityChangedEvent GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.WindowVisibilityChangedEvent.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowVisibilityChangedEventGetConnectionCount()
        {
            tlog.Debug(tag, $"WindowVisibilityChangedEventGetConnectionCount START");

            var testingTarget = new WindowVisibilityChangedEvent(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WindowVisibilityChangedEvent>(testingTarget, "Should be an Instance of WindowVisibilityChangedEvent!");

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

            tlog.Debug(tag, $"WindowVisibilityChangedEventGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowVisibilityChangedEvent Connect.")]
        [Property("SPEC", "Tizen.NUI.WindowVisibilityChangedEvent.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowVisibilityChangedEventConnect()
        {
            tlog.Debug(tag, $"WindowVisibilityChangedEventConnect START");

            var testingTarget = new WindowVisibilityChangedEvent(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WindowVisibilityChangedEvent>(testingTarget, "Should be an Instance of WindowVisibilityChangedEvent!");

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

            tlog.Debug(tag, $"WindowVisibilityChangedEventConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WindowVisibilityChangedEvent Emit.")]
        [Property("SPEC", "Tizen.NUI.WindowVisibilityChangedEvent.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowVisibilityChangedEventEmit()
        {
            tlog.Debug(tag, $"WindowVisibilityChangedEventEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (Window window = new Window(new Rectangle(0, 0, 2, 2), false))
            {
                var testingTarget = new WindowVisibilityChangedEvent(Window.Instance);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<WindowVisibilityChangedEvent>(testingTarget, "Should be an Instance of WindowVisibilityChangedEvent!");

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

            tlog.Debug(tag, $"WindowVisibilityChangedEventEmit END (OK)");
        }
    }
}
