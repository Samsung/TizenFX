using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/PinchGestureDetectedSignal")]
    public class InternalPinchGestureDetectedSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr signal);
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
        [Description("PinchGestureDetectedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetectedSignal.PinchGestureDetectedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectedSignalConstructor()
        {
            tlog.Debug(tag, $"PinchGestureDetectedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new PinchGestureDetectedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PinchGestureDetectedSignal>(testingTarget, "Should be an Instance of PinchGestureDetectedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PinchGestureDetectedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PinchGestureDetectedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetectedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectedSignalEmpty()
        {
            tlog.Debug(tag, $"PinchGestureDetectedSignalEmpty START");

            var testingTarget = new PinchGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PinchGestureDetectedSignal>(testingTarget, "Should be an Instance of PinchGestureDetectedSignal!");

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

            tlog.Debug(tag, $"PinchGestureDetectedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PinchGestureDetectedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetectedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"PinchGestureDetectedSignalGetConnectionCount START");

            var testingTarget = new PinchGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PinchGestureDetectedSignal>(testingTarget, "Should be an Instance of PinchGestureDetectedSignal!");

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

            tlog.Debug(tag, $"PinchGestureDetectedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PinchGestureDetectedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetectedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectedSignalConnect()
        {
            tlog.Debug(tag, $"PinchGestureDetectedSignalConnect START");

            var testingTarget = new PinchGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PinchGestureDetectedSignal>(testingTarget, "Should be an Instance of PinchGestureDetectedSignal!");

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

            tlog.Debug(tag, $"PinchGestureDetectedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PinchGestureDetectedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.PinchGestureDetectedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureDetectedSignalEmit()
        {
            tlog.Debug(tag, $"PinchGestureDetectedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new PinchGestureDetectedSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PinchGestureDetectedSignal>(testingTarget, "Should be an Instance of PinchGestureDetectedSignal!");

                try
                {
                    testingTarget.Emit(view, new PinchGesture(view.SwigCPtr.Handle, false));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PinchGestureDetectedSignalEmit END (OK)");
        }
    }
}
