using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ControlKeySignal")]
    public class InternalControlKeySignalTest
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
        [Description("ControlKeySignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ControlKeySignal.ControlKeySignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlKeySignalConstructor()
        {
            tlog.Debug(tag, $"ControlKeySignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ControlKeySignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ControlKeySignal>(testingTarget, "Should be an Instance of ControlKeySignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ControlKeySignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlKeySignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ControlKeySignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlKeySignalEmpty()
        {
            tlog.Debug(tag, $"ControlKeySignalEmpty START");

            var testingTarget = new ControlKeySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ControlKeySignal>(testingTarget, "Should be an Instance of ControlKeySignal!");

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

            tlog.Debug(tag, $"ControlKeySignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlKeySignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ControlKeySignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlKeySignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ControlKeySignalGetConnectionCount START");

            var testingTarget = new ControlKeySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ControlKeySignal>(testingTarget, "Should be an Instance of ControlKeySignal!");

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

            tlog.Debug(tag, $"ControlKeySignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlKeySignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ControlKeySignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ControlKeySignalConnect()
        {
            tlog.Debug(tag, $"ControlKeySignalConnect START");

            var testingTarget = new ControlKeySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ControlKeySignal>(testingTarget, "Should be an Instance of ControlKeySignal!");

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

            tlog.Debug(tag, $"ControlKeySignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ControlKeySignal Emit.")]
        [Property("SPEC", "Tizen.NUI.ControlKeySignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void ControlKeySignalEmit()
        {
            tlog.Debug(tag, $"ControlKeySignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new ControlKeySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ControlKeySignal>(testingTarget, "Should be an Instance of ControlKeySignal!");

            try
            {
                using (View view = new View())
                {
                    using (Key key = new Key(view.SwigCPtr.Handle, false))
                    {
                        testingTarget.Emit(view, key);
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"ControlKeySignalEmit END (OK)");
        }
    }
}
