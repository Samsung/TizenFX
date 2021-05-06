using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/WatchBoolSignal")]
    public class InternalWatchBoolSignalTest
    {
        private const string tag = "NUITEST";
        private delegate bool dummyCallback(IntPtr application);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
        }

        private bool IsWearable()
        {
            string value;
            var result = Tizen.System.Information.TryGetValue("tizen.org/feature/profile", out value);
            if (result && value.Equals("wearable"))
            {
                return true;
            }

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
        [Description("WatchBoolSignal constructor")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchBoolSignalConstructor()
        {
            tlog.Debug(tag, $"WatchBoolSignalConstructor START");

            if (IsWearable())
            {
                var testingTarget = new WatchBoolSignal();

                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchBoolSignalConstructor END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchBoolSignalConstructor END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchBoolSignal Empty")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchBoolSignalEmpty()
        {
            tlog.Debug(tag, $"WatchBoolSignalEmpty START");

            if (IsWearable())
            {
                var testingTarget = new WatchBoolSignal();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

                var result = testingTarget.Empty();
                Assert.IsTrue(result);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchBoolSignalEmpty END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchBoolSignalEmpty END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchBoolSignal GetConnectionCount")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchBoolSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"WatchBoolSignalGetConnectionCount START");

            if (IsWearable())
            {
                var testingTarget = new WatchBoolSignal();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

                var result = testingTarget.GetConnectionCount();
                Assert.IsTrue(result == 0, "result should be 0");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchBoolSignalGetConnectionCount END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchBoolSignalGetConnectionCount END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchBoolSignal Connection")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchBoolSignalConnection()
        {
            tlog.Debug(tag, $"WatchBoolSignalConnection START");

            if (IsWearable())
            {
                var testingTarget = new WatchBoolSignal();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

                dummyCallback callback = OnDummyCallback;
                testingTarget.Connect(callback);
                testingTarget.Disconnect(callback);
                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchBoolSignalConnection END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchBoolSignalConnection END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchBoolSignal Disconnection")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchBoolSignalDisconnection()
        {
            tlog.Debug(tag, $"WatchBoolSignalDisconnection START");

            if (IsWearable())
            {
                var testingTarget = new WatchBoolSignal();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

                dummyCallback callback = OnDummyCallback;
                testingTarget.Connect(callback);
                testingTarget.Disconnect(callback);
                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchBoolSignalDisconnection END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchBoolSignalDisconnection END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchBoolSignal Emit")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchBoolSignalEmit()
        {
            tlog.Debug(tag, $"WatchBoolSignalEmit START");

            if (IsWearable())
            {
                var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
                var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

                tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

                var testingTarget = new WatchBoolSignal();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchBoolSignal>(testingTarget, "should be an instance of testing target class!");

                var dummy = new Application();
                testingTarget.Emit(dummy, true);

                dummy.Dispose();
                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchBoolSignalEmit END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchBoolSignalEmit END (OK)");
                Assert.Pass("Not Supported profile");
            }            
        }
    }
}
