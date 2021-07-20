using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/HoverSignal")]
    public class InternalHoverSignalTest
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
        [Description("HoverSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.HoverSignal.HoverSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverSignalConstructor()
        {
            tlog.Debug(tag, $"HoverSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new HoverSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<HoverSignal>(testingTarget, "Should be an Instance of HoverSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"HoverSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("HoverSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.HoverSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverSignalEmpty()
        {
            tlog.Debug(tag, $"HoverSignalEmpty START");

            var testingTarget = new HoverSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<HoverSignal>(testingTarget, "Should be an Instance of HoverSignal!");

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

            tlog.Debug(tag, $"HoverSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("HoverSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.HoverSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"HoverSignalGetConnectionCount START");

            var testingTarget = new HoverSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<HoverSignal>(testingTarget, "Should be an Instance of HoverSignal!");

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

            tlog.Debug(tag, $"HoverSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("HoverSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.HoverSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void HoverSignalConnect()
        {
            tlog.Debug(tag, $"HoverSignalConnect START");

            var testingTarget = new HoverSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<HoverSignal>(testingTarget, "Should be an Instance of HoverSignal!");

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

            tlog.Debug(tag, $"HoverSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("HoverSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.HoverSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void HoverSignalEmit()
        {
            tlog.Debug(tag, $"HoverSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            var testingTarget = new HoverSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<HoverSignal>(testingTarget, "Should be an Instance of HoverSignal!");

            try
            {
                using (View view = new View())
                {
                    using (Hover hover = new Hover())
                    {
                        testingTarget.Emit(view, hover);
                    }
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"HoverSignalEmit END (OK)");
        }
    }
}
