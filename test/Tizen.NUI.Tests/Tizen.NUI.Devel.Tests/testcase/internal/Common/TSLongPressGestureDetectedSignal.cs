using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/LongPressGestureDetectedSignal")]
    public class InternalLongPressGestureDetectedSignalTest
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
        [Description("LongPressGestureDetectedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetectedSignal.LongPressGestureDetectedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectedSignalConstructor()
        {
            tlog.Debug(tag, $"LongPressGestureDetectedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new LongPressGestureDetectedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<LongPressGestureDetectedSignal>(testingTarget, "Should be an Instance of LongPressGestureDetectedSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LongPressGestureDetectedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetectedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetectedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectedSignalEmpty()
        {
            tlog.Debug(tag, $"LongPressGestureDetectedSignalEmpty START");

            var testingTarget = new LongPressGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LongPressGestureDetectedSignal>(testingTarget, "Should be an Instance of LongPressGestureDetectedSignal!");

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

            tlog.Debug(tag, $"LongPressGestureDetectedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetectedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetectedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"LongPressGestureDetectedSignalGetConnectionCount START");

            var testingTarget = new LongPressGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LongPressGestureDetectedSignal>(testingTarget, "Should be an Instance of LongPressGestureDetectedSignal!");

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

            tlog.Debug(tag, $"LongPressGestureDetectedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetectedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetectedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectedSignalConnect()
        {
            tlog.Debug(tag, $"LongPressGestureDetectedSignalConnect START");

            var testingTarget = new LongPressGestureDetectedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<LongPressGestureDetectedSignal>(testingTarget, "Should be an Instance of LongPressGestureDetectedSignal!");

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

            tlog.Debug(tag, $"LongPressGestureDetectedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LongPressGestureDetectedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.LongPressGestureDetectedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureDetectedSignalEmit()
        {
            tlog.Debug(tag, $"LongPressGestureDetectedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new LongPressGestureDetectedSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<LongPressGestureDetectedSignal>(testingTarget, "Should be an Instance of LongPressGestureDetectedSignal!");

                try
                {
                    testingTarget.Emit(view, new LongPressGesture(view.SwigCPtr.Handle, false));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LongPressGestureDetectedSignalEmit END (OK)");
        }
    }
}
