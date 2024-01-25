using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/FloatSignal")]
    public class InternalFloatSignalTest
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
        [Description("FloatSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.FloatSignal.FloatSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FloatSignalConstructor()
        {
            tlog.Debug(tag, $"FloatSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new FloatSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<FloatSignal>(testingTarget, "Should be an Instance of FloatSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"FloatSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FloatSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.FloatSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FloatSignalEmpty()
        {
            tlog.Debug(tag, $"FloatSignalEmpty START");

            var testingTarget = new FloatSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FloatSignal>(testingTarget, "Should be an Instance of FloatSignal!");

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

            tlog.Debug(tag, $"FloatSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FloatSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.FloatSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FloatSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"FloatSignalGetConnectionCount START");

            var testingTarget = new FloatSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FloatSignal>(testingTarget, "Should be an Instance of FloatSignal!");

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

            tlog.Debug(tag, $"FloatSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FloatSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.FloatSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FloatSignalConnect()
        {
            tlog.Debug(tag, $"FloatSignalConnect START");

            var testingTarget = new FloatSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FloatSignal>(testingTarget, "Should be an Instance of FloatSignal!");

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

            tlog.Debug(tag, $"FloatSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FloatSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.FloatSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void FloatSignalEmit()
        {
            tlog.Debug(tag, $"FloatSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new FloatSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<FloatSignal>(testingTarget, "Should be an Instance of FloatSignal!");

            try
            {
                 testingTarget.Emit(3.0f);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"FloatSignalEmit END (OK)");
        }
    }
}
