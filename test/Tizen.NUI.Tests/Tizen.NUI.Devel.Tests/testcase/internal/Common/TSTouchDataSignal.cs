using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TouchDataSignal")]
    public class InternalTouchDataSignalTest
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
        [Description("TouchDataSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.TouchDataSignal.TouchDataSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchDataSignalConstructor()
        {
            tlog.Debug(tag, $"TouchDataSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new TouchDataSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<TouchDataSignal>(testingTarget, "Should be an Instance of TouchDataSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TouchDataSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchDataSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.TouchDataSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchDataSignalEmpty()
        {
            tlog.Debug(tag, $"TouchDataSignalEmpty START");

            var testingTarget = new TouchDataSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchDataSignal>(testingTarget, "Should be an Instance of TouchDataSignal!");

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

            tlog.Debug(tag, $"TouchDataSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchDataSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.TouchDataSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchDataSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"TouchDataSignalGetConnectionCount START");

            var testingTarget = new TouchDataSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchDataSignal>(testingTarget, "Should be an Instance of TouchDataSignal!");

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

            tlog.Debug(tag, $"TouchDataSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchDataSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.TouchDataSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchDataSignalConnect()
        {
            tlog.Debug(tag, $"TouchDataSignalConnect START");

            var testingTarget = new TouchDataSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchDataSignal>(testingTarget, "Should be an Instance of TouchDataSignal!");

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

            tlog.Debug(tag, $"TouchDataSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchDataSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.TouchDataSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchDataSignalEmit()
        {
            tlog.Debug(tag, $"TouchDataSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                using (Touch touch = Touch.GetTouchFromPtr(view.SwigCPtr.Handle))
                {
                    var testingTarget = new TouchDataSignal();
                    Assert.IsNotNull(testingTarget, "Should be not null!");
                    Assert.IsInstanceOf<TouchDataSignal>(testingTarget, "Should be an Instance of TouchDataSignal!");

                    try
                    {
                        testingTarget.Emit(view, touch);
                    }
                    catch (Exception e)
                    {
                        tlog.Debug(tag, e.Message.ToString());
                        Assert.Fail("Caught Exception: Failed!");
                    }

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"TouchDataSignalEmit END (OK)");
        }
    }
}
