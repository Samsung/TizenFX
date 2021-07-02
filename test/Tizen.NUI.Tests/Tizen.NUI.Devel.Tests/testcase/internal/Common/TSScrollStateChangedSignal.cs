using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ScrollStateChangedSignal")]
    public class InternalScrollStateChangedSignalTest
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
        [Description("ScrollStateChangedSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ScrollStateChangedSignal.ScrollStateChangedSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollStateChangedSignalConstructor()
        {
            tlog.Debug(tag, $"ScrollStateChangedSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ScrollStateChangedSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ScrollStateChangedSignal>(testingTarget, "Should be an ScrollStateChangedSignal of WheelSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ScrollStateChangedSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollStateChangedSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ScrollStateChangedSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollStateChangedSignalEmpty()
        {
            tlog.Debug(tag, $"ScrollStateChangedSignalEmpty START");

            var testingTarget = new ScrollStateChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ScrollStateChangedSignal>(testingTarget, "Should be an Instance of ScrollStateChangedSignal!");

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

            tlog.Debug(tag, $"ScrollStateChangedSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollStateChangedSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ScrollStateChangedSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollStateChangedSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ScrollStateChangedSignalGetConnectionCount START");

            var testingTarget = new ScrollStateChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ScrollStateChangedSignal>(testingTarget, "Should be an Instance of ScrollStateChangedSignal!");

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

            tlog.Debug(tag, $"ScrollStateChangedSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollStateChangedSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ScrollStateChangedSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollStateChangedSignalConnect()
        {
            tlog.Debug(tag, $"ScrollStateChangedSignalConnect START");

            var testingTarget = new ScrollStateChangedSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ScrollStateChangedSignal>(testingTarget, "Should be an Instance of ScrollStateChangedSignal!");

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

            tlog.Debug(tag, $"ScrollStateChangedSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollStateChangedSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.ScrollStateChangedSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollStateChangedSignalEmit()
        {
            tlog.Debug(tag, $"ScrollStateChangedSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new ScrollStateChangedSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ScrollStateChangedSignal>(testingTarget, "Should be an Instance of ScrollStateChangedSignal!");

                try
                {
                    testingTarget.Emit(view);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ScrollStateChangedSignalEmit END (OK)");
        }
    }
}
