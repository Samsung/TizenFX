using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/ViewSignal")]
    public class InternalViewSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr viewSignal);
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
        [Description("ViewSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.ViewSignal.ViewSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSignalConstructor()
        {
            tlog.Debug(tag, $"ViewSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new ViewSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ViewSignal>(testingTarget, "Should be an Instance of ViewSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ViewSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.ViewSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSignalEmpty()
        {
            tlog.Debug(tag, $"ViewSignalEmpty START");

            var testingTarget = new ViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewSignal>(testingTarget, "Should be an Instance of ViewSignal!");

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

            tlog.Debug(tag, $"ViewSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.ViewSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"ViewSignalGetConnectionCount START");

            var testingTarget = new ViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewSignal>(testingTarget, "Should be an Instance of ViewSignal!");

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

            tlog.Debug(tag, $"ViewSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.ViewSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSignalConnect()
        {
            tlog.Debug(tag, $"ViewSignalConnect START");

            var testingTarget = new ViewSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<ViewSignal>(testingTarget, "Should be an Instance of ViewSignal!");

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

            tlog.Debug(tag, $"ViewSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ViewSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.ViewSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewSignalEmit()
        {
            tlog.Debug(tag, $"ViewSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new ViewSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<ViewSignal>(testingTarget, "Should be an Instance of ViewSignal!");

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

            tlog.Debug(tag, $"ViewSignalEmit END (OK)");
        }
    }
}
