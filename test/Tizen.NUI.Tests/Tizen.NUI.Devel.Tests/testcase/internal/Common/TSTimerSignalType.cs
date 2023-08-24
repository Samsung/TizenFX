using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TimerSignalType")]
    public class InternalTimerSignalTypeTest
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
        [Description("TimerSignalType constructor.")]
        [Property("SPEC", "Tizen.NUI.TimerSignalType.TimerSignalType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerSignalTypeConstructor()
        {
            tlog.Debug(tag, $"TimerSignalTypeConstructor START");

            using (View view = new View())
            {
                var testingTarget = new TimerSignalType(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TimerSignalType>(testingTarget, "Should be an Instance of TimerSignalType!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TimerSignalTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimerSignalType Empty.")]
        [Property("SPEC", "Tizen.NUI.TimerSignalType.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerSignalTypeEmpty()
        {
            tlog.Debug(tag, $"TimerSignalTypeEmpty START");

            var testingTarget = new TimerSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TimerSignalType>(testingTarget, "Should be an Instance of TimerSignalType!");

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

            tlog.Debug(tag, $"TimerSignalTypeEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimerSignalType GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.TimerSignalType.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerSignalTypeGetConnectionCount()
        {
            tlog.Debug(tag, $"TimerSignalTypeGetConnectionCount START");

            var testingTarget = new TimerSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TimerSignalType>(testingTarget, "Should be an Instance of TimerSignalType!");

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

            tlog.Debug(tag, $"TimerSignalTypeGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimerSignalType Connect.")]
        [Property("SPEC", "Tizen.NUI.TimerSignalType.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerSignalTypeConnect()
        {
            tlog.Debug(tag, $"TimerSignalTypeConnect START");

            var testingTarget = new TimerSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TimerSignalType>(testingTarget, "Should be an Instance of TimerSignalType!");

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

            tlog.Debug(tag, $"TimerSignalTypeConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimerSignalType Emit.")]
        [Property("SPEC", "Tizen.NUI.TimerSignalType.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TimerSignalTypeEmit()
        {
            tlog.Debug(tag, $"TimerSignalTypeEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new TimerSignalType();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TimerSignalType>(testingTarget, "Should be an Instance of TimerSignalType!");

            try
            {
                testingTarget.Emit();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"TimerSignalTypeEmit END (OK)");
        }
    }
}
