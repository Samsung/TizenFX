using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/PanGestureDetectedSignal")]
    public class InternalPanGestureDetectedSignalTest
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
        [Description("PanGestureDetectedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetectedSignal.PanGestureDetectedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectedSignalConstructor()
        {
            tlog.Debug(tag, $"PanGestureDetectedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new PanGestureDetectedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PanGestureDetectedSignal>(testingTarget, "Should be an Instance of PanGestureDetectedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PanGestureDetectedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetectedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetectedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectedSignalEmpty()
        {
            tlog.Debug(tag, $"PanGestureDetectedSignalEmpty START");

            var testingTarget = new PanGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PanGestureDetectedSignal>(testingTarget, "Should be an Instance of PanGestureDetectedSignal!");

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

            tlog.Debug(tag, $"PanGestureDetectedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetectedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetectedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"PanGestureDetectedSignalGetConnectionCount START");

            var testingTarget = new PanGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PanGestureDetectedSignal>(testingTarget, "Should be an Instance of PanGestureDetectedSignal!");

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

            tlog.Debug(tag, $"PanGestureDetectedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetectedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetectedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectedSignalConnect()
        {
            tlog.Debug(tag, $"PanGestureDetectedSignalConnect START");

            var testingTarget = new PanGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PanGestureDetectedSignal>(testingTarget, "Should be an Instance of PanGestureDetectedSignal!");

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

            tlog.Debug(tag, $"PanGestureDetectedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PanGestureDetectedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.PanGestureDetectedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDetectedSignalEmit()
        {
            tlog.Debug(tag, $"PanGestureDetectedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new PanGestureDetectedSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PanGestureDetectedSignal>(testingTarget, "Should be an Instance of PanGestureDetectedSignal!");

                try
                {
                    testingTarget.Emit(view, new PanGesture(view.SwigCPtr.Handle, false));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PanGestureDetectedSignalEmit END (OK)");
        }
    }
}
