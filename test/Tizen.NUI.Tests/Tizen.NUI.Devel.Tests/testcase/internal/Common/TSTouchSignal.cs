using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TouchSignal")]
    public class InternalTouchSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr touchSignal);
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
        [Description("TouchSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.TouchSignal.TouchSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchSignalConstructor()
        {
            tlog.Debug(tag, $"TouchSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new TouchSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TouchSignal>(testingTarget, "Should be an Instance of TouchSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TouchSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.TouchSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchSignalEmpty()
        {
            tlog.Debug(tag, $"TouchSignalEmpty START");

            var testingTarget = new TouchSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchSignal>(testingTarget, "Should be an Instance of TouchSignal!");

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

            tlog.Debug(tag, $"TouchSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.TouchSignal.TouchSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"TouchSignalGetConnectionCount START");

            var testingTarget = new TouchSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchSignal>(testingTarget, "Should be an Instance of TouchSignal!");

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

            tlog.Debug(tag, $"TouchSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.TouchSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchSignalConnect()
        {
            tlog.Debug(tag, $"TouchSignalConnect START");

            var testingTarget = new TouchSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchSignal>(testingTarget, "Should be an Instance of TouchSignal!");

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

            tlog.Debug(tag, $"TouchSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.TouchSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchSignalEmit()
        {
            tlog.Debug(tag, $"TouchSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new TouchSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TouchSignal>(testingTarget, "Should be an Instance of TouchSignal!");

                try
                {
                    testingTarget.Emit(Touch.GetTouchFromPtr(view.SwigCPtr.Handle));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TouchSignalEmit END (OK)");
        }
    }
}
