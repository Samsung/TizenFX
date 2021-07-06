using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ViewResourceReadySignal")]
    public class InternalViewResourceReadySignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr viewResourceReadySignal);
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
        [Description("ViewResourceReadySignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ViewResourceReadySignal.ViewResourceReadySignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewResourceReadySignalConstructor()
        {
            tlog.Debug(tag, $"ViewResourceReadySignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ViewResourceReadySignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ViewResourceReadySignal>(testingTarget, "Should be an Instance of ViewResourceReadySignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewResourceReadySignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewResourceReadySignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ViewResourceReadySignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewResourceReadySignalEmpty()
        {
            tlog.Debug(tag, $"ViewResourceReadySignalEmpty START");

            var testingTarget = new ViewResourceReadySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewResourceReadySignal>(testingTarget, "Should be an Instance of ViewResourceReadySignal!");

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

            tlog.Debug(tag, $"ViewResourceReadySignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewResourceReadySignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ViewResourceReadySignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewResourceReadySignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ViewResourceReadySignalGetConnectionCount START");

            var testingTarget = new ViewResourceReadySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewResourceReadySignal>(testingTarget, "Should be an Instance of ViewResourceReadySignal!");

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

            tlog.Debug(tag, $"ViewResourceReadySignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewResourceReadySignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ViewResourceReadySignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewResourceReadySignalConnect()
        {
            tlog.Debug(tag, $"ViewResourceReadySignalConnect START");

            var testingTarget = new ViewResourceReadySignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewResourceReadySignal>(testingTarget, "Should be an Instance of ViewResourceReadySignal!");

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

            tlog.Debug(tag, $"ViewResourceReadySignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewResourceReadySignal Emit.")]
        [Property("SPEC", "Tizen.NUI.ViewResourceReadySignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewResourceReadySignalEmit()
        {
            tlog.Debug(tag, $"ViewResourceReadySignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new ViewResourceReadySignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ViewResourceReadySignal>(testingTarget, "Should be an Instance of ViewResourceReadySignal!");

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

            tlog.Debug(tag, $"ViewResourceReadySignalEmit END (OK)");
        }
    }
}
