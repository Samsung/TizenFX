using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/RotationGestureDetectedSignal")]
    public class InternalRotationGestureDetectedSignalTest
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
        [Description("RotationGestureDetectedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetectedSignal.RotationGestureDetectedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectedSignalConstructor()
        {
            tlog.Debug(tag, $"RotationGestureDetectedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new RotationGestureDetectedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<RotationGestureDetectedSignal>(testingTarget, "Should be an Instance of RotationGestureDetectedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RotationGestureDetectedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RotationGestureDetectedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetectedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectedSignalEmpty()
        {
            tlog.Debug(tag, $"RotationGestureDetectedSignalEmpty START");

            var testingTarget = new RotationGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<RotationGestureDetectedSignal>(testingTarget, "Should be an Instance of RotationGestureDetectedSignal!");

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

            tlog.Debug(tag, $"RotationGestureDetectedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RotationGestureDetectedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetectedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"RotationGestureDetectedSignalGetConnectionCount START");

            var testingTarget = new RotationGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<RotationGestureDetectedSignal>(testingTarget, "Should be an Instance of RotationGestureDetectedSignal!");

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

            tlog.Debug(tag, $"RotationGestureDetectedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RotationGestureDetectedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetectedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectedSignalConnect()
        {
            tlog.Debug(tag, $"RotationGestureDetectedSignalConnect START");

            var testingTarget = new RotationGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<RotationGestureDetectedSignal>(testingTarget, "Should be an Instance of RotationGestureDetectedSignal!");

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

            tlog.Debug(tag, $"RotationGestureDetectedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("RotationGestureDetectedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.RotationGestureDetectedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureDetectedSignalEmit()
        {
            tlog.Debug(tag, $"RotationGestureDetectedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new RotationGestureDetectedSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<RotationGestureDetectedSignal>(testingTarget, "Should be an Instance of RotationGestureDetectedSignal!");

                try
                {
                    using (RotationGesture gesture = new RotationGesture(view.SwigCPtr.Handle, false))
                    {
                        testingTarget.Emit(view, gesture);
                    }
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"RotationGestureDetectedSignalEmit END (OK)");
        }
    }
}
