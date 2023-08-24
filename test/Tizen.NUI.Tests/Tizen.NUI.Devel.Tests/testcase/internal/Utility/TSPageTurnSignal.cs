using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Internal/Utility/PageTurnSignal")]
    public class InternalPageTurnSignalTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr pageTurnSignal);
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
        [Description("PageTurnSignal constructor.")]
        [Property("SPEC", "Tizen.NUI.PageTurnSignal.PageTurnSignal C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnSignalConstructor()
        {
            tlog.Debug(tag, $"PageTurnSignalConstructor START");

            using (View view = new View())
            {
                var testingTarget = new PageTurnSignal(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageTurnSignal>(testingTarget, "Should be an Instance of PageTurnSignal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PageTurnSignalConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnSignal Empty.")]
        [Property("SPEC", "Tizen.NUI.PageTurnSignal.Empty M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnSignalEmpty()
        {
            tlog.Debug(tag, $"PageTurnSignalEmpty START");

            var testingTarget = new PageTurnSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PageTurnSignal>(testingTarget, "Should be an Instance of PageTurnSignal!");

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

            tlog.Debug(tag, $"PageTurnSignalEmpty END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnSignal GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.PageTurnSignal.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnSignalGetConnectionCount()
        {
            tlog.Debug(tag, $"PageTurnSignalGetConnectionCount START");

            var testingTarget = new PageTurnSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PageTurnSignal>(testingTarget, "Should be an Instance of PageTurnSignal!");

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

            tlog.Debug(tag, $"PageTurnSignalGetConnectionCount END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnSignal Connect.")]
        [Property("SPEC", "Tizen.NUI.PageTurnSignal.Connect M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnSignalConnect()
        {
            tlog.Debug(tag, $"PageTurnSignalConnect START");

            var testingTarget = new PageTurnSignal();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<PageTurnSignal>(testingTarget, "Should be an Instance of PageTurnSignal!");

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

            tlog.Debug(tag, $"PageTurnSignalConnect END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PageTurnSignal Emit.")]
        [Property("SPEC", "Tizen.NUI.PageTurnSignal.Emit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageTurnSignalEmit()
        {
            tlog.Debug(tag, $"PageTurnSignalEmit START");
            var currentPid = global::System.Diagnostics.Process.GetCurrentProcess().Id;
            var currentTid = global::System.Threading.Thread.CurrentThread.ManagedThreadId;

            tlog.Debug(tag, $"thread check! main pid={App.mainPid}, current pid={currentPid}, main tid={App.mainTid}, current tid={currentTid}");

            using (View view = new View())
            {
                var testingTarget = new PageTurnSignal();
                Assert.IsNotNull(testingTarget, "Should be not null!");
                Assert.IsInstanceOf<PageTurnSignal>(testingTarget, "Should be an Instance of PageTurnSignal!");

                try
                {
                    testingTarget.Emit(new PageTurnView(view.SwigCPtr.Handle, false), 1, false);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PageTurnSignalEmit END (OK)");
        }
    }
}
