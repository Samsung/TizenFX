using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/WatchTimeSignal")]
    public class InternalWatchTimeSignalTest
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
        [Description("WatchTimeSignal constructor")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeSignalConstructor()
        {
            tlog.Debug(tag, $"WatchTimeSignalConstructor START");

            if (IsWearable())
            {
                var testingTarget = new WatchTimeSignal();

                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeSignalConstructor END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeSignalConstructor END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchTimeSignal Empty")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeSignalEmpty()
        {
            tlog.Debug(tag, $"WatchTimeSignalEmpty START");

            if (IsWearable())
            {
                var testingTarget = new WatchTimeSignal();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

                var result = testingTarget.Empty();
                Assert.IsTrue(result);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeSignalEmpty END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeSignalEmpty END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchTimeSignal GetConnectionCount")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"WatchTimeSignalGetConnectionCount START");

            if (IsWearable())
            {
                var testingTarget = new WatchTimeSignal();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

                var result = testingTarget.GetConnectionCount();
                Assert.IsTrue(result == 0, "result should be 0");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeSignalGetConnectionCount END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeSignalGetConnectionCount END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchTimeSignal Connection")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeSignalConnection()
        {
            tlog.Debug(tag, $"WatchTimeSignalConnection START");

            if (IsWearable())
            {
                var testingTarget = new WatchTimeSignal();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

                dummyCallback callback = OnDummyCallback;
                testingTarget.Connect(callback);
                testingTarget.Disconnect(callback);
                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeSignalConnection END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeSignalConnection END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchTimeSignal Disconnection")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeSignalDisconnection()
        {
            tlog.Debug(tag, $"WatchTimeSignalDisconnection START");

            if (IsWearable())
            {
                var testingTarget = new WatchTimeSignal();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

                dummyCallback callback = OnDummyCallback;
                testingTarget.Connect(callback);
                testingTarget.Disconnect(callback);
                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeSignalDisconnection END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeSignalDisconnection END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchTimeSignal Emit")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeSignalEmit()
        {
            tlog.Debug(tag, $"WatchTimeSignalEmit START");

            if (IsWearable())
            {
                var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
                var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

                tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

                var testingTarget = new WatchTimeSignal();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTimeSignal>(testingTarget, "should be an instance of testing target class!");

                Application application = new Application();
                WatchTime watchTime = new WatchTime();
                testingTarget.Emit(application, watchTime);

                application.Dispose();
                watchTime.Dispose();
                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeSignalEmit END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeSignalEmit END (OK)");
                Assert.Pass("Not Supported profile");
            }           
        }
    }
}
