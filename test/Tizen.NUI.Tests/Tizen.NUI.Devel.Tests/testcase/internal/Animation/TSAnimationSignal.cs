using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Animation/AnimationSignal")]
    public class InternalAnimationSignalTest
    {
        private const string tag = "NUITEST";
        private global::System.IntPtr OnIntPtrCallback; 
        private delegate bool dummyCallback(IntPtr animation);
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
        [Description("AnimationSignal constructor")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSignalConstructor()
        {
            tlog.Debug(tag, $"AnimationSignalConstructor START");

            var testingTarget = new AnimationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimationSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationSignalConstructor END (OK)");
        }

        [Test]
        [Description("AnimationSignal Empty")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSignalEmpty()
        {
            tlog.Debug(tag, $"AnimationSignalEmpty START");

            var testingTarget = new AnimationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimationSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Empty();
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationSignalEmpty END (OK)");
        }

        [Test]
        [Description("AnimationSignal GetConnectionCount")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"AnimationSignalGetConnectionCount START");

            var testingTarget = new AnimationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimationSignal>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.GetConnectionCount();
            Assert.IsTrue(result == 0, "result should be 0");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Description("AnimationSignal Connection")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSignalConnection()
        {
            tlog.Debug(tag, $"AnimationSignalConnection START");

            var testingTarget = new AnimationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimationSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationSignalConnection END (OK)");
        }

        [Test]
        [Description("AnimationSignal Connection with System.IntPtr")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSignalConnectionWithIntPtr()
        {
            tlog.Debug(tag, $"AnimationSignalConnectionWithIntPtr START");

            var testingTarget = new AnimationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimationSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Connect(OnIntPtrCallback);
            testingTarget.Disconnect(OnIntPtrCallback);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationSignalConnectionWithIntPtr END (OK)");
        }

        [Test]
        [Description("AnimationSignal Disconnection")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSignalDisconnection()
        {
            tlog.Debug(tag, $"AnimationSignalDisconnection START");

            var testingTarget = new AnimationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimationSignal>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationSignalDisconnection END (OK)");
        }

        [Test]
        [Description("AnimationSignal Disconnection with System.IntPtr")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSignalDisconnectionWithIntPtr()
        {
            tlog.Debug(tag, $"AnimationSignalDisconnectionWithIntPtr START");

            var testingTarget = new AnimationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimationSignal>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Connect(OnIntPtrCallback);
            testingTarget.Disconnect(OnIntPtrCallback);

            testingTarget.Dispose();
            tlog.Debug(tag, $"AnimationSignalDisconnectionWithIntPtr END (OK)");
        }

        [Test]
        [Description("AnimationSignal Emit")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AnimationSignalEmit()
        {
            tlog.Debug(tag, $"AnimationSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new AnimationSignal();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AnimationSignal>(testingTarget, "should be an instance of testing target class!");

            var dummy = new Animation();
            testingTarget.Emit(dummy);

            testingTarget.Dispose();
            dummy.Dispose();
            tlog.Debug(tag, $"AnimationSignalEmit END (OK)");
        }
    }
}
