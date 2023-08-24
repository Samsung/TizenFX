using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/VideoViewSignal")]
    public class InternalVideoViewSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr videoViewSignal);
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
        [Description("VideoViewSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.VideoViewSignal.VideoViewSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VideoViewSignalConstructor()
        {
            tlog.Debug(tag, $"VideoViewSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new VideoViewSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VideoViewSignal>(testingTarget, "Should be an Instance of VideoViewSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VideoViewSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VideoViewSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.VideoViewSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VideoViewSignalEmpty()
        {
            tlog.Debug(tag, $"VideoViewSignalEmpty START");

            var testingTarget = new VideoViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VideoViewSignal>(testingTarget, "Should be an Instance of VideoViewSignal!");

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

            tlog.Debug(tag, $"VideoViewSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VideoViewSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.VideoViewSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VideoViewSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"VideoViewSignalGetConnectionCount START");

            var testingTarget = new VideoViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VideoViewSignal>(testingTarget, "Should be an Instance of VideoViewSignal!");

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

            tlog.Debug(tag, $"VideoViewSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VideoViewSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.VideoViewSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VideoViewSignalConnect()
        {
            tlog.Debug(tag, $"VideoViewSignalConnect START");

            var testingTarget = new VideoViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VideoViewSignal>(testingTarget, "Should be an Instance of VideoViewSignal!");

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

            tlog.Debug(tag, $"VideoViewSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VideoViewSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.VideoViewSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VideoViewSignalEmit()
        {
            tlog.Debug(tag, $"VideoViewSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (VideoView view = new VideoView())
            {
                var testingTarget = new VideoViewSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<VideoViewSignal>(testingTarget, "Should be an Instance of VideoViewSignal!");

                try
                {
                    testingTarget.Emit(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"VideoViewSignalEmit END (OK)");
        }
    }
}
