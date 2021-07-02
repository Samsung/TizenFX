using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/FocusGroupChangedSignal")]
    public class InternalFocusGroupChangedSignalTest
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
        [Description("FocusGroupChangedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.FocusGroupChangedSignal.FocusGroupChangedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusGroupChangedSignalConstructor()
        {
            tlog.Debug(tag, $"FocusGroupChangedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new FocusGroupChangedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<FocusGroupChangedSignal>(testingTarget, "Should be an Instance of FocusGroupChangedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"FocusGroupChangedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusGroupChangedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.FocusGroupChangedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusGroupChangedSignalEmpty()
        {
            tlog.Debug(tag, $"FocusGroupChangedSignalEmpty START");

            var testingTarget = new FocusGroupChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FocusGroupChangedSignal>(testingTarget, "Should be an Instance of FocusGroupChangedSignal!");

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

            tlog.Debug(tag, $"FocusGroupChangedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusGroupChangedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.FocusGroupChangedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusGroupChangedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"FocusGroupChangedSignalGetConnectionCount START");

            var testingTarget = new FocusGroupChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FocusGroupChangedSignal>(testingTarget, "Should be an Instance of FocusGroupChangedSignal!");

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

            tlog.Debug(tag, $"FocusGroupChangedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusGroupChangedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.FocusGroupChangedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusGroupChangedSignalConnect()
        {
            tlog.Debug(tag, $"FocusGroupChangedSignalConnect START");

            var testingTarget = new FocusGroupChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FocusGroupChangedSignal>(testingTarget, "Should be an Instance of FocusGroupChangedSignal!");

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

            tlog.Debug(tag, $"FocusGroupChangedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusGroupChangedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.FocusGroupChangedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FocusGroupChangedSignalEmit()
        {
            tlog.Debug(tag, $"FocusGroupChangedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new FocusGroupChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FocusGroupChangedSignal>(testingTarget, "Should be an Instance of FocusGroupChangedSignal!");

            try
            {
                using (View current = new View())
                {
                    testingTarget.Emit(current, false);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"FocusGroupChangedSignalEmit END (OK)");
        }
    }
}
