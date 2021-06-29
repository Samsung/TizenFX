
using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Accessibility/AccessibilityFocusOvershotSignal")]
    public class InternalAccessibilityFocusOvershotSignalTests
    {
        private const string tag = "NUITEST";
        private delegate bool dummyCallback(IntPtr accessibilityManager);
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
        [Description("AccessibilityFocusOvershotSignal constructor")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityFocusOvershotSignalConstructor()
        {
            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalConstructor START");

            var testingTarget = new AccessibilityFocusOvershotSignal();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityFocusOvershotSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalConstructor END (OK)");
        }

        [Test]
        [Description("AccessibilityFocusOvershotSignal Empty")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityFocusOvershotSignalEmpty()
        {
            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalEmpty START");

            var testingTarget = new AccessibilityFocusOvershotSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityFocusOvershotSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Empty();
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalEmpty END (OK)");
        }

        [Test]
        [Description("AccessibilityFocusOvershotSignal GetConnectionCount")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityFocusOvershotSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalGetConnectionCount START");

            var testingTarget = new AccessibilityFocusOvershotSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityFocusOvershotSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.GetConnectionCount();
            Assert.IsTrue(result == 0, "result should be 0");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Description("AccessibilityFocusOvershotSignal Connection")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityFocusOvershotSignalConnection()
        {
            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalConnection START");

            var testingTarget = new AccessibilityFocusOvershotSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityFocusOvershotSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalConnection END (OK)");
        }

        [Test]
        [Description("AccessibilityFocusOvershotSignal Disconnection")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityFocusOvershotSignalDisconnection()
        {
            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalDisconnection START");

            var testingTarget = new AccessibilityFocusOvershotSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityFocusOvershotSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalDisconnection END (OK)");
        }

        [Test]
        [Description("AccessibilityFocusOvershotSignal Emit")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityFocusOvershotSignalEmit()
        {
            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new AccessibilityFocusOvershotSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityFocusOvershotSignal>(testingTarget, "should be an instance of testing target class!");

            View dummy = new View();
            testingTarget.Emit(dummy, Accessibility.AccessibilityManager.FocusOvershotDirection.Previous);
            
            testingTarget.Dispose();
            dummy.Dispose();

            tlog.Debug(tag, $"AccessibilityFocusOvershotSignalEmit END (OK)");
        }

    }
}
