
using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Accessibility/AccessibilityActionSignal")]
    public class InternalAccessibilityActionSignalTest
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
        [Description("AccessibilityActionSignal constructor")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityActionSignalConstructor()
        {
            tlog.Debug(tag, $"AccessibilityActionSignalConstructor START");

            var testingTarget = new AccessibilityActionSignal();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityActionSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AccessibilityActionSignalConstructor END (OK)");
        }

        [Test]
        [Description("AccessibilityActionSignal Empty")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityActionSignalEmpty()
        {
            tlog.Debug(tag, $"AccessibilityActionSignalEmpty START");

            var testingTarget = new AccessibilityActionSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityActionSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Empty();
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AccessibilityActionSignalEmpty END (OK)");
        }

        [Test]
        [Description("AccessibilityActionSignal GetConnectionCount")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityActionSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"AccessibilityActionSignal_GetConnectionCount START");

            var testingTarget = new AccessibilityActionSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityActionSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.GetConnectionCount();
            Assert.IsTrue(result == 0, "result should be 0");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AccessibilityActionSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Description("AccessibilityActionSignal Connection")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityActionSignalConnection()
        {
            tlog.Debug(tag, $"AccessibilityActionSignalConnection START");

            var testingTarget = new AccessibilityActionSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityActionSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"AccessibilityActionSignalConnection END (OK)");
        }

        [Test]
        [Description("AccessibilityActionSignal Disconnection")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityActionSignalDisconnection()
        {
            tlog.Debug(tag, $"AccessibilityActionSignalDisconnection START");

            var testingTarget = new AccessibilityActionSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityActionSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"AccessibilityActionSignalDisconnection END (OK)");
        }

        [Test]
        [Description("AccessibilityActionSignal Emit")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityActionSignalEmit()
        {
            tlog.Debug(tag, $"AccessibilityActionSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new AccessibilityActionSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityActionSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Emit(Tizen.NUI.Accessibility.AccessibilityManager.Instance);
            testingTarget.Dispose();

            tlog.Debug(tag, $"AccessibilityActionSignalEmit END (OK)");
        }

    }
}
