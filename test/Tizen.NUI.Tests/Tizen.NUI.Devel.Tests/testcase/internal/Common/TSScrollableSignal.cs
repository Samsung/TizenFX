using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ScrollableSignal")]
    public class InternalScrollableSignalTest
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
        [Description("ScrollableSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ScrollableSignal.ScrollableSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableSignalConstructor()
        {
            tlog.Debug(tag, $"ScrollableSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ScrollableSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ScrollableSignal>(testingTarget, "Should be an Instance of ScrollableSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ScrollableSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ScrollableSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableSignalEmpty()
        {
            tlog.Debug(tag, $"ScrollableSignalEmpty START");

            var testingTarget = new ScrollableSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ScrollableSignal>(testingTarget, "Should be an Instance of ScrollableSignal!");

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

            tlog.Debug(tag, $"ScrollableSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ScrollableSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ScrollableSignalGetConnectionCount START");

            var testingTarget = new ScrollableSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ScrollableSignal>(testingTarget, "Should be an Instance of ScrollableSignal!");

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

            tlog.Debug(tag, $"ScrollableSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ScrollableSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableSignalConnect()
        {
            tlog.Debug(tag, $"ScrollableSignalConnect START");

            var testingTarget = new ScrollableSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ScrollableSignal>(testingTarget, "Should be an Instance of ScrollableSignal!");

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

            tlog.Debug(tag, $"ScrollableSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollableSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.ScrollableSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollableSignalEmit()
        {
            tlog.Debug(tag, $"ScrollableSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (Vector2 vector = new Vector2(0.3f, 0.5f))
            {
                var testingTarget = new ScrollableSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ScrollableSignal>(testingTarget, "Should be an Instance of ScrollableSignal!");

                try
                {
                    testingTarget.Emit(vector);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ScrollableSignalEmit END (OK)");
        }
    }
}
