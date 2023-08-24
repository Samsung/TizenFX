using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/StateChangedSignalType")]
    public class InternalStateChangedSignalTypeTest
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
        [Description("StateChangedSignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.StateChangedSignalType.StateChangedSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StateChangedSignalTypeConstructor()
        {
            tlog.Debug(tag, $"StateChangedSignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new StateChangedSignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<StateChangedSignalType>(testingTarget, "Should be an Instance of StateChangedSignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"StateChangedSignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StateChangedSignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.StateChangedSignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StateChangedSignalTypeEmpty()
        {
            tlog.Debug(tag, $"StateChangedSignalTypeEmpty START");

            var testingTarget = new StateChangedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StateChangedSignalType>(testingTarget, "Should be an Instance of StateChangedSignalType!");

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

            tlog.Debug(tag, $"StateChangedSignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StateChangedSignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.StateChangedSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StateChangedSignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"StateChangedSignalTypeGetConnectionCount START");

            var testingTarget = new StateChangedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StateChangedSignalType>(testingTarget, "Should be an Instance of StateChangedSignalType!");

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

            tlog.Debug(tag, $"StateChangedSignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StateChangedSignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.StateChangedSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StateChangedSignalTypeConnect()
        {
            tlog.Debug(tag, $"StateChangedSignalTypeConnect START");

            var testingTarget = new StateChangedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StateChangedSignalType>(testingTarget, "Should be an Instance of StateChangedSignalType!");

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

            tlog.Debug(tag, $"StateChangedSignalTypeConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("StateChangedSignalType Emit.")]
        [Property("SPEC", "Tizen.NUI.StateChangedSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void StateChangedSignalTypeEmit()
        {
            tlog.Debug(tag, $"StatusSignalTypeEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new StateChangedSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<StateChangedSignalType>(testingTarget, "Should be an Instance of StateChangedSignalType!");

            try
            {
                testingTarget.Emit(TTSPlayer.TTSState.Paused, TTSPlayer.TTSState.Playing);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"StateChangedSignalTypeEmit END (OK)");
        }
    }
}
