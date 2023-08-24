using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/FocusChangedSignal")]
    public class InternalFocusChangedSignalTest
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
        [Description("FocusChangedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.FocusChangedSignal.FocusChangedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusChangedSignalConstructor()
        {
            tlog.Debug(tag, $"FocusChangedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new FocusChangedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<FocusChangedSignal>(testingTarget, "Should be an Instance of FocusChangedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"FocusChangedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusChangedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.FocusChangedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusChangedSignalEmpty()
        {
            tlog.Debug(tag, $"FocusChangedSignalEmpty START");

            var testingTarget = new FocusChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FocusChangedSignal>(testingTarget, "Should be an Instance of FocusChangedSignal!");

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

            tlog.Debug(tag, $"FocusChangedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusChangedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.FocusChangedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusChangedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"FocusChangedSignalGetConnectionCount START");

            var testingTarget = new FocusChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FocusChangedSignal>(testingTarget, "Should be an Instance of FocusChangedSignal!");

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

            tlog.Debug(tag, $"FocusChangedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusChangedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.FocusChangedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusChangedSignalConnect()
        {
            tlog.Debug(tag, $"FocusChangedSignalConnect START");

            var testingTarget = new FocusChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FocusChangedSignal>(testingTarget, "Should be an Instance of FocusChangedSignal!");

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

            tlog.Debug(tag, $"FocusChangedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusChangedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.FocusChangedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FocusChangedSignalEmit()
        {
            tlog.Debug(tag, $"FocusChangedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new FocusChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FocusChangedSignal>(testingTarget, "Should be an Instance of FocusChangedSignal!");

            try
            {
                using (View current = new View())
                {
                    using (View goal = new View())
                    {
                        testingTarget.Emit(current, goal);
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"FocusChangedSignalEmit END (OK)");
        }
    }
}
