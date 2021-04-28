using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/ApplicationSignal")]
    public class InternalApplicationSignalTest
    {
        private const string tag = "NUITEST";
        private delegate bool dummyCallback(IntPtr application);
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
        [Description("ApplicationSignal constructor")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationSignalConstructor()
        {
            tlog.Debug(tag, $"ApplicationSignalConstructor START");

            var testingTarget = new ApplicationSignal();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationSignalConstructor END (OK)");
        }

        [Test]
        [Description("ApplicationSignal Empty")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationSignalEmpty()
        {
            tlog.Debug(tag, $"ApplicationSignalEmpty START");

            var testingTarget = new ApplicationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Empty();
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationSignalEmpty END (OK)");
        }

        [Test]
        [Description("ApplicationSignal GetConnectionCount")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ApplicationSignalGetConnectionCount START");

            var testingTarget = new ApplicationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.GetConnectionCount();
            Assert.IsTrue(result == 0, "result should be 0");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Description("ApplicationSignal Connection")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationSignalConnection()
        {
            tlog.Debug(tag, $"ApplicationSignalConnection START");

            var testingTarget = new ApplicationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"ApplicationSignalConnection END (OK)");
        }

        [Test]
        [Description("ApplicationSignal Disconnection")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationSignalDisconnection()
        {
            tlog.Debug(tag, $"ApplicationSignalDisconnection START");

            var testingTarget = new ApplicationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"ApplicationSignalDisconnection END (OK)");
        }

        [Test]
        [Description("ApplicationSignal Emit")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationSignalEmit()
        {
            tlog.Debug(tag, $"ApplicationSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = Tizen.NUI.Application.Instance.PauseSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Emit(Tizen.NUI.Application.Current);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationSignalEmit END (OK)");
        }
    }
}
