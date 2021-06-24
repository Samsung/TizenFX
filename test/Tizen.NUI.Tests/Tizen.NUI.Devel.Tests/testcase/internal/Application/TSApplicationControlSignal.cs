using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/ApplicationControlSignal")]
    public class InternalApplicationControlSignalTest
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
        [Category("P1")]
        [Description("ApplicationControlSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ApplicationControlSignal.ApplicationControlSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationControlSignalConstructor()
        {
            tlog.Debug(tag, $"ApplicationControlSignalConstructor START");

            var testingTarget = new ApplicationControlSignal();

            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationControlSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationControlSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationControlSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ApplicationControlSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationControlSignalEmpty()
        {
            tlog.Debug(tag, $"ApplicationControlSignalEmpty START");

            var testingTarget = new ApplicationControlSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationControlSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Empty();
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationControlSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationControlSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ApplicationControlSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationControlSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ApplicationControlSignalGetConnectionCount START");

            var testingTarget = new ApplicationControlSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationControlSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.GetConnectionCount();
            Assert.IsTrue(result == 0, "result should be 0");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationControlSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationControlSignal connection.")]
        [Property("SPEC", "Tizen.NUI.ApplicationControlSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationControlSignalConnection()
        {
            tlog.Debug(tag, $"ApplicationControlSignalConnection START");

            var testingTarget = new ApplicationControlSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationControlSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"ApplicationControlSignalConnection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationControlSignal disconnection.")]
        [Property("SPEC", "Tizen.NUI.ApplicationControlSignal.Disconnect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationControlSignalDisconnection()
        {
            tlog.Debug(tag, $"ApplicationControlSignalDisconnection START");

            var testingTarget = new ApplicationControlSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationControlSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"ApplicationControlSignalDisconnection END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ApplicationControlSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.ApplicationControlSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationControlSignalEmit()
        {
            tlog.Debug(tag, $"ApplicationControlSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new ApplicationControlSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ApplicationControlSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Emit(Application.Current, new global::System.IntPtr(0));

            testingTarget.Dispose();
            tlog.Debug(tag, $"ApplicationControlSignalEmit END (OK)");
        }
    }
}
