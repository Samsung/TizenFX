using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/StageWheelSignal")]
    public class InternalStageWheelSignalTest
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
        [Description("StageWheelSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.StageWheelSignal.StageWheelSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StageWheelSignalConstructor()
        {
            tlog.Debug(tag, $"StageWheelSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new StageWheelSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<StageWheelSignal>(testingTarget, "Should be an Instance of StageWheelSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"StageWheelSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StageWheelSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.StageWheelSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StageWheelSignalEmpty()
        {
            tlog.Debug(tag, $"StageWheelSignalEmpty START");

            var testingTarget = new StageWheelSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StageWheelSignal>(testingTarget, "Should be an Instance of StageWheelSignal!");

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

            tlog.Debug(tag, $"StageWheelSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StageWheelSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.StageWheelSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StageWheelSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"StageWheelSignalGetConnectionCount START");

            var testingTarget = new StageWheelSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StageWheelSignal>(testingTarget, "Should be an Instance of StageWheelSignal!");

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

            tlog.Debug(tag, $"StageWheelSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StageWheelSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.StageWheelSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StageWheelSignalConnect()
        {
            tlog.Debug(tag, $"StageWheelSignalConnect START");

            var testingTarget = new StageWheelSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StageWheelSignal>(testingTarget, "Should be an Instance of StageWheelSignal!");

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

            tlog.Debug(tag, $"StageWheelSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StageWheelSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.StageWheelSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StageWheelSignalEmit()
        {
            tlog.Debug(tag, $"StageWheelSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new StageWheelSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StageWheelSignal>(testingTarget, "Should be an Instance of StageWheelSignal!");

            try
            {
                testingTarget.Emit(new Wheel());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"StageWheelSignalEmit END (OK)");
        }
    }
}
