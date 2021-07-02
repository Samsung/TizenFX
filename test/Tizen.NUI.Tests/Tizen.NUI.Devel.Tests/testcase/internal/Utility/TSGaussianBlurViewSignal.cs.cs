using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/GaussianBlurViewSignal")]
    public class InternalGaussianBlurViewSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr gaussianBlurViewSignal);
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
        [Description("GaussianBlurViewSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurViewSignal.GaussianBlurViewSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewSignalConstructor()
        {
            tlog.Debug(tag, $"GaussianBlurViewSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new GaussianBlurViewSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<GaussianBlurViewSignal>(testingTarget, "Should be an Instance of GaussianBlurViewSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"GaussianBlurViewSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GaussianBlurViewSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurViewSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewSignalEmpty()
        {
            tlog.Debug(tag, $"GaussianBlurViewSignalEmpty START");

            var testingTarget = new GaussianBlurViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GaussianBlurViewSignal>(testingTarget, "Should be an Instance of GaussianBlurViewSignal!");

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

            tlog.Debug(tag, $"GaussianBlurViewSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GaussianBlurViewSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurViewSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"GaussianBlurViewSignalGetConnectionCount START");

            var testingTarget = new GaussianBlurViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GaussianBlurViewSignal>(testingTarget, "Should be an Instance of GaussianBlurViewSignal!");

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

            tlog.Debug(tag, $"GaussianBlurViewSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GaussianBlurViewSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurViewSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewSignalConnect()
        {
            tlog.Debug(tag, $"GaussianBlurViewSignalConnect START");

            var testingTarget = new GaussianBlurViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<GaussianBlurViewSignal>(testingTarget, "Should be an Instance of GaussianBlurViewSignal!");

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

            tlog.Debug(tag, $"GaussianBlurViewSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GaussianBlurViewSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.GaussianBlurViewSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GaussianBlurViewSignalEmit()
        {
            tlog.Debug(tag, $"GaussianBlurViewSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new GaussianBlurViewSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<GaussianBlurViewSignal>(testingTarget, "Should be an Instance of GaussianBlurViewSignal!");

                try
                {
                    testingTarget.Emit(new GaussianBlurView(view.SwigCPtr.Handle, false));
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"GaussianBlurViewSignalEmit END (OK)");
        }
    }
}
