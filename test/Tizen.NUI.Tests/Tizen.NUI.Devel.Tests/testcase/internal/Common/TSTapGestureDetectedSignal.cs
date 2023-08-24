using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TapGestureDetectedSignal")]
    public class InternalTapGestureDetectedSignalTest
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
        [Description("TapGestureDetectedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetectedSignal.TapGestureDetectedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectedSignalConstructor()
        {
            tlog.Debug(tag, $"TapGestureDetectedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new TapGestureDetectedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TapGestureDetectedSignal>(testingTarget, "Should be an Instance of TapGestureDetectedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TapGestureDetectedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetectedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetectedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectedSignalEmpty()
        {
            tlog.Debug(tag, $"TapGestureDetectedSignalEmpty START");

            var testingTarget = new TapGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TapGestureDetectedSignal>(testingTarget, "Should be an Instance of TapGestureDetectedSignal!");

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

            tlog.Debug(tag, $"TapGestureDetectedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetectedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetectedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"TapGestureDetectedSignalGetConnectionCount START");

            var testingTarget = new TapGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TapGestureDetectedSignal>(testingTarget, "Should be an Instance of TapGestureDetectedSignal!");

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

            tlog.Debug(tag, $"TapGestureDetectedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetectedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetectedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectedSignalConnect()
        {
            tlog.Debug(tag, $"TapGestureDetectedSignalConnect START");

            var testingTarget = new TapGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TapGestureDetectedSignal>(testingTarget, "Should be an Instance of TapGestureDetectedSignal!");

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

            tlog.Debug(tag, $"TapGestureDetectedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGestureDetectedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.TapGestureDetectedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureDetectedSignalEmit()
        {
            tlog.Debug(tag, $"TapGestureDetectedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (TextLabel label = new TextLabel())
            {
                var testingTarget = new TapGestureDetectedSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TapGestureDetectedSignal>(testingTarget, "Should be an Instance of TapGestureDetectedSignal!");

                try
                {
                    testingTarget.Emit(label, new TapGesture());
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TapGestureDetectedSignalEmit END (OK)");
        }
    }
}
