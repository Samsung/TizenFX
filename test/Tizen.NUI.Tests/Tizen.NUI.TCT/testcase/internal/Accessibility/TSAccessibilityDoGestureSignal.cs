
using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Accessibility/AccessibilityDoGestureSignal")]
    public class InternalAccessibilityDoGestureSignalTest
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
        [Description("AccessibilityDoGestureSignal constructor")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityDoGestureSignalConstructor()
        {
            tlog.Debug(tag, $"AccessibilityDoGestureSignalConstructor START");

            var testingTarget = new AccessibilityDoGestureSignal();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityDoGestureSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AccessibilityDoGestureSignalConstructor END (OK)");
        }

        [Test]
        [Description("AccessibilityDoGestureSignal GetSizeOfGestureInfo")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityDoGestureSignalGetSizeOfGestureInfo()
        {
            tlog.Debug(tag, $"AccessibilityDoGestureSignalGetSizeOfGestureInfo START");

            uint size = AccessibilityDoGestureSignal.GetSizeOfGestureInfo();

            tlog.Debug(tag, $"size={size}");
            Assert.IsNotNull(size, "should be not null");

            tlog.Debug(tag, $"AccessibilityDoGestureSignalGetSizeOfGestureInfo END (OK)");
        }

        [Test]
        [Description("AccessibilityDoGestureSignal Empty")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityDoGestureSignalEmpty()
        {
            tlog.Debug(tag, $"AccessibilityDoGestureSignalEmpty START");

            var testingTarget = new AccessibilityDoGestureSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityDoGestureSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Empty();
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AccessibilityDoGestureSignalEmpty END (OK)");
        }

        [Test]
        [Description("AccessibilityDoGestureSignal GetConnectionCount")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityDoGestureSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"AccessibilityDoGestureSignal_GetConnectionCount START");

            var testingTarget = new AccessibilityDoGestureSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityDoGestureSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.GetConnectionCount();
            Assert.IsTrue(result == 0, "result should be 0");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AccessibilityDoGestureSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Description("AccessibilityDoGestureSignal Connection")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityDoGestureSignalConnection()
        {
            tlog.Debug(tag, $"AccessibilityDoGestureSignalConnection START");

            var testingTarget = new AccessibilityDoGestureSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityDoGestureSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"AccessibilityDoGestureSignalConnection END (OK)");
        }

        [Test]
        [Description("AccessibilityDoGestureSignal Disconnection")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityDoGestureSignalDisconnection()
        {
            tlog.Debug(tag, $"AccessibilityDoGestureSignalDisconnection START");

            var testingTarget = new AccessibilityDoGestureSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityDoGestureSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"AccessibilityDoGestureSignalDisconnection END (OK)");
        }

        [Test]
        [Description("AccessibilityDoGestureSignal Emit")]
        [Property("AUTHOR", "dongsug.song@samsung.com")]
        public void AccessibilityDoGestureSignalEmit()
        {
            tlog.Debug(tag, $"AccessibilityDoGestureSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new AccessibilityDoGestureSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AccessibilityDoGestureSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Emit();
            testingTarget.Dispose();

            tlog.Debug(tag, $"AccessibilityDoGestureSignalEmit END (OK)");
        }

    }
}
