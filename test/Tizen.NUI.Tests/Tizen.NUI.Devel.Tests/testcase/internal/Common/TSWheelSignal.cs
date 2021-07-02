using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/WheelSignal")]
    public class InternalWheelSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr wheelSignal);
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
        [Description("WheelSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.WheelSignal.WheelSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelSignalConstructor()
        {
            tlog.Debug(tag, $"WheelSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new WheelSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<WheelSignal>(testingTarget, "Should be an Instance of WheelSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WheelSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WheelSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.WheelSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelSignalEmpty()
        {
            tlog.Debug(tag, $"WheelSignalEmpty START");

            var testingTarget = new WheelSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WheelSignal>(testingTarget, "Should be an Instance of WheelSignal!");

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

            tlog.Debug(tag, $"WheelSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WheelSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.WheelSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"WheelSignalGetConnectionCount START");

            var testingTarget = new WheelSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WheelSignal>(testingTarget, "Should be an Instance of WheelSignal!");

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

            tlog.Debug(tag, $"WheelSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WheelSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.WheelSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelSignalConnect()
        {
            tlog.Debug(tag, $"WheelSignalConnect START");

            var testingTarget = new WheelSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WheelSignal>(testingTarget, "Should be an Instance of WheelSignal!");

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

            tlog.Debug(tag, $"WheelSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WheelSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.WheelSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WheelSignalEmit()
        {
            tlog.Debug(tag, $"WheelSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new WheelSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<WheelSignal>(testingTarget, "Should be an Instance of WheelSignal!");

                try
                {
                    testingTarget.Emit(view, new Wheel());
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WheelSignalEmit END (OK)");
        }
    }
}
